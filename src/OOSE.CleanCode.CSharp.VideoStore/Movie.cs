using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSE.CleanCode.CSharp.VideoStore
{
    public class Movie
    {
        public Movie(string title, int priceCode)
        {
            PriceCode = priceCode;
            Title = title;
        }

        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        public const int CHILDREN = 2;

        public int PriceCode { get; set; }
        public virtual string Title { get; }

        public decimal Amount(int daysRented)
        {
            var thisAmount = 0m;
            switch (PriceCode)
            {
                // todo: Now we can change these enums in its own classes and use polymorphism.
                case REGULAR:
                    thisAmount += 2;
                    if (daysRented > 2)
                    {
                        thisAmount += (daysRented - 2) * 1.5m;
                    }
                    break;
                case NEW_RELEASE:
                    thisAmount += daysRented * 3;
                    break;
                case CHILDREN:
                    thisAmount += 1.5m;
                    if (daysRented > 3)
                    {
                        thisAmount += (daysRented - 3) * 1.5m;
                    }
                    break;
            }

            return thisAmount;
        }

    }
}
