using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSE.CleanCode.CSharp.VideoStore
{
    public class ChildrensPrice : Price
    {
        public ChildrensPrice() : base(Movie.CHILDREN)
        {
        }

        public override double Amount(int daysRented)
        {
            double thisAmount = 1.5;
            if (daysRented > 3)
            {
                thisAmount += (daysRented - 3) * 1.5;
            }
            return thisAmount;
        }
    }
}
