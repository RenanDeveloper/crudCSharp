using System;


namespace CRUD
{
    internal class Fisico : Produto, ICloneable , IProduto
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