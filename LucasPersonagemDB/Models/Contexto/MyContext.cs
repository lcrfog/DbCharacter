using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LucasPersonagemDB.Models.Contexto
{
    public class MyContext : DbContext
    {
        public MyContext() : base("strConn")
        {
            
        }

        public System.Data.Entity.DbSet<LucasPersonagemDB.Models.Personagem> Personagems { get; set; }
    }
}