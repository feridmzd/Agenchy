using Microsoft.AspNetCore.Mvc;
using WebApplicationAgency.DAL;
using WebApplicationAgency.Models;
using WebApplicationAgency.ViewModel;

namespace WebApplicationAgency.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PortfoliesController : Controller
    {
      
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PortfoliesController(AppDbContext context,IWebHostEnvironment environment)
        {
           _context = context;
          _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_context.Portfolies.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatePortfolieVm createPortfolieVm) 
        
        {
            if (!createPortfolieVm.ImgFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImgFile", "Duzgun format daxil edin");
                return View();
            }
            string path = _environment.WebRootPath + @"\Upload\";
            string filename = Guid.NewGuid() + createPortfolieVm.ImgFile.FileName;

            using (FileStream filestream=new FileStream(path+filename,FileMode.Create))
            {
               createPortfolieVm.ImgFile.CopyTo(filestream);
            
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            Portfolies portfolies = new Portfolies()
            {
                Name = createPortfolieVm.Name,
                Description = createPortfolieVm.Description,
                ImgUrl = filename
            };
            _context.Portfolies.Add(portfolies);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }





        public IActionResult Delete(int id) 
        {
         var portfolio= _context.Portfolies.FirstOrDefault(x=> x.Id == id);


            if (portfolio != null)
            {

                string path = _environment.WebRootPath + @"\Upload\" + portfolio.ImgUrl;
                FileInfo  fileInfo= new FileInfo(path);

                if (fileInfo.Exists)
                {
                    fileInfo.Delete();

                }
                _context.Portfolies.Remove(portfolio);
                _context.SaveChanges();
                return RedirectToAction("Index");


            }
            return RedirectToAction("Index");



        }
        public IActionResult Update(int id)
        {
            Portfolies portfolies= _context.Portfolies.FirstOrDefault(x=>x.Id == id);
            UpdatePortfolieVm updatePortfolieVm= new UpdatePortfolieVm()
            {

                Id=portfolies.Id,
                Name=portfolies.Name,
                Description=portfolies.Description,
                ImgUrl=portfolies.ImgUrl,



            };
            if (portfolies == null)
            {
                return RedirectToAction("Index");
            }
            return View(updatePortfolieVm);

        }
        [HttpPost]
        public IActionResult Update(UpdatePortfolieVm PortfolieVm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }



            var portfolio= _context.Portfolies.FirstOrDefault(x=>x.Id ==PortfolieVm.Id);
            if (portfolio == null) { return RedirectToAction("Index"); }
            portfolio.Name = PortfolieVm.Name;
            portfolio.Description = PortfolieVm.Description;
            portfolio.ImgUrl=PortfolieVm.ImgUrl;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}
