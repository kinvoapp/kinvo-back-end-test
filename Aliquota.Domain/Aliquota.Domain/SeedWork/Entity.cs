namespace Aliquota.Domain.SeedWork
{
    public abstract class Entity
    {
        private int id;
        public virtual int Id
        {
            get
            {
                return this.id;
            }
            protected set
            {
                this.id = value;
            }
        }
    }
}
