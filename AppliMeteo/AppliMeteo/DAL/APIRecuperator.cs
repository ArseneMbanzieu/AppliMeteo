using AppliMeteo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppliMeteo.DAL
{
    public class APIRecuperator : IDisposable
    {
        private HttpClient client;

        public APIRecuperator()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<VilleRoot>> GetVilles()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("http://www.prevision-meteo.ch/services/json/list-cities").Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<Dictionary<string, VilleRoot>>();
                    return result.Select(v => v.Value).Where(v => v.country=="BEL");
                }
                return null;
            }
        }   

        public async Task<MeteoRoot> GetMeteoAsync(string city)
        {
            HttpResponseMessage reponse = client.GetAsync($"https://www.prevision-meteo.ch/services/json/{city}").Result;
            if (reponse.IsSuccessStatusCode)
            {
                MeteoRoot mr = await reponse.Content.ReadAsAsync<MeteoRoot>();

                if (mr.city_info != null)
                {
                    return mr;
                }
            }
            else
            {
                throw new Exception($"Erreur serveur : {(int)reponse.StatusCode}\n{reponse.ReasonPhrase}");
            }
            throw new Exception($"Erreur de connexion");
        }

        public void Dispose()
        {

        }
    }
}
