namespace Models.Interfaces
{
    public interface IModel
    {
        DomainModel.IModel DomainModel { get; }
    }
}