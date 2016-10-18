using System;
using System.Management.Automation.Host;

namespace WhiteChamber.PowerShellExtension.VirtualUi
{
    internal class VirtualRawUserInterface : PSHostRawUserInterface
    {
        public override KeyInfo ReadKey(ReadKeyOptions options)
        {
            throw new NotSupportedException();
        }

        public override void FlushInputBuffer()
        {
            throw new NotSupportedException();
        }

        public override void SetBufferContents(Coordinates origin, BufferCell[,] contents)
        {
            throw new NotSupportedException();
        }

        public override void SetBufferContents(Rectangle rectangle, BufferCell fill)
        {
            throw new NotSupportedException();
        }

        public override BufferCell[,] GetBufferContents(Rectangle rectangle)
        {
            throw new NotSupportedException();
        }

        public override void ScrollBufferContents(Rectangle source, Coordinates destination, Rectangle clip, BufferCell fill)
        {
            throw new NotSupportedException();
        }

        public override ConsoleColor ForegroundColor { get; set; }
        public override ConsoleColor BackgroundColor { get; set; }
        public override Coordinates CursorPosition { get; set; }
        public override Coordinates WindowPosition { get; set; }
        public override int CursorSize { get; set; }
        public override Size BufferSize { get; set; }
        public override Size WindowSize { get; set; }

        public override Size MaxWindowSize
        {
            get { throw new NotSupportedException(); }
        }

        public override Size MaxPhysicalWindowSize
        {
            get { throw new NotSupportedException(); }
        }

        public override bool KeyAvailable
        {
            get { throw new NotSupportedException(); }
        }

        public override string WindowTitle { get; set; }
    }
}
