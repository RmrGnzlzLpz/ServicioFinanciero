using Domain.Base;

namespace Domain.Interfaces
{
    public interface IGenericFactory<T> where T : BaseEntity
    {
        T CreateEntity(int type);
    }
}