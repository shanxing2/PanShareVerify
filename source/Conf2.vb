Imports ShanXingTech

''' <summary>
''' 配置信息辅助类。由于VB.NET自带的 <see cref="My.Settings"/> 工具处于调试模式时，可能不按照预期运行（不保存用户设置值），因此造此类以替代。
''' 需要添加配置项时可往实体中添加属性，同时，可以给配置项设置默认属性（建议在构造函数里面延迟设置属性值）
''' 20191217
''' </summary>
<Serializable>
Friend NotInheritable Class Conf2
    Inherits ConfBase

#Region "属性区"
    ''' <summary>
    ''' 配置信息类实例。使用此实例访问或者设置配置信息的值,请勿更改此属性
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property Instance As Conf2
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
    Public Property BdVerifierConf As BdVerifierConf
#End Region

#Region "构造函数"
    ''' <summary>
    ''' 类构造函数
    ''' 类之内的任意一个静态方法第一次调用时调用此构造函数
    ''' 而且程序生命周期内仅调用一次
    ''' </summary>
    Shared Sub New()
        Try
            Dim path = Instance.GetLocalInstanceStorePath(NameOf(Conf2))

            Instance.BinaryDeserialize(path)
        Catch ex As Exception
            Throw
        Finally
            If Instance Is Nothing Then
                Instance = New Conf2
            End If
        End Try
    End Sub

    Sub New()
        ' 只有第一次使用的时候（退出的时候正常保存了配置文件），才会进入到此构造器
        APPName = "网盘违规文件检测姬  - 快速查出百度网盘分享文件中的违规文件  By 胖头鱼煲汤好好次 Q2287190283"
        BdVerifierConf = New BdVerifierConf With {
            .SharePrivatePassword = "ptyo",
            .VerifyPrivatePassword = "6666",
            .VerifyExpirationDate = Net2.BaiduNetdisk.ShareExpirationDate.SevenDay,
            .ShareExpirationDate = Net2.BaiduNetdisk.ShareExpirationDate.SevenDay,
            .Order = Net2.BaiduNetdisk.OrderMode.name,
            .Desc = False
        }
    End Sub
#End Region
End Class
