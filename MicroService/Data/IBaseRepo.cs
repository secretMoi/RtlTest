using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Models;

namespace MicroService.Data
{
	public interface IBaseRepo<out T>
	{
		RtlContext Context { get; }
		bool SaveChanges();
		Task<Test> GetByIdAsync(int id);
	}
}
