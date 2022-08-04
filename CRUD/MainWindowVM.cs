using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace CRUD
{
    public class MainWindowVM : Observer
    {
        private Enumeravel produtoEnumeravel;

        public List<IProduto> listaProdutos { get; set; }
        public ICommand Criar { get; private set; }
        public ICommand Adicionar { get; private set; }
        public ICommand Remove { get; private set; }
        public ICommand Alterar { get; private set; }
        public ICommand EditarProduto { get; set; }
        public IProduto produtoSelecionado { get; set; }

        public MainWindowVM()
        {
            Conexao con = new Conexao();
            List<IProduto> minhaLista = con.dadosDoBanco();
            
            if(minhaLista != null) {
                listaProdutos = new List<IProduto>(minhaLista);
            }

            //listaProdutos = new ObservableCollection<IProduto>()
            //{
            //    new Fisico()
            //    {
            //        Nome = "Mouse USB",
            //        Categoria = "Informática",
            //        Preco = "25",
            //        CodBarras = "76237623",
            //        Tipo = "Físico"
            //    },

            //    new Digital()
            //    {
            //        Nome = "Curso Online",
            //        Categoria = "Educação",
            //        Preco = "179",
            //        Login = "nome@email.com",
            //        Password = "senhacurso123",
            //        Tipo = "Digital"
            //    }
            //};

            IniciarComandos();
        }
        public Enumeravel ProdutoEnumeravel {
            get => produtoEnumeravel;
            set
            {
                produtoEnumeravel = value;
                Notifica("listaLinkada");
            }
        } 

        public IEnumerable<IProduto> listaLinkada { 
            get {
                string tipoProd = ProdutoEnumeravel.ToString();
                if (tipoProd == "Todos") return listaProdutos;

                return listaProdutos.Where(item => item.Tipo == tipoProd);
            } 
        }

        public void IniciarComandos()
        {

            Adicionar = new RelayCommand((object _) =>
            {
                string tipoProd = ProdutoEnumeravel.ToString();
                IProduto elemento = NovaEntidade.criaNovoProduto(tipoProd);
                Window tela = NovaEntidade.criaNovaTela(tipoProd);
                tela.DataContext = elemento;
                tela.ShowDialog();
                if (tela.DialogResult == true)
                {
                    Conexao con = new Conexao();
                    con.insertProduto(elemento);

                    listaProdutos.Add(elemento);

                }
            },(object _) => ProdutoEnumeravel.ToString() != "Todos");

            Remove = new RelayCommand((object _) =>
            {
                Conexao con = new Conexao();
                if (produtoSelecionado != null) { 
                    con.deletarProduto(produtoSelecionado);
                    listaProdutos.Remove(produtoSelecionado);   
                }
            }, (object _) => produtoSelecionado != null);

            
            Alterar = new RelayCommand((object _) =>
            {
                if (produtoSelecionado != null)
                {
                    Conexao con = new Conexao();

                    if (produtoSelecionado.Tipo == "Físico")
                    {
                        Fisico produtoFisico = produtoSelecionado as Fisico;
                        if (produtoFisico != null)
                        {
                            Fisico nova = (Fisico)produtoFisico.Clone();
                            CadastroProduto form = new CadastroProduto();
                            form.DataContext = nova;
                            form.ShowDialog();
                            if (form.DialogResult == true)
                            {
                                String chave = produtoFisico.Nome;

                                produtoFisico.Nome = nova.Nome;
                                produtoFisico.Categoria = nova.Categoria;
                                produtoFisico.Preco = nova.Preco;
                                produtoFisico.CodBarras = nova.CodBarras;
                                
                                con.alterarProduto(produtoFisico, chave);
                            }
                        }
                    }
                    else
                    {
                        Digital produtoDigital = produtoSelecionado as Digital;
                        if (produtoDigital != null)
                        {
                            Digital nova = (Digital)produtoDigital.Clone();
                            CadastroProdutoDigital form = new CadastroProdutoDigital();
                            form.DataContext = nova;
                            form.ShowDialog();
                            if (form.DialogResult == true)
                            {
                                String chave = produtoDigital.Nome;

                                produtoDigital.Nome = nova.Nome;
                                produtoDigital.Categoria = nova.Categoria;
                                produtoDigital.Preco = nova.Preco;
                                produtoDigital.Login = nova.Login;
                                produtoDigital.Password = nova.Password;

                                con.alterarProduto(produtoDigital, chave);

                            }
                        }
                    }
                }
            },(object _) => produtoSelecionado != null );
        }
    }
}