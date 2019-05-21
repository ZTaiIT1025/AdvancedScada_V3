using OfficeOpenXml;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedScada.Utils.Excel
{
    public delegate void GetErorr(string erorr);
    public static class ExcelUtils

    {
        public static GetErorr eventGetErorr;

        public static DataTable ReadExcel(string filename, string sheetName)
        {
            var myConnection = new OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0; " +
                "data source='" + filename + "';" +
                "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ");

            var dtImport = new DataTable();
            var myImportCommand = new OleDbDataAdapter("select * from [" + sheetName + "$]", myConnection);
            myImportCommand.Fill(dtImport);
            return dtImport;
        }

        /// <summary>
        ///     Exports the datagridview values to Excel.
        /// </summary>
        public static void ExportToExcelPackage(string DataBlockName, ListView listViewS)
        {
            // Creating a Excel object.
            using (var p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "Miles Dyson";
                p.Workbook.Properties.Title = "SkyNet Monthly Report";
                p.Workbook.Properties.Company = "Cyberdyne Systems";

                // The rest of our code will go here...

                p.Workbook.Worksheets.Add(DataBlockName);
                var ws = p.Workbook.Worksheets[1]; // 1 is the position of the worksheet
                ws.Name = DataBlockName;

                var cellRowIndex = 1;
                var cellColumnIndex = 1;

                //Loop through each row and read value from each column.
                for (var i = 0; i < listViewS.Items.Count + 1; i++)
                {
                    for (var j = 0; j < listViewS.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check.
                        if (cellRowIndex == 1)
                        {
                            var cell_actionName = ws.Cells[cellRowIndex, cellColumnIndex];
                            cell_actionName.Value = listViewS.Columns[j].Text;
                        }
                        else
                        {
                            var processorCell = ws.Cells[cellRowIndex, cellColumnIndex];
                            processorCell.Value = listViewS.Items[i - 1].SubItems[j].Text;
                        }

                        cellColumnIndex++;
                    }

                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user.
                var saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.FileName = DataBlockName;
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var bin = p.GetAsByteArray();
                    File.WriteAllBytes(saveDialog.FileName, bin);
                    MessageBox.Show("Export Successful");
                }
            }
        }
    }
    public class ExcelHelper
    {
        #region Reading From Excel File

        public static string[] getExcelSheets(string mFile)
        {
            try
            {
                string strXlsConnString;
                strXlsConnString = "Provider=Microsoft.ACE.OLEDB.12.0; " + "data source='" + mFile + "';" +
                                   "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ";
                var xlsConn = new OleDbConnection(strXlsConnString);
                xlsConn.Open();
                var xlTable = new DataTable();
                xlTable = xlsConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                var strExcelSheetNames = string.Empty;
                string sheetName;
                //Loop through the excel database table names and take only the tables that ends with a $ characters. Other tables are not worksheets...
                for (var lngStart = 0; lngStart < xlTable.Rows.Count; lngStart++)
                {
                    sheetName = xlTable.Rows[lngStart][2].ToString()
                        .Replace("'", string.Empty); //Remove the single-quote surrounding the table name...
                    if (sheetName.EndsWith("$")) //Yes, this is a worksheet
                        strExcelSheetNames +=
                            sheetName.Substring(0, sheetName.Length - 1) +
                            "~"; //concatenate with a single-quote delimeter... to be returned as a string array later using the split function
                }

                if (strExcelSheetNames.EndsWith("~")
                ) //the last single quote needs to be removed so that the array index ends with the last sheetname
                    strExcelSheetNames = strExcelSheetNames.Substring(0, strExcelSheetNames.Length - 1);

                xlsConn.Close();
                xlsConn.Dispose();
                char[] chrDelimter = { '~' };
                return strExcelSheetNames.Split(chrDelimter);
            }
            catch (Exception exp)
            {
                throw new Exception("Error while listing the excel sheets from upload file <br>" + exp.Message, exp);
            }
        }

        public static DataTable getXLData(string xlSheetName, string xlFileName, string AdditionalFields)
        {
            try
            {
                // string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + xlFileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                var xlConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; " +
                                                 "data source='" + xlFileName + "';" +
                                                 "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ");
                var dtImport = new DataTable();
                dtImport.Clear();
                xlConn.Open();
                var xlDA = new OleDbDataAdapter("Select" + AdditionalFields + " * from [" + xlSheetName + "$] ",
                    xlConn);
                xlDA.Fill(dtImport);
                xlConn.Close();
                xlConn.Dispose();

                RemoveEmptyRows(dtImport,
                    (AdditionalFields.Length - AdditionalFields.ToLower().Replace(" as ", string.Empty).Length) / 4);
                return dtImport;
            }
            catch (Exception e)
            {
                throw new Exception("Error while reading data from excel sheet", e);
            }
        }

        public static void RemoveEmptyRows(DataTable dtbl, int intNumberOfFieldsToIgnore)
        {
            var strFilter = string.Empty;
            //Check at least 3/4th of the columns for null value
            var intAvgColsToCheck = Convert.ToInt32((dtbl.Columns.Count - intNumberOfFieldsToIgnore) * 0.75);
            //Can't entertain checking less than three columns.
            if (intAvgColsToCheck < 3) intAvgColsToCheck = dtbl.Columns.Count;

            //Building the filter string that checks null value in 3/4th of the total column numbers...

            //We will be doing it in reverse, checking the last three-quarter columns
            var lngEnd = dtbl.Columns.Count;
            lngEnd = lngEnd - intAvgColsToCheck;
            for (var lngStartColumn = dtbl.Columns.Count; lngStartColumn > lngEnd; lngStartColumn--)
                strFilter +=
                    "[" + dtbl.Columns[lngStartColumn - 1].ColumnName +
                    "] IS NULL AND "; //AND to concatenate the next column in the filter

            //Remove the trailing AND
            if (strFilter.Length > 1) //At least one column is added (and thus, the trailing AND)
                strFilter = strFilter.Remove(strFilter.Length - 4);
            var drows = dtbl.Select(strFilter);

            //Remove the rows that are empty...
            foreach (var drow in drows) dtbl.Rows.Remove(drow);
        }

        public static void BulkCopy(DataTable dtTable)
        {
            var SqlConn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ArmsConnStr"].ToString());
            SqlConn1.Open();
            using (var bc = new SqlBulkCopy(SqlConn1))
            {
                bc.DestinationTableName = "TableName";
                bc.WriteToServer(dtTable);
                bc.Close();
            }

            SqlConn1.Close();
        }

        #endregion

        #region ExportToMultipleExcelSheets

        private static readonly StringBuilder SqlScript = new StringBuilder();
        private static readonly StringBuilder SqlInsert = new StringBuilder();
        private static readonly bool mPredefineFile = false;

        public static void ImportToMultipleXLSheets(string SqlSelect, string mOutputFileName)
        {
            string FolderPath;
            FolderPath = mOutputFileName.Remove(mOutputFileName.LastIndexOf("\\"),
                mOutputFileName.Length - mOutputFileName.LastIndexOf("\\"));


            File.Copy(FolderPath + "\\Sample.xls", mOutputFileName, true);

            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ArmsConnStr"].ToString());
            SqlConn.Open();
            var DS = new DataSet();
            var connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mOutputFileName +
                          ";Extended Properties='Excel 8.0'";
            var xlConn = new OleDbConnection(connstr);

            try
            {
                xlConn.Open();

                var SqlDA = new SqlDataAdapter(SqlSelect, SqlConn);
                SqlDA.Fill(DS);
                SqlConn.Close();
                SqlConn.Dispose();
                PrepareScript(DS.Tables[0]);
                StartImport(DS.Tables[0], xlConn);
            }
            catch (Exception exp)
            {
                throw new Exception("ImportToMultipleXLSheets", exp.InnerException);
            }
            finally
            {
                if (xlConn != null)
                {
                    if (xlConn.State == ConnectionState.Open) xlConn.Close();
                    xlConn.Dispose();
                }

                if (SqlConn != null)
                {
                    if (SqlConn.State == ConnectionState.Open) SqlConn.Close();
                    SqlConn.Dispose();
                }
            }
        }

        private static void CreateXLSheets(DataTable DTable, OleDbConnection xlConn, string XLSheetName)
        {
            // Create New Excel Sheet

            var SqlFinalScript = new StringBuilder();
            var cmdXl = new OleDbCommand();
            try
            {
                SqlFinalScript.Length = 0;

                cmdXl.Connection = xlConn;

                SqlFinalScript.Append("CREATE TABLE " + XLSheetName + " (");
                SqlFinalScript.Append(SqlScript);

                cmdXl.CommandText = SqlFinalScript.ToString();
                cmdXl.ExecuteNonQuery();
            }
            catch (Exception xlSheetExp)
            {
                throw new Exception("CreateXLSheetException", xlSheetExp.InnerException);
            }
            finally
            {
                cmdXl.Dispose();
            }
        }

        private static string PrepareScript(DataTable DTable)
        {
            // Prepare Scripts to create excel Sheet

            SqlInsert.Length = 0;
            SqlScript.Length = 0;
            for (var i = 0; i < DTable.Columns.Count; i++)
            {
                SqlInsert.Append("[" + DTable.Columns[i].ColumnName + "],");

                SqlScript.Append("[" + DTable.Columns[i].ColumnName.Replace("'", "''") + "]");

                if (DTable.Columns[i].DataType.ToString().ToLower().Contains("int") ||
                    DTable.Columns[i].DataType.ToString().ToLower().Contains("decimal"))
                    SqlScript.Append(" double");
                else
                    SqlScript.Append(" text");

                SqlScript.Append(", ");
            }

            SqlInsert.Remove(SqlInsert.Length - 1, 1);
            SqlScript.Remove(SqlScript.Length - 2, 1);
            SqlScript.Append(") ");
            return SqlScript.ToString();
        }

        private static void StartImport(DataTable DTable, OleDbConnection xlConn)
        {
            long rowNo = 0, xlSheetIndex = 2, TotalNoOfRecords = 0;

            var NewXLSheetName = "Sheet";
            var strInsert = new StringBuilder();
            TotalNoOfRecords = DTable.Rows.Count;
            var cmdXl = new OleDbCommand();
            cmdXl.Connection = xlConn;
            if (mPredefineFile) xlSheetIndex = 1;
            for (var count = 0; count < DTable.Rows.Count; count++)
            {
                strInsert.Length = 0;

                if (rowNo == 0 && !mPredefineFile)
                    CreateXLSheets(DTable, xlConn, NewXLSheetName + xlSheetIndex);
                rowNo += 1;

                // TotalNoOfRecords : Total no of records return by Sql Query, ideally should be set to 65535
                //rowNo : current Row no in the loop 
                if (TotalNoOfRecords > 5000 && rowNo > 5000)
                {
                    xlSheetIndex += 1;
                    if (!mPredefineFile) CreateXLSheets(DTable, xlConn, NewXLSheetName + xlSheetIndex);
                    rowNo = 1;
                }

                strInsert.Append("Insert Into [" + NewXLSheetName + xlSheetIndex + "$](" + SqlInsert + ") Values (");
                foreach (DataColumn dCol in DTable.Columns)
                {
                    if (dCol.DataType.ToString().ToLower().Contains("int"))
                    {
                        if (DTable.Rows[count][dCol.Ordinal].ToString() == string.Empty)
                            strInsert.Append("NULL");
                        else
                            strInsert.Append(DTable.Rows[count][dCol.Ordinal]);
                    }
                    else if (dCol.DataType.ToString().ToLower().ToLower().Contains("decimal"))
                    {
                        if (DTable.Rows[count][dCol.Ordinal].ToString() == string.Empty)
                            strInsert.Append("NULL");
                        else
                            strInsert.Append(DTable.Rows[count][dCol.Ordinal]);
                    }
                    else
                    {
                        strInsert.Append("\"" + DTable.Rows[count][dCol.Ordinal].ToString().Replace("'", "''") + "\"");
                    }

                    strInsert.Append(",");
                }

                strInsert.Remove(strInsert.Length - 1, 1);
                strInsert.Append(");");
                cmdXl.CommandText = strInsert.ToString();
                cmdXl.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
