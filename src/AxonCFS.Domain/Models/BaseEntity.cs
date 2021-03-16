using System.ComponentModel.DataAnnotations;
using AxonCFS.Domain.Models.Interfaces;

namespace AxonCFS.Domain.Models
{
    public abstract class BaseEntity
    {
    }

    public abstract class BaseEntity<T>
        : BaseEntity, IEntity<T>, IConcurrencyEntity
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public virtual T Id { get; set; }

        /// <summary>
        /// Gets or sets the tstamp.
        /// </summary>
        /// <value>The tstamp.</value>
        [Timestamp]
        public virtual byte[] Tstamp { get; set; }
    }
}