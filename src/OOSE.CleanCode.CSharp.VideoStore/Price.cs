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

        public decimal Amount(int daysRented)
        {
            var thisAmount = 0m;
            switch (priceCode)
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
