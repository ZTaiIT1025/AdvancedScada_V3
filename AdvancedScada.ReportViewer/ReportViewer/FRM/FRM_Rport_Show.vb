Imports AdvancedScada.DataAccess.SqlDb
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class FRM_Rport_Show
#Region "Field"
    Dim max As Integer = 10
    Dim x As Integer, y As Integer
    Dim _comBatchName As String
    Dim _Date1, _Date2, _tpFrom, _tpTo As Date
    Public dt1 As New DataTable
    Public _boolComWerk As Boolean

    Dim totField1 As Double
    Dim totField2 As Double
    Dim totField3 As Double
    Dim totField4 As Double
    Dim totField5 As Double
    Dim totField6 As Double
    Dim totField7 As Double
    Dim totField8 As Double
    Dim totField9 As Double

    Dim FieldShow As Boolean
    Dim dt2 As New DataTable
    Dim currentstyle As String
#End Region
    Private Sub CreateDataTable()

        dt1.Columns.Add("رقم")
        dt1.Columns.Add("التركيبةاسم")
        dt1.Columns.Add("1اسم الخامة")
        dt1.Columns.Add("اسم الخامة2")
        dt1.Columns.Add("اسم الخامة3")
        dt1.Columns.Add("اسم الخامة4")
        dt1.Columns.Add("اسم الخامة5")
        dt1.Columns.Add("اسم الخامة6")
        dt1.Columns.Add("اسم الخامة7")
        dt1.Columns.Add("اسم الخامة8")
        dt1.Columns.Add("الزيت")
        dt1.Columns.Add("الوردية")
        dt1.Columns.Add("التاريخ")
        dt1.Columns.Add("الوقت")

        dgvData.DataSource = dt1


    End Sub
#Region "Initialize"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()


        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal comBatchName As String, ByVal Date1 As Date, ByVal Date2 As Date)
        Me.New()
        _comBatchName = comBatchName
        _Date1 = Date1
        _Date2 = Date2
    End Sub

    Public Sub New(ByVal comBatchName As String, ByVal Date1 As Date, ByVal Date2 As Date, ByVal boolComWerk As Boolean)
        Me.New()
        _comBatchName = comBatchName
        _Date1 = Date1
        _Date2 = Date2

        _boolComWerk = boolComWerk
    End Sub
