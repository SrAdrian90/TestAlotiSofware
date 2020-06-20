using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Aloti.Forms.Prims.Storage
{
    public class DBContext
    {
        public static object Lock = new object();

        public string DBFileName { get; private set; }

        public SQLiteConnection _SQLiteConnection { get; set; }

        [ThreadStatic]
        private static Dictionary<string, DBContext> _contexts = new Dictionary<string, DBContext>();

        private static readonly Dictionary<string, DBContextCfg> Cfgs = new Dictionary<string, DBContextCfg>();

        public DBContext(string dbName, List<Type> types)
        {
            _SQLiteConnection = new SQLiteConnection(dbName);
            try
            {
                lock (Lock)
                {
                    foreach (Type type in types)
                    {
                        _SQLiteConnection.CreateTable(type);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DBContext constructor: " + ex.Message);
            }

        }

        private class DBContextCfg
        {
            public string DBName { get; set; }

            public List<Type> Types { get; set; }

            public DBContextCfg() { }
        }

        public delegate void AddTypesDelegateHandler(List<Type> types);

        public static string DBPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);

        public static void Add(string dbName, List<Type> types)
        {
            dbName = Path.Combine(DBPath, dbName);
            Cfgs[dbName] = new DBContextCfg { DBName = dbName, Types = types };
        }

        public static DBContext Get(string dbName)
        {
            if (_contexts == null)
            {
                _contexts = new Dictionary<string, DBContext>();
            }
            if (!_contexts.ContainsKey(dbName))
            {
                DBContextCfg cfg = Cfgs[dbName];
                _contexts[dbName] = new DBContext(dbName, cfg.Types)
                {
                    DBFileName = dbName
                };
            }
            return _contexts[dbName];
        }

        public static DBContext Get(Type entityType)
        {
            string dbName = null;
            foreach (DBContextCfg cfg in Cfgs.Values)
            {
                if (cfg.Types.Contains(entityType))
                {
                    dbName = cfg.DBName;
                    break;
                }
            }

            if (dbName == null)
            {
                throw new Exception("That entity type isn't in any db");
            }
            return Get(dbName);
        }

        public static DBContext Get()
        {
            Dictionary<string, DBContextCfg>.ValueCollection.Enumerator enumerator = Cfgs.Values.GetEnumerator();
            enumerator.MoveNext();
            string dbName = enumerator.Current.DBName;
            return Get(dbName);
        }


        public void Delete(object entity)
        {
            lock (Lock)
            {
                _SQLiteConnection.Delete(entity);
            }
        }

        public void Delete<T>(object id)
        {
            lock (Lock)
            {
                _SQLiteConnection.Delete<T>(id);
            }
        }

        public T Find<T>(object id) where T : class, new()
        {
            lock (Lock)
            {
                T obj = _SQLiteConnection.Find<T>(id);
                return obj;
            }
        }

        public void InsertOrReplace(object obj)
        {
            lock (Lock)
            {
                _SQLiteConnection.InsertOrReplace(obj);
            }
        }

        public List<T> ToList<T>(TableQuery<T> query)
        {
            lock (Lock)
            {
                return query.ToList();
            }
        }

        public List<T> Query<T>(string query, object[] args) where T : class, new()
        {
            lock (Lock)
            {
                return _SQLiteConnection.Query<T>(query, args);
            }
        }

        public int Insert(object obj)
        {
            lock (Lock)
            {
                return _SQLiteConnection.Insert(obj);
            }
        }

        public void Update(object obj)
        {
            lock (Lock)
            {
                _SQLiteConnection.Update(obj);
            }
        }


    }
}

