using MVC_Assessment_8.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Assessment_8.Controllers
{
    public class CodeController : Controller
    {
        public ActionResult Index()

        {

            return View();

        }

        private NorthwindEntities db = new NorthwindEntities();



        public ActionResult CustomersInGermany()

        {

            var customers = db.Customers

                              .Where(c => c.Country == "Germany")

                              .ToList();

            return View(customers);

        }



        public ActionResult CustomerByOrder()

        {

            var customer = (from o in db.Orders

                            where o.OrderID == 10248

                            select o.Customer).FirstOrDefault();

            return View(customer);

        }

    }

}

