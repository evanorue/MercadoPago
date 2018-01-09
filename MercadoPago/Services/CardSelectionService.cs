using MercadoPago.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercadoPago.Services
{
    public class CardSelectionService
    {
        public async Task<List<CreditCard>> GetPayments()
        {
            var json = "";
            List<CreditCard> listCreditCards = new List<CreditCard>();

            using (var httpClient = new HttpClient())
            {
                json = await httpClient.GetStringAsync("https://api.mercadopago.com/v1/payment_methods?public_key=444a9ef5-8a6b-429f-abdf-587639155d88");
                
                try
                {
                    JArray jsonArray = JArray.Parse(json);

                    for (int i = 0; i < jsonArray.Count; i++)
                    {
                        JObject data = JObject.Parse(jsonArray[i].ToString());
                        CreditCard creditCards = new CreditCard();
                        creditCards.Name = data["name"].ToString();
                        creditCards.Id = data["id"].ToString();
                        listCreditCards.Add(creditCards);
                    }
                }
                catch (Exception ex)
                {
                    var a = ex.Message;
                    throw;
                }

            }

            return listCreditCards;
        }
    }
}