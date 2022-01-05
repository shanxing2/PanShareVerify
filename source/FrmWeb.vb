Imports System.ComponentModel
Imports ShanXingTech
Imports ShanXingTech.Net2

''' <summary>
''' 闪星网络信息科技 Q2287190283
''' 神即道, 道法自然, 如来
''' </summary>
Public Class FrmWeb
    ''' <summary>
    ''' 需要访问的地址
    ''' </summary>
    Public Shared Property Url As String
    Public Shared Property OperateUrl As String

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
        If Url.IsNullOrEmpty Then
            MessageBox.Show(String.Concat("Url未初始化,请先设置", Me.Name, ".Url属性"), My.Resources.MsgCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 不显示脚本错误等信息
        Web1.ScriptErrorsSuppressed = True
        Web1.ChangeUserAgent("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36 SE 2.X MetaSr 1.0")
        ' 消除网页加载嘟嘟声
        Web1.DisableNavigationSounds(True)
        ' 如果已经登录 就不需要再次加载登录页了
        If Not OperateUrl.IsNullOrEmpty Then Return

        ' 改变程序内部IE浏览器默认的版本号
        ' app.exe and app.vshost.exe
        Dim appname As String = String.Concat(Process.GetCurrentProcess().ProcessName, ".exe")
        ' 改变程序内部IE浏览器默认的版本号
        ' 注意：如果是淘宝，想要快捷登录（识别已经登录的旺旺），需要设置 项目——属性——编译——目标CPU——勾选首选32位
        Web1.SetVersionEmulation(BrowserEmulationMode.IE11, appname)

#Region "多线程加载网页"
        ' 多线程加载网页(WebBrowser只能是单线程单元)
        ' 因为task模型不能直接设置Threading.ApartmentState.STA，所以这里目前只能用Threading.Thread实现 20170924
        ' 此处必须加载先一个页面，这里用about:blank，否则会发生“无法获取“WebBrowser”控件的窗口句柄。不支持无窗口的 ActiveX 控件。”错误
        Web1.Navigate("about:blank")
        		Dim newThread As New Threading.Thread(Sub()
												  Try
													  Web1.Navigate(Url)
												  Catch ex As Exception
													  MessageBox.Show("加载网页失败，请关闭网页后重新打开再试", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
												  End Try
											  End Sub)
        ' 多线程操作webbrowser控件，一定要设置为 STA 模式
        newThread.TrySetApartmentState(Threading.ApartmentState.STA)

        ' 获取程序内部使用的IE内核浏览器版本
        'url = "http://ie.icoa.cn/"

        ' 如果已经有登录之后的cookie  可以直接去往目标地址
        newThread.Start()
#End Region
    End Sub

    Private Sub FrmWeb_FormClosing(sender As Object, e As CancelEventArgs) Handles Me.FormClosing
        ' 启用消除网页加载嘟嘟声
        Web1.DisableNavigationSounds(False)


        If Web1.Document Is Nothing Then Return
        ' 经过观察，Cookie 有 "XFCS" 表示登录成功(新版旧版通用)
        If Web1.Document.Cookie IsNot Nothing AndAlso Web1.Document.Cookie.IndexOf("XFCS") > -1 Then
            OperateUrl = Web1.Url.AbsoluteUri

            ' 如果已经登录 则获取cookie
            If Not OperateUrl.IsNullOrEmpty Then
                ' 获取webbrowser登录成功后的cookie,需要带上登录成功后的URL
                ' 而且 也需要从 Web1.Document.Cookie 处获取cookie，否则会漏掉一些cookie(跟Operate.OperateUrl不属于同一个域的cookie)
                ' 不同页面，Domain不一样，视具体情况而定
                Conf2.Instance.BdVerifierConf.BdCookies.GetFromKeyValuePairs(Web1.Document.Cookie, OperateUrl)
                Conf2.Instance.BdVerifierConf.BdCookies.GetFromUrl(OperateUrl)

                HttpAsync.Instance.ReInit(Conf2.Instance.BdVerifierConf.BdCookies)

                Dim html = Web1.Document.Body.InnerHtml
                Dim loginedInfo = BdVerifier.GetLoginInfo(html)
                Conf2.Instance.BdVerifierConf.BdsToken = loginedInfo.BdsToken
                Conf2.Instance.BdVerifierConf.BdUSS = loginedInfo.BdUSS
            End If
        End If
    End Sub
End Class