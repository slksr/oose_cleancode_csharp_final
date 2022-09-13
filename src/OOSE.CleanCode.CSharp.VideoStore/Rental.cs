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

        public int RenterPoints(int daysRented)
        {
            return Movie.RenterPoints(daysRented);
        }


        /// <summary>
        /// Calculate the amount for a rental movie
        /// </summary>
        /// <returns></returns>
        public double Amount()
        {
            return Movie.Amount(DaysRented);
        }

    }
}
