using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dm8Compilers
{
    public class Dm8QueryFactory : QueryFactory
    {
        public Dm8QueryFactory(IDbConnection connection, Compiler compiler)
            : base(connection, compiler)
        { }
    }
}
