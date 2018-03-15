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
    [Table("thing")]
    public partial class thing
    {

        public thing()
        {
            this.datastream = new HashSet<datastream>();
            this.historicallocation = new HashSet<historicallocation>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Properties { get; set; }

        [JsonIgnore]
        public virtual ICollection<datastream> datastream { get; set; }
        [JsonIgnore]
        public virtual ICollection<historicallocation> historicallocation { get; set; }
    }
}
