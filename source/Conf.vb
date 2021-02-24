Imports ShanXingTech

''' <summary>
''' 配置信息辅助类。由于VB.NET自带的 <see cref="My.Settings"/> 工具处于调试模式时，可能不按照预期运行（不保存用户设置值），因此造此类以替代。
''' 需要添加配置项时可往实体中添加属性，同时，可以给配置项设置默认属性（建议在构造函数里面延迟设置属性值）
''' 20191217
''' </summary>
Friend NotInheritable Class Conf

#Region "字段区"
    Private Shared ReadOnly m_ConfPath As String
#End Region

#Region "属性区"
    ''' <summary>
    ''' 配置信息类实例。使用此实例访问或者设置配置信息的值,请勿更改此属性
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property Instance As Conf
    ''' <summary>
    ''' 产品名
    ''' </summary>
    ''' <returns></returns>
    Public Property ProductName As String
    ''' <summary>
    ''' 软件名
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property APPName As String
    ''' <summary>
    ''' 上一次浏览目录
    ''' </summary>
    ''' <returns></returns>
    Public Property LastBrowseFolder As String
#End Region

#Region "构造函数"
    ''' <summary>
    ''' 类构造函数
    ''' 类之内的任意一个静态方法第一次调用时调用此构造函数
    ''' 而且程序生命周期内仅调用一次
    ''' </summary>
    Shared Sub New()
        Try
            Dim productName = Reflection.Assembly.GetExecutingAssembly.GetName.Name
            ' 最终路径 C:\ProgramData\ShanXingTech\{产品名}\conf.json
            m_ConfPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
            m_ConfPath = If("\"c = m_ConfPath.Chars(m_ConfPath.Length - 1),
                $"{m_ConfPath}ShanXingTech\{productName}\conf.conf",
                $"{m_ConfPath}\ShanXingTech\{productName}\conf.conf")
            If Not IO.Directory.Exists(m_ConfPath) Then
                IO2.Directory.Create(m_ConfPath)
            End If

            Dim json = If(IO.File.Exists(m_ConfPath),
                IO2.Reader.ReadFile(m_ConfPath, Text.Encoding.UTF8).FromHexString(True),
                New Conf With {.ProductName = productName}.Serialize)

            Instance = MSJsSerializer.Deserialize(Of Conf)(json)
        Catch ex As Exception
            Throw
        Finally
            If Instance Is Nothing Then
                Instance = New Conf
            End If
        End Try
    End Sub

    Sub New()
        APPName = "PanVerify - 快速查出百度网盘分享文件中的违规文件"
    End Sub
#End Region

#Region "函数区"
    ''' <summary>
    ''' 保存配置（持久化配置信息）
    ''' </summary>
    Public Sub Save()
        Try
            Dim json = Instance.Serialize.ToHexString(UpperLowerCase.Upper, True)
            If json.Length = 0 Then Return

            IO2.Writer.WriteText(m_ConfPath, json, IO.FileMode.Create, IO2.CodePage.UTF8)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class
