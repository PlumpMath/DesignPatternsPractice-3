using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal class FibonacciEnumerator : IEnumerator<int>
    {
        private int _numberOfValues;
        private int _currentPosition;
        private int _previousTotal;
        private int _currentTotal;

        public FibonacciEnumerator(int numberOfValues)
        {
            _numberOfValues = numberOfValues;
        }

        public int Current { get { return _currentTotal; } }

        object IEnumerator.Current { get { return Current; } }

        public bool MoveNext()
        {
            if (_currentPosition == 0)
                _currentTotal = 1;
            else
            {
                int _newTotal = _previousTotal + _currentTotal;
                _previousTotal = _currentTotal;
                _currentTotal = _newTotal;
            }
            _currentPosition++;

            return _currentPosition <= _numberOfValues;
        }

        public void Reset()
        {
            _currentPosition = 0;
            _previousTotal = 0;
            _currentTotal = 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        
    }
}
