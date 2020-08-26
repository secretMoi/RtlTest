using System.Threading.Tasks;
using AutoMapper;
using MicroService.Data.Tests;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.Tests;
using Models.Models;

namespace MicroService.Controllers
{
	[Route("api/testsDb")] // permet de renommer la classe sans que les clients ne soient impactés et de donenr un préfix
	[ApiController] // indique que cette classe est un controller api
	public class TestsController : ControllerBase
	{
		private readonly ITestRepo _repository; // repo sur lequel le controller va travailler
		private readonly IMapper _mapper;

		public TestsController(ITestRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		// GET api/testsDb/count
		/// <summary>
		/// Récupère tous les enregistrements des tests sous format JSON
		/// </summary>
		/// <returns>Renvoie le nombre d'enregistrements dans la table encapsulé dans le status 200 OK</returns>
		[HttpGet("count")] // indique que cette méthode répond à une requete http
		public async Task<ActionResult<int>> Count()
		{
			int number = await _repository.CountAsync();

			return Ok(number); // méthode Ok définie dans controllerBase
		}

		// GET api/testsDb/5
		// GET api/testsDb/{id}
		/// <summary>
		/// Récupère un test via son id sous format JSON
		/// </summary>
		/// <param name="idTest">Id du test</param>
		/// <returns>Renvoie un test encapsulé dans le status 200 OK<br />
		/// Renvoie le status NotFound 404 si le test n'est pas trouvé</returns>
		[HttpGet("{idTest:int}")] // indique que cette méthode répond à une requete http
		public async Task<ActionResult<TestReadDto>> GetTestById(int idTest)
		{
			Test test = await _repository.GetByIdAsync(idTest);

			if (test != null)
				return Ok(_mapper.Map<TestReadDto>(test));

			return NotFound(); // si pas trouvé renvoie 404 not found
		}
	}
}
