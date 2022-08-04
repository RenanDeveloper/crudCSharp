using System;


namespace CRUD
{
    public class Fisico : Produto, ICloneable , IProduto
    {
        private string codBarras;
        public Fisico()
        {

            this.Tipo = "Físico";
        }

        public Fisico(Fisico f)
        {
            this.Nome = f.Nome;
            this.Categoria = f.Categoria;
            this.Preco = f.Preco;
            this.codBarras = f.codBarras;
            this.Tipo = "Físico";
        }

        public Fisico(string Nome, string Categoria, string Preco, string codBarras)
        {
            this.Nome = Nome;
            this.Categoria = Categoria;
            this.Preco = Preco;
            this.codBarras = codBarras;
            this.Tipo = "Físico";
        }

        public string CodBarras
        {
            get { return codBarras; }
            set { codBarras = value; Notifica("CodBarras"); }
        }

        public string Tipo { get ; set; }

        public object Clone()
        {
            return new Fisico(this);
        }
    }
}