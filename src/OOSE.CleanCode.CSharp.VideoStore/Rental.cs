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
    }
}
