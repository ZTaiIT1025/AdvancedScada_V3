

Imports AdvancedScada.DataAccess
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class FRM_Rpot_All

    Dim Text8(9) As String
    Protected myFrom As Date
    Protected myTo As Date
    Protected TheSource As ReportDataSource = New ReportDataSource
    Protected DS1 As Batchs = New Batchs
    Private dt As New DataTable

#Region "ازرار التشغيل"
    Private Sub butShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butShow.Click
        Try
            Dim dt As New DataTable

            Me.myFrom = Me.Date_From.Value
            Me.myTo = Me.Date_To.Value

            Dim day As Date = Date_From.Text
            Dim a, b As String
            a = Date_From.Text
            a = Format(day, "yyyy/MM/dd")
            Dim sday As Date = Date_To.Text
            b = Date_To.Text
            b = Format(sday, "yyyy/MM/dd")
            Dim sqlstrAll As String
            If comBatchName.Text = "الكل" Then
                Dim sqlstr2 As String = "SELECT NameTankFinal.*,BatchFinal.* FROM [NameTankFinal] inner join BatchFinal on BatchFinal.BatchID = NameTankFinal.BatchID and BatchFinal.BatchName = NameTankFinal.BatchName WHERE NameTankFinal.[DateT] between @myFrom and @myTo"
                sqlstrAll = sqlstr2
            Else
                Dim sqlstr1 As String = "SELECT NameTankFinal.*,BatchFinal.* FROM [NameTankFinal] inner join BatchFinal on BatchFinal.BatchID = NameTankFinal.BatchID and BatchFinal.BatchName = NameTankFinal.BatchName WHERE NameTankFinal.[BatchName] =@BatchName And NameTankFinal.[DateT] between @myFrom and @myTo"
                sqlstrAll = sqlstr1

            End If
            Using cmd = New SqlCommand(sqlstrAll, con)
                If comBatchName.Text = "الكل" Then

                Else
                    cmd.Parameters.AddWithValue("@BatchName", SqlDbType.VarChar).Value = comBatchName.Text

                End If

                cmd.Parameters.AddWithValue("@myFrom", SqlDbType.Date).Value = Format(Me.myFrom, "yyyy/MM/dd")
                cmd.Parameters.AddWithValue("@myTo", SqlDbType.Date).Value = Format(Me.myTo, "yyyy/MM/dd")
                DS1.BatchFinal.Clear()
                Dim DataAdapter As New SqlDataAdapter(cmd)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                DataAdapter.Fill(DS1.BatchFinal)
                con.Close()
            End Using
            If DS1.BatchFinal.Rows.Count > 0 Then
                TheSource.Name = "DataSet1"
                TheSource.Value = DS1.BatchFinal
                Dim date1parameter(0) As ReportParameter
                Dim date2parameter(0) As ReportParameter
                date1parameter(0) = New ReportParameter("Date1", a)
                date2parameter(0) = New ReportParameter("Date2", b)

                Dim Frm As New FrmViwer

                Frm.ReportViewer1.Reset()

                With Frm.ReportViewer1
                    .LocalReport.DataSources.Clear()
                    .LocalReport.DataSources.Add(TheSource)
                    .LocalReport.ReportEmbeddedResource = "AdvancedScada.ReportViewer.Report_BatchName.rdlc"
                    .LocalReport.SetParameters(date1parameter)
                    .LocalReport.SetParameters(date2parameter)
                    .RefreshReport()
                    Frm.Show()
                End With
            End If


        Catch ex As Exception
            Exit Sub
        End Try



    End Sub



    Dim currentstyle, currentstyle2 As String
    Private Sub FRM_Rpot_All_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try
            ' rc = New ResizeableControl(groupBox1)


            Date1.Value = Today
            Date2.Value = Today

            Date_From.Value = Today
            Date_To.Value = Today

            Date5.Value = Today
            Date6.Value = Today

            If SqlDb.FillCombo(comBatchName, "select * from Batchs  order by BatchName", "BatchName", "BatchID").Rows.Count > 0 Then

            End If

        Catch ex As Exception
            dt.Columns.Add("Error")
            dt.Rows.Add(ex.Message)
            Exit Sub
        End Try



    End Sub
    Private Sub Get_ExecuteBatchFinal(ByVal Tabal As String, ByVal Param As String, ByVal comBatchName As String, ByVal Date1 As Date, ByVal Date2 As Date)
        Try
            Dim sqlstr1 As String = "SELECT NameTankFinal.*,BatchFinal.* FROM [NameTankFinal] inner join BatchFinal on BatchFinal.BatchID = NameTankFinal.BatchID and BatchFinal.BatchName = NameTankFinal.BatchName WHERE NameTankFinal. " + Tabal + " =" + Param + " And NameTankFinal.[DateT] between @myFrom and @myTo"

            Using cmd = New SqlCommand(sqlstr1, con)
                cmd.Parameters.AddWithValue(Param, SqlDbType.VarChar).Value = comBatchName
                cmd.Parameters.AddWithValue("@myFrom", SqlDbType.Date).Value = Date1.ToString("yyyy/MM/dd")
                cmd.Parameters.AddWithValue("@myTo", SqlDbType.Date).Value = Date2.ToString("yyyy/MM/dd")
                DS1.Clear()
                Dim DataAdapter As New SqlDataAdapter(cmd)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                DataAdapter.Fill(DS1.BatchFinal)
                con.Close()
            End Using
        Catch ex As Exception
            Exit Sub
        Finally
            con.Close()
        End Try



    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butShow3.Click
        Try

            Me.myFrom = Me.Date5.Value
            Me.myTo = Me.Date6.Value

            Dim day As Date = Date5.Text
            Dim a, b As String
            a = Date5.Text
            a = Format(day, "yyyy/MM/dd")
            Dim sday As Date = Date6.Text
            b = Date6.Text
            b = Format(sday, "yyyy/MM/dd")


            If comGroupName.Text = "الكل" Then
                Dim sqlstr1 As String = "SELECT NameTankFinal.*,BatchFinal.* FROM [NameTankFinal] inner join BatchFinal on BatchFinal.BatchID = NameTankFinal.BatchID and BatchFinal.BatchName = NameTankFinal.BatchName WHERE NameTankFinal.[DateT] between @myFrom and @myTo"

                Using cmd = New SqlCommand(sqlstr1, con)

                    cmd.Parameters.AddWithValue("@myFrom", SqlDbType.Date).Value = Date5.Value.ToString("yyyy/MM/dd")
                    cmd.Parameters.AddWithValue("@myTo", SqlDbType.Date).Value = Date6.Value.ToString("yyyy/MM/dd")
                    DS1.Clear()
                    Dim DataAdapter As New SqlDataAdapter(cmd)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    DataAdapter.Fill(DS1.BatchFinal)
                    con.Close()
                End Using
            ElseIf comGroupName.Text = "تقرير الوردية مفصل" Then
                Get_ExecuteBatchFinal("Works", "@Works", ComWerk.Text, myFrom, myTo)
            Else

            End If
            Dim Frm As New FrmViwer
            If DS1.BatchFinal.Rows.Count > 0 Then

                TheSource.Name = "DataSet1"
                TheSource.Value = DS1.BatchFinal
                Dim date1parameter(0) As ReportParameter
                Dim date2parameter(0) As ReportParameter
                date1parameter(0) = New ReportParameter("Date1", a)
                date2parameter(0) = New ReportParameter("Date2", b)
                Frm.ReportViewer1.Reset()
                With Frm.ReportViewer1
                    .LocalReport.DataSources.Clear()
                    .LocalReport.DataSources.Add(TheSource)
                    .LocalReport.ReportEmbeddedResource = "AdvancedScada.ReportViewer.Report_GroupName.rdlc"
                    .LocalReport.SetParameters(date1parameter)
                    .LocalReport.SetParameters(date2parameter)
                    .RefreshReport()
                    Frm.Show()
                End With
            End If



        Catch ex As Exception
            Exit Sub
        Finally
            con.Close()
        End Try


    End Sub
    Private Sub comGroupName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comGroupName.SelectedIndexChanged
        Try
            If comGroupName.Text = "الكل" Then
                ComWerk.Enabled = False

            ElseIf comGroupName.Text = "تقرير الوردية مفصل" Then

                ComWerk.Enabled = True
            ElseIf comGroupName.Text = "تقرير الوردية مجمع" Then

                ComWerk.Enabled = False
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            con.Close()
        End Try


    End Sub
