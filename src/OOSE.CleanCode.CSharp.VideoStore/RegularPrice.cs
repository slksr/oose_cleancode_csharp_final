namespace OOSE.CleanCode.CSharp.VideoStore
{
    public class RegularPrice : Price
    {
        
        public RegularPrice() : base(Movie.REGULAR)
        {
           
        }

        public override double Amount(int daysRented)
        {
            double thisAmount = 2.0;
            if (daysRented > 2)
            {
                thisAmount += (daysRented - 2) * 1.5;
            }

            return thisAmount;
        }
    }
}