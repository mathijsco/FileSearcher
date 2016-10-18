using System;

namespace FileSearcher.Model.DuplicateAnalyse
{
    internal class LazyDisposable<T> : IDisposable where T : IDisposable
    {
        private readonly Func<T> _constructor;
        private bool _isConstructed;
        private T _innerObject;

        public LazyDisposable(Func<T> constructor)
        {
            _constructor = constructor;
        }

        public T Instance
        {
            get
            {
                if (!_isConstructed)
                {
                    _innerObject = _constructor();
                    _isConstructed = true;
                }
                return _innerObject;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_isConstructed) _innerObject.Dispose();
            }
        }
    }
}