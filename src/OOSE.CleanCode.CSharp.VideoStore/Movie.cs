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

        public Movie(string title, Price price)
        {
            _price = price;
            Title = title;
        }

        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        public const int CHILDREN = 2;


        public virtual string Title { get; }
        
        // Is obsolete geworden door refactoring
        //public Price Price { get => _price; }

        public double Amount(int daysRented)
        {
            return _price.Amount(daysRented);
        }

        public int RenterPoints(int daysRented)
        {
            return _price.Renterpoints(daysRented);
        }

    }
}
