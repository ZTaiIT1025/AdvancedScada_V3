
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DataAccessC.SQLite
{
    /// <summary>
    /// Wraps around a Sqlite database to provide core functionality,
    /// such as, create, open, close database etc...
    /// </summary>
    public class SQLiteDatabase
    {
        #region الحقول العامة

        public string _DBFileName = "batchs.db3";
        public static string ConnectionString = string.Format("Data Source={0};Version=3;", Application.StartupPath+ "\\Database\\batchs.db3");
        public static SQLiteConnection _Connection =new SQLiteConnection(ConnectionString);
        
        
        #endregion الحقول العامة
        #region الدوال


        //قراة البيانات 
        public DataTable SelectData(string Str, SQLiteParameter[] param)
        {
            SQLiteCommand sqlcmd = new SQLiteCommand()
            {
                CommandType = CommandType.Text,
                CommandText = Str,
                Connection = _Connection
            };

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);

                }
            }
            SQLiteDataAdapter da = new SQLiteDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //اجراء اضافة البيانات 
        public void ExecuteCommand(string Str, SQLiteParameter[] param)
        {
            SQLiteCommand sqlcmd = new SQLiteCommand()
            {
                CommandType = CommandType.Text,
                CommandText = Str,
                Connection = _Connection
            };
            sqlcmd.Parameters.AddRange(param);
            sqlcmd.ExecuteNonQuery();
        }

        public void FillCombo(ComboBox Combo, string Query, string DisplayMember, string ValueMember)
        {
            //On Error Resume Next
            DataTable dt = GetRecors(Query);
            Combo.DataSource = dt;
            Combo.DisplayMember = DisplayMember;
            Combo.ValueMember = ValueMember;

        }
        public DataTable GetRecors(string Query)
        {
            SQLiteConnection c = new SQLiteConnection(ConnectionString);
            SQLiteCommand cmd = new SQLiteCommand(Query, c);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt.Columns.Add("Error");
                dt.Rows.Add(ex.Message);
            }
            return dt;
        }
        #endregion
        #region Get_ID
        public int Get_IDBatch(string Tabel)
        {
            int x = 0;
            string Sql = "SELECT MAX(BatchID) FROM " + Tabel;

            SQLiteCommand cmd = new SQLiteCommand(Sql, _Connection);
            _Connection.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                object[] values = new object[reader.FieldCount];
                int fieldCount = reader.GetValues(values);
                for (int i = 0; i < fieldCount; i++)
                {
                    if (reader.IsDBNull(i))
                    {

                        x = 1;
                    }
                    else
                    {
                        x = Convert.ToInt32(reader.GetValue(i));

                    }
                    // x = reader.GetValue(0)

                }

            }
            reader.NextResult();
            reader.Close();
            _Connection.Close();

            return x;
        }
        #endregion
        #region تفاصيل التركيبة
        /// <summary>
        /// تفاصيل التركيبة
        /// </summary>
        /// <param name="BatchName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DataTable Get_BatchsDetails(string BatchName)
        {
            _Connection.Open();
            DataTable dt = new DataTable();
            const string selsct = "SELECT Batchs.BatchID, BatchsDetails.BatchID,BatchsDetails.TankName, BatchsDetails.MixWeight, BatchsDetails.LowWeight, BatchsDetails.FreeFallWeight, BatchsDetails.HighSpeed, BatchsDetails.LowSpeed, BatchsDetails.Orders, BatchsDetails.Working FROM Batchs INNER JOIN BatchsDetails ON Batchs.BatchID = BatchsDetails.BatchID  WHERE Batchs.BatchName=@BatchName";
            SQLiteCommand cmd = new SQLiteCommand(selsct, _Connection);
            cmd.Parameters.AddWithValue("@BatchName", BatchName);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            _Connection.Close();
            return dt;
        }
        public void Get_txt(ComboBox comBatchName, ComboBox comTankName, TextBox txt_MixWeight, TextBox txt_LowWeight, TextBox txt_FreeFallWeight, TextBox txt_HighSpeed, TextBox txt_LowSpeed, TextBox num_Orders, ComboBox com_Werking, int x)
        {


            DataTable dt1 = new DataTable();
            dt1 = GetRecors(string.Format("SELECT Batchs.BatchID, BatchsDetails.BatchID,BatchsDetails.TankName, BatchsDetails.MixWeight, BatchsDetails.LowWeight, BatchsDetails.FreeFallWeight, BatchsDetails.HighSpeed, BatchsDetails.LowSpeed, BatchsDetails.Orders, BatchsDetails.Working FROM Batchs INNER JOIN BatchsDetails ON Batchs.BatchID = BatchsDetails.BatchID  WHERE Batchs.BatchName='{0}'", comBatchName.Text));

            if (dt1.Rows.Count > 0)
            {
                comTankName.Text = dt1.Rows[x]["TankName"].ToString();
                txt_MixWeight.Text = dt1.Rows[x]["MixWeight"].ToString();
                txt_LowWeight.Text = dt1.Rows[x]["LowWeight"].ToString();
                txt_FreeFallWeight.Text = dt1.Rows[x]["FreeFallWeight"].ToString();
                txt_HighSpeed.Text = dt1.Rows[x]["HighSpeed"].ToString();
                txt_LowSpeed.Text = dt1.Rows[x]["LowSpeed"].ToString();
                num_Orders.Text = dt1.Rows[x]["Orders"].ToString();
                com_Werking.Text = dt1.Rows[x]["Working"].ToString();
            }


        }
        #endregion
        #region حذف
        public void del_BatchName(string BatchName)
        {
            _Connection.Open();
            const string SQL = "DELETE FROM [Batchs]WHERE BatchName=@BatchName";
            SQLiteParameter[] param = new SQLiteParameter[1];

            param[0] = new SQLiteParameter("@BatchName", BatchName);
             

            ExecuteCommand(SQL, param);
            _Connection.Close();
        }
        public void del_TankNames(string TankName)
        {
            _Connection.Open();
            const string SQL = "DELETE FROM [TankNames]WHERE TankName=@TankName";
            SQLiteParameter[] param = new SQLiteParameter[1];

            param[0] = new SQLiteParameter("@TankName", TankName);
            

            ExecuteCommand(SQL, param);
            _Connection.Close();
        }
        /// <summary>
        /// حذف جميع بيانات الخلاطات
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public DataTable DELETE_Batchs()
        {
            const string selsct = " DELETE * FROM  Batchs";
            DataTable DT = new DataTable();
            DT = SelectData(selsct, null);
            _Connection.Close();
            return DT;
        }
        /// <summary>
        /// حذف التقرير كل
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public DataTable DELETE_BatchFinal()
        {
            const string selsct1 = " DELETE * FROM  BatchFinal";
            DataTable DT = new DataTable();
            DT = SelectData(selsct1, null);
            const string selsct2 = " DELETE * FROM  NameTankFinal";

            DT = SelectData(selsct2, null);
            const string selsct3 = " DELETE * FROM  BatchWeight";

            DT = SelectData(selsct3, null);
            _Connection.Close();

            return DT;
        }
        #endregion
        #region اسماء التركيبة
        /// <summary>
        /// اجراء جلب اسماء الباتشات
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public DataTable GET_ALL_BatchName()
        {
            const string selsct = " SELECT * FROM  Batchs";
            DataTable DT = new DataTable();

            DT = SelectData(selsct, null);
            _Connection.Close();
            return DT;

        }

       
        #endregion
        #region اضافة خامة
        /// <summary>
        /// اضافة اسم الخامة
        /// </summary>
        /// <param name="TanksID"></param>
        /// <param name="TanksName"></param>
        /// <remarks></remarks>
        public static bool ADD_Tanks(int TanksID, string TanksName)
        {

            try
            {

                if (TanksName.Equals("")) return false;
                // Insert into Database
                string query = "INSERT INTO Tanks ('TanksID', 'TanksName')VALUES(@TanksID, @TanksName)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, _Connection))
                {
                    cmd.Parameters.AddWithValue("@TanksID", TanksID);
                    cmd.Parameters.AddWithValue("@TanksName", TanksName);
                    var result = cmd.ExecuteNonQuery();


                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region اضافة تركيبة وتعديلها
        /// <summary>
        /// اجراء مخزن لاضافة اسم الباتشة 
        /// </summary>
        /// <param name="BatchID"></param>
        /// <param name="BatchName"></param>
        /// <remarks></remarks>
        public static bool ADD_Batchs(int BatchID, string BatchName)
        {
            try
            {
                if (BatchName.Equals("")) return false;

                // Insert into Database
                string query = "INSERT INTO Batchs ('BatchID', 'BatchName')VALUES(@BatchID, @BatchName)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, _Connection))
                {
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID));
                    cmd.Parameters.AddWithValue("@BatchName", BatchName);
                    var result = cmd.ExecuteNonQuery();


                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// اضافة تفاصيل الباتشة
        /// </summary>
        /// <param name="BatchID"></param>
        /// <param name="TankID"></param>
        /// <param name="TankName"></param>
        /// <param name="MixWeight"></param>
        /// <param name="LowWeight"></param>
        /// <param name="FreeFallWeight"></param>
        /// <param name="HighSpeed"></param>
        /// <param name="LowSpeed"></param>
        /// <param name="Orders"></param>
        /// <param name="Working"></param>
        /// <remarks></remarks>
        public static bool ADD_Batchs_Details(int BatchID, int TankID, string TankName, int MixWeight, int LowWeight, int FreeFallWeight, int HighSpeed, int LowSpeed, int Orders, string Working)
        {
            try
            {
                if (TankName.Equals("")) return false;
                // Insert into Database
                string query = "INSERT INTO BatchsDetails ('BatchID', 'TankID', 'TankName', 'MixWeight', 'LowWeight'," +
                    " 'FreeFallWeight', 'HighSpeed', 'Orders', 'Working')VALUES(@BatchID, @TankID, @TankName, @MixWeight, @LowWeight, @FreeFallWeight, @HighSpeed, @Orders, @Working)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, _Connection))
                {
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID));
                    cmd.Parameters.AddWithValue("@TankID", TankID);
                    cmd.Parameters.AddWithValue("@TankName", TankName);
                    cmd.Parameters.AddWithValue("@MixWeight", MixWeight);
                    cmd.Parameters.AddWithValue("@LowWeight", LowWeight);
                    cmd.Parameters.AddWithValue("@FreeFallWeight", FreeFallWeight);
                    cmd.Parameters.AddWithValue("@HighSpeed", HighSpeed);
                    cmd.Parameters.AddWithValue("@Orders", Orders);
                    cmd.Parameters.AddWithValue("@Working", Working);
                    var result = cmd.ExecuteNonQuery();


                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// تحديث تفاصيل الباتشا
        /// </summary>
        /// <param name="BatchID"></param>
        /// <param name="TankID"></param>
        /// <param name="TankName"></param>
        /// <param name="MixWeight"></param>
        /// <param name="LowWeight"></param>
        /// <param name="FreeFallWeight"></param>
        /// <param name="HighSpeed"></param>
        /// <param name="LowSpeed"></param>
        /// <param name="Working"></param>
        /// <param name="Orders"></param>
        /// <remarks></remarks>
        public static bool UPDATE_Batchs_Details(int BatchID, int TankID, string TankName, int MixWeight, int LowWeight, int FreeFallWeight, int HighSpeed, int LowSpeed, string Working, int Orders)
        {
            try
            {
                const string query = "UPDATE BatchsDetails SET BatchID =@BatchID, TankID =@TankID, TankName =@TankName, MixWeight =@MixWeight, LowWeight =@LowWeight, FreeFallWeight =@FreeFallWeight, HighSpeed =@HighSpeed, LowSpeed =@LowSpeed, Working =@Working, Orders = @Orders WHERE (BatchID = @BatchID) AND (TankID = @TankID) ";
                using (SQLiteCommand cmd = new SQLiteCommand(query, _Connection))
                {
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID));
                    cmd.Parameters.AddWithValue("@TankID", TankID);
                    cmd.Parameters.AddWithValue("@TankName", TankName);
                    cmd.Parameters.AddWithValue("@MixWeight", MixWeight);
                    cmd.Parameters.AddWithValue("@LowWeight", LowWeight);
                    cmd.Parameters.AddWithValue("@FreeFallWeight", FreeFallWeight);
                    cmd.Parameters.AddWithValue("@HighSpeed", HighSpeed);
                    cmd.Parameters.AddWithValue("@Orders", Orders);
                    cmd.Parameters.AddWithValue("@Working", Working);
                    var result = cmd.ExecuteNonQuery();


                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion
        #region التقرير

        /// <summary>
        /// اجراء تخزين قيم التنكات للتقرير
        /// </summary>
        /// <param name="BatchID"></param>
        /// <param name="BatchName"></param>
        /// <param name="Tank1"></param>
        /// <param name="Tank2"></param>
        /// <param name="Tank3"></param>
        /// <param name="Tank4"></param>
        /// <param name="Tank5"></param>
        /// <param name="Tank6"></param>
        /// <param name="Tank7"></param>
        /// <param name="Tank8"></param>
        /// <param name="Works"></param>
        /// <param name="Datet"></param>
        /// <param name="Time"></param>
        /// <remarks></remarks>
        public static bool InsertBatchFinal(int BatchID, string BatchName, double Tank1, double Tank2, double Tank3, double Tank4, double Tank5, double Tank6, double Tank7, double Tank8, double thnk_rec_oil, int Works, string DateT, string Time)
        {
            try
            {
                if (BatchName.Equals("")) return false;

                // Insert into Database
                string query = "INSERT INTO BatchFinal ('BatchID', 'BatchName', 'Tank1', 'Tank2', 'Tank3'," +
                    " 'Tank4', 'Tank5', 'Tank6', 'Tank7', 'Tank8', 'Tank9', 'Works', 'DateT', 'TimeT')VALUES(@BatchID," +
                    " @TankID, @BatchName, @Tank1, @Tank2, @Tank3, @Tank4, @Tank5, @Tank6, @Tank7, @Tank8, @Tank9, @Works, @DateT, @TimeT)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, _Connection))
                {
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID));
                    cmd.Parameters.AddWithValue("@BatchName", BatchName);
                    cmd.Parameters.AddWithValue("@Tank1", Convert.ToDouble(Tank1));
                    cmd.Parameters.AddWithValue("@Tank2", Convert.ToDouble(Tank2));
                    cmd.Parameters.AddWithValue("@Tank3", Convert.ToDouble(Tank3));
                    cmd.Parameters.AddWithValue("@Tank4", Convert.ToDouble(Tank4));
                    cmd.Parameters.AddWithValue("@Tank5", Convert.ToDouble(Tank5));
                    cmd.Parameters.AddWithValue("@Tank6", Convert.ToDouble(Tank6));
                    cmd.Parameters.AddWithValue("@Tank7", Convert.ToDouble(Tank7));
                    cmd.Parameters.AddWithValue("@Tank8", Convert.ToDouble(Tank8));
                    cmd.Parameters.AddWithValue("@Tank9", Convert.ToDouble(thnk_rec_oil));
                    cmd.Parameters.AddWithValue("@Works", Works);
                    cmd.Parameters.AddWithValue("@DateT", DateT);
                    cmd.Parameters.AddWithValue("@TimeT", Time);
                    var result = cmd.ExecuteNonQuery();


                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// اضافة اسماء التانكات للتقرير
        /// </summary>
        /// <param name="BatchID"></param>
        /// <param name="BatchName"></param>
        /// <param name="Tank1N"></param>
        /// <param name="Tank2N"></param>
        /// <param name="Tank3N"></param>
        /// <param name="Tank4N"></param>
        /// <param name="Tank5N"></param>
        /// <param name="Tank6N"></param>
        /// <param name="Tank7N"></param>
        /// <param name="Tank8N"></param>
        /// <param name="Works"></param>
        /// <param name="Datet"></param>
        /// <param name="Time"></param>
        /// <remarks></remarks>
        public static bool InsertNameTankFinal(int BatchID, string BatchName, string Tank1N, string Tank2N, string Tank3N, string Tank4N, string Tank5N, string Tank6N, string Tank7N, string Tank8N, int Works, string DateT, string Time)
        {
            try
            {
                if (BatchName.Equals("")) return false;

                // Insert into Database
                string query = "INSERT INTO NameTankFinal ('BatchID', 'BatchName', 'Tank1N', 'Tank2N', 'Tank3N'," +
                    " 'Tank4N', 'Tank5N', 'Tank6N', 'Tank7N', 'Tank8N','Works', 'DateT', 'TimeT')VALUES(@BatchID," +
                    " @TankID, @BatchName, @Tank1N, @Tank2N, @Tank3N, @Tank4N, @Tank5N, @Tank6N, @Tank7N, @Tank8N, @Works, @DateT, @TimeT)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, _Connection))
                {
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID));
                    cmd.Parameters.AddWithValue("@BatchName", BatchName);
                    cmd.Parameters.AddWithValue("@Tank1N", Tank1N);
                    cmd.Parameters.AddWithValue("@Tank2N", Tank2N);
                    cmd.Parameters.AddWithValue("@Tank3N", Tank3N);
                    cmd.Parameters.AddWithValue("@Tank4N", Tank4N);
                    cmd.Parameters.AddWithValue("@Tank5N", Tank5N);
                    cmd.Parameters.AddWithValue("@Tank6N", Tank6N);
                    cmd.Parameters.AddWithValue("@Tank7N", Tank7N);
                    cmd.Parameters.AddWithValue("@Tank8N", Tank8N);
                    cmd.Parameters.AddWithValue("@Works", Works);
                    cmd.Parameters.AddWithValue("@DateT", DateT);
                    cmd.Parameters.AddWithValue("@TimeT", Time);
                    var result = cmd.ExecuteNonQuery();


                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool ADD_BatchWeight(int BatchID, string BatchName, string TankName, double FinalWeight, int Works, string DateT, string TimeT)
        {

            try
            {
                if (TankName.Equals("")) return false;

                // Insert into Database
                string query = "INSERT INTO BatchWeight ('BatchID', 'BatchName', 'TankName', 'FinalWeight'," +
                    " 'Works', 'DateT', 'TimeT')VALUES(@BatchID," +
                    " @BatchName, @TankName, @FinalWeight,@Works, @DateT, @TimeT)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, _Connection))
                {
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID));
                    cmd.Parameters.AddWithValue("@BatchName", BatchName);
                    cmd.Parameters.AddWithValue("@TankName", TankName);
                    cmd.Parameters.AddWithValue("@FinalWeight", Convert.ToDouble(FinalWeight));
                    cmd.Parameters.AddWithValue("@Works", Works);
                    cmd.Parameters.AddWithValue("@DateT", DateT);
                    cmd.Parameters.AddWithValue("@TimeT", TimeT);
                    var result = cmd.ExecuteNonQuery();


                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
