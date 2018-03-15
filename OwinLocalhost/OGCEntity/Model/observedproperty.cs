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
    [Table("observedproperty")]
    public partial class observedproperty
    {

        public observedproperty()
        {
            this.datastream = new HashSet<datastream>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Definition { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<datastream> datastream { get; set; }
    }
}
