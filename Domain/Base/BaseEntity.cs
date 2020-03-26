namespace Domain.Base
{
    public class BaseEntity
    {
        
    }
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id {get; set; }
    }
}