using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FileSearcher.Model.EncodingDetection;
using FileSearcher.Model.Engine;

namespace FileSearcher.Model.CriterionSchemas
{
    internal class ContentCriterion : CriterionBase, ICriterion
    {
        private const int BufferSize = 32*1024; // 32KB

        private readonly string _text;
        private readonly char[][] _textInChars;
        private readonly bool _ignoreCase;
        private readonly bool _matchFullWords;
        private readonly IEncodingFactory _encodingFactory;

        public ContentCriterion(string text, bool ignoreCase, bool matchFullWords, IEncodingFactory encodingFactory)
        {
            if (text == null) throw new ArgumentNullException("text");
            if (encodingFactory == null) throw new ArgumentNullException("encodingFactory");

            _text = text;
            _ignoreCase = ignoreCase;
            _matchFullWords = matchFullWords;
            _encodingFactory = encodingFactory;

            _textInChars = StringToCharArrays(text, ignoreCase);
        }

        public string Name { get { return "File content"; } }

        public CriterionWeight Weight { get { return CriterionWeight.Heavy;} }

        public bool DirectorySupport { get { return false; } }

        public bool FileSupport { get { return true; } }

        public bool IsMatch(FileSystemInfo fileSystemInfo, ICriterionContext context)
        {
            var fileInfo = (FileInfo)fileSystemInfo;

            var buffer = new byte[BufferSize];
            var textLength = _text.Length;

            Encoding[] encodings = new Encoding[1];

            // Check multiple encodings
            for (int encodingIndex = 0; encodingIndex < encodings.Length; encodingIndex++)
            {
                // Encoding for current loop. First try will be NULL.
                Encoding encoding = encodings[encodingIndex];
                bool characterShouldBeNonWord = false;
                char characterBefore = '\0';

                using (var stream = fileInfo.OpenRead())
                {
                    int length;
                    int foundMatchingSymbols = 0;
                    while ((length = stream.Read(buffer, 0, BufferSize)) > 0)
                    {
                        // If encoding is not yet determined, detect it now.
                        if (encoding == null)
                        {
                            encodings = _encodingFactory.DetectEncoding(buffer);
                            encoding = encodings[encodingIndex];
                        }

                        var currentString = encoding.GetString(buffer, 0, length);
                        var currentStringLength = currentString.Length; // Cache

                        bool startAtBegin = foundMatchingSymbols > 0;
                        var charIndex = 0;

                        // The first character should be a non-word character if the prev bytes read are ending with a matching string.
                        if (_matchFullWords && characterShouldBeNonWord && currentStringLength > 0)
                        {
                            characterShouldBeNonWord = false;
                            if (!CharIsWordChar(currentString[0]))
                                return true;
                        }

                        // Check if the first or next matching symbol is in the current string.
                        if ((charIndex = currentString.IndexOfAny(_textInChars[foundMatchingSymbols], charIndex)) >= 0)
                        {
                            do
                            {
                                // Assign the character before.
                                if (charIndex > 0 && foundMatchingSymbols == 0 && _matchFullWords)
                                    characterBefore = currentString[charIndex - 1];

                                // Not first character of the _text, so check if the second char is at the first position.
                                if (startAtBegin)
                                {
                                    startAtBegin = false;
                                    if (charIndex > 0) // Letter should be at the first position! Of not, start over from the first char in _text.
                                    {
                                        foundMatchingSymbols = 0;
                                        continue;
                                    }
                                }

                                // Copy the variable, so it won't be changed in the loop below.
                                var current = charIndex;
                                // Try to match as many of characters as possible.
                                while (++foundMatchingSymbols < textLength && currentStringLength > ++current && (currentString[current] == _text[foundMatchingSymbols] || _ignoreCase && _textInChars[foundMatchingSymbols].Any(c => c == currentString[current]))) ;
                                // Found it!
                                if (foundMatchingSymbols == textLength && (!_matchFullWords || !CharIsWordChar(characterBefore)))
                                {
                                    if (_matchFullWords)
                                    {
                                        // Try to figure out next read if the string ends with a non-word char.
                                        if (current >= currentStringLength - 1)
                                            characterShouldBeNonWord = true;
                                            // Check if the next letter is not a word char. If not, return true. Else make sure that the current is +1 so it will be reset in the next IF statement.
                                        else if (!CharIsWordChar(currentString[++current]))
                                            return true;
                                    }
                                    else
                                        // Retrurn true of it not checking for words instead part of a string.
                                        return true;
                                }
                                // Reset the matching symbols counter if the end of the current string is not reached. If it is, continue testing on the next read.
                                if (currentStringLength != current)
                                    foundMatchingSymbols = 0;
                                // Check if the next matching symbol is in the current string.
                            } while ((charIndex = currentString.IndexOfAny(_textInChars[foundMatchingSymbols], ++charIndex)) >= 0);

                            // Assign the last character, so in the next round it knows the character before.
                            if (foundMatchingSymbols == 0 && _matchFullWords)
                                characterBefore = currentString[currentStringLength - 1];
                        }
                        else
                        {
                            foundMatchingSymbols = 0;
                            // Reasign the character before to the last char in the string.
                            if (_matchFullWords) characterBefore = currentString[currentStringLength - 1];
                        }
                    }
                    if (_matchFullWords && characterShouldBeNonWord)
                        return true;
                }
            }
            return false;
        }


