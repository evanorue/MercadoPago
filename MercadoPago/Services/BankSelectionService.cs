using MercadoPago.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercadoPago.Services
{
    public class BankSelectionService
    {
        public async Task<List<Bank>> GetBanks(string idBank)
        {
            var json = "";
            List<Bank> listBanks = new List<Bank>();

            using (var httpClient = new HttpClient())
            {
                json = await httpClient.GetStringAsync("https://api.mercadopago.com/v1/payment_methods/card_issuers?public_key=444a9ef5-8a6b-429f-abdf-587639155d88&payment_method_id=" + idBank);

                try
                {
                    JArray jsonArray = JArray.Parse(json);

                    for (int i = 0; i < jsonArray.Count; i++)
                    {
                        JObject data = JObject.Parse(jsonArray[i].ToString());
                        Bank bank = new Bank();
                        bank.Name = data["name"].ToString();
                        bank.Id = Convert.ToInt32(data["id"]);
                        listBanks.Add(bank);
                    }
                }
                catch (Exception ex)
                {
                    var a = ex.Message;
                    throw;
                }

            }

            return listBanks;
        }
    }
}