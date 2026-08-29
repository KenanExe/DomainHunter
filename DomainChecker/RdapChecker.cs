using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DomainChecker
{
    internal class RdapChecker
    {
        private static readonly HttpClient client = CreateClient();

        private static HttpClient CreateClient()
        {
            var c = new HttpClient();
            c.DefaultRequestHeaders.Add("User-Agent", "Kenan.bio/DomainChecker");
            c.DefaultRequestHeaders.Add("Accept", "application/rdap+json, application/json");
            return c;
        }

        public static async Task<int> CheckDomainAsync(string domain)
        {
            try
            {
                var response = await client.GetAsync($"https://rdap.org/domain/{domain}");
                return (int)response.StatusCode;
            }
            catch (Exception ex)
            {
                LoggingService.Log("Error checking domain: " + ex.Message);
                return -1;
            }
        }
    }
}