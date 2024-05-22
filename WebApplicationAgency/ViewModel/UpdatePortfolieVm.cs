namespace WebApplicationAgency.ViewModel
{
    public class UpdatePortfolieVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set;}
      public IFormFile ImgFile { get; set; }

    }
}
