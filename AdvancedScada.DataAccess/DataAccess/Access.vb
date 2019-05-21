Imports System.Data.OleDb
Imports System.Windows.Forms

Public Module Access
#Region "الحقول العامة"
    Private conStrin As String = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\Database\db.mdb")
    Private cmd As New OleDbCommand
    Private adapt As New OleDbDataAdapter
    Private conn As New OleDbConnection(conStrin)
    Private ds As New DataSet
    Private dt As New DataTable
    Private usrrr As String
    Private psrrr As String
#End Region
#Region "اسماء التركيبة"
    Public Function GET_ALL_BatchName() As DataTable
        Const selsct As String = " SELECT * FROM  Batchs"
        Dim DT As New DataTable()

        DT = SelectData(selsct, Nothing)
        conn.Close()
        Return DT

    End Function
#End Region
#Region "الدوال"


    'قراة البيانات 
    Public Function SelectData(ByVal Str As String, ByVal param() As OleDbParameter) As DataTable
        Dim sqlcmd As New OleDbCommand() With {.CommandType = CommandType.Text, .CommandText = Str, .Connection = conn}

        If param IsNot Nothing Then
            For i As Integer = 0 To param.Length - 1
                sqlcmd.Parameters.Add(param(i))

            Next i
        End If
        Dim da As New OleDbDataAdapter(sqlcmd)
        Dim dt As New DataTable()
        da.Fill(dt)
        Return dt
    End Function
    'اجراء اضافة البيانات 
    Public Sub ExecuteCommand(ByVal Str As String, ByVal param() As OleDbParameter)
        Dim sqlcmd As New OleDbCommand() With {.CommandType = CommandType.Text, .CommandText = Str, .Connection = conn}
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
        Dim c As New OleDbConnection(conStrin)
        Dim cmd As New OleDbCommand(Query, c)
        Dim da As New OleDbDataAdapter(cmd)
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
#Region "تفاصيل التركيبة"
    ''' <summary>
    ''' تفاصيل التركيبة
    ''' </summary>
    ''' <param name="BatchName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_BatchsDetails(ByVal BatchName As String) As DataTable
        conn.Open()
        Dim dt As New DataTable
        Const selsct As String = "SELECT Batchs.BatchID, BatchsDetails.BatchID,BatchsDetails.TankName, BatchsDetails.MixWeight, BatchsDetails.LowWeight, BatchsDetails.FreeFallWeight, BatchsDetails.HighSpeed, BatchsDetails.LowSpeed, BatchsDetails.Orders, BatchsDetails.Working FROM Batchs INNER JOIN BatchsDetails ON Batchs.BatchID = BatchsDetails.BatchID  WHERE Batchs.BatchName=@BatchName"
        Dim cmd As New OleDbCommand(selsct, conn)
        cmd.Parameters.AddWithValue("@BatchName", OleDbType.VarChar).Value = BatchName
        Dim da As New OleDbDataAdapter(cmd)
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Sub Get_txt(ByVal comBatchName As ComboBox, ByVal comTankName As ComboBox, ByVal txt_MixWeight As TextBox, ByVal txt_LowWeight As TextBox, ByVal txt_FreeFallWeight As TextBox, ByVal txt_HighSpeed As TextBox, ByVal txt_LowSpeed As TextBox, ByVal num_Orders As TextBox, ByVal com_Werking As ComboBox, ByVal x As Integer)


        Dim dt1 As New DataTable
        dt1 = GetRecors(String.Format("SELECT Batchs.BatchID, BatchsDetails.BatchID,BatchsDetails.TankName, BatchsDetails.MixWeight, BatchsDetails.LowWeight, BatchsDetails.FreeFallWeight, BatchsDetails.HighSpeed, BatchsDetails.LowSpeed, BatchsDetails.Orders, BatchsDetails.Working FROM Batchs INNER JOIN BatchsDetails ON Batchs.BatchID = BatchsDetails.BatchID  WHERE Batchs.BatchName='{0}'", comBatchName.Text))

        If dt1.Rows.Count > 0 Then
            comTankName.Text = dt1.Rows(x).Item("TankName").ToString
            txt_MixWeight.Text = dt1.Rows(x).Item("MixWeight").ToString
            txt_LowWeight.Text = dt1.Rows(x).Item("LowWeight").ToString
            txt_FreeFallWeight.Text = dt1.Rows(x).Item("FreeFallWeight").ToString
            txt_HighSpeed.Text = dt1.Rows(x).Item("HighSpeed").ToString
            txt_LowSpeed.Text = dt1.Rows(x).Item("LowSpeed").ToString
            num_Orders.Text = dt1.Rows(x).Item("Orders").ToString
            com_Werking.Text = dt1.Rows(x).Item("Working").ToString
        End If


    End Sub
