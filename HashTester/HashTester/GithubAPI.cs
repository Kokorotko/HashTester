using Newtonsoft.Json.Linq;
using System;
using System.Drawing.Printing;
using System.Net.Http;
using System.Threading.Tasks;

namespace HashTester
{
    internal class GithubAPI
    {
        public async Task<string> GetVersion()
        {
            string url = "https://api.github.com/repos/Kokorotko/HashTester/releases/latest";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "HashTester"); // GitHub requires a User-Agent

                string json = await client.GetStringAsync(url); //get API
                JObject release = JObject.Parse(json); //convert API
                string latestRelease = release["tag_name"]?.ToString();
                latestRelease = latestRelease.Substring(1); //remove the version (v1.0.0 ==> 1.0.0)
                return latestRelease;
            }
        }

        public static bool CheckGithubAPITime()
        {
            DateTime temp = Settings.GithubRequestAPI;
            if (temp.AddHours(12) <= DateTime.Now) return true;
            else return false;
        }
    }
}
