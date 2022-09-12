using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSE.CleanCode.CSharp.VideoStore
{
    public abstract class Price
    {
        private readonly int priceCode;

        public Price(int priceCode)
        {
            this.priceCode = priceCode;
        }

        public int PriceCode { get => priceCode; }

        public abstract double Amount(int daysRented);
    }
}
