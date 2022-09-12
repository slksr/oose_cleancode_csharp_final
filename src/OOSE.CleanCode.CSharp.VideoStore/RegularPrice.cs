namespace OOSE.CleanCode.CSharp.VideoStore
{
    public class RegularPrice : Price
    {
        
        public RegularPrice() : base(Movie.REGULAR)
        {
           
        }

        public decimal Amount(int daysRented)
        {
            decimal thisAmount = 2;
            if (daysRented > 2)
            {
                thisAmount += (daysRented - 2) * 1.5m;
            }

            return thisAmount;
        }
    }
}