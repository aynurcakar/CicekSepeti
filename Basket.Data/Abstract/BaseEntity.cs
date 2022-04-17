using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Data.Abstract
{
    public class BaseEntity<TProperty> where TProperty : struct
    {
        [Key]
        public TProperty Id { get; set; } = default(TProperty);
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = "System";
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
