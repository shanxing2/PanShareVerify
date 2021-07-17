Imports ShanXingTech.Net2.BaiduNetdisk
Imports ShanXingTech

Public Class FrmSetting

    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        txtSharePrivatePassword.Text = Conf2.Instance.BdVerifierConf.SharePrivatePassword
        txtVerifyPrivatePassword.Text = Conf2.Instance.BdVerifierConf.VerifyPrivatePassword

        cmbVerifyExpirationDate.Items.AddRange({ShareExpirationDate.Forever.GetDescription,
                                              ShareExpirationDate.OneDay.GetDescription,
                                              ShareExpirationDate.SevenDay.GetDescription})
        cmbShareExpirationDate.Items.AddRange({ShareExpirationDate.Forever.GetDescription,
                                              ShareExpirationDate.OneDay.GetDescription,
                                              ShareExpirationDate.SevenDay.GetDescription})
        cmbShareExpirationDate.Text = Conf2.Instance.BdVerifierConf.ShareExpirationDate.GetDescription
        cmbVerifyExpirationDate.Text = Conf2.Instance.BdVerifierConf.VerifyExpirationDate.GetDescription
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Conf2.Instance.BdVerifierConf.VerifyPrivatePassword = txtVerifyPrivatePassword.Text.Trim
        Conf2.Instance.BdVerifierConf.SharePrivatePassword = txtSharePrivatePassword.Text.Trim

        Select Case cmbVerifyExpirationDate.Text
            Case ShareExpirationDate.Forever.GetDescription
                Conf2.Instance.BdVerifierConf.VerifyExpirationDate = ShareExpirationDate.Forever
            Case ShareExpirationDate.OneDay.GetDescription
                Conf2.Instance.BdVerifierConf.VerifyExpirationDate = ShareExpirationDate.OneDay
            Case ShareExpirationDate.SevenDay.GetDescription
                Conf2.Instance.BdVerifierConf.VerifyExpirationDate = ShareExpirationDate.SevenDay
        End Select

        Select Case cmbShareExpirationDate.Text
            Case ShareExpirationDate.Forever.GetDescription
                Conf2.Instance.BdVerifierConf.ShareExpirationDate = ShareExpirationDate.Forever
            Case ShareExpirationDate.OneDay.GetDescription
                Conf2.Instance.BdVerifierConf.ShareExpirationDate = ShareExpirationDate.OneDay
            Case ShareExpirationDate.SevenDay.GetDescription
                Conf2.Instance.BdVerifierConf.ShareExpirationDate = ShareExpirationDate.SevenDay
        End Select

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class