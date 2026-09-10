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
            c.DefaultRequestHeaders.Add("User-Agent", "Kenan.bio/DomainHunter");
            c.DefaultRequestHeaders.Add("Accept", "application/rdap+json, application/json");
            return c;
        }

        public static async Task<int> CheckDomainAsync(string domain)
        {
            try
            {
                string url;
                string tld = domain.Split('.').Last().ToLower();

                if (tld == "io") // .io
                {
                    url = $"https://rdap.identitydigital.services/rdap/domain/{domain}";
                }
                else if (tld == "dev" || tld == "app") // .dev and .app
                {
                    url = $"https://pubapi.registry.google/rdap/domain/{domain}";
                }
                else if (tld == "ai") // .ai
                {
                    url = $"https://rdap.identitydigital.services/rdap/domain/{domain}";
                }
                else if (tld == "com") // .com
                {
                    url = $"https://rdap.verisign.com/com/v1/domain/{domain}";
                }
                else if (tld == "net") // .net
                {
                    url = $"https://rdap.verisign.com/net/v1/domain/{domain}";
                }
                else if (tld == "org") // .org
                {
                    //url = $"https://rdap.publicinterestregistry.org/rdap/domain/{domain}"; rate limit to much
                    url = $"https://rdap.org/domain/{domain}";
                }
                else if (tld == "gov") // .gov
                {
                    //url = $"https://rdap.nic.gov/rdap/domain/{domain}"; rate limit to much
                    url = $"https://rdap.org/domain/{domain}";
                }
                else // others
                {
                    url = $"https://rdap.org/domain/{domain}";
                }

                var response = await client.GetAsync(url);
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