using Models.Interfaces;

namespace Models.Implementations
{
    public class Model : IModel
    {
        private readonly DomainModel.Model _domainModel;

        public Model(DomainModel.Model domainModel)
        {
            _domainModel = domainModel;
        }

        DomainModel.IModel IModel.DomainModel => _domainModel;
    }
}