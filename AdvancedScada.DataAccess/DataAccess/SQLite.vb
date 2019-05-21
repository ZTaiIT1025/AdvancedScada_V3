Option Infer On

Imports System
Imports System.Data.SQLite
Imports System.Windows.Forms

Namespace DataAccessC.SQLite
    ''' <summary>
    ''' Wraps around a Sqlite database to provide core functionality,
    ''' such as, create, open, close database etc...
    ''' </summary>
    Public Class SQLiteDatabase
#Region "الحقول العامة"

        Public _DBFileName As String = "batchs.db3"
        Public Shared ConnectionString As String = String.Format("Data Source={0};Version=3;", Application.StartupPath & "\Database\batchs.db3")
        Public Shared _Connection As New SQLiteConnection(ConnectionString)


#End Region ' الحقول العامة
#Region "الدوال"


        'قراة البيانات 
        Public Function SelectData(ByVal Str As String, ByVal param() As SQLiteParameter) As DataTable
            Dim sqlcmd As New SQLiteCommand() With {
                .CommandType = CommandType.Text,
                .CommandText = Str,
                .Connection = _Connection
            }

            If param IsNot Nothing Then
                For i As Integer = 0 To param.Length - 1
                    sqlcmd.Parameters.Add(param(i))

                Next i
            End If
            Dim da As New SQLiteDataAdapter(sqlcmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            Return dt
        End Function
        'اجراء اضافة البيانات 
        Public Sub ExecuteCommand(ByVal Str As String, ByVal param() As SQLiteParameter)
            Dim sqlcmd As New SQLiteCommand() With {
                .CommandType = CommandType.Text,
                .CommandText = Str,
                .Connection = _Connection
            }
            sqlcmd.Parameters.AddRange(param)
            sqlcmd.ExecuteNonQuery()
        End Sub

        Public Sub FillCombo(ByVal Combo As ComboBox, ByVal Query As String, ByVal DisplayMember As String, ByVal ValueMember As String)
            'On Error Resume Next
            Dim dt As DataTable = GetRecors(Query)
            Combo.DataSource = dt
            Combo.DisplayMember = DisplayMember
            Combo.ValueMember = ValueMember

        End Sub
        Public Function GetRecors(ByVal Query As String) As DataTable
            Dim c As New SQLiteConnection(ConnectionString)
            Dim cmd As New SQLiteCommand(Query, c)
            Dim da As New SQLiteDataAdapter(cmd)
            Dim dt As New DataTable()
            Try
                da.Fill(dt)
            Catch ex As Exception
                dt.Columns.Add("Error")
                dt.Rows.Add(ex.Message)
            End Try
            Return dt
        End Function
#End Region
#Region "Get_ID"
        Public Function Get_IDBatch(ByVal Tabel As String) As Integer
            Dim x As Integer = 0
            Dim Sql As String = "SELECT MAX(BatchID) FROM " & Tabel

            Dim cmd As New SQLiteCommand(Sql, _Connection)
            _Connection.Open()
            Dim reader As SQLiteDataReader = cmd.ExecuteReader()

            Do While reader.Read()
                Dim values(reader.FieldCount - 1) As Object
                Dim fieldCount As Integer = reader.GetValues(values)
                For i As Integer = 0 To fieldCount - 1
                    If reader.IsDBNull(i) Then

                        x = 1
                    Else
                        x = Convert.ToInt32(reader.GetValue(i))

                    End If
                    ' x = reader.GetValue(0)

                Next i

            Loop
            reader.NextResult()
            reader.Close()
            _Connection.Close()

            Return x
        End Function
#End Region
#Region "تفاصيل التركيبة"
        ''' <summary>
        ''' تفاصيل التركيبة
        ''' </summary>
        ''' <param name="BatchName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Get_BatchsDetails(ByVal BatchName As String) As DataTable
            _Connection.Open()
            Dim dt As New DataTable()
            Const selsct As String = "SELECT Batchs.BatchID, BatchsDetails.BatchID,BatchsDetails.TankName, BatchsDetails.MixWeight, BatchsDetails.LowWeight, BatchsDetails.FreeFallWeight, BatchsDetails.HighSpeed, BatchsDetails.LowSpeed, BatchsDetails.Orders, BatchsDetails.Working FROM Batchs INNER JOIN BatchsDetails ON Batchs.BatchID = BatchsDetails.BatchID  WHERE Batchs.BatchName=@BatchName"
            Dim cmd As New SQLiteCommand(selsct, _Connection)
            cmd.Parameters.AddWithValue("@BatchName", BatchName)
            Dim da As New SQLiteDataAdapter(cmd)
            da.Fill(dt)
            _Connection.Close()
            Return dt
        End Function
        Public Sub Get_txt(ByVal comBatchName As ComboBox, ByVal comTankName As ComboBox, ByVal txt_MixWeight As TextBox, ByVal txt_LowWeight As TextBox, ByVal txt_FreeFallWeight As TextBox, ByVal txt_HighSpeed As TextBox, ByVal txt_LowSpeed As TextBox, ByVal num_Orders As TextBox, ByVal com_Werking As ComboBox, ByVal x As Integer)


            Dim dt1 As New DataTable()
            dt1 = GetRecors(String.Format("SELECT Batchs.BatchID, BatchsDetails.BatchID,BatchsDetails.TankName, BatchsDetails.MixWeight, BatchsDetails.LowWeight, BatchsDetails.FreeFallWeight, BatchsDetails.HighSpeed, BatchsDetails.LowSpeed, BatchsDetails.Orders, BatchsDetails.Working FROM Batchs INNER JOIN BatchsDetails ON Batchs.BatchID = BatchsDetails.BatchID  WHERE Batchs.BatchName='{0}'", comBatchName.Text))

            If dt1.Rows.Count > 0 Then
                comTankName.Text = dt1.Rows(x)("TankName").ToString()
                txt_MixWeight.Text = dt1.Rows(x)("MixWeight").ToString()
                txt_LowWeight.Text = dt1.Rows(x)("LowWeight").ToString()
                txt_FreeFallWeight.Text = dt1.Rows(x)("FreeFallWeight").ToString()
                txt_HighSpeed.Text = dt1.Rows(x)("HighSpeed").ToString()
                txt_LowSpeed.Text = dt1.Rows(x)("LowSpeed").ToString()
                num_Orders.Text = dt1.Rows(x)("Orders").ToString()
                com_Werking.Text = dt1.Rows(x)("Working").ToString()
            End If


        End Sub
#End Region
#Region "حذف"
        Public Sub del_BatchName(ByVal BatchName As String)
            _Connection.Open()
            Const SQL As String = "DELETE FROM [Batchs]WHERE BatchName=@BatchName"
            Dim param(0) As SQLiteParameter

            param(0) = New SQLiteParameter("@BatchName", BatchName)


            ExecuteCommand(SQL, param)
            _Connection.Close()
        End Sub
        Public Sub del_TankNames(ByVal TankName As String)
            _Connection.Open()
            Const SQL As String = "DELETE FROM [TankNames]WHERE TankName=@TankName"
            Dim param(0) As SQLiteParameter

            param(0) = New SQLiteParameter("@TankName", TankName)


            ExecuteCommand(SQL, param)
            _Connection.Close()
        End Sub
        ''' <summary>
        ''' حذف جميع بيانات الخلاطات
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DELETE_Batchs() As DataTable
            Const selsct As String = " DELETE * FROM  Batchs"
            Dim DT As New DataTable()
            DT = SelectData(selsct, Nothing)
            _Connection.Close()
            Return DT
        End Function
        ''' <summary>
        ''' حذف التقرير كل
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DELETE_BatchFinal() As DataTable
            Const selsct1 As String = " DELETE * FROM  BatchFinal"
            Dim DT As New DataTable()
            DT = SelectData(selsct1, Nothing)
            Const selsct2 As String = " DELETE * FROM  NameTankFinal"

            DT = SelectData(selsct2, Nothing)
            Const selsct3 As String = " DELETE * FROM  BatchWeight"

            DT = SelectData(selsct3, Nothing)
            _Connection.Close()

            Return DT
        End Function
#End Region
#Region "اسماء التركيبة"
        ''' <summary>
        ''' اجراء جلب اسماء الباتشات
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GET_ALL_BatchName() As DataTable
            Const selsct As String = " SELECT * FROM  Batchs"
            Dim DT As New DataTable()

            DT = SelectData(selsct, Nothing)
            _Connection.Close()
            Return DT

        End Function


#End Region
#Region "اضافة خامة"
        ''' <summary>
        ''' اضافة اسم الخامة
        ''' </summary>
        ''' <param name="TanksID"></param>
        ''' <param name="TanksName"></param>
        ''' <remarks></remarks>
        Public Shared Function ADD_Tanks(ByVal TanksID As Integer, ByVal TanksName As String) As Boolean

            Try

                If TanksName.Equals(String.Empty) Then
                    Return False
                End If
                ' Insert into Database
                Dim query As String = "INSERT INTO Tanks ('TanksID', 'TanksName')VALUES(@TanksID, @TanksName)"
                Using cmd As New SQLiteCommand(query, _Connection)
                    cmd.Parameters.AddWithValue("@TanksID", TanksID)
                    cmd.Parameters.AddWithValue("@TanksName", TanksName)
                    Dim result = cmd.ExecuteNonQuery()


                End Using
                Return True
            Catch
                Return False
            End Try
        End Function
#End Region
#Region "اضافة تركيبة وتعديلها"
        ''' <summary>
        ''' اجراء مخزن لاضافة اسم الباتشة 
        ''' </summary>
        ''' <param name="BatchID"></param>
        ''' <param name="BatchName"></param>
        ''' <remarks></remarks>
        Public Shared Function ADD_Batchs(ByVal BatchID As Integer, ByVal BatchName As String) As Boolean
            Try
                If BatchName.Equals(String.Empty) Then
                    Return False
                End If

                ' Insert into Database
                Dim query As String = "INSERT INTO Batchs ('BatchID', 'BatchName')VALUES(@BatchID, @BatchName)"
                Using cmd As New SQLiteCommand(query, _Connection)
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID))
                    cmd.Parameters.AddWithValue("@BatchName", BatchName)
                    Dim result = cmd.ExecuteNonQuery()


                End Using
                Return True
            Catch
                Return False
            End Try
        End Function
        ''' <summary>
        ''' اضافة تفاصيل الباتشة
        ''' </summary>
        ''' <param name="BatchID"></param>
        ''' <param name="TankID"></param>
        ''' <param name="TankName"></param>
        ''' <param name="MixWeight"></param>
        ''' <param name="LowWeight"></param>
        ''' <param name="FreeFallWeight"></param>
        ''' <param name="HighSpeed"></param>
        ''' <param name="LowSpeed"></param>
        ''' <param name="Orders"></param>
        ''' <param name="Working"></param>
        ''' <remarks></remarks>
        Public Shared Function ADD_Batchs_Details(ByVal BatchID As Integer, ByVal TankID As Integer, ByVal TankName As String, ByVal MixWeight As Integer, ByVal LowWeight As Integer, ByVal FreeFallWeight As Integer, ByVal HighSpeed As Integer, ByVal LowSpeed As Integer, ByVal Orders As Integer, ByVal Working As String) As Boolean
            Try
                If TankName.Equals(String.Empty) Then
                    Return False
                End If
                ' Insert into Database
                Dim query As String = "INSERT INTO BatchsDetails ('BatchID', 'TankID', 'TankName', 'MixWeight', 'LowWeight'," & " 'FreeFallWeight', 'HighSpeed', 'Orders', 'Working')VALUES(@BatchID, @TankID, @TankName, @MixWeight, @LowWeight, @FreeFallWeight, @HighSpeed, @Orders, @Working)"
                Using cmd As New SQLiteCommand(query, _Connection)
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID))
                    cmd.Parameters.AddWithValue("@TankID", TankID)
                    cmd.Parameters.AddWithValue("@TankName", TankName)
                    cmd.Parameters.AddWithValue("@MixWeight", MixWeight)
                    cmd.Parameters.AddWithValue("@LowWeight", LowWeight)
                    cmd.Parameters.AddWithValue("@FreeFallWeight", FreeFallWeight)
                    cmd.Parameters.AddWithValue("@HighSpeed", HighSpeed)
                    cmd.Parameters.AddWithValue("@Orders", Orders)
                    cmd.Parameters.AddWithValue("@Working", Working)
                    Dim result = cmd.ExecuteNonQuery()


                End Using
                Return True
            Catch
                Return False
            End Try

        End Function
        ''' <summary>
        ''' تحديث تفاصيل الباتشا
        ''' </summary>
        ''' <param name="BatchID"></param>
        ''' <param name="TankID"></param>
        ''' <param name="TankName"></param>
        ''' <param name="MixWeight"></param>
        ''' <param name="LowWeight"></param>
        ''' <param name="FreeFallWeight"></param>
        ''' <param name="HighSpeed"></param>
        ''' <param name="LowSpeed"></param>
        ''' <param name="Working"></param>
        ''' <param name="Orders"></param>
        ''' <remarks></remarks>
        Public Shared Function UPDATE_Batchs_Details(ByVal BatchID As Integer, ByVal TankID As Integer, ByVal TankName As String, ByVal MixWeight As Integer, ByVal LowWeight As Integer, ByVal FreeFallWeight As Integer, ByVal HighSpeed As Integer, ByVal LowSpeed As Integer, ByVal Working As String, ByVal Orders As Integer) As Boolean
            Try
                Const query As String = "UPDATE BatchsDetails SET BatchID =@BatchID, TankID =@TankID, TankName =@TankName, MixWeight =@MixWeight, LowWeight =@LowWeight, FreeFallWeight =@FreeFallWeight, HighSpeed =@HighSpeed, LowSpeed =@LowSpeed, Working =@Working, Orders = @Orders WHERE (BatchID = @BatchID) AND (TankID = @TankID) "
                Using cmd As New SQLiteCommand(query, _Connection)
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID))
                    cmd.Parameters.AddWithValue("@TankID", TankID)
                    cmd.Parameters.AddWithValue("@TankName", TankName)
                    cmd.Parameters.AddWithValue("@MixWeight", MixWeight)
                    cmd.Parameters.AddWithValue("@LowWeight", LowWeight)
                    cmd.Parameters.AddWithValue("@FreeFallWeight", FreeFallWeight)
                    cmd.Parameters.AddWithValue("@HighSpeed", HighSpeed)
                    cmd.Parameters.AddWithValue("@Orders", Orders)
                    cmd.Parameters.AddWithValue("@Working", Working)
                    Dim result = cmd.ExecuteNonQuery()


                End Using
                Return True
            Catch
                Return False
            End Try

        End Function