#End Region
#Region "Sub"

    Private Sub FormatColumns()
        With dgvData
            .Columns(5).Width = "150"
            .Columns(6).Width = "150"
            .Columns(1).DefaultCellStyle.Format = "N"
            .Columns(2).DefaultCellStyle.Format = "N"
            .Columns(3).DefaultCellStyle.Format = "N"
            .Columns(4).DefaultCellStyle.Format = "N"
            .Columns(5).DefaultCellStyle.Format = "N"
            .Columns(6).DefaultCellStyle.Format = "N"

        End With
    End Sub
    Private Sub NewRow()
        Dim w As Integer
        dgvData.Columns(0).HeaderText = "اسم الخلطة"
        dgvData.Columns(1).HeaderText = "اسم الخامة 1"
        dgvData.Columns(2).HeaderText = "اسم الخامة2"
        dgvData.Columns(3).HeaderText = "اسم الخامة3"
        dgvData.Columns(4).HeaderText = "اسم الخامة4"
        dgvData.Columns(5).HeaderText = "اسم الخامة5"
        dgvData.Columns(6).HeaderText = "اسم الخامة6"
        dgvData.Columns(7).HeaderText = "اسم الخامة7"
        dgvData.Columns(8).HeaderText = "اسم الخامة8"
        dgvData.Columns(9).HeaderText = "الزيت"
        dgvData.Columns(10).HeaderText = "الوردية"
        dgvData.Columns(11).HeaderText = "التاريخ      "
        dgvData.Columns(12).HeaderText = "الوقت      "

        For Each r As DataGridViewRow In dgvData.Rows
            w = w + 1
            If FieldShow = False Then
                Try
                    For i As Integer = 1 To 8
                        If r.Cells(i).Value = 0 Then
                            dgvData.Columns(i).Visible = False
                        Else
                            dgvData.Columns(i).Visible = True
                        End If
                    Next
                Catch ex As Exception
                    Exit Try
                End Try

                FieldShow = True
            End If


            If Not IsDBNull(r.Cells(1).Value) Then
                r.Cells(0).Value = w
                totField1 += r.Cells(1).Value
                totField2 += r.Cells(2).Value
                totField3 += r.Cells(3).Value
                totField4 += r.Cells(4).Value
                totField5 += r.Cells(5).Value
                totField6 += r.Cells(6).Value
                totField7 += r.Cells(7).Value
                totField8 += r.Cells(8).Value
                totField9 += r.Cells(9).Value
            End If
        Next
        Dim newrow As DataRow = dt2.NewRow
        newrow(0) = "المجموع:"
        newrow(1) = totField1
        newrow(2) = totField2
        newrow(3) = totField3
        newrow(4) = totField4
        newrow(5) = totField5
        newrow(6) = totField6
        newrow(7) = totField7
        newrow(8) = totField8
        newrow(9) = totField9
        dt2.Rows.Add(newrow)

    End Sub
    Private Sub Get_ExecuteScalar(ByVal Tabal As String, ByVal Param As String, ByVal comBatchName As String, ByVal Date1 As Date, ByVal Date2 As Date)
        Try


            Dim sqlstr1 As String = "SELECT count(*) FROM BatchFinal WHERE " + Tabal + " =" + Param + " And [DateT] between @myFrom and @myTo"
            Dim cmd As New SqlCommand(sqlstr1, con)

            cmd.Parameters.AddWithValue(Param, SqlDbType.VarChar).Value = _comBatchName
            cmd.Parameters.AddWithValue("@myFrom", SqlDbType.Date).Value = Date1.ToString("yyyy/MM/dd")
            cmd.Parameters.AddWithValue("@myTo", SqlDbType.Date).Value = Date2.ToString("yyyy/MM/dd")
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            x = (Convert.ToInt32(cmd.ExecuteScalar()))
            con.Close()

        Catch ex As Exception
            Exit Sub
        Finally
            con.Close()
        End Try

    End Sub
    Private Sub Get_ExecuteBatchFinal(ByVal Tabal As String, ByVal Param As String, ByVal comBatchName As String, ByVal Date1 As Date, ByVal Date2 As Date)
        Try

            Dim sqlstr1 As String = "SELECT DISTINCT [BatchID],[Tank1],[Tank2],[Tank3] ,[Tank4] ,[Tank5],[Tank6],[Tank7],[Tank8],[Tank9],[Works],[DateT],[TimeT] FROM BatchFinal WHERE " + Tabal + " =" + Param + " And [DateT] between @myFrom and @myTo"
            Using cmd = New SqlCommand(sqlstr1, con)
                cmd.Parameters.AddWithValue(Param, SqlDbType.VarChar).Value = comBatchName
                cmd.Parameters.AddWithValue("@myFrom", SqlDbType.Date).Value = Date1.ToString("yyyy/MM/dd")
                cmd.Parameters.AddWithValue("@myTo", SqlDbType.Date).Value = Date2.ToString("yyyy/MM/dd")
                Dim d As New SqlDataAdapter(cmd)
                dt2.Clear()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                d.Fill(DirectCast(ComPaging.SelectedItem, listitem).value, max, dt2)
                con.Close()
                dgvData.DataSource = dt2
                GroupByGrid1.DataSource = dt2
            End Using


        Catch ex As Exception
            Exit Sub
        End Try

    End Sub
    Private Sub Get_ExecuteBatchFinalWorks(ByVal Tabal As String, ByVal Param As String, ByVal comBatchName As String, ByVal Date1 As Date, ByVal Date2 As Date)
        Try
            Dim w As Integer

            Dim sqlstr1 As String = "SELECT DISTINCT [BatchID], [BatchName],[Tank1],[Tank2],[Tank3] ,[Tank4] ,[Tank5],[Tank6],[Tank7],[Tank8],[Tank9],[Works],[DateT],[TimeT] FROM BatchFinal WHERE " + Tabal + " =" + Param + " And [DateT] between @myFrom and @myTo"
            Using cmd = New SqlCommand(sqlstr1, con)
                cmd.Parameters.AddWithValue(Param, SqlDbType.VarChar).Value = comBatchName
                cmd.Parameters.AddWithValue("@myFrom", SqlDbType.Date).Value = Date1.ToString("yyyy/MM/dd")
                cmd.Parameters.AddWithValue("@myTo", SqlDbType.Date).Value = Date2.ToString("yyyy/MM/dd")
                Dim d As New SqlDataAdapter(cmd)
                dt2.Clear()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                d.Fill(DirectCast(ComPaging.SelectedItem, listitem).value, max, dt2)
                con.Close()
                'dgvData.DataSource = dt2
                GroupByGrid1.DataSource = dt2
            End Using


            GroupByGrid1.Columns(0).HeaderText = "الترقيم"
            GroupByGrid1.Columns(1).HeaderText = "اسم التركيبة"
            GroupByGrid1.Columns(2).HeaderText = "اسم الخامة1"
            GroupByGrid1.Columns(3).HeaderText = "اسم الخامة2"
            GroupByGrid1.Columns(4).HeaderText = "اسم الخامة3"
            GroupByGrid1.Columns(5).HeaderText = "اسم الخامة4"
            GroupByGrid1.Columns(6).HeaderText = "اسم الخامة5"
            GroupByGrid1.Columns(7).HeaderText = "اسم الخامة6"
            GroupByGrid1.Columns(8).HeaderText = "اسم الخامة7"
            GroupByGrid1.Columns(9).HeaderText = "اسم الخامة8"
            GroupByGrid1.Columns(10).HeaderText = "الزيت"
            GroupByGrid1.Columns(11).HeaderText = "الوردية"
            GroupByGrid1.Columns(12).HeaderText = "التاريخ      "
            GroupByGrid1.Columns(13).HeaderText = "الوقت      "


            For Each r As DataGridViewRow In GroupByGrid1.Rows
                w = w + 1
                If FieldShow = False Then
                    Try
                        For i As Integer = 2 To 9
                            If r.Cells(i).Value = 0 Then
                                GroupByGrid1.Columns(i).Visible = False
                            Else
                                GroupByGrid1.Columns(i).Visible = True
                            End If
                        Next
                    Catch ex As Exception
                        Exit Try
                    End Try

                    FieldShow = True
                End If
                If Not IsDBNull(r.Cells(1).Value) Then
                    r.Cells(0).Value = w
                    totField1 += r.Cells(2).Value
                    totField2 += r.Cells(3).Value
                    totField3 += r.Cells(4).Value
                    totField4 += r.Cells(5).Value
                    totField5 += r.Cells(6).Value
                    totField6 += r.Cells(7).Value
                    totField7 += r.Cells(8).Value
                    totField8 += r.Cells(9).Value
                    totField9 += r.Cells(10).Value
                End If
            Next
            Dim newrow As DataRow = dt2.NewRow
            newrow(0) = "المجموع:"
            newrow(2) = totField1
            newrow(3) = totField2
            newrow(4) = totField3
            newrow(5) = totField4
            newrow(6) = totField5
            newrow(7) = totField6
            newrow(8) = totField7
            newrow(9) = totField8
            newrow(10) = totField9
            dt2.Rows.Add(newrow)
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub
    Private Sub Get_ExecuteNameTankFinal(ByVal Tabal As String, ByVal Param As String, ByVal comBatchName As String, ByVal Date1 As Date, ByVal Date2 As Date)

        Try


            Dim sqlstr1 As String = "SELECT DISTINCT * FROM NameTankFinal WHERE " + Tabal + " =" + Param + " And [DateT] between @myFrom and @myTo"
            Using cmd = New SqlCommand(sqlstr1, con)
                cmd.Parameters.AddWithValue(Param, SqlDbType.VarChar).Value = comBatchName
                cmd.Parameters.AddWithValue("@myFrom", SqlDbType.Date).Value = Date1.ToString("yyyy/MM/dd")
                cmd.Parameters.AddWithValue("@myTo", SqlDbType.Date).Value = Date2.ToString("yyyy/MM/dd")
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If


                con.Open()

                Dim dr1 As SqlDataReader = cmd.ExecuteReader

                dr1.Read()

                If dr1.HasRows Then

                    NewRow()

                    ''اضافة اسماء الخلطة
                    Dim newrow2 As DataRow = dt2.NewRow
                    newrow2(0) = dr1(1)
                    newrow2(1) = dr1(2)
                    newrow2(2) = dr1(3)
                    newrow2(3) = dr1(4)
                    newrow2(4) = dr1(5)
                    newrow2(5) = dr1(6)
                    newrow2(6) = dr1(7)
                    newrow2(7) = dr1(8)
                    newrow2(8) = dr1(9)

                    dt2.Rows.InsertAt(newrow2, 0)
                    dr1.Close()
                    con.Close()
                    FormatColumns()
                End If
            End Using

        Catch ex As Exception
            Exit Sub
        Finally
            con.Close()
        End Try


    End Sub
