namespace GenericsHomework
{
    public class Node<T> where T : notnull
    {
        private T Value { get; set; }
        public Node<T> Next { get; private set; }

        public Node(T value)
        {
            Value = value;
            Next = this;
        }

        public override string? ToString()
        {
            return Value.ToString();
        }

        public void Append(T value)
        {
            if(Exists(value)) { throw new ArgumentException("The value already exists"); }

            Node<T> node = new(value);
            Node<T> currentNext = this.GetNext();

            while(currentNext.GetNext() != this) { currentNext = currentNext.GetNext(); }

            currentNext.SetNext(node);
            node.SetNext(this);
        }

        public void Clear()
        {
            // TODO: implement Clear() method
        }

        public bool Exists(T value)
        {
            if(this.Value.Equals(value)) { return true; }

            Node<T> currentNext = this.GetNext();

            while(currentNext != this)
            {
                if(currentNext.Value.Equals(value)) { return true; }
                currentNext = currentNext.GetNext();
            }

            return false;
        }

        public Node<T> GetNext()
        {
            return this.Next;
        }

        public void SetNext(Node<T> next)
        {
            this.Next = next;
        }
    }
}