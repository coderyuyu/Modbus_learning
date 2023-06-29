Imports System.Xml
Imports System.IO
Imports System.IO.Ports
Imports EasyModbus
Imports System.Net
Imports System.Windows.Forms.AxHost

Module mPublic
    Public Const CHANNEL1 = "COM3"
    Public Const CHANNEL2 = "COM4"
    Class MSG
        Shared ReadOnly Property START_NG = "系統啟動失敗, 詳情請參閱Console"
        Shared ReadOnly Property START_OK = "系統啟動成功"
        Shared ReadOnly Property LOAD_SETTING_FAIL = "參數讀取失敗"
    End Class




    Public Class SETTINGS
        Shared ReadOnly Property SYSTEM_NAME = "風扇控制" ' Shared ReadOnly 表示該值不可改
        Shared ReadOnly Property SETTING_FILE = "setting.xml"
        Shared Property WarningDegree As Decimal = 40
        Shared Property FanOpenDegree As Decimal = 20
        Shared Property FanCloseDegree As Decimal = 15
        Shared Property Fan1On As Boolean = True
        Shared Property Fan2On As Boolean = True

        Shared Sub LoadSettingsFromFile()

            '            foreach(var prop In foo.GetType().GetProperties()) {
            '    Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
            '}


            Dim xml As New XmlDocument
            If File.Exists(GetSettingsFilePath()) Then
                Try
                    xml.Load(GetSettingsFilePath())
                    For Each p As XmlElement In xml.GetElementsByTagName("parameter")
                        Dim id As String = p.GetAttribute("id")
                        Select Case id
                            Case "WarningDegree"
                                WarningDegree = p.GetAttribute("value")
                            Case "FanOpenDegree"
                                FanOpenDegree = p.GetAttribute("value")
                            Case "FanCloseDegree"
                                FanCloseDegree = p.GetAttribute("value")
                            Case "Fan1On"
                                Fan1On = p.GetAttribute("value")
                            Case "Fan2On"
                                Fan2On = p.GetAttribute("value")
                        End Select
                    Next
                Catch ex As Exception
                    ' 如果有錯, 則放棄這個 xml
                    Debug.Print(ex.ToString)
                End Try
            End If
        End Sub

        Shared Sub SaveSettingsToFile()
            Dim xml As New XmlDocument
            Dim root As XmlElement = xml.CreateElement("system")
            Dim settings As XmlElement
            Dim filepath As String = GetSettingsFilePath()
            Dim parm As XmlElement
            root.SetAttribute("name", SYSTEM_NAME)
            xml.AppendChild(root)
            settings = xml.CreateElement("setting")
            root.AppendChild(settings)
            For Each key In paraArray().Keys
                parm = xml.CreateElement("parameter")
                With parm
                    '.SetAttribute("name", NameOf(obj))
                    .SetAttribute("id", key)
                    .SetAttribute("value", paraArray()(key))
                End With
                settings.AppendChild(parm)
            Next
            xml.Save(filepath)
        End Sub

        Shared Function paraArray() As Dictionary(Of String, String)
            Dim dic As New Dictionary(Of String, String)
            dic.Add(NameOf(WarningDegree), WarningDegree)
            dic.Add(NameOf(FanOpenDegree), FanOpenDegree)
            dic.Add(NameOf(FanCloseDegree), FanCloseDegree)
            dic.Add(NameOf(Fan1On), Fan1On)
            dic.Add(NameOf(Fan2On), Fan2On)
            Return dic
        End Function
        Shared Function GetSettingsFilePath()
            Return Application.StartupPath & "\" & SETTING_FILE
        End Function
    End Class

    ''' <summary>
    ''' 這個class需要在程式啟動之初實體化 (new)
    ''' 用於 TASK_READ, 快速不斷更新, 不做任何處理
    ''' 每個以時間+值配對
    ''' </summary>
    Public Class cDATA0
        Property Fan1Degree As Integer
        Property Fan1DegreeTime As DateTime
        Property Fan2Degree As Integer
        Property Fan2DegreeTime As DateTime
        Property Fan1On As Boolean
        Property Fan1OnTime As DateTime
        Property Fan2On As Boolean
        Property Fan2OnTime As DateTime
    End Class

    ''' <summary>
    ''' 這個class需要在程式啟動之初實體化 (new)
    ''' 用於 TASK_PROCESS, 定時由 DATA0 複製過來
    ''' 依需求設計 events 
    ''' </summary>
    Public Class cDATA1
        Dim varFan1Degree As Decimal = 0
        Dim varFan2Degree As Decimal = 0
        Dim varFan1On As Boolean = Nothing
        Dim varFan2On As Boolean = Nothing
        Dim varFan1DegreeTime As DateTime = Nothing
        Dim varFan2DegreeTime As DateTime = Nothing
        Dim varFan1OnTime As DateTime = Nothing
        Dim varFan2OnTime As DateTime = Nothing
        Property Fan1DegreeTime As DateTime
        Property Fan1Degree As Decimal
            Get
                Return varFan1Degree
            End Get
            Set(value As Decimal)
                If varFan1Degree <> value Then
                    varFan1Degree = value
                    RaiseEvent Fan1DegreeChange(varFan1DegreeTime, value)
                    Select Case value
                        Case >= SETTINGS.FanOpenDegree
                            If Not SETTINGS.Fan1On Then
                                RaiseEvent Fan1OnOff(varFan1DegreeTime, True)
                            End If
                        Case <= SETTINGS.FanCloseDegree
                            If SETTINGS.Fan1On Then
                                RaiseEvent Fan1OnOff(varFan1DegreeTime, False)
                            End If
                        Case Else

                    End Select

                End If
            End Set
        End Property
        Property Fan2DegreeTime As DateTime
        Property Fan2Degree As Decimal
            Get
                Return varFan2Degree
            End Get
            Set(value As Decimal)
                If varFan2Degree <> value Then
                    varFan2Degree = value
                    RaiseEvent Fan2DegreeChange(varFan2DegreeTime, value)
                    Select Case value
                        Case >= SETTINGS.FanOpenDegree
                            If Not SETTINGS.Fan2On Then
                                RaiseEvent Fan2OnOff(varFan1DegreeTime, True)
                            End If
                        Case <= SETTINGS.FanCloseDegree
                            If SETTINGS.Fan2On Then
                                RaiseEvent Fan2OnOff(varFan1DegreeTime, False)
                            End If
                        Case Else

                    End Select
                End If
            End Set
        End Property

        Property Fan1On As Boolean
        Property Fan1OnTime As DateTime
        Property Fan2On As Boolean
        Property Fan2OnTime As DateTime

        Public Event Fan1OnOff(HappenTime As DateTime, OnOffStatus As Boolean)
        Public Event Fan2OnOff(HappenTime As DateTime, OnOffStatus As Boolean)
        Public Event Fan1DegreeChange(HappenTime As DateTime, degree As Decimal)
        Public Event Fan2DegreeChange(HappenTime As DateTime, degree As Decimal)

        Sub New()

        End Sub
        Sub Update(D As cDATA0)
            With D
                Me.Fan1DegreeTime = .Fan1DegreeTime
                Me.Fan1Degree = .Fan1Degree / 10

                Me.Fan2DegreeTime = .Fan2DegreeTime
                Me.Fan2Degree = .Fan2Degree / 10

                Me.Fan1OnTime = .Fan1OnTime
                Me.Fan1On = .Fan1On

                Me.Fan2OnTime = .Fan2OnTime
                Me.Fan2On = .Fan1On
            End With
        End Sub

        Function LogString() As String
            Return $"{Format(Now, "yyyy-MM-dd HH:mm:ss")},{varFan1Degree},{varFan1On},{varFan1Degree},{varFan2On}"
        End Function

    End Class
    ''' <summary>
    ''' 宣告相關設定
    ''' </summary>
    Public Class RS ' resource
        ' 這裡用 Class 來宣告, 代表它是一個物件, 可以被實例化
        ' 但內容宣告都用 Shared, Shared 實體化物會共同使用該變數
        ' 以下面SETTING為例, 全都朂Shared, 因此實體化沒有意義
        Class SETTING ' 參數設定
            Shared ReadOnly Property SYSTEM_NAME = "風扇控制" ' Shared ReadOnly 表示該值不可改
            Shared ReadOnly Property SETTING_FILE = "setting.xml"
            Shared Property WarningDegree As Decimal = 40
            Shared Property FanOpenDegree As Decimal = 20
            Shared Property FanCloseDegree As Decimal = 15
            Shared Property Fan1On As Decimal = True
            Shared Property Fan2On As Decimal = True

        End Class
        ' 主畫面相關變數
        Class UI
            Shared Property START_BUTTON As String = FormMain.ButtonStart.Name
            Shared Property STATUS_LABEL As String = FormMain.status.Name
            Shared ReadOnly Property SYSTEM_NAME = "風扇控制"
            Shared ReadOnly Property BUTTON_START_TEXT As String = "Start" ' Start Button 文字
            Shared ReadOnly Property BUTTON_STOP_TEXT = "Stop"
            Shared ReadOnly Property BUTTON_STOPPING_TEXT = "Stopping"
        End Class
        ' 訊息文字集中管理
        Class MSG
            Shared ReadOnly Property START_NG = "系統啟動失敗, 詳情請參閱Console"
            Shared ReadOnly Property START_OK = "系統啟動成功"
            Shared ReadOnly Property LOAD_SETTING_FAIL = "參數讀取失敗"
        End Class


    End Class

    ''' <summary>
    ''' 控制組態
    ''' </summary>
    Public Class cSYS
        Property COMS As Dictionary(Of String, cCOM)
        Property TAGS As Dictionary(Of String, Array)
        Sub New()
            loadConfig()
        End Sub

        Sub ConnectAll()
            Dim com As cCOM
            For Each k In COMS.Keys
                com = COMS(k)
                com.Connect()
            Next
        End Sub

        Sub DisConnectAll()
            Dim com As cCOM
            For Each k In COMS.Keys
                com = COMS(k)
                com.DisConnect()
            Next
        End Sub
        ''' <summary>
        ''' 客戶監控組態 com ports 及 tags
        ''' 注意tagname不要重覆
        ''' </summary>
        Private Sub loadConfig()
            COMS = New Dictionary(Of String, cCOM)
            Dim com As cCOM
            com = New cCOM(CHANNEL1, Name:="第一組")
            With com
                .AddTag(New cTAG(tagName:="f1temp", slaveid:=1, registerAddress:=1, dataLength:=1))
                .AddTag(New cTAG(tagName:="f1onoff", slaveid:=1, registerAddress:=2, dataLength:=1))
            End With
            COMS.Add(com.SerialPort, com)
            com = New cCOM(CHANNEL2, Name:="第二組")
            With com
                .AddTag(New cTAG(tagName:="f2temp", slaveid:=1, registerAddress:=1, dataLength:=1))
                .AddTag(New cTAG(tagName:="f2onoff", slaveid:=1, registerAddress:=2, dataLength:=1))
            End With
            COMS.Add(com.SerialPort, com)
        End Sub
    End Class
    ''' <summary>
    ''' 定義COM port及其下的 slave, address (tag)
    ''' </summary>
    Public Class cCOM
        Property SerialPort As String
        Property Baudrate As Integer
        Property Parity As Parity = IO.Ports.Parity.None
        Property StopBits As StopBits = IO.Ports.StopBits.One
        Property Name As String = ""
        Property Tags As New Dictionary(Of String, cTAG)
        Property mbc As New ModbusClient
        Sub New(SerialPort As String,
                Optional Baudrate As Integer = 9600,
                Optional Parity As Parity = Parity.None,
                Optional StopBits As StopBits = StopBits.One, Optional Name As String = "")
            With Me
                .SerialPort = SerialPort
                .Baudrate = Baudrate
                .Parity = Parity
                .StopBits = StopBits
                .Name = Name
            End With
        End Sub
        Sub AddTag(tag As cTAG)
            If Not Tags.ContainsKey(tag.tagName) Then
                Tags.Add(tag.tagName, tag)
            End If
        End Sub
        ''' <summary>
        ''' 在 COM port 下增加一個TAG
        ''' </summary>
        ''' <param name="tagName">取一個方便記憶的文字</param>
        ''' <param name="slaveid"></param>
        ''' <param name="registerAddress"></param>
        ''' <param name="dataLength"></param>
        Sub AddTag(tagName As String, slaveid As Integer, registerAddress As Integer, dataLength As Integer)
            Dim tag As cTAG = New cTAG(tagName, slaveid, registerAddress, dataLength)
            If Not Tags.ContainsKey(tagName) Then
                Tags.Add(tagName, tag)
            End If
        End Sub
        ''' <summary>
        ''' 建立 modbus client 連線
        ''' </summary>
        Sub Connect()
            If Not mbc.Connected Then
                With mbc
                    .SerialPort = Me.SerialPort
                    .Baudrate = Me.Baudrate
                    .Parity = Me.Parity
                    .StopBits = Me.StopBits
                    .Connect()
                End With
            End If
        End Sub

        Sub DisConnect()
            If mbc.Connected Then
                mbc.Disconnect()
            End If
        End Sub

        Sub WriteTag(tagname As String, values As Integer())
            Dim tag As cTAG
            If Not mbc.Connected Then
                Me.Connect()
            End If
            If Me.Tags.ContainsKey(tagname) Then
                tag = Tags(tagname)
                SyncLock mbc
                    With tag
                        mbc.UnitIdentifier = .slaveid
                        mbc.WriteMultipleRegisters(.registerAddress, values)
                    End With
                End SyncLock
            End If
        End Sub

        Function ReadTag(tagname) As Integer()
            Dim tag As cTAG
            Dim values = Nothing
            If Not mbc.Connected Then
                Me.Connect()
            End If
            If Me.Tags.ContainsKey(tagname) Then
                SyncLock mbc
                    tag = Tags(tagname)
                    With tag
                        mbc.UnitIdentifier = .slaveid
                        values = mbc.ReadHoldingRegisters(.registerAddress, tag.dataLength)
                    End With
                End SyncLock
            End If
            Return values
        End Function
    End Class

    Public Class cTAG
        Property tagName As String
        Property slaveid As Integer
        Property registerAddress As Integer
        Property dataLength As Integer
        Public Sub New(tagName As String, slaveid As Integer, registerAddress As Integer, dataLength As Integer)
            Me.tagName = tagName
            Me.slaveid = slaveid
            Me.registerAddress = registerAddress
            Me.dataLength = dataLength
        End Sub
    End Class

    ''' <summary>
    ''' 通用LOG元件
    ''' 
    ''' </summary>
    Public Class LOGGER
        Shared locker As New Object
        Shared logHeader As New Dictionary(Of String, String)
        Shared Sub AddLogHeader(logtype As String, header As String)
            logtype = logtype.ToLower
            If Not logHeader.ContainsKey(logtype) Then
                logHeader.Add(logtype, header)
            End If
        End Sub

        Shared Sub WriteLog(logtype As String, text As String, Optional isAddDateTime As Boolean = False)
            Dim logs As New List(Of String)
            logs.Add(text)
            WriteLog(logtype.ToLower, logs, isAddDateTime)
        End Sub

        Shared Sub WriteLog(logtype As String, logs As List(Of String), Optional isAddDateTime As Boolean = False)
            Dim logFileName As String = PrepareLogFile(logtype.ToLower)
            SyncLock locker
                DoWriteLog(logs, logFileName, isAddDateTime)
            End SyncLock
        End Sub

        Private Shared Function PrepareLogFile(logtype As String) As String
            'Dim logPath As String = Path.Combine(Application.StartupPath, "logs") ' LOG預設存檔位置在程式下logs子目錄
            Dim logFileName As String = Path.Combine(LogPath, $"{logtype}_{Format(Now, "yyyy-MM-dd")}.log")
            If Not Directory.Exists(LogPath) Then
                Directory.CreateDirectory(LogPath)
            End If
            If Not File.Exists(logFileName) Then
                Using sw = File.CreateText(logFileName)
                    If logHeader.ContainsKey(logtype) Then
                        sw.WriteLine(logHeader(logtype))
                    End If
                End Using
            End If
            Return logFileName
        End Function

        Shared Function LogPath() As String
            Return Path.Combine(Application.StartupPath, "logs")
        End Function
        Private Shared Sub DoWriteLog(list As List(Of String), logfileName As String, isAddDateTime As Boolean)
            Using sw As New StreamWriter(File.Open(logfileName, FileMode.Append))
                For Each line In list
                    If isAddDateTime Then
                        sw.WriteLine($"{Format(Now, "yyyy-MM-dd HH:mm:ss")},{line}")
                    Else
                        sw.WriteLine($"{line}")
                    End If
                Next
            End Using
        End Sub
    End Class

End Module
