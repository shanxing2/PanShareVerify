Imports System.ComponentModel
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Text.RegularExpressions

Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms

Imports ShanXingTech
Imports ShanXingTech.Net2
Imports ShanXingTech.Text2

''' <summary>
''' 闪星网络信息科技 Q2287190283
''' 神即道, 道法自然, 如来
''' </summary>
Public Class FrmWeb
#Region "事件区"
    Public Event WebView2Initing As EventHandler(Of WebView2Info)
#End Region

#Region "字段区"
    Private WithEvents m_WebView2 As WebView2
    Private WithEvents m_CoreWebView2 As CoreWebView2
#End Region
#Region "属性区"
    ''' <summary>
    ''' 需要访问的地址
    ''' </summary>
    Public Property Url As String
    Public Property OperateUrl As String

    Private m_NeedReload As Boolean
    Public ReadOnly Property NeedReload() As Boolean
        Get
            Return m_NeedReload
        End Get
    End Property

#End Region


#Region "构造函数"
    Sub New(ByVal url As String)

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        Me.Url = url
    End Sub
#End Region

#Region "IDisposable Support"
    ' 要检测冗余调用
    Dim isDisposed2 As Boolean = False

    ''' <summary>
    ''' 重写Dispose 以清理非托管资源
    ''' </summary>
    ''' <param name="disposing"></param>
    Protected Overrides Sub Dispose(disposing As Boolean)
        ' 窗体内的控件调用Close或者Dispose方法时，isDisposed2的值为True
        If isDisposed2 Then Return

        ' TODO: 释放托管资源(托管对象)。
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
                components = Nothing
            End If
        End If

        ' TODO: 释放未托管资源(未托管对象)并在以下内容中替代 Finalize()。
        ' TODO: 将大型字段设置为 null。
        isDisposed2 = True
    End Sub

    ' NOTE: Leave out the finalizer altogether if this class doesn't   
    ' own unmanaged resources itself, but leave the other methods  
    ' exactly as they are.   
    'Protected Overrides Sub Finalize()
    '    Try
    '        ' Finalizer calls Dispose(false)  
    '        Dispose(False)
    '    Finally
    '        MyBase.Finalize()
    '    End Try
    'End Sub
#End Region


    Private Sub FrmWeb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If m_WebView2 Is Nothing Then
            m_WebView2 = New WebView2 With {
                .Dock = DockStyle.Fill,
                .Source = New Uri(Me.Url)
            }

            Me.Controls.Add(m_WebView2)
        End If
    End Sub

    Private Sub m_WebView2_CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) Handles m_WebView2.CoreWebView2InitializationCompleted
        With m_WebView2.CoreWebView2
            .Settings.AreDevToolsEnabled = True
            .Settings.IsPasswordAutosaveEnabled = False
            .IsMuted = True
        End With

        m_CoreWebView2 = m_WebView2.CoreWebView2

        AddHandler m_WebView2.CoreWebView2.NewWindowRequested, AddressOf m_CoreWebView2_NewWindowRequested
    End Sub

    Public Async Function CaptrueCookiesAsync() As Task
        If Me.IsDisposed Then
            Return
        End If

        If m_CoreWebView2 Is Nothing Then
            m_WebView2.Visible = False
        End If

        Dim cookies = Await m_CoreWebView2.CookieManager.GetCookiesAsync(m_CoreWebView2.Source)
        Dim cookieKvp = cookies.ToKeyValuePairs(False)

        ' 经过观察，Cookie 有 "XFCS" 表示登录成功(新版旧版通用)
        If cookies Is Nothing OrElse cookieKvp.IndexOf("XFCS") = -1 Then Return

        OperateUrl = m_WebView2.Source.AbsoluteUri

        ' 如果已经登录 则获取cookie
        If OperateUrl.IsNullOrEmpty Then Return

        Conf2.Instance.BdVerifierConf.BdCookies.GetFromKeyValuePairs(cookieKvp, OperateUrl)

        HttpAsync.Instance.ReInit(Conf2.Instance.BdVerifierConf.BdCookies)

        Dim loginedInfo = BdVerifier.GetLoginInfo(cookieKvp)
        Conf2.Instance.BdVerifierConf.BdsToken = loginedInfo.BdsToken
        Conf2.Instance.BdVerifierConf.BdUSS = loginedInfo.BdUSS
    End Function

    Private Async Sub Web1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        Await LocateLoginFrameAsync()
    End Sub

    Private Async Sub FrmWeb_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Await LocateLoginFrameAsync()
    End Sub

    ''' <summary>
    ''' 定位到登录框（在浏览器窗口可见范围内能看到登录框）
    ''' </summary>
    Private Async Function LocateLoginFrameAsync() As Task
        If m_CoreWebView2 Is Nothing Then Return

        ' 底部齐平
        Dim js = "var loginFrame = document.getElementById('login-middle');
        if (loginFrame != null) {loginFrame.scrollIntoView(false)};
        "

        Await m_CoreWebView2.ExecuteScriptAsync(js)
    End Function

    Public Async Function EnsureWebview2Installsync(ByVal installSlient As Boolean) As Task(Of Boolean)
        ' 判断是否安装  webview2 运行时
        Dim errMessage As String
        Dim dlgRst As DialogResult
        Dim pv As Object
        Try
            pv = If(Environment.Is64BitOperatingSystem,
                Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\EdgeUpdate\Clients\{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}"， "pv"， Nothing),
                Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\EdgeUpdate\Clients\{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}"， "pv"， Nothing))
        Catch ex As Exception
            errMessage = ex.Message
            Logger.WriteLine(ex)
            Return False
        End Try

        If pv IsNot Nothing Then
            Return True
        End If

#Disable Warning BC42104 ' 在为变量赋值之前，变量已被使用
        If Not String.IsNullOrEmpty(errMessage) Then
#Enable Warning BC42104 ' 在为变量赋值之前，变量已被使用
            MessageBox.Show(errMessage, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            RaiseEvent WebView2Initing(Me, New WebView2Info(WebView2Info.InitStatus.Unknow))
            Return False
        End If

        dlgRst = MessageBox.Show("软件检测到浏览器组件缺失，请问是否下载并安装？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dlgRst = DialogResult.None OrElse dlgRst = DialogResult.No Then
            Return False
        End If

        RaiseEvent WebView2Initing(Me, New WebView2Info(WebView2Info.InitStatus.DownloadBegin))
        Dim runtimeFileFullPath = IO.Path.GetFullPath(IO.Path.Combine("temp", "MicrosoftEdgeWebview2Setup.exe"))
        Dim downloadRuntimeSuccess = Await DownloadWebView2RuntimeAsync(runtimeFileFullPath, 3)
        RaiseEvent WebView2Initing(Me, New WebView2Info(If(downloadRuntimeSuccess, WebView2Info.InitStatus.DownloadSuccess, WebView2Info.InitStatus.DownloadFailure)))

        If Not downloadRuntimeSuccess Then
            MessageBox.Show($"下载{If(downloadRuntimeSuccess, "成功", "失败")}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        RaiseEvent WebView2Initing(Me, New WebView2Info(WebView2Info.InitStatus.InstallBegin))
        Dim installRuntimeSuccess = InstallWebview2Runtime(runtimeFileFullPath, installSlient)
        RaiseEvent WebView2Initing(Me, New WebView2Info(If(installRuntimeSuccess, WebView2Info.InitStatus.InstallSuccess, WebView2Info.InitStatus.InstallFailure)))
        If installRuntimeSuccess Then
            MessageBox.Show("浏览器组件安装成功，重新打开此模块后生效", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("浏览器组件安装失败，请检查网络后重新打开此模块", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return installRuntimeSuccess
    End Function

    ''' <summary>
    ''' 下载Webview2运行时
    ''' </summary>
    ''' <param name="fileFullPath">运行时存储路径</param>
    ''' <param name="tryTime">尝试下载次数</param>
    ''' <returns></returns>
    Private Async Function DownloadWebView2RuntimeAsync(ByVal fileFullPath As String, Optional ByVal tryTime As Integer = 3) As Task(Of Boolean)
        Dim i As Integer
        Dim success As Boolean
        Do
            Try
                Dim uri As New Uri("https://go.microsoft.com/fwlink/p/?LinkId=2124703")

                'HttpAsync.Instance.ReInit(Nothing, False)
                'Dim rst = Await HttpAsync.Instance.TryDownloadFileAsync("https://go.microsoft.com/fwlink/p/?LinkId=2124703", fileName, 1)
                'Using webClient As New Net.WebClient
                '    Dim ccc = Await webClient.DownloadDataTaskAsync(uri)
                'End Using

                Dim httpHandle As New HttpClientHandler With {
                    .AllowAutoRedirect = False,
                    .AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
                }
                Using httpClient As New HttpClient(httpHandle)
                    Dim rst2 = Await httpClient.GetAsync(uri)
                    If rst2.StatusCode <> Net.HttpStatusCode.Moved Then
                        success = False
                        Exit Try
                    End If

                    Dim location = rst2.Headers.Location
                    If location Is Nothing Then
                        success = False
                        Exit Try
                    End If

                    Dim fileBytes = Await httpClient.GetByteArrayAsync(location)
                    If fileBytes.Length = 0 Then
                        success = False
                        Exit Try
                    End If

                    Dim path = IO.Path.GetDirectoryName(fileFullPath)

                    If Not IO.Directory.Exists(path) Then
                        IO.Directory.CreateDirectory(path)
                    End If
                    Using writer = New IO.FileStream(fileFullPath, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.ReadWrite, 10240)
                        Await writer.WriteAsync(fileBytes, 0, fileBytes.Length)
                    End Using
                End Using

                success = True
            Catch ex As Exception
                Logger.WriteLine(ex)
            End Try

            i += 1
        Loop Until success OrElse i >= tryTime

        Return success
    End Function

    Private Function InstallWebview2Runtime(ByVal runtimeFileName As String, ByVal installSlient As Boolean) As Boolean
        ' MicrosoftEdgeWebview2Setup.exe /silent /install
        Dim cmdRst = Windows2.CmdRunOnlyReturnResult($"{runtimeFileName} /install{If(installSlient, " /slient", String.Empty)}")
        'If cmdRst.Length > 0 Then
        '    MessageBox.Show("浏览器组件安装失败，请联系开发者", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If

        Return cmdRst.Length = 0
    End Function

    Private Sub m_CoreWebView2_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs)
        e.NewWindow = m_WebView2.CoreWebView2
        e.Handled = True
    End Sub
End Class