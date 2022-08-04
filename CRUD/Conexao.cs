using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace CRUD
{
    public class Conexao
    {
        private IDbConnection con;
        private NpgsqlCommand comando;
        private NpgsqlDataReader leitorDados;
        public Conexao(IDbConnection conn)
        {
            con = conn;
            comando = new NpgsqlCommand();
            comando.Connection = con as NpgsqlConnection;
        }

        public IDbConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                    Console.WriteLine("Conexao com banco ocorreu com sucesso!");
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    con.Close();
                    Console.WriteLine("Conexao com banco finalizou com sucesso!");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Não foi desconectar o banco de dados, erro: " + e);

                }
            }
        }

        public NpgsqlDataReader setQuery(String Comando)
        {
            if (con.State != System.Data.ConnectionState.Open)
            { 
                con.Open();
            }
            if (leitorDados != null)
            { 
                leitorDados.Close();
            }
            comando.CommandText = Comando;
            leitorDados = comando.ExecuteReader();
            return leitorDados;
        }

        public void insertProduto(IProduto produto)
        {
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            if (produto.Tipo == "Físico")
            {
                setQuery("INSERT into tb_fisicos (fis_nome, fis_categoria, fis_preco, fis_codbarras, fis_tipo) VALUES ('" + produto.Nome + "', '" + produto.Categoria + "', '" + produto.Preco + "', '" + ((Fisico)produto).CodBarras + "', 'Físico')");
            }else if(produto.Tipo == "Digital")
            {
                setQuery("INSERT into tb_digital (dig_nome, dig_categoria, dig_preco, dig_email, dig_password, dig_tipo) VALUES ('" + produto.Nome + "', '" + produto.Categoria + "', '" + produto.Preco + "', '" + ((Digital)produto).Login + "', '" + ((Digital)produto).Password + "', 'Digital')");

            }
            else
            {
                Console.WriteLine("Não foi possível inserir o produto pois ele não é de um Tipo conhecido");
            }
        }

        public List<IProduto> BuscaDadosDoBanco()
        {

            List<IProduto> minhaLista = new List<IProduto>();
            try
            {
                conectar();
                setQuery("SELECT * FROM tb_fisicos");
                while (leitorDados.Read())
                {
                    minhaLista.Add(new Fisico()
                    {
                        Nome = leitorDados.GetString(1),
                        Categoria = leitorDados.GetString(2),
                        Preco = leitorDados.GetString(3),
                        CodBarras = leitorDados.GetString(4)
                    });
                }
                if(leitorDados != null) { 
                    leitorDados.Close();
                }

                setQuery("SELECT * FROM tb_digital");
                while (leitorDados.Read())
                {
                    minhaLista.Add(new Digital()
                    {
                        Nome = leitorDados.GetString(1),
                        Categoria = leitorDados.GetString(2),
                        Preco = leitorDados.GetString(3),
                        Login = leitorDados.GetString(4),
                        Password = leitorDados.GetString(5)
                    });
                }

                return minhaLista;
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível ler do banco e adicionar a lista, erro: " + e);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void alterarProduto(IProduto produtoSelecionado, String chave)
        {
            if (produtoSelecionado.Tipo == "Físico")
            {
                try
                {
                    String n = "UPDATE tb_fisicos SET fis_nome = '" + produtoSelecionado.Nome + "', fis_categoria = '" + produtoSelecionado.Categoria + "', fis_preco = '" + produtoSelecionado.Preco + "', fis_codbarras = '" + ((Fisico)produtoSelecionado).CodBarras + "' WHERE fis_nome = '" + chave + "'";
                    setQuery(n);
                    Console.WriteLine("Alterado com sucesso!.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Não foi possível alterar o Produto, erro: " + e);
                }
            }
            else if (produtoSelecionado.Tipo == "Digital")
            {
                try
                {
                    String n = "UPDATE tb_digital SET dig_nome = '" + produtoSelecionado.Nome + "', dig_categoria = '" + produtoSelecionado.Categoria + "', dig_preco = '" + produtoSelecionado.Preco + "', dig_email = '" + ((Digital)produtoSelecionado).Login + "', dig_password = '" + ((Digital)produtoSelecionado).Password + "' WHERE dig_nome = '" + chave + "'";

                    setQuery(n);
                    Console.WriteLine("Alterado com sucesso!.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Não foi possível alterar o Produto, erro: " + e);
                }
            }
        }

        public void deletarProduto(IProduto produtoSelecionado)
        {
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            if(produtoSelecionado.Tipo == "Físico") { 
                try
                {
                    String n = "DELETE FROM tb_fisicos WHERE fis_nome = '" + produtoSelecionado.Nome + "'";
                    setQuery(n);
                    Console.WriteLine("Apagado com sucesso!.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Não foi possível apagar o Produto, erro: " + e);
                }
            }else if(produtoSelecionado.Tipo == "Digital")
            {
                try
                {
                    String n = "DELETE FROM tb_digital WHERE dig_nome = '" + produtoSelecionado.Nome + "'";
                    setQuery(n);
                    Console.WriteLine("Apagado com sucesso!.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Não foi possível apagar o Produto, erro: " + e);
                }
            }
        }

        //public void listarDados()
        //{
        //    if(leitorDados != null && con.State == System.Data.ConnectionState.Open) {
        //        Console.WriteLine("Listando dados da tabela:");
        //        while (leitorDados.Read())
        //        {
        //            Console.WriteLine(leitorDados.GetInt32(0) + " - " + leitorDados.GetString(1) + " - " + leitorDados.GetString(2));
        //            //Console.WriteLine(leitorDados["fis_nome"] + " - " + leitorDados["fis_categoria"]);
        //        }
        //        Console.WriteLine("Fim da listagem!");
        //        leitorDados.Close();
        //        con.Dispose();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Use o método setQuery, depois executarQuery, só então use o listarDados.");
        //    }
        //}
    }
}
