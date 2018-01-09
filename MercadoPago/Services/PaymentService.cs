using MercadoPago.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercadoPago.Services
{
    public class PaymentService
    {
        public async Task<List<Payment>> GetPayments(string idBank, string idCard, string amount)
        {
            var json = "";
            List<Payment> listPayments = new List<Payment>();

            using (var httpClient = new HttpClient())
            {
                json = await httpClient.GetStringAsync("https://api.mercadopago.com/v1/payment_methods/installments?public_key=444a9ef5-8a6b-429f-abdf-587639155d88&amount="+amount+"&payment_method_id="+ idBank.ToLower() + "&issuer.id="+ idCard);

                try
                {
                    JArray jsonArray = JArray.Parse(json);

                    for (int i = 0; i < jsonArray.Count; i++)
                    {
                        JObject data = JObject.Parse(jsonArray[i].ToString());

                        JArray jsonArrayChild = JArray.Parse(data["payer_costs"].ToString());
                        
                        for (int a = 0; a < jsonArrayChild.Count; a++)
                        {
                            JObject payerCosts = JObject.Parse(jsonArrayChild[a].ToString());
                            Payment payment = new Payment();
                            payment.Name = payerCosts["recommended_message"].ToString();
                            listPayments.Add(payment);
                        }                       
                    }
                }
                catch (Exception ex)
                {
                    var a = ex.Message;
                    throw;
                }

            }

            return listPayments;
        }
    }
}