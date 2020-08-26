using System;
using System.Threading.Tasks;
using Models.Dtos.Tests;
using RestApiClient;
using RestApiClient.Controllers.Service;
using RestApiClient.Controllers.TestDb;

namespace Client
{
	public class Controller
	{
		private readonly ITestDbController _dbController = new TestDbController();
		private readonly IServiceController _serviceController = new ServiceController();

		public Controller()
		{
			try
			{
				RestApiBase.InitializeClient("http://localhost:5000/api/"); // init la connexion au serveur
			}
			catch
			{
				throw new Exception("Impossible de contacter le serveur");
			}
		}

		/// <summary>
		/// Récupère un test grâce à son id
		/// </summary>
		/// <returns>Renvoie le texte contenu dans la bdd</returns>
		public async Task<string> CallDbAsync()
		{
			//bug problème si il y a des trous entre les enregistrements
			try
			{
				string result = (await _dbController.GetByIdAsync<TestReadDto>(_dbController.CurrentId)).Text; // récupère le prochain enregistrement

				int recordsCount = await _dbController.CountAsync();
				if (_dbController.CurrentId > recordsCount
				) // si on a dépassé le nombre d'enregistrements on reset le nombre
					_dbController.ResetCurrentId();

				return result;
			}
			catch(Exception e)
			{
				throw new Exception("Erreur : " + e.Message);
			}
		}

		/// <summary>
		/// Récupère le texte renvoyé par le service
		/// </summary>
		/// <returns>Retourne le texte</returns>
		public async Task<string> CallServiceAsync()
		{
			try
			{
				return await _serviceController.GetString();
			}
			catch (Exception e)
			{
				throw new Exception("Erreur : " + e.Message);
			}
		}
	}
}
