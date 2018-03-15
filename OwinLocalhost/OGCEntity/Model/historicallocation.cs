using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCCodeEF.Model
{
    [Table("historicallocation")]
    public partial class historicallocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Thing_Id { get; set; }

        [Required]
        public int Location_Id { get; set; }

        public DateTime? Time { get; set; }

        [JsonIgnore]
        [ForeignKey("Location_Id")]
        public virtual location location { get; set; }
        [JsonIgnore]
        [ForeignKey("Thing_Id")]
        public virtual thing thing { get; set; }
    }
}
