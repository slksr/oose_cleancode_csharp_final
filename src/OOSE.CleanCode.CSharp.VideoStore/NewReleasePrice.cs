using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSE.CleanCode.CSharp.VideoStore
{
    public class NewReleasePrice : Price
    {
        public NewReleasePrice() : base(Movie.NEW_RELEASE)
        {
        }

        public override double Amount(int daysRented)
        {
            double thisAmount = daysRented * 3;
            return thisAmount;
        }

        public override int Renterpoints(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1;
        }
    }
}