#End Region
#Region "التقرير"

        ''' <summary>
        ''' اجراء تخزين قيم التنكات للتقرير
        ''' </summary>
        ''' <param name="BatchID"></param>
        ''' <param name="BatchName"></param>
        ''' <param name="Tank1"></param>
        ''' <param name="Tank2"></param>
        ''' <param name="Tank3"></param>
        ''' <param name="Tank4"></param>
        ''' <param name="Tank5"></param>
        ''' <param name="Tank6"></param>
        ''' <param name="Tank7"></param>
        ''' <param name="Tank8"></param>
        ''' <param name="Works"></param>
        ''' <param name="Datet"></param>
        ''' <param name="Time"></param>
        ''' <remarks></remarks>
        Public Shared Function InsertBatchFinal(ByVal BatchID As Integer, ByVal BatchName As String, ByVal Tank1 As Double, ByVal Tank2 As Double, ByVal Tank3 As Double, ByVal Tank4 As Double, ByVal Tank5 As Double, ByVal Tank6 As Double, ByVal Tank7 As Double, ByVal Tank8 As Double, ByVal thnk_rec_oil As Double, ByVal Works As Integer, ByVal DateT As String, ByVal Time As String) As Boolean
            Try
                If BatchName.Equals(String.Empty) Then
                    Return False
                End If

                ' Insert into Database
                Dim query As String = "INSERT INTO BatchFinal ('BatchID', 'BatchName', 'Tank1', 'Tank2', 'Tank3'," & " 'Tank4', 'Tank5', 'Tank6', 'Tank7', 'Tank8', 'Tank9', 'Works', 'DateT', 'TimeT')VALUES(@BatchID," & " @TankID, @BatchName, @Tank1, @Tank2, @Tank3, @Tank4, @Tank5, @Tank6, @Tank7, @Tank8, @Tank9, @Works, @DateT, @TimeT)"
                Using cmd As New SQLiteCommand(query, _Connection)
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID))
                    cmd.Parameters.AddWithValue("@BatchName", BatchName)
                    cmd.Parameters.AddWithValue("@Tank1", Convert.ToDouble(Tank1))
                    cmd.Parameters.AddWithValue("@Tank2", Convert.ToDouble(Tank2))
                    cmd.Parameters.AddWithValue("@Tank3", Convert.ToDouble(Tank3))
                    cmd.Parameters.AddWithValue("@Tank4", Convert.ToDouble(Tank4))
                    cmd.Parameters.AddWithValue("@Tank5", Convert.ToDouble(Tank5))
                    cmd.Parameters.AddWithValue("@Tank6", Convert.ToDouble(Tank6))
                    cmd.Parameters.AddWithValue("@Tank7", Convert.ToDouble(Tank7))
                    cmd.Parameters.AddWithValue("@Tank8", Convert.ToDouble(Tank8))
                    cmd.Parameters.AddWithValue("@Tank9", Convert.ToDouble(thnk_rec_oil))
                    cmd.Parameters.AddWithValue("@Works", Works)
                    cmd.Parameters.AddWithValue("@DateT", DateT)
                    cmd.Parameters.AddWithValue("@TimeT", Time)
                    Dim result = cmd.ExecuteNonQuery()


                End Using
                Return True
            Catch
                Return False
            End Try

        End Function
        ''' <summary>
        ''' اضافة اسماء التانكات للتقرير
        ''' </summary>
        ''' <param name="BatchID"></param>
        ''' <param name="BatchName"></param>
        ''' <param name="Tank1N"></param>
        ''' <param name="Tank2N"></param>
        ''' <param name="Tank3N"></param>
        ''' <param name="Tank4N"></param>
        ''' <param name="Tank5N"></param>
        ''' <param name="Tank6N"></param>
        ''' <param name="Tank7N"></param>
        ''' <param name="Tank8N"></param>
        ''' <param name="Works"></param>
        ''' <param name="Datet"></param>
        ''' <param name="Time"></param>
        ''' <remarks></remarks>
        Public Shared Function InsertNameTankFinal(ByVal BatchID As Integer, ByVal BatchName As String, ByVal Tank1N As String, ByVal Tank2N As String, ByVal Tank3N As String, ByVal Tank4N As String, ByVal Tank5N As String, ByVal Tank6N As String, ByVal Tank7N As String, ByVal Tank8N As String, ByVal Works As Integer, ByVal DateT As String, ByVal Time As String) As Boolean
            Try
                If BatchName.Equals(String.Empty) Then
                    Return False
                End If

                ' Insert into Database
                Dim query As String = "INSERT INTO NameTankFinal ('BatchID', 'BatchName', 'Tank1N', 'Tank2N', 'Tank3N'," & " 'Tank4N', 'Tank5N', 'Tank6N', 'Tank7N', 'Tank8N','Works', 'DateT', 'TimeT')VALUES(@BatchID," & " @TankID, @BatchName, @Tank1N, @Tank2N, @Tank3N, @Tank4N, @Tank5N, @Tank6N, @Tank7N, @Tank8N, @Works, @DateT, @TimeT)"
                Using cmd As New SQLiteCommand(query, _Connection)
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID))
                    cmd.Parameters.AddWithValue("@BatchName", BatchName)
                    cmd.Parameters.AddWithValue("@Tank1N", Tank1N)
                    cmd.Parameters.AddWithValue("@Tank2N", Tank2N)
                    cmd.Parameters.AddWithValue("@Tank3N", Tank3N)
                    cmd.Parameters.AddWithValue("@Tank4N", Tank4N)
                    cmd.Parameters.AddWithValue("@Tank5N", Tank5N)
                    cmd.Parameters.AddWithValue("@Tank6N", Tank6N)
                    cmd.Parameters.AddWithValue("@Tank7N", Tank7N)
                    cmd.Parameters.AddWithValue("@Tank8N", Tank8N)
                    cmd.Parameters.AddWithValue("@Works", Works)
                    cmd.Parameters.AddWithValue("@DateT", DateT)
                    cmd.Parameters.AddWithValue("@TimeT", Time)
                    Dim result = cmd.ExecuteNonQuery()


                End Using
                Return True
            Catch
                Return False
            End Try

        End Function
        Public Shared Function ADD_BatchWeight(ByVal BatchID As Integer, ByVal BatchName As String, ByVal TankName As String, ByVal FinalWeight As Double, ByVal Works As Integer, ByVal DateT As String, ByVal TimeT As String) As Boolean

            Try
                If TankName.Equals(String.Empty) Then
                    Return False
                End If

                ' Insert into Database
                Dim query As String = "INSERT INTO BatchWeight ('BatchID', 'BatchName', 'TankName', 'FinalWeight'," & " 'Works', 'DateT', 'TimeT')VALUES(@BatchID," & " @BatchName, @TankName, @FinalWeight,@Works, @DateT, @TimeT)"
                Using cmd As New SQLiteCommand(query, _Connection)
                    cmd.Parameters.AddWithValue("@BatchID", Convert.ToInt32(BatchID))
                    cmd.Parameters.AddWithValue("@BatchName", BatchName)
                    cmd.Parameters.AddWithValue("@TankName", TankName)
                    cmd.Parameters.AddWithValue("@FinalWeight", Convert.ToDouble(FinalWeight))
                    cmd.Parameters.AddWithValue("@Works", Works)
                    cmd.Parameters.AddWithValue("@DateT", DateT)
                    cmd.Parameters.AddWithValue("@TimeT", TimeT)
                    Dim result = cmd.ExecuteNonQuery()


                End Using

                Return True
            Catch
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace
