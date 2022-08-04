using CRUD;
using Npgsql;

namespace TestProject
{
    public class IntegrationTest
    {
        private Conexao db;
        private NpgsqlDataReader dr;
        [SetUp]
        public void Setup()
        {
            db = new Conexao(new NpgsqlConnection(@"Server=localhost;Port=5433;User Id=postgres;Password=senha1234;Database=crud"));
        }

        [Test]
        public void TestaInsereDeleteSelectProdutoPostgres()
        {
            Fisico prod = new Fisico("Fisico_Teste", "Fisico_Cad_Teste", "123", "324940");

            db.insertProduto(prod);

            dr = db.setQuery($"select * from tb_fisicos " +
                $"where fis_nome = '{prod.Nome}' " +
                $"and fis_categoria = '{prod.Categoria}' " +
                $"and fis_preco = '{prod.Preco}' " +
                $"and fis_codbarras = '{prod.CodBarras}';");

            Assert.IsTrue(dr.Read());

            db.deletarProduto(prod);

            dr = db.setQuery($"select * from tb_fisicos " +
                $"where fis_nome = '{prod.Nome}' " +
                $"and fis_categoria = '{prod.Categoria}' " +
                $"and fis_preco = '{prod.Preco}' " +
                $"and fis_codbarras = '{prod.CodBarras}';");

            Assert.IsFalse(dr.Read());
        }
    }
}