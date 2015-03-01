using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology.Utilities
{
    public sealed class TokenEnumerator : IEnumerator, ICloneable, IEnumerator<char>, IDisposable
    {
        private String input;
        private int index;
        private char currentElement;

        internal TokenEnumerator(String input)
        {
            Contract.Requires(input != null, "Input string cannot be null" );
            this.input = input;
            this.index = -1;
        }

        public Object Clone()
        {
            return MemberwiseClone();
        }

        public bool MoveNext()
        {
            if (index < (input.Length - 1))
            {
                index++;
                currentElement = input[index];
                return true;
            }
            else
                index = input.Length;
            return false;

        }

        public void Dispose()
        {
            if (input != null)
                index = input.Length;
            input = null;
        }

        //For backward compatibility
        Object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public char Current
        {
            get
            {
                if (index == -1 || index >= input.Length)
                    return Constants.DefaultToken;
                return currentElement;
            }
        }

        public void Reset()
        {
            currentElement = Constants.DefaultToken;
            index = -1;
        }
    }
}
