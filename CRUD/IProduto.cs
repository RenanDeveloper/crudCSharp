using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public interface IProduto
    {
        string Nome { get; set; }
        string Categoria { get; set; }
        string Preco { get; set; }
        string Tipo { get; set; }

    }
}
