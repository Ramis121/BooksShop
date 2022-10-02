using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseEntityKey
{
    public class EntityKey : DateCreateBooks
    {
        [Key]
        public int Id { get; set; }
    }

    public abstract class DateCreateBooks
    {
        [Required]
        public DateTime CreateDate { get; set; }
    }
}
