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
                var thisAmount = each.Amount();
                result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            }

            double totalAmount = TotalAmount(_rentals);
            int frequentRenterPoints = FrequentRenderPoints(_rentals);

            result += Footer(frequentRenterPoints, totalAmount);

            return result;
        }


        private string Header(string name)
        {
            return "Rental Record for " + name + "\n";
        }

        private string Footer(int frequentRenterPoints, double totalAmount)
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
            int totalRenterPoints = 0;
            foreach (var rental in rentals)
            {
                totalRenterPoints += rental.RenterPoints(rental.DaysRented);
            }
            return totalRenterPoints ;
        }

        /// <summary>
        /// Calculate the total amount of the rentals
        /// </summary>
        /// <param name="rentals"></param>
        /// <returns></returns>
        private double TotalAmount(List<Rental> rentals)
        {
            double totalAmount = 0;
            foreach (var each in rentals)
            {
                var thisAmount = each.Amount();
                totalAmount += thisAmount;
            }

            return totalAmount;
        }
    }
}
