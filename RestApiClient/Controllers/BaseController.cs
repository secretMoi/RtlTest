using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models.Dtos;
using Newtonsoft.Json;

namespace RestApiClient.Controllers
{
	public class BaseController
	{
		protected string Url;
		protected List<BaseMethod> BaseMethods;

		protected enum BaseMethod
		{
			GetAll,
			GetId,
			Count
		}

		public BaseController()
		{
			BaseMethods = new List<BaseMethod>();
		}

		/// <summary>
		/// Permet aux classes enfants de s'autoriser certaines méthodes parentes
		/// </summary>
		/// <param name="methods">Liste des méthodes à autoriser</param>
		protected void FillBaseMethods(params BaseMethod[] methods)
		{
			foreach (BaseMethod method in methods)
				BaseMethods.Add(method);
		}

		/// <summary>
		/// Sérialise un objet en JSON
		/// </summary>
		/// <param name="dto">Objet à sérialiser</param>
		/// <returns>Une string au format JSON</returns>
		protected StringContent SerializeAsJson<T>(T dto)
		{
			string json = JsonConvert.SerializeObject(dto);
			return new StringContent(json, Encoding.UTF8, "application/json");
		}

		/// <summary>
		/// Formatte l'URL où appeler le serveur
		/// </summary>
		/// <param name="suffix">Contenu à rajouter à l'url de base</param>
		/// <returns>L'URL finale</returns>
		protected string MakeUrl(params object[] suffix)
		{
			StringBuilder url = new StringBuilder(Url);

			foreach (object element in suffix)
				url.Append("/" + element);

			return url.ToString();
		}

		/// <summary>
		/// Demande un élément au serveur via un id
		/// </summary>
		/// <param name="id">Id à demander</param>
		/// <returns>Retourne l'élément dans le type demandé</returns>
		public virtual async Task<T> GetByIdAsync<T>(int id) where T : IReadDto
		{
			if (!BaseMethods.Contains(BaseMethod.GetId)) return default;

			string url = MakeUrl(id);

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await RestApiBase.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					T data = await response.Content.ReadAsAsync<T>();

					return data;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}

		/// <summary>
		/// Demande un nombre éléments au serveur
		/// </summary>
		/// <returns>Retourne le nombre d'élément</returns>
		public virtual async Task<int> CountAsync()
		{
			if (!BaseMethods.Contains(BaseMethod.Count)) return -1;

			string url = MakeUrl("count");

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await RestApiBase.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					int number = await response.Content.ReadAsAsync<int>();

					return number;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}

		public virtual async Task<IList<T>> GetAll<T>() where T : IReadDto
		{
			if (!BaseMethods.Contains(BaseMethod.GetAll)) return default;

			string url = MakeUrl();

			// fais une req sur l'url et attend la réponse
			using (HttpResponseMessage response = await RestApiBase.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// map le json lu dans la req http dans le model
					IList<T> data = await response.Content.ReadAsAsync<IList<T>>();

					return data;
				}
				else
					throw new Exception(response.ReasonPhrase);
			}
		}
	}
}
