using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public  class Notice
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool Visible { get; set; }

        // quan hệ
        public virtual Staff Staff { get; set; }
    }
}
