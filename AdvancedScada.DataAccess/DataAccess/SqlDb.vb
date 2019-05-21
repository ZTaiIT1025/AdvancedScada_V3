Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Module SqlDb
    Public conStrin As String = String.Format("Data Source={0};Initial Catalog=batchs;Integrated Security=True", My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\TestApp", "ServerUser", Nothing))
    ' Public conStrin As String = String.Format("Data Source=.;AttachDbFilename=|DataDirectory|Database\batchs.mdf;Integrated Security=True;Connect Timeout=30")

    Public con As New SqlConnection(conStrin)
    Private dt As New DataTable

#Region "الدوال"
    Public Function GetTable(ByVal sql As String) As DataTable
        Dim c As New SqlConnection(conStrin)
        Dim da As New SqlDataAdapter(sql, c)
        Dim dt As New DataTable()
        Try
            da.Fill(dt)
        Catch
            MessageBox.Show("قاعدة البيانات غير متصلة")
        End Try
        Return dt
    End Function
    Public Function GetRecors(ByVal Query As String) As DataTable
        Dim c As New SqlConnection(conStrin)
        Dim cmd As New SqlCommand(Query, c)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        Try
            da.Fill(dt)
        Catch ex As Exception
            dt.Columns.Add("Error")
            dt.Rows.Add(ex.Message)
        End Try
        Return dt
    End Function
    Public Function FillCombo(ByVal Combo As ComboBox, ByVal Query As String, ByVal DisplayMember As String, ByVal ValueMember As String) As DataTable
        Dim dt As DataTable = GetRecors(Query)
        Combo.DataSource = dt
        Combo.DisplayMember = DisplayMember
        Combo.ValueMember = ValueMember
        Return dt
    End Function
    'قراة البيانات 

    Public Function SelectData(ByVal stored_procedure As String, ByVal param() As SqlParameter) As DataTable
        Dim sqlcmd As New SqlCommand()
        sqlcmd.CommandType = CommandType.StoredProcedure
        sqlcmd.CommandText = stored_procedure
        sqlcmd.Connection = con

        If param IsNot Nothing Then
            For i As Integer = 0 To param.Length - 1
                sqlcmd.Parameters.Add(param(i))

            Next i
        End If
        Dim da As New SqlDataAdapter(sqlcmd)
        Dim dt As New DataTable()
        da.Fill(dt)
        Return dt
    End Function

    'اجراء اضافة البيانات 
    Public Sub ExecuteCommand(ByVal stored_procedure As String, ByVal param() As SqlParameter)
        Try
            Dim sqlcmd As New SqlCommand()
            sqlcmd.CommandType = CommandType.StoredProcedure
            sqlcmd.CommandText = stored_procedure
            sqlcmd.Connection = con

            sqlcmd.Parameters.AddRange(param)


            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try



    End Sub
#End Region
#Region "Get_ID"
    Public Function Get_IDBatch(ByVal Tabel As String) As Integer
        Dim c As New SqlConnection(conStrin)
        Dim x As Integer
        Dim Sql As String = "SELECT MAX(BatchID) FROM " + Tabel
        Dim cmd As New SqlCommand(Sql, c)
        c.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            Dim values(reader.FieldCount - 1) As Object
            Dim fieldCount As Integer = reader.GetValues(values)
            For i As Integer = 0 To fieldCount - 1
                If reader.IsDBNull(i) Then
                    x = 0
                Else
                    x = Val(reader.GetValue(i))
                End If
                ' x = reader.GetValue(0)
            Next
        End While
        reader.NextResult()
        reader.Close()
        c.Close()
        Return x
    End Function
    Public Function GET_LAST_Batchs_ID() As DataTable
        con.Open()

        Dim DT As New DataTable()
        DT = SelectData("GET_LAST_Batchs_ID", Nothing)
        con.Close()
        Return DT
    End Function
    Public Function GET_LAST_ID(ByVal ID As String) As DataTable
        con.Open()

        Dim DT As New DataTable()
        DT = SelectData(ID, Nothing)
        con.Close()
        Return DT
    End Function
#End Region
#Region "تفاصيل التركيبة"
    Public Sub Get_txt_save(ByVal lbl_GREB As Label, ByVal lbl_HighSpeed As Label, ByVal lbl_LowSpeed As Label, ByVal lbl_FreeFallWeight As Label, ByVal lbl_LowWeight As Label, ByVal lbl_Working As Label, ByVal lbl_Orders As Label)
        On Error Resume Next
        Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\TestApp", "Name", Nothing)
        lbl_GREB.Text = CStr(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\TestApp", "Grop_Type", Nothing))
        Dim dt2 As New DataTable
        dt2 = GetRecors(String.Format("SELECT * FROM BatchsDetails WHERE BatchID='{0}'", GetRecors(String.Format("SELECT * FROM Batchs WHERE BatchName='{0}'", readValue)).Rows(0).Item(0)))
        '====================================================================
        For i As Integer = 0 To 6
            lbl_HighSpeed.Text = dt2.Rows(i).Item("HighSpeed").ToString
            lbl_LowSpeed.Text = dt2.Rows(i).Item("LowSpeed").ToString
            lbl_FreeFallWeight.Text = dt2.Rows(i).Item("FreeFallWeight").ToString
            lbl_LowWeight.Text = dt2.Rows(i).Item("LowWeight").ToString
            lbl_Working.Text = dt2.Rows(i).Item("Working").ToString
            lbl_Orders.Text = dt2.Rows(i).Item("Orders").ToString

        Next
    End Sub
    Public Sub Get_txt(ByVal comBatchName As ComboBox, ByVal comTankName As ComboBox, ByRef txt_MixWeight As TextBox, ByRef txt_LowWeight As TextBox, ByRef txt_FreeFallWeight As TextBox, ByRef txt_HighSpeed As TextBox, ByRef txt_LowSpeed As TextBox, ByRef num_Orders As TextBox, ByRef com_Werking As ComboBox, ByVal x As Integer)
        Dim dt As New DataTable
        dt = Get_BatchsDetails(comBatchName.Text)
        'dt = GetRecors("SELECT * FROM BatchsDetails WHERE BatchID='" + GetRecors("SELECT * FROM Batchs WHERE BatchName='" + comBatchName.Text + "'").Rows(0).Item(0).ToString + "'")

        'txt_BatchID.Text = dt.Rows(x).Item("BatchID").ToString
        'TXT_GROP.Text = dt.Rows(x).Item("GroupName").ToString

        comTankName.Text = dt.Rows(x).Item("TankName").ToString
        txt_MixWeight.Text = dt.Rows(x).Item("MixWeight").ToString
        txt_LowWeight.Text = dt.Rows(x).Item("LowWeight").ToString
        txt_FreeFallWeight.Text = dt.Rows(x).Item("FreeFallWeight").ToString
        txt_HighSpeed.Text = dt.Rows(x).Item("HighSpeed").ToString
        txt_LowSpeed.Text = dt.Rows(x).Item("LowSpeed").ToString
        com_Werking.Text = dt.Rows(x).Item("Working").ToString
        num_Orders.Text = dt.Rows(x).Item("Orders").ToString


    End Sub
    ''' <summary>
    ''' تفاصيل التركيبة
    ''' </summary>
    ''' <param name="BatchName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_BatchsDetails(ByVal BatchName As String) As DataTable

        con.Open()
        Dim param(0) As SqlParameter

        param(0) = New SqlParameter("@BatchName", SqlDbType.VarChar)
        param(0).Value = BatchName
        Dim DT As New DataTable()
        DT = SelectData("Get_BatchsDetails", param)
        con.Close()
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
        con.Open()
        Dim DT As New DataTable()
        DT = SelectData("GET_ALL_BatchName", Nothing)
        con.Close()
        Return DT
    End Function
    Sub update_base(ByVal comBatchName As ComboBox)
        comBatchName.DataSource = DELETE_BatchFinal()
        comBatchName.DisplayMember = "BatchName"
        comBatchName.ValueMember = "BatchID"
    End Sub
#End Region
#Region "اضافة خامة"
    ''' <summary>
    ''' اضافة اسم الخامة
    ''' </summary>
    ''' <param name="TanksID"></param>
    ''' <param name="TanksName"></param>
    ''' <remarks></remarks>
    Public Sub ADD_Tanks(ByVal TanksID As Integer, ByVal TanksName As String)

        con.Open()
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@TanksID", SqlDbType.Int)
        param(0).Value = TanksID

        param(1) = New SqlParameter("@TanksName", SqlDbType.VarChar)
        param(1).Value = TanksName

        ExecuteCommand("INSERT_Tanks", param)
        con.Close()
    End Sub
#End Region
#Region "حذف"
    ''' <summary>
    ''' حذف اسم الباتشة
    ''' </summary>
    ''' <param name="BatchName"></param>
    ''' <remarks></remarks>
    Public Sub Del_BatchName(ByVal BatchName As String)

        con.Open()
        Dim param(0) As SqlParameter

        param(0) = New SqlParameter("@BatchName", SqlDbType.VarChar)
        param(0).Value = BatchName

        ExecuteCommand("del_BatchName", param)
        con.Close()
    End Sub
    ''' <summary>
    ''' حذف جميع بيانات الخلاطات
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DELETE_Batchs() As DataTable
        con.Open()

        Dim DT As New DataTable()
        DT = SelectData("DELETE_Batchs", Nothing)
        con.Close()
        Return DT
    End Function
    ''' <summary>
    ''' حذف التقرير كل
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DELETE_BatchFinal() As DataTable

        Dim DT As New DataTable()
        DT = SelectData("DELETE_BatchFinal", Nothing)
        con.Close()
        Return DT
    End Function
#End Region
#Region "اضافة تركيبة وتعديلها"
    ''' <summary>
    ''' اجراء مخزن لاضافة اسم الباتشة 
    ''' </summary>
    ''' <param name="BatchID"></param>
    ''' <param name="BatchName"></param>
    ''' <remarks></remarks>
    Public Sub ADD_Batchs(ByVal BatchID As Integer, ByVal BatchName As String)
        con.Open()
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@BatchID", SqlDbType.Int)
        param(0).Value = BatchID

        param(1) = New SqlParameter("@BatchName", SqlDbType.VarChar)
        param(1).Value = BatchName

        ExecuteCommand("INSERT_Batchs", param)
        con.Close()
    End Sub
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
    Public Sub ADD_Batchs_Details(ByVal BatchID As Integer, ByVal TankID As Integer, ByVal TankName As String, ByVal MixWeight As Integer, ByVal LowWeight As Integer, ByVal FreeFallWeight As Integer, ByVal HighSpeed As Integer, ByVal LowSpeed As Integer, ByVal Orders As Integer, ByVal Working As String)

        con.Open()
        Dim param(9) As SqlParameter


        param(0) = New SqlParameter("@BatchID", SqlDbType.VarChar)
        param(0).Value = BatchID

        param(1) = New SqlParameter("@TankID", SqlDbType.Int)
        param(1).Value = TankID

        param(2) = New SqlParameter("@TankName", SqlDbType.VarChar)
        param(2).Value = TankName

        param(3) = New SqlParameter("@MixWeight", SqlDbType.Int)
        param(3).Value = MixWeight

        param(4) = New SqlParameter("@LowWeight", SqlDbType.Int)
        param(4).Value = LowWeight

        param(5) = New SqlParameter("@FreeFallWeight", SqlDbType.Int)
        param(5).Value = FreeFallWeight

        param(6) = New SqlParameter("@HighSpeed", SqlDbType.Int)
        param(6).Value = HighSpeed

        param(7) = New SqlParameter("@LowSpeed", SqlDbType.Int)
        param(7).Value = LowSpeed

        param(8) = New SqlParameter("@Orders", SqlDbType.Int)
        param(8).Value = Orders

        param(9) = New SqlParameter("@Working", SqlDbType.VarChar)
        param(9).Value = Working

        ExecuteCommand("ADD_Batchs_Details", param)
        con.Close()
    End Sub
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
    Public Sub UPDATE_Batchs_Details(ByVal BatchID As Integer, ByVal TankID As Integer, ByVal TankName As String, ByVal MixWeight As Integer, ByVal LowWeight As Integer, ByVal FreeFallWeight As Integer, ByVal HighSpeed As Integer, ByVal LowSpeed As Integer, ByVal Working As String, ByVal Orders As Integer)

        con.Open()
        Dim param(9) As SqlParameter

        param(0) = New SqlParameter("@BatchID", SqlDbType.Int)
        param(0).Value = BatchID

        param(1) = New SqlParameter("@TankID", SqlDbType.Int)
        param(1).Value = TankID

        param(2) = New SqlParameter("@TankName", SqlDbType.VarChar)
        param(2).Value = TankName

        param(3) = New SqlParameter("@MixWeight", SqlDbType.Int)
        param(3).Value = MixWeight

        param(4) = New SqlParameter("@LowWeight", SqlDbType.Int)
        param(4).Value = LowWeight

        param(5) = New SqlParameter("@FreeFallWeight", SqlDbType.Int)
        param(5).Value = FreeFallWeight

        param(6) = New SqlParameter("@HighSpeed", SqlDbType.Int)
        param(6).Value = HighSpeed

        param(7) = New SqlParameter("@LowSpeed", SqlDbType.Int)
        param(7).Value = LowSpeed

        param(8) = New SqlParameter("@Working", SqlDbType.VarChar)
        param(8).Value = Working

        param(9) = New SqlParameter("@Orders", SqlDbType.Int)
        param(9).Value = Orders

        ExecuteCommand("UPDATE_Batchs_Details", param)
        con.Close()
    End Sub
#End Region
#Region "جلب اسماء التركيبة"
    Public Function GET_ALL_Report_BatchFinal(ByVal BatchName As String, ByVal Date1 As Date, ByVal Date2 As Date, ByVal Time1 As String, ByVal Time2 As String) As DataTable
        con.Open()


        Dim param(4) As SqlParameter
        param(0) = New SqlParameter("@BatchName", SqlDbType.VarChar)
        param(0).Value = BatchName

        param(1) = New SqlParameter("@myFrom", SqlDbType.Date)
        param(1).Value = Date1

        param(2) = New SqlParameter("@span", SqlDbType.VarChar)
        param(2).Value = Time1

        param(3) = New SqlParameter("@myTo", SqlDbType.Date)
        param(3).Value = Date2

        param(4) = New SqlParameter("@span2", SqlDbType.VarChar)
        param(4).Value = Time2
        Dim DT As New DataTable()
        DT = SelectData("GET_ALL_Report_BatchFinal", param)
        con.Close()
        Return DT

    End Function
    Public Function GET_ALL_Report_TankNameVal(ByVal BatchName As String, ByVal Date1 As Date, ByVal Date2 As Date) As DataTable

        con.Open()
        Dim param(2) As SqlParameter
        param(0) = New SqlParameter("@BatchName", SqlDbType.VarChar)
        param(0).Value = BatchName

        param(1) = New SqlParameter("@myFrom", SqlDbType.Date)
        param(1).Value = Date1

        param(2) = New SqlParameter("@myTo", SqlDbType.Date)
        param(2).Value = Date2

        Dim DT As New DataTable()
        DT = SelectData("TankNameVal", param)
        con.Close()
        Return DT

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
    Public Sub InsertBatchFinal(ByVal BatchID As Integer, ByVal BatchName As String, ByVal Tank1 As Double, ByVal Tank2 As Double, ByVal Tank3 As Double, ByVal Tank4 As Double, ByVal Tank5 As Double, ByVal Tank6 As Double, ByVal Tank7 As Double, ByVal Tank8 As Double, thnk_rec_oil As Double, ByVal Works As Integer, ByVal DateT As String, ByVal Time As String)

        con.Open()
        Dim param(13) As SqlParameter
        param(0) = New SqlParameter("@BatchID", SqlDbType.VarChar)
        param(0).Value = BatchID

        param(1) = New SqlParameter("@BatchName", SqlDbType.VarChar)
        param(1).Value = BatchName

        param(2) = New SqlParameter("@Tank1", SqlDbType.VarChar)
        param(2).Value = Tank1

        param(3) = New SqlParameter("@Tank2", SqlDbType.VarChar)
        param(3).Value = Tank2

        param(4) = New SqlParameter("@Tank3", SqlDbType.VarChar)
        param(4).Value = Tank3

        param(5) = New SqlParameter("@Tank4", SqlDbType.VarChar)
        param(5).Value = Tank4

        param(6) = New SqlParameter("@Tank5", SqlDbType.VarChar)
        param(6).Value = Tank5

        param(7) = New SqlParameter("@Tank6", SqlDbType.VarChar)
        param(7).Value = Tank6

        param(8) = New SqlParameter("@Tank7", SqlDbType.VarChar)
        param(8).Value = Tank7

        param(9) = New SqlParameter("@Tank8", SqlDbType.VarChar)
        param(9).Value = Tank8

        param(9) = New SqlParameter("@Tank8", SqlDbType.VarChar)
        param(9).Value = Tank8

        param(10) = New SqlParameter("@Tank9", SqlDbType.VarChar)
        param(10).Value = thnk_rec_oil

        param(11) = New SqlParameter("@Works", SqlDbType.VarChar)
        param(11).Value = Works

        param(12) = New SqlParameter("@Date", SqlDbType.Date)
        param(12).Value = DateT

        param(13) = New SqlParameter("@Time", SqlDbType.VarChar)
        param(13).Value = Time


        ExecuteCommand("InsertBatchFinal", param)
        con.Close()
    End Sub
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
    Public Sub InsertNameTankFinal(ByVal BatchID As Integer, ByVal BatchName As String, ByVal Tank1N As String, ByVal Tank2N As String, ByVal Tank3N As String, ByVal Tank4N As String, ByVal Tank5N As String, ByVal Tank6N As String, ByVal Tank7N As String, ByVal Tank8N As String, ByVal Works As Integer, ByVal DateT As Date, ByVal Time As String)

        con.Open()
        Dim param(12) As SqlParameter
        param(0) = New SqlParameter("@BatchID", SqlDbType.Int)
        param(0).Value = BatchID

        param(1) = New SqlParameter("@BatchName", SqlDbType.VarChar)
        param(1).Value = BatchName

        param(2) = New SqlParameter("@Tank1N", SqlDbType.VarChar)
        param(2).Value = Tank1N

        param(3) = New SqlParameter("@Tank2N", SqlDbType.VarChar)
        param(3).Value = Tank2N

        param(4) = New SqlParameter("@Tank3N", SqlDbType.VarChar)
        param(4).Value = Tank3N

        param(5) = New SqlParameter("@Tank4N", SqlDbType.VarChar)
        param(5).Value = Tank4N

        param(6) = New SqlParameter("@Tank5N", SqlDbType.VarChar)
        param(6).Value = Tank5N

        param(7) = New SqlParameter("@Tank6N", SqlDbType.VarChar)
        param(7).Value = Tank6N

        param(8) = New SqlParameter("@Tank7N", SqlDbType.VarChar)
        param(8).Value = Tank7N

        param(9) = New SqlParameter("@Tank8N", SqlDbType.VarChar)
        param(9).Value = Tank8N

        param(10) = New SqlParameter("@Works", SqlDbType.VarChar)
        param(10).Value = Works

        param(11) = New SqlParameter("@Date", SqlDbType.Date)
        param(11).Value = DateT

        param(12) = New SqlParameter("@Time", SqlDbType.VarChar)
        param(12).Value = Time

        ExecuteCommand("InsertNameTankFinal", param)
        con.Close()
    End Sub
    Public Sub ADD_BatchWeight(ByVal BatchID As Integer, ByVal BatchName As String, ByVal TankName As String, ByVal FinalWeight As Integer, ByVal Works As Integer, ByVal DateT As Date, ByVal TimeT As String)

        con.Open()
        Dim param(6) As SqlParameter


        param(0) = New SqlParameter("@BatchID", SqlDbType.Int)
        param(0).Value = BatchID

        param(1) = New SqlParameter("@BatchName", SqlDbType.VarChar)
        param(1).Value = BatchName

        param(2) = New SqlParameter("@TankName", SqlDbType.VarChar)
        param(2).Value = TankName

        param(3) = New SqlParameter("@FinalWeight", SqlDbType.Real)
        param(3).Value = FinalWeight

        param(4) = New SqlParameter("@Works", SqlDbType.Int)
        param(4).Value = Works

        param(5) = New SqlParameter("@DateT", SqlDbType.Date)
        param(5).Value = DateT

        param(6) = New SqlParameter("@TimeT", SqlDbType.VarChar)
        param(6).Value = TimeT


        ExecuteCommand("ADD_Batch_Weight", param)
        con.Close()
    End Sub
#End Region

End Module

