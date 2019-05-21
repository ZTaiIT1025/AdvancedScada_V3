<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_Rpot_All
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.But_Show2 = New System.Windows.Forms.Button()
        Me.ComWerk = New System.Windows.Forms.ComboBox()
        Me.comGroupName = New System.Windows.Forms.ComboBox()
        Me.butShow3 = New System.Windows.Forms.Button()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.Date6 = New System.Windows.Forms.DateTimePicker()
        Me.Date5 = New System.Windows.Forms.DateTimePicker()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.butShow2 = New System.Windows.Forms.Button()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.Date2 = New System.Windows.Forms.DateTimePicker()
        Me.Date1 = New System.Windows.Forms.DateTimePicker()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.But_Show = New System.Windows.Forms.Button()
        Me.Date_To = New System.Windows.Forms.DateTimePicker()
        Me.Date_From = New System.Windows.Forms.DateTimePicker()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.butShow = New System.Windows.Forms.Button()
        Me.comBatchName = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBox3.SuspendLayout
        Me.groupBox2.SuspendLayout
        Me.groupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.groupBox3.Controls.Add(Me.But_Show2)
        Me.groupBox3.Controls.Add(Me.ComWerk)
        Me.groupBox3.Controls.Add(Me.comGroupName)
        Me.groupBox3.Controls.Add(Me.butShow3)
        Me.groupBox3.Controls.Add(Me.label9)
        Me.groupBox3.Controls.Add(Me.label10)
        Me.groupBox3.Controls.Add(Me.label11)
        Me.groupBox3.Controls.Add(Me.label12)
        Me.groupBox3.Controls.Add(Me.Date6)
        Me.groupBox3.Controls.Add(Me.Date5)
        Me.groupBox3.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.groupBox3.Location = New System.Drawing.Point(16, 348)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.groupBox3.Size = New System.Drawing.Size(984, 156)
        Me.groupBox3.TabIndex = 8
        Me.groupBox3.TabStop = false
        Me.groupBox3.Text = "التقرير مجمع لكل الخلطات خلال فترة "
        '
        'But_Show2
        '
        Me.But_Show2.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.But_Show2.Location = New System.Drawing.Point(262, 117)
        Me.But_Show2.Name = "But_Show2"
        Me.But_Show2.Size = New System.Drawing.Size(143, 33)
        Me.But_Show2.TabIndex = 43
        Me.But_Show2.Text = "اظهار البيانات"
        Me.But_Show2.UseVisualStyleBackColor = true
        '
        'ComWerk
        '
        Me.ComWerk.Enabled = false
        Me.ComWerk.FormattingEnabled = true
        Me.ComWerk.Items.AddRange(New Object() {"1", "2", "3"})
        Me.ComWerk.Location = New System.Drawing.Point(135, 94)
        Me.ComWerk.Name = "ComWerk"
        Me.ComWerk.Size = New System.Drawing.Size(121, 27)
        Me.ComWerk.TabIndex = 14
        '
        'comGroupName
        '
        Me.comGroupName.FormattingEnabled = true
        Me.comGroupName.Items.AddRange(New Object() {"الكل", "تقرير الوردية مفصل", "تقرير الوردية مجمع"})
        Me.comGroupName.Location = New System.Drawing.Point(135, 40)
        Me.comGroupName.Name = "comGroupName"
        Me.comGroupName.Size = New System.Drawing.Size(121, 27)
        Me.comGroupName.TabIndex = 13
        '
        'butShow3
        '
        Me.butShow3.Location = New System.Drawing.Point(24, 41)
        Me.butShow3.Name = "butShow3"
        Me.butShow3.Size = New System.Drawing.Size(105, 31)
        Me.butShow3.TabIndex = 12
        Me.butShow3.Text = "اظهار التقرير"
        Me.butShow3.UseVisualStyleBackColor = true
        '
        'label9
        '
        Me.label9.AutoSize = true
        Me.label9.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label9.Location = New System.Drawing.Point(273, 43)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(106, 19)
        Me.label9.TabIndex = 7
        Me.label9.Text = "انقر لاظهار التقرير"
        '
        'label10
        '
        Me.label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.label10.AutoSize = true
        Me.label10.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label10.Location = New System.Drawing.Point(841, 97)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(134, 19)
        Me.label10.TabIndex = 6
        Me.label10.Text = "انقر لنهاية تاريخ التقرير"
        '
        'label11
        '
        Me.label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.label11.AutoSize = true
        Me.label11.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label11.Location = New System.Drawing.Point(841, 46)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(132, 19)
        Me.label11.TabIndex = 5
        Me.label11.Text = "انقر لبداية تاريخ التقرير"
        '
        'label12
        '
        Me.label12.AutoSize = true
        Me.label12.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label12.Location = New System.Drawing.Point(273, 94)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(127, 19)
        Me.label12.TabIndex = 2
        Me.label12.Text = "انقر لختيار اسم الخلطة"
        '
        'Date6
        '
        Me.Date6.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date6.Location = New System.Drawing.Point(605, 91)
        Me.Date6.Name = "Date6"
        Me.Date6.Size = New System.Drawing.Size(200, 26)
        Me.Date6.TabIndex = 1
        Me.Date6.Value = New Date(2014, 12, 22, 0, 0, 0, 0)
        '
        'Date5
        '
        Me.Date5.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date5.Location = New System.Drawing.Point(605, 46)
        Me.Date5.Name = "Date5"
        Me.Date5.Size = New System.Drawing.Size(200, 26)
        Me.Date5.TabIndex = 0
        Me.Date5.Value = New Date(2014, 12, 22, 0, 0, 0, 0)
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.groupBox2.Controls.Add(Me.butShow2)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.label7)
        Me.groupBox2.Controls.Add(Me.Date2)
        Me.groupBox2.Controls.Add(Me.Date1)
        Me.groupBox2.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.groupBox2.Location = New System.Drawing.Point(14, 186)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.groupBox2.Size = New System.Drawing.Size(984, 156)
        Me.groupBox2.TabIndex = 7
        Me.groupBox2.TabStop = false
        Me.groupBox2.Text = "التقرير الاجمالى لكل الخامات خلال فترة محددة"
        '
        'butShow2
        '
        Me.butShow2.Location = New System.Drawing.Point(34, 82)
        Me.butShow2.Name = "butShow2"
        Me.butShow2.Size = New System.Drawing.Size(143, 38)
        Me.butShow2.TabIndex = 8
        Me.butShow2.Text = "اظهار التقرير"
        Me.butShow2.UseVisualStyleBackColor = true
        '
        'label5
        '
        Me.label5.AutoSize = true
        Me.label5.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label5.Location = New System.Drawing.Point(212, 98)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(106, 19)
        Me.label5.TabIndex = 7
        Me.label5.Text = "انقر لاظهار التقرير"
        '
        'label6
        '
        Me.label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.label6.AutoSize = true
        Me.label6.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label6.Location = New System.Drawing.Point(841, 97)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(134, 19)
        Me.label6.TabIndex = 6
        Me.label6.Text = "انقر لنهاية تاريخ التقرير"
        '
        'label7
        '
        Me.label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.label7.AutoSize = true
        Me.label7.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label7.Location = New System.Drawing.Point(841, 46)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(132, 19)
        Me.label7.TabIndex = 5
        Me.label7.Text = "انقر لبداية تاريخ التقرير"
        '
        'Date2
        '
        Me.Date2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date2.Location = New System.Drawing.Point(605, 91)
        Me.Date2.Name = "Date2"
        Me.Date2.Size = New System.Drawing.Size(200, 26)
        Me.Date2.TabIndex = 1
        Me.Date2.Value = New Date(2014, 12, 22, 20, 54, 0, 0)
        '
        'Date1
        '
        Me.Date1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date1.Location = New System.Drawing.Point(605, 46)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(200, 26)
        Me.Date1.TabIndex = 0
        Me.Date1.Value = New Date(2014, 12, 22, 20, 54, 0, 0)
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.But_Show)
        Me.groupBox1.Controls.Add(Me.Date_To)
        Me.groupBox1.Controls.Add(Me.Date_From)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.butShow)
        Me.groupBox1.Controls.Add(Me.comBatchName)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.groupBox1.Location = New System.Drawing.Point(14, 19)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.groupBox1.Size = New System.Drawing.Size(984, 161)
        Me.groupBox1.TabIndex = 6
        Me.groupBox1.TabStop = false
        Me.groupBox1.Text = "التقرير المفصل لجميع بيانات الخلطة خلال فترة "
        '
        'But_Show
        '
        Me.But_Show.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.But_Show.Location = New System.Drawing.Point(295, 111)
        Me.But_Show.Name = "But_Show"
        Me.But_Show.Size = New System.Drawing.Size(143, 33)
        Me.But_Show.TabIndex = 42
        Me.But_Show.Text = "اظهار البيانات"
        Me.But_Show.UseVisualStyleBackColor = true
        '
        'Date_To
        '
        Me.Date_To.CustomFormat = "yyyy/MM/dd hh:mm tt"
        Me.Date_To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date_To.Location = New System.Drawing.Point(618, 97)
        Me.Date_To.Name = "Date_To"
        Me.Date_To.Size = New System.Drawing.Size(200, 26)
        Me.Date_To.TabIndex = 11
        Me.Date_To.Value = New Date(2014, 12, 22, 0, 0, 0, 0)
        '
        'Date_From
        '
        Me.Date_From.CustomFormat = "yyyy/MM/dd hh:mm tt"
        Me.Date_From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date_From.Location = New System.Drawing.Point(618, 47)
        Me.Date_From.Name = "Date_From"
        Me.Date_From.Size = New System.Drawing.Size(200, 26)
        Me.Date_From.TabIndex = 10
        Me.Date_From.Value = New Date(2014, 12, 22, 0, 0, 0, 0)
        '
        'label4
        '
        Me.label4.AutoSize = true
        Me.label4.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label4.Location = New System.Drawing.Point(183, 111)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(106, 19)
        Me.label4.TabIndex = 7
        Me.label4.Text = "انقر لاظهار التقرير"
        '
        'label3
        '
        Me.label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.label3.AutoSize = true
        Me.label3.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label3.Location = New System.Drawing.Point(841, 97)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(134, 19)
        Me.label3.TabIndex = 6
        Me.label3.Text = "انقر لنهاية تاريخ التقرير"
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = true
        Me.label2.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label2.Location = New System.Drawing.Point(841, 46)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(132, 19)
        Me.label2.TabIndex = 5
        Me.label2.Text = "انقر لبداية تاريخ التقرير"
        '
        'butShow
        '
        Me.butShow.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.butShow.Location = New System.Drawing.Point(34, 104)
        Me.butShow.Name = "butShow"
        Me.butShow.Size = New System.Drawing.Size(143, 33)
        Me.butShow.TabIndex = 4
        Me.butShow.Text = "اظهار التقرير"
        Me.butShow.UseVisualStyleBackColor = true
        '
        'comBatchName
        '
        Me.comBatchName.FormattingEnabled = true
        Me.comBatchName.Items.AddRange(New Object() {"الكل"})
        Me.comBatchName.Location = New System.Drawing.Point(34, 47)
        Me.comBatchName.Name = "comBatchName"
        Me.comBatchName.Size = New System.Drawing.Size(143, 27)
        Me.comBatchName.TabIndex = 3
        '
        'label1
        '
        Me.label1.AutoSize = true
        Me.label1.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label1.Location = New System.Drawing.Point(183, 53)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(127, 19)
        Me.label1.TabIndex = 2
        Me.label1.Text = "انقر لختيار اسم الخلطة"
        '
        'FRM_Rpot_All
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1012, 518)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FRM_Rpot_All"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "شاشة اختيار التقرير"
        Me.groupBox3.ResumeLayout(false)
        Me.groupBox3.PerformLayout
        Me.groupBox2.ResumeLayout(false)
        Me.groupBox2.PerformLayout
        Me.groupBox1.ResumeLayout(false)
        Me.groupBox1.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ComWerk As System.Windows.Forms.ComboBox
    Friend WithEvents comGroupName As System.Windows.Forms.ComboBox
    Friend WithEvents butShow3 As System.Windows.Forms.Button
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents Date6 As System.Windows.Forms.DateTimePicker
    Private WithEvents Date5 As System.Windows.Forms.DateTimePicker
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents Date2 As System.Windows.Forms.DateTimePicker
    Private WithEvents Date1 As System.Windows.Forms.DateTimePicker
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Date_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Date_From As System.Windows.Forms.DateTimePicker
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents butShow As System.Windows.Forms.Button
    Private WithEvents comBatchName As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents But_Show As System.Windows.Forms.Button
    Private WithEvents But_Show2 As System.Windows.Forms.Button
    Private WithEvents butShow2 As System.Windows.Forms.Button
End Class
