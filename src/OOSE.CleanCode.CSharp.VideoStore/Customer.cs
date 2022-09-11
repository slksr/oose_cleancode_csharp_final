using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSE.CleanCode.CSharp.VideoStore
{
    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void AddRental(Rental rental) 
        {
            _rentals.Add(rental);
        }

        public string Statement()
        {
            var result = Header(Name);

            foreach (var each in _rentals)
            {
                var thisAmount = AmountFor(each);
                result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            }

            decimal totalAmount = TotalAmount(_rentals);
            int frequentRenterPoints = FrequentRenderPoints(_rentals);

            result += Footer(frequentRenterPoints, totalAmount);

            return result;
        }


        private string Header(string name)
        {
            return "Rental Record for " + name + "\n";
        }

        private string Footer(int frequentRenterPoints, decimal totalAmount)
        {
            // add footer
            string footer1 = "You owed " + totalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            string footer2 = "You earned " + frequentRenterPoints.ToString() + " frequent renter points \n";
            string footer = footer1 + footer2;
            return footer;
        }

        /// <summary>
        /// Calculate Frequent Render Points
        /// </summary>
        /// <param name="rentals"></param>
        /// <returns></returns>
        private int FrequentRenderPoints(List<Rental> rentals)
        {
            // just the frequentRenterPoints
            int frequentRenterPoints = 0;
            foreach (var each in rentals)
            {
                frequentRenterPoints++;

                if (each.Movie.PriceCode == Movie.NEW_RELEASE && each.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }
            }

            return frequentRenterPoints;
        }

        /// <summary>
        /// Calculate the total amount of the rentals
        /// </summary>
        /// <param name="rentals"></param>
        /// <returns></returns>
        private decimal TotalAmount(List<Rental> rentals)
        {
            decimal totalAmount = 0m;
            foreach (var each in rentals)
            {
                var thisAmount = AmountFor(each);
                totalAmount += thisAmount;
            }

            return totalAmount;
        }

        /// <summary>
        /// Calculate the amount for a rental movie
        /// </summary>
        /// <param name="each"></param>
        /// <returns></returns>
        /// <remarks>This all about Rentals, so what is it doing in the Customer class?</remarks>
        private decimal AmountFor(Rental each)
        {
            var thisAmount = 0m;

            //determines the amount for each line
            switch (each.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (each.DaysRented > 2)
                    {
                        thisAmount += (each.DaysRented - 2) * 1.5m;
                    }
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += each.DaysRented * 3;
                    break;
                case Movie.CHILDREN:
                    thisAmount += 1.5m;
                    if (each.DaysRented > 3)
                    {
                        thisAmount += (each.DaysRented - 3) * 1.5m;
                    }
                    break;

            }

            return thisAmount;
        }


    }
}
