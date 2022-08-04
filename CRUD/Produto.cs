using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Produto : Observer
    {
        private string nome;
        private string categoria;
        private string preco;

        public Produto()
        {

        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; Notifica("Nome"); }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; Notifica("Categoria"); }
        }

        public string Preco
        {
            get { return preco; }
            set { preco = value; Notifica("Preco"); }
        }
    }
    public enum Enumeravel
    {
        Todos = 0,
        Físico = 1,
        Digital = 2
    }

}