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
    [Table("location")]
    public partial class location
    {

        public location()
        {
            this.historicallocation = new HashSet<historicallocation>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string EncodingType { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        [JsonIgnore]
        public virtual ICollection<historicallocation> historicallocation { get; set; }
    }
}
