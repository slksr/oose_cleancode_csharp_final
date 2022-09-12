using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSE.CleanCode.CSharp.VideoStore
{
    public class Price
    {
        private readonly int priceCode;

        public Price(int priceCode)
        {
            this.priceCode = priceCode;
        }

        public int PriceCode { get => priceCode; }

        public virtual double Amount(int daysRented)
        {
            double thisAmount = 0;
            switch (priceCode)
            {
                case Movie.NEW_RELEASE:
                    thisAmount += daysRented * 3;
                    break;
                case Movie.CHILDREN:
                    thisAmount += 1.5;
                    if (daysRented > 3)
                    {
                        thisAmount += (daysRented - 3) * 1.5;
                    }
                    break;
            }

            return thisAmount;
        }
    }
}
