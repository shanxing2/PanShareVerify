<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetting
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtVerifyPrivatePassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbVerifyExpirationDate = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbShareExpirationDate = New System.Windows.Forms.ComboBox()
        Me.txtSharePrivatePassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtVerifyPrivatePassword
        '
        Me.txtVerifyPrivatePassword.Location = New System.Drawing.Point(54, 20)
        Me.txtVerifyPrivatePassword.MaxLength = 4
        Me.txtVerifyPrivatePassword.Name = "txtVerifyPrivatePassword"
        Me.txtVerifyPrivatePassword.ReadOnly = True
        Me.txtVerifyPrivatePassword.Size = New System.Drawing.Size(121, 21)
        Me.txtVerifyPrivatePassword.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "提取码："
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbVerifyExpirationDate)
        Me.GroupBox1.Controls.Add(Me.txtVerifyPrivatePassword)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(182, 147)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "检测"
        '
        'cmbVerifyExpirationDate
        '
        Me.cmbVerifyExpirationDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVerifyExpirationDate.FormattingEnabled = True
        Me.cmbVerifyExpirationDate.Location = New System.Drawing.Point(54, 47)
        Me.cmbVerifyExpirationDate.Name = "cmbVerifyExpirationDate"
        Me.cmbVerifyExpirationDate.Size = New System.Drawing.Size(121, 20)
        Me.cmbVerifyExpirationDate.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "有效期："
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(226, 165)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 22
        Me.btnOK.Text = "确定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(307, 165)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbShareExpirationDate)
        Me.GroupBox2.Controls.Add(Me.txtSharePrivatePassword)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(203, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(182, 147)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "分享"
        '
        'cmbShareExpirationDate
        '
        Me.cmbShareExpirationDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShareExpirationDate.FormattingEnabled = True
        Me.cmbShareExpirationDate.Location = New System.Drawing.Point(54, 47)
        Me.cmbShareExpirationDate.Name = "cmbShareExpirationDate"
        Me.cmbShareExpirationDate.Size = New System.Drawing.Size(121, 20)
        Me.cmbShareExpirationDate.TabIndex = 0
        '
        'txtSharePrivatePassword
        '
        Me.txtSharePrivatePassword.Location = New System.Drawing.Point(54, 20)
        Me.txtSharePrivatePassword.MaxLength = 4
        Me.txtSharePrivatePassword.Name = "txtSharePrivatePassword"
        Me.txtSharePrivatePassword.ReadOnly = True
        Me.txtSharePrivatePassword.Size = New System.Drawing.Size(121, 21)
        Me.txtSharePrivatePassword.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "有效期："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "提取码："
        '
        'FrmSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 200)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSetting"
        Me.Text = "全局设置"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtVerifyPrivatePassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbVerifyExpirationDate As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbShareExpirationDate As ComboBox
    Friend WithEvents txtSharePrivatePassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
