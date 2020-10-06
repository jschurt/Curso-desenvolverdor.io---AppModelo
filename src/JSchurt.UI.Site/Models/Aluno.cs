using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSchurt.UI.Site.Models
{
    public class Aluno
    {

        public Guid AlunoId { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

    } //class
} //namespace
