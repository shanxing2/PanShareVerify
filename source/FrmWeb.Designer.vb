<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmWeb
    Inherits System.Windows.Forms.Form

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWeb))
        Me.Web1 = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'Web1
        '
        Me.Web1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Web1.Location = New System.Drawing.Point(0, 0)
        Me.Web1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Web1.Name = "Web1"
        Me.Web1.Size = New System.Drawing.Size(628, 433)
        Me.Web1.TabIndex = 1
        '
        'FrmWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 433)
        Me.Controls.Add(Me.Web1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmWeb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "登录专用浏览器 V1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Web1 As WebBrowser
End Class
