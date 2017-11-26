using Studio_Line.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Studio_Line.ViewModels;
using System.Data.Entity;


namespace Studio_Line.Controllers
{
    public class MagasinController : Controller
    {

        private ApplicationDbContext _contextDb;

        public MagasinController()
        {
            _contextDb = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contextDb.Dispose();
        }

        // GET: Magasin
        public ActionResult Index()
        {
            var magasins = _contextDb.Magasins.Include(c => c.Genre).ToList();

            return View(magasins);
            /*/
            var magasin = new Magasin() { Name = " Orian Pictures" };
            
            var customers = new List<Customers>
            {
             new Customers {Name = " Adam Jones"},
             new Customers {Name = "John Doe"}

            };

            var viewModels = new viewModels()
            {
                magasin = magasin,
                Customers = customers
            };
            /*/

        }

        public ActionResult Details(int id)
        {
            var magasin = _contextDb.Magasins.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if(magasin == null)
            {
                return HttpNotFound();
            }
            return View(magasin);

        }

        public ActionResult CreateForm()
        {
            ViewData["H1"] = "New Magasin";

            var viewModel = new viewGenreModel
            {
                GenreList = _contextDb.GenreList.ToList(),
            };
            
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(viewGenreModel NewMagasin)                            //---> Start here Complete the saving function and You are Done for Day:::
        {

            if(NewMagasin.magasin.Id == 0)
            {
                _contextDb.Magasins.Add(NewMagasin.magasin);
            }
            else
            {
                var magasinDb = _contextDb.Magasins.Single(c => c.Id == NewMagasin.magasin.Id);

                magasinDb.Name = NewMagasin.magasin.Name;
                magasinDb.RealeaseDate = NewMagasin.magasin.RealeaseDate;
                magasinDb.DataAdd = NewMagasin.magasin.DataAdd;
                magasinDb.InStock = NewMagasin.magasin.InStock;
                magasinDb.GenreId = NewMagasin.magasin.GenreId; 
            }
            _contextDb.SaveChanges();

            return RedirectToAction("Index", "Magasin");
        }

        public ActionResult Edit(int id)
        {
            
            ViewData["H1"] = "Edit Magasin"; 

            var magasin= _contextDb.Magasins.SingleOrDefault(c => c.Id == id);

            if (magasin == null)
            {
                return HttpNotFound();
            }

            var viewModel = new viewGenreModel
            {
                magasin = magasin,
                GenreList = _contextDb.GenreList.ToList()
            };

            return View("CreateForm", viewModel);
        }


        /*/
        private IEnumerable<Magasin> GetMagasin()
        {
            return new List<Magasin>()
            {
                new Magasin { Id = 1, Name = "National Graphic"},
                new Magasin { Id = 2, Name = "Filmz"}
            };
        }
        /*/

    }
}