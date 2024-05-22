using System.ComponentModel.DataAnnotations;

namespace WebApplicationAgency.ViewModel
{
    public class CreatePortfolieVm
    {
        [Required]
        [StringLength(25, ErrorMessage = "Uzlug 25 i kece bilmez")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public IFormFile ImgFile { get; set; }
    }
}
