using System;
using System.ComponentModel.DataAnnotations;

namespace src.Models
{
    public class BaseEntity
    {
        private DateTime _addedDate;
        private DateTime _modifiedDate;
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            AddedDate = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime AddedDate
        {
            get => DateTime.SpecifyKind(_addedDate, DateTimeKind.Utc);
            private set => _addedDate = value;
        }
        public DateTime ModifiedDate
        {
            get => DateTime.SpecifyKind(_modifiedDate, DateTimeKind.Utc);
            set => _modifiedDate = value;
        }
    }
}
