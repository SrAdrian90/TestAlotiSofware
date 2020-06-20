using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aloti.Forms.Prims.Interfaces
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
