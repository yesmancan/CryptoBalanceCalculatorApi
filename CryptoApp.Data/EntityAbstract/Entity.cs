using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoApp.Data.EntityAbstract
{
    public abstract class Entity
    {
        [Required]
        public int Status { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreateDt { get; set; }
        public string CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateDt { get; set; }
        [StringLength(50)]
        public string UpdatedBy { get; set; }
    }
}
