using System.Threading.Tasks;

namespace RestApiClient.Controllers.Service
{
	public interface IServiceController
	{
		Task<string> GetString();
	}
}
