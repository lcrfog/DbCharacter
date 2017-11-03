using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LucasPersonagemDB.Models
{
    public class Personagem
    {

        public enum Genero
        {
            Masculino, Feminino
        }

        public int PersonagemID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Genero Sexo { get; set; }
        public string Classe { get; set; }
        public string Raça { get; set; }
        public int Nivel { get; set; }

    }
}