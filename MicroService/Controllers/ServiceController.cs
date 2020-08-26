using Microsoft.AspNetCore.Mvc;

namespace MicroService.Controllers
{
	[Route("api/service")] // permet de renommer la classe sans que les clients ne soient impactés et de donenr un préfix
	[ApiController] // indique que cette classe est un controller api
	public class ServiceController : ControllerBase
	{
		// GET api/service
		/// <summary>
		/// Récupère une string de test
		/// </summary>
		/// <returns>Renvoie un string encapsulé dans le status 200</returns>
		[HttpGet] // indique que cette méthode répond à une requete http
		public ActionResult<string> GetString()
		{
			return Ok("Recu 5/5 Roger !");
		}
	}
}
