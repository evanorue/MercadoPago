using MercadoPago.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MercadoPago.Controllers
{
    public class BankSelectionController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var bankId = Request.Form["Items"];
            System.Web.HttpContext.Current.Session["IdBank"] = bankId;
            BankSelectionService model = new BankSelectionService();
            var banks = await model.GetBanks(bankId.ToLower());
            return View(banks);
        }
    }
}