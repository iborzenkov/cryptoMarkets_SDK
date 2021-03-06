namespace DomainModel.Features
{
    public class OrderId
    {
        public OrderId(string orderId)
        {
            Id = orderId;
        }

        public string Id { get; }

        public override string ToString()
        {
            return Id;
        }

        public bool Equals(OrderId other)
        {
            return other != null && Id.Equals(other.Id);
        }
    }
}