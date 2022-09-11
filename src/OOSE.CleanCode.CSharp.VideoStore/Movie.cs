using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSE.CleanCode.CSharp.VideoStore
{
    public class Movie
    {
        private Price _price;

        public Movie(string title, int priceCode)
        {
            Title = title;
            _price = new Price(priceCode);
        }

        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        public const int CHILDREN = 2;


        public virtual string Title { get; }
        public Price Price { get => _price; }

        public decimal Amount(int daysRented)
        {
            return _price.Amount(daysRented);
        }

    }
}
