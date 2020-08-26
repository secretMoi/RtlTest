using System.Threading.Tasks;
using Models.Models;

namespace MicroService.Data.Tests
{
	public interface ITestRepo : IBaseRepo<Test>
	{
		Task<int> CountAsync();
	}
}
