using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoRefList
{
    public class TwoRefList<T>
    {
        public TwoRefList()
        {
            _head = _tail = null;
            _length = 0;
        }

        public TwoRefList(params T[] values)
        {
            Add(values);
        }

        private Node<T> _head, _tail;
        private int _length;
        public int Length { get { return _length; } }

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new Node<T>(value);
                _tail = _head;
            }
            else
            {
                _tail.next = new Node<T>(value, prev: _tail);
                _tail = _tail.next;
            }

            _length++;
            return;
        }

        public void Add(params T[] values)
        {
            foreach (var item in values)
            {
                Add(item);
            }
        }

        public void PushFront(T value)
        {
            _head.prev = new Node<T>(value, next: _head);
            _head = _head.prev;
            _length++;
        }

        public void Insert(int index, T value)
        {
            if (index == 0)
            {
                PushFront(value);
            }

            else if (index == _length - 1)
            {
                Add(value);
            }
            else
            {
                Node<T> current = this[index];
                current.prev.next = new Node<T>(value, prev: current.prev, next: current);
                current.prev = current.prev.next;
            }

            _length++;
        }

        public void PopFront()
        {
            if (_head is null)
            {
                return;
            }

            _head = _head.next;
            _head.prev = null;
            _length--;
        }

        public void PopBack()
        {
            if (_tail is null)
            {
                return;
            }

            _tail = _tail.prev;
            _tail.next = null;
            _length--;
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                PopFront();
            }
            else if (index == _length - 1)
            {
                PopBack();
            }
            else
            {
                Node<T> current = this[index];
                current.prev.next = current.next;
                current.next.prev = current.prev;
            }

            _length--;
        }

        public override string ToString()
        {   
            if (_head == null)
            {
                return string.Empty;
            }

            string result = "";
            Node<T> current = _head;
            while (current != null)
            {
                result += $"{current.data} ";
                current = current.next;
            }

            return result;
        }

        public Node<T> this[int index]
        {
            get
            {
                if (index >= _length || index < 0)
                {
                    throw new System.IndexOutOfRangeException(nameof(index));
                }

                Node<T> current;
                if (index < _length / 2)
                {
                    current = _head;
                    for (int i = 0; i < index; i++)
                    {
                        current = current.next;
                    }

                    return current;
                }

                current = _tail;
                for (int i = _length - 1; i > index; i--)
                {
                    current = current.prev;
                }

                return current;
            }
        }

        public class Node<t>
        {
            public Node(t data, Node<t> next = null, Node<t> prev = null)
            {
                this.data = data;
                this.next = next;
                this.prev = prev;
            }

            public t data;
            public Node<t> next, prev;
        }
    }
}
