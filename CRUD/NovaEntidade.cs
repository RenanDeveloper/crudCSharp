using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD
{
    internal static class NovaEntidade
    {
        public static IProduto criaNovoProduto(string prod)
        {
            if(prod == "Digital")
            {
                return new Digital();
            }else if(prod == "Físico"){
                return new Fisico();
            }
            return null;
        }

        public static Window criaNovaTela(string prod)
        {
            if (prod == "Digital")
            {
                return new CadastroProdutoDigital();
            }
            else if (prod == "Físico")
            {
                return new CadastroProduto();
            }
            return null;
        }
    }
}
