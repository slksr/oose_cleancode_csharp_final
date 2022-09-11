using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSE.CleanCode.CSharp.VideoStore
{
    public class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            DaysRented = daysRented;
            Movie = movie;
        }

        public int DaysRented { get; }
        public virtual Movie Movie { get; }


        /// <summary>
        /// Calculate the amount for a rental movie
        /// </summary>
        /// <returns></returns>
        public decimal Amount()
        {
            return Amount(Movie, DaysRented);
        }

        private decimal Amount(Movie movie, int daysRented)
        {
            var thisAmount = 0m;
            switch (movie.PriceCode)
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (daysRented > 2)
                    {
                        thisAmount += (daysRented - 2) * 1.5m;
                    }
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += daysRented * 3;
                    break;
                case Movie.CHILDREN:
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
