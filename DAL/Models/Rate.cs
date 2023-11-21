using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Đánh giá")]
    public class Rate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        //public IdMB 
    }
}
