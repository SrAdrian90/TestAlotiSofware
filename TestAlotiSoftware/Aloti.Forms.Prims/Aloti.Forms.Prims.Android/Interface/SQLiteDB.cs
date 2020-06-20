
using Aloti.Forms.Prims.Droid.Interface;
using Aloti.Forms.Prims.Interfaces;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDB))]
namespace Aloti.Forms.Prims.Droid.Interface
{
    public class SQLiteDB : ISQLite
    {

        public SQLiteAsyncConnection GetConnection()
        {
            string documentspatch = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);

            string patch = Path.Combine(documentspatch, "Database.db3");

            return new SQLiteAsyncConnection(patch);

        }
    }
}