#End Region
    ''' <summary>
    ''' دالة البحث عن قيم الخامات المستخدمة فى التركيبات على حسب اسم الخامة والمجموعة
    ''' </summary>
    ''' <param name="Date1"> التاريخ الاول</param>
    ''' <param name="Date2">التاريخ الثانى</param>
    ''' <param name="TankName">اسم التنكات</param>
    ''' <param name="Text1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TankNameVal(ByVal Date1 As Date, ByVal Date2 As Date, ByVal TankName As String, ByRef Text1 As Double) As Double
        Try

            Dim x As Integer
            If SqlDb.GET_ALL_Report_TankNameVal(TankName, Format(Date1, "yyyy/MM/dd"), Format(Date2, "yyyy/MM/dd")).Rows.Count > 0 Then
                x = SqlDb.GET_ALL_Report_TankNameVal(TankName, Format(Date1, "yyyy-MM-dd"), Format(Date2, "yyyy-MM-dd")).Rows(0)(0).ToString()
                Text1 = x
            End If

        Catch ex As Exception
            Exit Try
        Finally
            con.Close()
        End Try
        Return Text1
    End Function

    Private Sub butShow2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butShow2.Click
        Dim dt As New DataTable
        Dim Text2 As New List(Of String)
        Try
            Text2.AddRange({"ذورة", "ذورة2", "صويا", "صويا2", "جير", "مركبات", "مركبات", "عباد الشمس", "زيت"})


            Me.myFrom = Me.Date1.Value
            Me.myTo = Me.Date2.Value

            Dim day As Date = Date1.Text
            Dim a, b As String
            a = Date1.Text
            a = Format(day, "yyyy/MM/dd")
            Dim sday As Date = Date2.Text
            b = Date2.Text
            b = Format(sday, "yyyy/MM/dd")

            For i As Integer = 0 To 8
                Text8(i) = 0
            Next

            For x = 0 To 8
                TankNameVal(myFrom, myTo, Text2(x), Text8(x))
            Next

            Dim Frm As New FrmViwer


            Dim pare As New List(Of ReportParameter)
            pare.Add(New ReportParameter("Tank1N", Text2(0)))
            pare.Add(New ReportParameter("Tank2N", Text2(1)))
            pare.Add(New ReportParameter("Tank3N", Text2(2)))
            pare.Add(New ReportParameter("Tank4N", Text2(3)))
            pare.Add(New ReportParameter("Tank5N", Text2(4)))
            pare.Add(New ReportParameter("Tank6N", Text2(5)))
            pare.Add(New ReportParameter("Tank7N", Text2(6)))
            pare.Add(New ReportParameter("Tank8N", Text2(7)))
            pare.Add(New ReportParameter("Tank1", Text8(0)))
            pare.Add(New ReportParameter("Tank2", Text8(1)))
            pare.Add(New ReportParameter("Tank3", Text8(2)))
            pare.Add(New ReportParameter("Tank4", Text8(3)))
            pare.Add(New ReportParameter("Tank5", Text8(4)))
            pare.Add(New ReportParameter("Tank6", Text8(5)))
            pare.Add(New ReportParameter("Tank7", Text8(6)))
            pare.Add(New ReportParameter("Tank8", Text8(7)))
            pare.Add(New ReportParameter("Tank9", Text8(8)))


            pare.Add(New ReportParameter("Date1", a))
            pare.Add(New ReportParameter("Date2", b))
            Frm.ReportViewer1.Reset()
            With Frm.ReportViewer1
                .LocalReport.ReportEmbeddedResource = "AdvancedScada.ReportViewer.AllTankNames.rdlc"
                .LocalReport.SetParameters(pare)
                .RefreshReport()
                Frm.Show()
            End With


        Catch ex As Exception
            Exit Sub
        Finally
            con.Close()
        End Try
        If Date1.Value > Date2.Value Then
            MsgBox("قيمة التاريخ الأولى لا يمكن أن تكون أكبر من قيمة التاريخ الثانية")
            Exit Sub
        End If






    End Sub
    Private Sub But_Show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles But_Show.Click
        Try
            If Date_From.Value > Date_To.Value Then
                MsgBox("قيمة التاريخ الأولى لا يمكن أن تكون أكبر من قيمة التاريخ الثانية")
                Exit Sub
            End If

            Me.myFrom = Me.Date_From.Value.Date
            Me.myTo = Me.Date_To.Value.Date
            Dim frm As New FRM_Rport_Show(comBatchName.Text, myFrom, myTo, False)
            frm.Show()
        Catch
            Exit Sub
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub But_Show2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles But_Show2.Click
        Try
            If Date5.Value > Date6.Value Then
                MsgBox("قيمة التاريخ الأولى لا يمكن أن تكون أكبر من قيمة التاريخ الثانية")
                Exit Sub
            End If

            Me.myFrom = Me.Date5.Value
            Me.myTo = Me.Date6.Value
            If comGroupName.Text = "الكل" Then
                Dim frm As New FRM_Rport_Show(comGroupName.Text, myFrom, myTo, True)
                frm.Show()
            Else

                Dim frm As New FRM_Rport_Show(ComWerk.Text, myFrom, myTo, True)
                frm.Show()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            con.Close()
        End Try

    End Sub
End Class