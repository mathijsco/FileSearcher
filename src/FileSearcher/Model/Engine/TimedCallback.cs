using System;
using System.Collections.Generic;

namespace FileSearcher.Model.Engine
{
    internal class TimedCallback<T>
    {
        private readonly TimeSpan _timeout;
        private readonly Action<IEnumerable<T>> _callback;
        private DateTime _lastTrigger;
        private bool _isRunning = false;

        public TimedCallback(TimeSpan timeout, Action<IEnumerable<T>> callback)
        {
            if (callback == null) throw new ArgumentNullException("callback");
            if (timeout.TotalSeconds < 0.1) throw new ArgumentException(@"The timeout should be minimal 0.1 second.", "timeout");

            _timeout = timeout;
            _callback = callback;
            _lastTrigger = DateTime.UtcNow;
        }

        /// <summary>
        /// Value indicating whether the timeout period has exceeded and new data can be obtained.
        /// </summary>
        public bool DataNeeded
        {
            get { return !_isRunning && DateTime.UtcNow - _lastTrigger >= _timeout; }
        }

        /// <summary>
        /// Sets the data to be send to the callback delegate.
        /// </summary>
        /// <param name="collection">Collection with the data.</param>
        public void SetData(IEnumerable<T> collection)
        {
            try
            {
                _isRunning = true;
                _callback(collection);
                _lastTrigger = DateTime.UtcNow;
            }
            finally 
            {
                _isRunning = false;
            }
        }
    }
}
