using MercadoPago.Models;
using MercadoPago.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MercadoPago.Controllers
{
    public class CreditCardSelectionController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var amount = Request.Form["amount"];
            System.Web.HttpContext.Current.Session["IdValue"] = amount;
            CardSelectionService model = new CardSelectionService();
            List<CreditCard> creditCards = await model.GetPayments();
            return View(creditCards);
        }
    }
}