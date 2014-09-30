    using System.Data.SQLite;
    
    public class mLocalDB
    {
        #region Singlton

        private static readonly mLocalDB _instance = new mLocalDB();

        protected mLocalDB()
        {
            IsBaseOpen = false;
        }

        ~mLocalDB()
        {
            if (IsBaseOpen)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public static mLocalDB Instance
        {
            get { return _instance; }
        }

        #endregion

        private SQLiteConnection connection;

        public bool IsBaseOpen { get; private set; }

        public bool SetConnection(string baseName)
        {
            if (IsBaseOpen)
            {
                connection.Close();
                connection.Dispose();
            }

            connection = new SQLiteConnection();
            connection.ConnectionString = String.Format("Data Source={0}", baseName);

            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                IsBaseOpen = false;
            }

            IsBaseOpen = true;
            return IsBaseOpen;
        }

        public DataTable GetDataTable(string sql)
        {
            if (!IsBaseOpen)
                return null;
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                SQLiteCommand mycommand = new SQLiteCommand(connection);
                mycommand.CommandText = sql;
                SQLiteDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dt;
        }

        public int ExecuteNonQuery(string sql)
        {
            if (!IsBaseOpen)
                return 0;
            connection.Open();
            SQLiteCommand mycommand = new SQLiteCommand(connection);
            mycommand.CommandText = sql;
            int rowsUpdated = mycommand.ExecuteNonQuery();
            connection.Close();
            return rowsUpdated;
        }

        public string ExecuteScalar(string sql)
        {
            if (!IsBaseOpen)
                return string.Empty;
            connection.Open();
            SQLiteCommand mycommand = new SQLiteCommand(connection);
            mycommand.CommandText = sql;
            object rowsSelected = mycommand.ExecuteScalar();
            connection.Close();
            return rowsSelected == null ? "" : rowsSelected.ToString();
        }
    }
