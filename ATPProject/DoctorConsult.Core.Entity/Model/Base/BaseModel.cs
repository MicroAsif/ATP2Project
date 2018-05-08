using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Entity.Model.Base
{
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }
        public bool IsDelete { get; set; }

      
    }
}
