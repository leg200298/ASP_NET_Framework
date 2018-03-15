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
    [Table("observation")]
    public partial class observation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? Phenomenon_Time { get; set; }

        public DateTime? ResultTime { get; set; }

        [MaxLength(50)]
        public string Result { get; set; }

        [MaxLength(150)]
        public string ResultQuality { get; set; }

        [MaxLength(150)]
        public string ValidTime { get; set; }

        [MaxLength(300)]
        public string Parameters { get; set; }

        [Required]
        public int FeatureOflnterest_Id { get; set; }

        [Required]
        public int Datastream_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Datastream_Id")]
        public virtual datastream datastream { get; set; }
        [JsonIgnore]
        [ForeignKey("FeatureOflnterest_Id")]
        public virtual featureofinterest featureofinterest { get; set; }
    }
}
