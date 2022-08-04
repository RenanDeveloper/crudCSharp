using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class Digital : Produto , ICloneable, IProduto
    {
        private string login;
        private string password;

        public Digital()
        {
            this.Nome = Nome;
            this.Categoria = Categoria;
            this.Preco = Preco;
            this.Tipo = "Digital";

        }

        public Digital(Digital d)
        {
            this.Nome = d.Nome;
            this.Categoria = d.Categoria;
            this.Preco = d.Preco;
            this.Login = d.Login;
            this.Password = d.Password;
            this.Tipo = "Digital";
        }

        public string Login
        {
            get { return login; }
            set { login = value; Notifica("Login"); }
        }
        public string Password
        {
            get { return password; }
            set { password = value; Notifica("Password"); }
        }
        public string Tipo { get; set; }


        public object Clone()
        {
            return new Digital(this);
        }
    }
}
