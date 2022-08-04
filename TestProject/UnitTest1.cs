using CRUD;
using Moq;
using System.Data;

namespace TestProject
{
    public class Tests
    {
        private Mock<IDbConnection> _connection;
        private Conexao db;
        [SetUp]
        public void Setup()
        {
            _connection = new Mock<IDbConnection>();
            db = new Conexao(_connection.Object);

        }

        [Test]
        public void TestaFalhaOpen()
        {
            string messageError = "Falhou tudo";
            _connection.Setup(metodos => metodos.Open()).Throws(new Exception(messageError));

            Exception ex = Assert.Throws<Exception>(() => db.conectar());
            Assert.IsTrue(ex.Message == messageError);

        }
    }
}