#End Region
#Region "حذف"
    Public Sub del_BatchName(ByVal BatchName As String)
        conn.Open()
        Const SQL As String = "DELETE FROM [Batchs]WHERE BatchName=@BatchName"
        Dim param(0) As OleDbParameter

        param(0) = New OleDbParameter("@BatchName", SqlDbType.VarChar)
        param(0).Value = BatchName

        ExecuteCommand(SQL, param)
        conn.Close()
    End Sub
    Public Sub del_TankNames(ByVal TankName As String)
        conn.Open()
        Const SQL As String = "DELETE FROM [TankNames]WHERE TankName=@TankName"
        Dim param(0) As OleDbParameter

        param(0) = New OleDbParameter("@TankName", SqlDbType.VarChar)
        param(0).Value = TankName

        ExecuteCommand(SQL, param)
        conn.Close()
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
        conn.Close()
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
        conn.Close()

        Return DT
    End Function
#End Region
#Region "اضافة مستخدم "

    Public Sub ADD_User(ByVal User_Name As String, ByVal Pas As String, ByVal Type As String)

        Const insertcmd As String = "INSERT INTO [User]([UserName],[Pas],[Type])VALUES(?,?,?)"

        Dim cmd As New OleDbCommand(insertcmd, conn)

        cmd.Parameters.AddWithValue("@UserName", OleDbType.VarChar).Value = User_Name
        cmd.Parameters.AddWithValue("@Pas", OleDbType.VarChar).Value = Pas
        cmd.Parameters.AddWithValue("@Type", OleDbType.VarChar).Value = Type

        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Sub UPDATE_User(ByVal User_Name As String, ByVal Pas As String, ByVal Type As String)

        Const insertcmd As String = "UPDATE[User]SET[UserName]=@UserName,[Pas]=@Pas,[Type]=@Type "

        Dim cmd As New OleDbCommand(insertcmd, conn)

        cmd.Parameters.AddWithValue("@UserName", OleDbType.VarChar).Value = User_Name
        cmd.Parameters.AddWithValue("@Pas", OleDbType.VarChar).Value = Pas
        cmd.Parameters.AddWithValue("@Type", OleDbType.VarChar).Value = Type

        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

