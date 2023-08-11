using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dm8Compilers
{
    public static class QueryExtensions
    {
        public static int GetDMLimit(this Query query,string engineCode)
        {
            var limit = query.GetOneComponent<LimitClause>("limit", engineCode);

            return limit?.Limit ?? 0;
        }

        public static long GetDMOffset(this Query query,string engineCode)
        {
            var offset = query.GetOneComponent<OffsetClause>("offset", engineCode);

            return offset?.Offset ?? 0;
        }
    }
}
