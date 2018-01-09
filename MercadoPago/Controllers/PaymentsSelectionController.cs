using MercadoPago.Models;
using MercadoPago.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MercadoPago.Controllers
{
    public class PaymentsSelectionController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var entidadBancariaId = Request.Form["Items"];
            var amount = System.Web.HttpContext.Current.Session["IdValue"].ToString();
            var idBank = System.Web.HttpContext.Current.Session["IdBank"].ToString();
            PaymentService model = new PaymentService();
            var payments = await model.GetPayments(idBank, entidadBancariaId, amount);
            return View(payments);
        }

        public ActionResult Finish()
        {
            ViewBag.Message = "Gracias por su Compra.";

            return View();
        }
    }
}