#End Region
#Region "اضافة خامة"
    Public Sub ADD_TankName(ByVal TanksID As Integer, ByVal TankName As String)

        Const INSERT_TankNames As String = "INSERT INTO TankNames(TanksID,TankName)VALUES(@TanksID,@TankName)"

        Dim cmd As New OleDbCommand(INSERT_TankNames, conn)
        cmd.Parameters.AddWithValue("@TanksID", OleDbType.Integer).Value = TanksID
        cmd.Parameters.AddWithValue("@TankName", OleDbType.VarChar).Value = TankName
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub
#End Region
#Region "اضافة تركيبة وتعديلها"
    Public Sub ADD_Batchs(ByVal BatchName As String)

        Const INSERT_Batchs As String = "INSERT INTO Batchs(BatchName)VALUES(@BatchName)"

        Dim cmd As New OleDbCommand(INSERT_Batchs, conn)

        cmd.Parameters.AddWithValue("@BatchName", OleDbType.VarChar).Value = BatchName
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub
    Public Sub ADD_Batchs(ByVal BatchID As Integer, ByVal BatchName As String)

        Const INSERT_Batchs As String = "INSERT INTO Batchs(BatchID,BatchName)VALUES(@BatchID,@BatchName)"

        Dim cmd As New OleDbCommand(INSERT_Batchs, conn)

        cmd.Parameters.AddWithValue("@BatchID", OleDbType.VarChar).Value = BatchID
        cmd.Parameters.AddWithValue("@BatchName", OleDbType.VarChar).Value = BatchName
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub
    Public Sub UPDATE_Batchs_Details(ByVal BatchID As Integer, ByVal TankID As Integer, ByVal TankName As String, ByVal MixWeight As Integer, ByVal LowWeight As Integer, ByVal FreeFallWeight As Integer, ByVal HighSpeed As Integer, ByVal LowSpeed As Integer, ByVal Werking As String, ByVal Orders As Integer)
        Try
            Const SQL As String = "UPDATE BatchsDetails SET BatchID =@BatchID, TankID =@TankID, TankName =@TankName, MixWeight =@MixWeight, LowWeight =@LowWeight, FreeFallWeight =@FreeFallWeight, HighSpeed =@HighSpeed, LowSpeed =@LowSpeed, Working =@Working, Orders = @Orders WHERE (BatchID = @BatchID) AND (TankID = @TankID) "
            Dim cmd As New OleDbCommand(SQL, conn)

            cmd.Parameters.AddWithValue("@BatchID", OleDbType.VarChar).Value = BatchID
            cmd.Parameters.AddWithValue("@TankID", OleDbType.VarChar).Value = TankID
            cmd.Parameters.AddWithValue("@TankName", OleDbType.VarChar).Value = TankName
            cmd.Parameters.AddWithValue("@MixWeight", OleDbType.VarChar).Value = MixWeight
            cmd.Parameters.AddWithValue("@LowWeight", OleDbType.VarChar).Value = LowWeight
            cmd.Parameters.AddWithValue("@FreeFallWeight", OleDbType.VarChar).Value = FreeFallWeight
            cmd.Parameters.AddWithValue("@HighSpeed", OleDbType.VarChar).Value = HighSpeed
            cmd.Parameters.AddWithValue("@LowSpeed", OleDbType.VarChar).Value = LowSpeed
            cmd.Parameters.AddWithValue("@Working", OleDbType.VarChar).Value = Werking
            cmd.Parameters.AddWithValue("@Orders", OleDbType.VarChar).Value = Orders
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub ADD_Batchs_Details(ByVal BatchID As Integer, ByVal TankID As Integer, ByVal TankName As String, ByVal MixWeight As Integer, ByVal LowWeight As Integer, ByVal FreeFallWeight As Integer, ByVal HighSpeed As Integer, ByVal LowSpeed As Integer, ByVal Orders As String, ByVal Werking As String)
        Dim sqlstr As String = "INSERT INTO [BatchsDetails]([BatchID] ,[TankID],[TankName],[MixWeight],[LowWeight],[FreeFallWeight],[HighSpeed],[LowSpeed],[Orders],[Working])VALUES(@BatchID, @TankID,@TankName ,@MixWeight,@LowWeight,@FreeFallWeight,@HighSpeed,@LowSpeed,@Orders,@Working)"
        Dim cmd As New OleDbCommand(sqlstr, conn)

        cmd.Parameters.AddWithValue("@BatchID", OleDbType.VarChar).Value = BatchID
        cmd.Parameters.AddWithValue("@TankID", OleDbType.VarChar).Value = TankID
        cmd.Parameters.AddWithValue("@TankName", OleDbType.VarChar).Value = TankName
        cmd.Parameters.AddWithValue("@MixWeight", OleDbType.VarChar).Value = MixWeight
        cmd.Parameters.AddWithValue("@LowWeight", OleDbType.VarChar).Value = LowWeight
        cmd.Parameters.AddWithValue("@FreeFallWeight", OleDbType.VarChar).Value = FreeFallWeight
        cmd.Parameters.AddWithValue("@HighSpeed", OleDbType.VarChar).Value = HighSpeed
        cmd.Parameters.AddWithValue("@LowSpeed", OleDbType.VarChar).Value = LowSpeed
        cmd.Parameters.AddWithValue("@Orders", OleDbType.VarChar).Value = Orders
        cmd.Parameters.AddWithValue("@Working", OleDbType.VarChar).Value = Werking
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

    End Sub
#End Region
#Region "Get_ID"
    Public Function Get_IDBatch(ByVal Tabel As String) As Integer
        Dim x As Integer
        Dim Sql As String = "SELECT MAX(BatchID) FROM " + Tabel

        Dim cmd As New OleDbCommand(Sql, conn)
        conn.Open()
        Dim reader As OleDbDataReader = cmd.ExecuteReader()

        While reader.Read()
            Dim values(reader.FieldCount - 1) As Object
            Dim fieldCount As Integer = reader.GetValues(values)
            For i As Integer = 0 To fieldCount - 1
                If reader.IsDBNull(i) Then

                    x = 1
                Else
                    x = Val(reader.GetValue(i))

                End If
                ' x = reader.GetValue(0)

            Next

        End While
        reader.NextResult()
        reader.Close()
        conn.Close()

        Return x
    End Function