#End Region
#Region "Eivent"
    Private Sub Semi_Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try



            If _boolComWerk = False And _comBatchName <> "الكل" Then
                Get_ExecuteScalar("BatchName", "@BatchName", _comBatchName, Me._Date1, Me._Date2)

            ElseIf _boolComWerk = True And _comBatchName <> "الكل" Then
                Get_ExecuteScalar("Works", "@Works", _comBatchName, Me._Date1, Me._Date2)
            End If
            If _comBatchName = "الكل" Then

                Dim sqlstr1 As String = "SELECT count(*) FROM BatchFinal WHERE [DateT] between @myFrom and @myTo"
                Dim cmd As New SqlCommand(sqlstr1, con)
                cmd.Parameters.AddWithValue("@myFrom", SqlDbType.Date).Value = Me._Date1.ToString("yyyy/MM/dd")
                cmd.Parameters.AddWithValue("@myTo", SqlDbType.Date).Value = Me._Date2.ToString("yyyy/MM/dd")
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                x = (Convert.ToInt32(cmd.ExecuteScalar()))
                con.Close()


            End If

            Dim z As Integer = x / max
            y = x Mod max
            If y <> 0 Then
                z += 1
            End If

            For r = 1 To z
                ComPaging.Items.Add(New listitem(r, r * max - max))
            Next

            ComPaging.SelectedIndex = 0


        Catch ex As Exception
            Exit Sub
        Finally
            con.Close()
        End Try



    End Sub
    Private Sub ComPaging_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComPaging.SelectedIndexChanged
        Dim w As Integer = 0
        Try
            totField1 = 0
            totField2 = 0
            totField3 = 0
            totField4 = 0
            totField5 = 0
            totField6 = 0
            totField7 = 0
            totField8 = 0
            totField9 = 0
            If _boolComWerk = False And _comBatchName <> "الكل" Then
                Get_ExecuteBatchFinal("BatchName", "@BatchName", _comBatchName, Me._Date1, Me._Date2)
            ElseIf _boolComWerk = True And _comBatchName <> "الكل" Then
                Get_ExecuteBatchFinalWorks("Works", "@Works", _comBatchName, Me._Date1, Me._Date2)
            End If

            If _boolComWerk = True And _comBatchName <> "الكل" Then
                dgvData.Visible = False
                GroupByGrid1.Visible = True
            ElseIf _boolComWerk = False And _comBatchName <> "الكل" Then
                dgvData.Visible = True
                GroupByGrid1.Visible = False
                Get_ExecuteNameTankFinal("BatchName", "@BatchName", _comBatchName, Me._Date1, Me._Date2)
            Else
                GoTo All
            End If


