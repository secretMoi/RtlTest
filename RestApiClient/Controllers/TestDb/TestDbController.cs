using System.Threading.Tasks;

namespace RestApiClient.Controllers.TestDb
{
	public class TestDbController : BaseController, ITestDbController
	{
		private int _currentId = 1;

		public int CurrentId => _currentId;

		/// <summary>
		/// Reset l'id courant à son état d'origine
		/// </summary>
		public void ResetCurrentId()
		{
			_currentId = 1;
		}

		public TestDbController()
		{
			Url = "testsDb";

			FillBaseMethods(
				BaseMethod.GetId,
				BaseMethod.Count
			);
		}

		/// <summary>
		/// Récupère une enregistrement via son id ET incrémente la position
		/// </summary>
		/// <param name="id">Id de l'enregistrement</param>
		public override async Task<T> GetByIdAsync<T>(int id)
		{
			T result = await base.GetByIdAsync<T>(id);

			_currentId++;

			return result;
		}
	}
}
