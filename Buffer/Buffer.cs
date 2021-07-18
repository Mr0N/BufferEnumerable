using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext
{
    class Buffer<T> : IEnumerable<T>, IEnumerator<T>
    {
        public Buffer(IEnumerator<T> enumerator, bool? state = null)
        {
            if (state != null)
            {
                this.state = state.Value;
            }
            else
            {
                this.buffer = new List<T>();
            }
            this.enumerator = enumerator;


        }
        bool state;
        IEnumerator<T> enumerator;
        List<T> buffer;
        public T Current
        {
            get
            {
                var current = this.enumerator.Current;
                if (buffer != null) buffer.Add(current);
                return current;
            }
        }

        object IEnumerator.Current => this.Current;

        public IEnumerator<T> GetEnumerator()
        {
            if (state == false)
            {
                return this;
            }
            else return new Buffer<T>(this.buffer.GetEnumerator(), true);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool MoveNext()
        {
            return this.enumerator.MoveNext();
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            this.enumerator.Dispose();
            this.state = true;
        }
    }
}
