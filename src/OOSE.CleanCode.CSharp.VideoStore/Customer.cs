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
            var totalAmount = 0m;
            var result = Header(Name);

            foreach (var each in _rentals)
            {
                var thisAmount = 0m;

                //dtermines the amount for each line
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

                result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
                totalAmount += thisAmount;
            }

            // just the frequentRenterPoints
            int frequentRenterPoints = 0;
            foreach (var each in _rentals)
            {
                frequentRenterPoints++;

                if (each.Movie.PriceCode == Movie.NEW_RELEASE && each.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }
            }

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


    }
}
