using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Catagory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter category name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter description upto 500 charectors")]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
