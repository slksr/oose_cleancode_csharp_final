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
            var thisAmount = 0m;

            // Now this is a lot about movie. So shouldn't it be in the Movie class?
            switch (Movie.PriceCode)
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (DaysRented > 2)
                    {
                        thisAmount += (DaysRented - 2) * 1.5m;
                    }
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += DaysRented * 3;
                    break;
                case Movie.CHILDREN:
                    thisAmount += 1.5m;
                    if (DaysRented > 3)
                    {
                        thisAmount += (DaysRented - 3) * 1.5m;
                    }
                    break;

            }

            return thisAmount;
        }
    }
}
