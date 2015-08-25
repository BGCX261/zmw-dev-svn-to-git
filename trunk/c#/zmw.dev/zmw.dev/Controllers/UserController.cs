using System.Linq;
using System.Web.Mvc;

namespace zmw.dev.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View();
        }


        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
