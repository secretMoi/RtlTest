using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestApiClient.Controllers.Service
{
	public class ServiceController : BaseController, IServiceController
	{
		public ServiceController()
		{
			Url = "service";
		}

		/// <summary>
		/// Dialogue avec le service et renvoie la string indiquée par le service
		/// </summary>
		/// <returns>La string du service</returns>
		public async Task<string> GetString()
		{
			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await RestApiBase.ApiClient.GetAsync(MakeUrl()))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					string data = await response.Content.ReadAsAsync<string>();

					return data;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}
	}
}
