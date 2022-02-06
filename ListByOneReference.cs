namespace OneRefList
{
    public class OneRefList<T>
    {
        private Node<T> _head, _tail;
        private int _length;
        public int Length => this._length;

        public OneRefList()
        {
            _head = null;
            _length = 0;
        }

        public OneRefList(T value)
        {
            _head = null;
            _length = 0;
            this.Add(value);
        }

        public OneRefList(params T[] values)
        {
            _head = null;
            _length = 0;
            Add(values);
        }

        public void Add(T intValue)
        {
            if (_head is null)
            {
                _head = new Node<T>(intValue);
                _tail = _head;
                _length = 1;
                return;
            }

            _tail.reference = new Node<T>(intValue);
            _tail = _tail.reference;
            _length++;
        }

        public void Add(params T[] intValues)
        {
            foreach (var item in intValues)
            {
                this.Add(item);
            }
        }
        public void PushFront(T value)
        {
            Node<T> temp = _head;
            _head = new Node<T>(value, temp);
            _length++;
        }

        public void Insert(int index, T value)
        {
            if (index == 0)
            {
                PushFront(value);
                return;
            }

            this[index - 1].reference = new Node<T>(value, this[index]);
            _length++;
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                PopFront();
            }

            if (index == Length - 1)
            {
                PopEnd();
                return;
            }

            this[index - 1].reference = this[index + 1];
            _length--;
        }

        public bool PopFront()
        {
            if (_head != null)
            {
                _head = _head.reference ?? null;
                _length--;
                return true;
            }

            return false;
        }

        public void PopEnd()
        {
            if (Length > 1)
            {
                this[^2].reference = null;
                _tail = this[^1];
            }
            else
            {
                _head = null;
                _tail = null;
            }

            _length--;
        }

        public override string ToString()
        {
            string result = "";
            for (Node<T> item = _head; item != null; item = item.reference)
            {
                result += $"{item.data} ";
            }

            return result;
        }

        public Node<T> this[int index]
        {
            get
            {
                if (index >= this.Length)
                {
                    throw new System.IndexOutOfRangeException(nameof(index));
                }

                Node<T> current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.reference;
                }

                return current;
            }
        }

        public class Node<t>
        {
            public Node(t value, Node<t> reff = null)
            {
                data = value;
                reference = reff;
            }

            public Node<t> reference;
            public t data;
        }
    }
}
