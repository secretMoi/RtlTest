using System.Threading.Tasks;
using Models.Dtos;

namespace RestApiClient.Controllers.TestDb
{
	public interface ITestDbController
	{
		Task<T> GetByIdAsync<T>(int id) where T : IReadDto;
		Task<int> CountAsync();

		int CurrentId { get; }
		void ResetCurrentId();
	}
}