#End Region
#Region "التقرير"
    Public Sub InsertBatchFinal(ByVal BatchID As Integer, ByVal BatchName As String, ByVal Tank1 As Double, ByVal Tank2 As Double, ByVal Tank3 As Double, ByVal Tank4 As Double, ByVal Tank5 As Double, ByVal Tank6 As Double, ByVal Tank7 As Double, ByVal Tank8 As Double, ByVal Tank9 As Integer, ByVal Tank10 As Integer, ByVal Tank11 As String, ByVal Tank12 As Integer, ByVal Works As String, ByVal DateT As Date, ByVal TimeT As String)
        Try
            Const sqlstr As String = "INSERT INTO BatchFinal (BatchID, BatchName, Tank1, Tank2, Tank3, Tank4, Tank5, Tank6, Tank7, Tank8, [Work], [Date],[Time])VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)"
            Dim cmd As New OleDbCommand(sqlstr, conn)
            cmd.Parameters.AddWithValue("@BatchID", OleDbType.VarChar).Value = BatchID
            cmd.Parameters.AddWithValue("@BatchName", OleDbType.VarChar).Value = BatchName
            cmd.Parameters.AddWithValue("@Tank1", OleDbType.Double).Value = Tank1
            cmd.Parameters.AddWithValue("@Tank2", OleDbType.Double).Value = Tank2
            cmd.Parameters.AddWithValue("@Tank3", OleDbType.Double).Value = Tank3
            cmd.Parameters.AddWithValue("@Tank4", OleDbType.Double).Value = Tank4
            cmd.Parameters.AddWithValue("@Tank5", OleDbType.Double).Value = Tank5
            cmd.Parameters.AddWithValue("@Tank6", OleDbType.Double).Value = Tank6
            cmd.Parameters.AddWithValue("@Tank7", OleDbType.Double).Value = Tank7
            cmd.Parameters.AddWithValue("@Tank8", OleDbType.Double).Value = Tank8
            cmd.Parameters.AddWithValue("@[Work]", OleDbType.VarChar).Value = Works
            cmd.Parameters.AddWithValue("@[Date]", OleDbType.Date).Value = DateT
            cmd.Parameters.AddWithValue("@[Time]", OleDbType.VarChar).Value = TimeT
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub InsertNameTankFinal(ByVal BatchID As Integer, ByVal BatchName As String, ByVal Tank1 As String, ByVal Tank2 As String, ByVal Tank3 As String, ByVal Tank4 As String, ByVal Tank5 As String, ByVal Tank6 As String, ByVal Tank7 As String, ByVal Tank8 As String, ByVal Tank9 As Integer, ByVal Tank10 As Integer, ByVal Tank11 As String, ByVal Tank12 As Integer, ByVal Work As String, ByVal DateT As Date, ByVal TimeT As String)
        Try
            Const sqlstr As String = "INSERT INTO NameTankFinal (BatchID, BatchName, Tank1N, Tank2N, Tank3N, Tank4N, Tank5N, Tank6N, Tank7N,Tank8N, [Works],  [Date],[Time])VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)"
            Dim cmd As New OleDbCommand(sqlstr, conn)
            cmd.Parameters.AddWithValue("@BatchID", OleDbType.VarChar).Value = BatchID
            cmd.Parameters.AddWithValue("@BatchName", OleDbType.VarChar).Value = BatchName
            cmd.Parameters.AddWithValue("@Tank1N", OleDbType.Double).Value = Tank1
            cmd.Parameters.AddWithValue("@Tank2N", OleDbType.Double).Value = Tank2
            cmd.Parameters.AddWithValue("@Tank3N", OleDbType.Double).Value = Tank3
            cmd.Parameters.AddWithValue("@Tank4N", OleDbType.Double).Value = Tank4
            cmd.Parameters.AddWithValue("@Tank5N", OleDbType.Double).Value = Tank5
            cmd.Parameters.AddWithValue("@Tank6N", OleDbType.Double).Value = Tank6
            cmd.Parameters.AddWithValue("@Tank7N", OleDbType.Double).Value = Tank7
            cmd.Parameters.AddWithValue("@Tank8N", OleDbType.Double).Value = Tank8
            cmd.Parameters.AddWithValue("@[Works]", OleDbType.VarChar).Value = Work
            cmd.Parameters.AddWithValue("@[Date]", OleDbType.Date).Value = DateT
            cmd.Parameters.AddWithValue("@[Time]", OleDbType.VarChar).Value = TimeT
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception

        End Try

    End Sub
#End Region
End Module
