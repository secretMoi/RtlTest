using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace MicroService.Data.Tests
{
	public class TestRepo : ITestRepo
	{
		private readonly RtlContext _context;

		public RtlContext Context => _context;

		public TestRepo(RtlContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Sauvegarde les changements faits dans la bdd
		/// </summary>
		/// <returns>Renvoie le nombre d'enregistrements dans la table encapsulé dans le status 200 OK</returns>
		public bool SaveChanges()
		{
			// permet d'appliquer les modifications à la db
			return _context.SaveChanges() >= 0;
		}

		/// <summary>
		/// Récupère un enregistrement via son id
		/// </summary>
		/// <param name="id">Id de l'enregisterment</param>
		/// <returns>Renvoie l'objet test</returns>
		public async Task<Test> GetByIdAsync(int id)
		{
			// retourne le premier dont l'id correspond
			return await _context.Tests.FirstOrDefaultAsync(p => p.Id == id);
		}

		/// <summary>
		/// Compte le nombre d'enregistrements
		/// </summary>
		/// <returns>Renvoie le nombre d'enregistrements</returns>
		public async Task<int> CountAsync()
		{
			return await _context.Tests.CountAsync(); // retourne la liste des commandes
		}
	}
}
