using CSharpPLINQ.Utilities;
using CSharpPLINQ.DataAccess;

namespace CSharpPLINQ.Examples
{
    public class Z_ExampleBase
    {
        protected static DataAccessManager DataManager = new DataAccessManager();
        protected static PrintUtility PrintManager = new PrintUtility();
    }
}
