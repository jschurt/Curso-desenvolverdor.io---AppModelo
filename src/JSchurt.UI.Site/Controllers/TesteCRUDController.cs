using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSchurt.UI.Site.Data;
using JSchurt.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JSchurt.UI.Site.Controllers
{
    public class TesteCRUDController : Controller
    {

        private readonly MeuDbContext _context;

        public TesteCRUDController(MeuDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult Index()
        {

            var aluno = new Aluno
            {
                Nome = "Julio",
                Email = "julio@teste.com",
                DataNascimento = DateTime.Now
            };


            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            var alunos2 = _context.Alunos.Find(aluno.AlunoId);
            var aluno3 = _context.Alunos.FirstOrDefault(a => a.Email == "julio@teste");
            var aluno4 = _context.Alunos.Where(a => a.Nome == "Julio");

            aluno.Nome = "Pedro";
            _context.Alunos.Update(aluno);
            _context.SaveChanges();

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

            return View();
        }
    }
}