        // SLOWER

        //public bool IsMatch(FileSystemInfo fileSystemInfo)
        //{
        //    var fileInfo = (FileInfo)fileSystemInfo;

        //    var buffer = new byte[BufferSize];
        //    var matchedValueTill = 0;
        //    var startNonWordSymbol = true; // true, so the beginning of the file is also valid.
        //    var textLength = _text.Length;

        //    // Check multiple encodings
        //    foreach (var encoding in _encodings)
        //    {
        //        using (var stream = fileInfo.OpenRead())
        //        {
        //            int length;
        //            while ((length = stream.Read(buffer, 0, buffer.Length)) > 0)
        //            {
        //                var currentString = encoding.GetString(buffer, 0, length);
        //                var currentStringLength = currentString.Length;

        //                for (int i = 0; i < currentStringLength; i++)
        //                {
        //                    var c = currentString[i];

        //                    if (_matchFullWords)
        //                    {
        //                        if (!startNonWordSymbol && !CharIsWordChar(c))
        //                        {
        //                            startNonWordSymbol = true;
        //                            continue;
        //                        }
        //                        if (matchedValueTill == textLength && !CharIsWordChar(c))
        //                        {
        //                            return true;
        //                        }
        //                    }

        //                    // Exact same char
        //                    if (startNonWordSymbol && matchedValueTill < textLength
        //                        && (c == _text[matchedValueTill]
        //                        // Ignore case
        //                        || (_ignoreCase && char.IsLower(c) && char.ToUpper(c) == _text[matchedValueTill])))
        //                        matchedValueTill++;
        //                    // Reset
        //                    else
        //                    {
        //                        matchedValueTill = 0;
        //                        if (_matchFullWords) startNonWordSymbol = false;
        //                    }

        //                    // Return true if the full text is matched and it should not match words.
        //                    if (!_matchFullWords && matchedValueTill == textLength)
        //                        return true;
        //                }
        //            }
        //        }
        //    }
        //    return textLength == matchedValueTill;
        //}

        //private bool CharsAreEqual(char c1, char textChar)
        //{
        //    if (!_ignoreCase) return c1 == textChar;
        //    return c1 == textChar && char.ToUpperInvariant(c1) == textChar;
        //}

        private static bool CharIsWordChar(char c)
        {
            return char.IsLetterOrDigit(c) || c == '_';
        }

        private static char[][] StringToCharArrays(string input, bool ignoreCase)
        {
            var list = new List<char[]>();
            foreach (var c in input)
            {
                if (!ignoreCase || !char.IsLetter(c))
                    list.Add(new[] {c});
                else
                {
                    var u = char.ToUpperInvariant(c);
                    var l = char.ToLowerInvariant(c);
                    list.Add(u != l ? new[] {u, l} : new[] {c});
                }
            }
            return list.ToArray();
        }
    }
}
