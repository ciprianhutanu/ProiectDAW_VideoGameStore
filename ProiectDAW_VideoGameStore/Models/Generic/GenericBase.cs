using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectDAW_VideoGameStore.Models.Generic
{
    public class GenericBase:IGenericBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
