using System;

namespace TestAfClassLibrary_.NET_Core_
{
    public class Book
    {
        private double _price;
        private string _author;
        private string _title;

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Author
        {
            get => _author;
            set => _author = value;
        }

        public double Price
        {
            get => _price;
            set
            {
                if(value < 0.0) throw new ArgumentOutOfRangeException();
                _price = value;
            } 
        }

        public override string ToString()
        {
            return Author + " " + Title + " " + Price;
        }
    }
}
