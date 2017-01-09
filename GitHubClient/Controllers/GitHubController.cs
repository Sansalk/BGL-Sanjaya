using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GitHubClient.Controllers
{
    public class GitHubController : ApiController
    {
        private const string Address = "http://api.github.com/users/";

        /// <summary>
        /// Retrieve given users information. 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<string> Get(string userName)
        {
            var result = await GetGitHubResponse(Address + userName);
            return result;
        }

        /// <summary>
        /// Get repository information for the user.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetRepos(string url)
        {
            var result = await GetGitHubResponse(url);
            return result;
        }

        /// <summary>
        /// External API helper
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<string> GetGitHubResponse(string url)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "GitUserAgent"); //To fix the git hub api protocol violstion 
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