All:

            If _comBatchName = "الكل" Then

                Dim sqlstr1 As String = "SELECT DISTINCT [BatchID],BatchName ,[Tank1],[Tank2],[Tank3] ,[Tank4] ,[Tank5],[Tank6],[Tank7],[Tank8],[Tank9],[Works],[DateT],[TimeT] FROM BatchFinal WHERE [DateT] between @myFrom and @myTo"

                Using cmd = New SqlCommand(sqlstr1, con)

                    cmd.Parameters.AddWithValue("@myFrom", SqlDbType.Date).Value = Me._Date1.ToString("yyyy/MM/dd")
                    cmd.Parameters.AddWithValue("@myTo", SqlDbType.Date).Value = Me._Date2.ToString("yyyy/MM/dd")
                    Dim d As New SqlDataAdapter(cmd)

                    dt2.Clear()
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If


                    con.Open()
                    d.Fill(DirectCast(ComPaging.SelectedItem, listitem).value, max, dt2)
                    con.Close()
                    dgvData.Visible = False
                    GroupByGrid1.DataSource = dt2
                End Using



                GroupByGrid1.Columns(0).HeaderText = "الترقيم"
                GroupByGrid1.Columns(1).HeaderText = "اسم التركيبة"
                GroupByGrid1.Columns(2).HeaderText = "اسم الخامة1"
                GroupByGrid1.Columns(3).HeaderText = "اسم الخامة2"
                GroupByGrid1.Columns(4).HeaderText = "اسم الخامة3"
                GroupByGrid1.Columns(5).HeaderText = "اسم الخامة4"
                GroupByGrid1.Columns(6).HeaderText = "اسم الخامة5"
                GroupByGrid1.Columns(7).HeaderText = "اسم الخامة6"
                GroupByGrid1.Columns(8).HeaderText = "اسم الخامة7"
                GroupByGrid1.Columns(9).HeaderText = "اسم الخامة8"
                GroupByGrid1.Columns(10).HeaderText = "الزيت"
                GroupByGrid1.Columns(11).HeaderText = "الوردية"
                GroupByGrid1.Columns(12).HeaderText = "التاريخ      "
                GroupByGrid1.Columns(13).HeaderText = "الوقت      "


                For Each r As DataGridViewRow In GroupByGrid1.Rows
                    w = w + 1

                    If Not IsDBNull(r.Cells(1).Value) Then
                        r.Cells(0).Value = w
                        totField1 += r.Cells(2).Value
                        totField2 += r.Cells(3).Value
                        totField3 += r.Cells(4).Value
                        totField4 += r.Cells(5).Value
                        totField5 += r.Cells(6).Value
                        totField6 += r.Cells(7).Value
                        totField7 += r.Cells(8).Value
                        totField8 += r.Cells(9).Value
                        totField9 += r.Cells(10).Value
                    End If



                Next


                Dim newrow As DataRow = dt2.NewRow
                newrow(0) = "المجموع:"
                newrow(2) = totField1
                newrow(3) = totField2
                newrow(4) = totField3
                newrow(5) = totField4
                newrow(6) = totField5
                newrow(7) = totField6
                newrow(8) = totField7
                newrow(9) = totField8
                newrow(10) = totField9
                dt2.Rows.Add(newrow)


            End If


        Catch ex As Exception
            Exit Sub
        Finally
            con.Close()
        End Try

    End Sub

#End Region
End Class
