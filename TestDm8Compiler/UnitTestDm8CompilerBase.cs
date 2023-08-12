using Dm;
using Dm8Compilers;
using SqlKata.Compilers;
using System.Data;
using System.Data.Common;

namespace TestDm8Compiler
{
    [TestClass]
    public class UnitTestDm8CompilerBase
    {
        public const string ConnectionString = "Server=127.0.0.1:5236;Database=PERSON;UserId=SYSDBA;Pwd=a1314521@";

        public Dm8QueryFactory CreateDefaultDm8QueryFactory()
        {
            var connection = new DmConnection(ConnectionString);
            connection.Schema = "PERSON";
            return new Dm8QueryFactory(
                new DmConnection(ConnectionString), new Dm8Compiler());
        }

        public DbConnection CreateDefaultDmConnection()
        {
            DmConnection dmConnection = new(ConnectionString);
            DbConnection connection = dmConnection;

            return connection;
        }
    }
}