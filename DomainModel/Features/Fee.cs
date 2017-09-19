namespace DomainModel.Features
{
    public abstract class Fee
    {
        public abstract double Value(Order order);
    }
}