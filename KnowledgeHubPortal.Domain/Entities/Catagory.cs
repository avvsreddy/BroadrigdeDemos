using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Catagory
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
