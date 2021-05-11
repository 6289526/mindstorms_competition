'                                              ```                                                   
'                                              sy/                                                   
'                    L2 6                      hhy-                  R2 7                                
'                    L1 4                     ohhh/                  R1 5
'                     `.:/:                   yhhho                  `//-.                           
'               `-:+oyhhhhdyyo:`             `+hhy/              -sy+oyhdddys+:.`                    
'           -+syhhhdddddddhh/--\:::::::::::::+dhhdh:::::::::::/sd/--\sssssyhhdddhs+`                
'          .hdddmmddhyysssss|  |yddddddhhhhhhddddddhhhhhhhhhhhddh|  |hhhhyyysssssyhhs
'        .dmmdhyo+/// +++oyh|SH|hdhhhhhhhhhhhddhhddhdddddddddddmh|OP|dhhhhdddhhhhyyys +`              
'        `hmdso++/+//+++ooyd|09|dNmmmmmmmmmmm      mmmmmmmmmmmmNh|09|dhhhhd/----\ddddss/              
'        smmyo+++ossssssyyys\--/dmmmmmmmmmmmm  PD  mmmmmmmmmmmmNNh\--/yyhhdh| △ |dddyss:              
'       +mmdsoshmmmmmmmdyyyyyhhhdmmmmmmmmmmmm  13  mmmmmmmmmmmmNhhhhhhhhhdd| TR |dddddsss.            
'      -mmmyshmNm  +y mNdyhhhhhdNmmmmmmmmmmmm      mmmmmmmmmmNNNhhhhd/----\| 03 |/----\so`           
'      hmmdshmNm   ↑   mNhyhhhhdmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmNhhddy| □ |\----/| 02 |yys/           
'     mmmysdmN -x←10→+x NyhhhhdmmmmmmmmmmmNmmmNmmmNmmmNNmmNNNdhddsh| SQ |dddddm| CI |dyys.
'    `hmmdyshhNNm  ↓   Nhhhhhhhmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmhhhdd| 00 |dddddd| ○ |dhyy+          
'    mmmdyyyyydNNm -y Nmhyhhhhhhhhhhhyyysydddhhhhddddyyyyyhhhhhhhhhdd\----//----\\----/hhhs.
'    ommmdhyyyyyyhddddhyyhhhhhhmmddmdhhhhhmddmdhhhmddmdddhhdmmmdhmmdhddddmh| 01 |ddddddhhhy
'   .ymmmddhyysyyyyyyyhhhhhhhhhNdddmmhhhhhddddhhhhddmddhdmNNm     Nmhdddddd| CR |ddddddhddh+`        
'   /hmmmdddhyyyyyyyyhhhhhhmdddmddddmddddhhhdhhhdddddddhNNmm   ↑  NNmhdddd| ☓ |dddddddddhs-        
'  `ohmmmmdddhyyyyyyyhhhhhdmddddddhhhhhhNhhhhh/----\mdddddNN ←11→  Nddddd\----/dddddddddhs/        
'  -shmmmmdddddhhyyyhhhhhhdmmmmmdhhhddddmhhhhd| PS |ddddmNmmm  ↓  NNyhdddddddddddddddddddhyo`       
'  /ydmmmmmmdddddddhhhhhhhhddddNdhhdmddddhhhhh| 12 |dddhyhNmmN    NNhyddddddddddddddddddddys-       
' `oydmmmmmmmmdddddddddddddddddNdddmmhhhhyyssh\----/dydddyyhddmmddhyhddddddddddddddddddddddhs/       
' .shdmmmmmmmmmddddddddddddhhhhhhhhyyssssssssoooosoosssssssoo+ooosyhhddddddddddddddddddddddhy +`      
' -shdmmmmmmmmmmmmddddhhyyssoo++//:--....```````````````...--://+oossyyyhdddmmmmddddddmdddhyo.      
' /yhdmmmmmmmmmmddddhyyssoo+//:-.``                           ``.-:/++ossyyhhddddddddmdddddhys-      
' +yhdmmmmmmmmdddhhhyysso+/:-.`                                   `.-/+oosyyyhhhdddddddddddhys:      
' +yhddddmmdddhhhhyyysso+/-`       v min mid max                    `.-/+ossyyhhhhhdddddddhhys/      
'`oyhhddddddhhhhhyyyso+/-`         x   0  50 100                       .:+osyyyyhhhhhhdddhhhys/      
'`+yyhhhhhhhhhhyyyyso+:.           y   0  50 100                         -/ossyyyyhhhhhhhhhhys/      
'`+yyhhhhhhhhyyyyyso+-`            z   0  50 100                          `:+ssyyyyyhhhhhhhhys/      
' +syyyyhyyyyyyyyso/.                                                       -+osyyyyyyyhhhyyys      
' osyyyyyyyyysso+: `                                                         ./ossyyyyyyyyyyso-      
' `+osyyyysssso+:.                                                             ./oosssyyyysso/`      
'  .: +oooooo+/-.                                                                 .:/+oooooo+:`       
'    `..--..`                                                                       `......`         

Imports SlimDX.DirectInput
Imports System.IO.Ports

Public Class EV3
    Private m_JoysTick As Joystick
    Private m_JoysticSt As JoystickState
    Private N As Integer = 0
    Dim tex As String = ""
    Private ReadOnly SQUARE As Integer = 0
    Private ReadOnly CROSS As Integer = 1
    Private ReadOnly CIRCLE As Integer = 2
    Private ReadOnly TRIANGLE As Integer = 3
    Private ReadOnly L1 As Integer = 4
    Private ReadOnly R1 As Integer = 5
    Private ReadOnly L2 As Integer = 6
    Private ReadOnly R2 As Integer = 7
    Private ReadOnly SHARE As Integer = 8
    Private ReadOnly OPTIONS As Integer = 9
    Private ReadOnly L_STICK As Integer = 10
    Private ReadOnly R_STICK As Integer = 11
    Private ReadOnly PS As Integer = 12
    Private ReadOnly PAD As Integer = 13

    Private SLX As Integer = 0
    Private SLY As Integer = 0
    Private SRX As Integer = 0
    Private SRY As Integer = 0
    Private POV As Integer = 0

    Private SL2 As Integer = 0
    Private SR2 As Integer = 0

    Private Sub GamePad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug_Send("プログラムを起動しました。")
        Dim manager As New DirectInput
        Dim timer As Timer = New Timer()
        'ゲームパッド検索
        Debug_Send("コントローラーの検索中．．．")
        For Each wDeviceInstance As DeviceInstance In
            manager.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly)
            m_JoysTick = New Joystick(manager, wDeviceInstance.InstanceGuid)
            Exit For
        Next wDeviceInstance
        If m_JoysTick Is Nothing Then
            Dim unused0 = MessageBox.Show("コントローラが見つかりません！！", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        Else
            Debug_Send("コントローラーが見つかりました。")
            Debug_Send("ボタンの割り当て中．．．")
            '入力値範囲設定
            For Each wObjects As DeviceObjectInstance In m_JoysTick.GetObjects
                If (wObjects.ObjectType And ObjectDeviceType.Axis) <> 0 Then
                    m_JoysTick.Properties.SetRange(0, 100)
                End If
            Next wObjects
            '協調レベル(バックグラウンドでも受け付ける)
            Dim unused1 = m_JoysTick.SetCooperativeLevel(Me, CooperativeLevel.Nonexclusive Or CooperativeLevel.Background)
            Dim unused2 = m_JoysTick.Acquire() '情報取得
            'タイマー開始
            AddHandler timer.Tick, New EventHandler(AddressOf Timer_Tick)
            timer.Interval = 100
            timer.Enabled = True
            Debug_Send("シリアルポートを検索中．．．")
            For Each sp As String In My.Computer.Ports.SerialPortNames
                Dim unused = ComNum.Items.Add(sp)
            Next
            ComNum.SelectedIndex = 0
            Debug_Send("シリアルポートを選択して「接続！」を押してください。")
        End If
    End Sub

    Private Sub Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        SerialPort.Close() 'シリアルポートクローズ
    End Sub
    Private Sub Controller_Click(sender As Object, e As EventArgs) Handles Controller.Click
        Select Case N Mod 3
            Case 0
                Controller.Image = My.Resources.Blue
                Exit Select
            Case 1
                Controller.Image = My.Resources.Black
                Exit Select
            Case 2
                Controller.Image = My.Resources.Red
                Exit Select
            Case Else
                Exit Select
        End Select
        N += 1
    End Sub

    Private Sub Connect_Click(sender As Object, e As EventArgs) Handles Connect.Click
        Debug_Send("シリアルポート" + ComNum.SelectedItem + "を開いています．．．")
        With SerialPort
            'シリアルポート設定  
            .PortName = ComNum.SelectedItem 'ポート名  
            .BaudRate = 115200              '通信速度指定  
            .Parity = Parity.None           'パリティ指定  
            .DataBits = 8                   'ビット数指定  
            .Handshake = Handshake.None
            .StopBits = StopBits.One        'ストップビット指定
            .Encoding = System.Text.Encoding.UTF8
            .Open()                         'シリアルポートオープン  
        End With
        Debug_Send("シリアルポートを開きました。" + vbCrLf + "ロボットに接続中．．．．．．" + vbCrLf + "------------------------------------------")
        ComNum.Enabled = False
        Connect.Enabled = False
        Debug_Send(tex)
    End Sub

    Delegate Sub AddText(ByVal Text As String)
    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        Dim unused1 = ConsoleBox.Invoke(New AddText(AddressOf ConsoleBox.AppendText), SerialPort.ReadLine + " のロボットに接続しました。")
    End Sub

    Private Sub Debug_Send(sendStr As String)
        ConsoleBox.AppendText(sendStr + vbCrLf)
        Console.WriteLine(sendStr)
    End Sub

    Private Sub Serial_Send(sendStr As String)
        If SerialPort.IsOpen Then
            SerialPort.Write(sendStr) ' シリアル送信
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        m_JoysticSt = m_JoysTick.GetCurrentState '状態取得
        'ボタン状態送信
        Dim bs As Char() = New Char() {"0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c}
        For i As Integer = SQUARE To PAD
            bs(i) = If(m_JoysticSt.GetButtons(i), "1"c, "0"c)
        Next i

        SL2 = m_JoysticSt.RotationX
        SR2 = m_JoysticSt.RotationY
        SLX = m_JoysticSt.X
        SLY = 100 - m_JoysticSt.Y
        SRX = m_JoysticSt.Z
        SRY = 100 - m_JoysticSt.RotationZ
        POV = If(m_JoysticSt.GetPointOfViewControllers(0) = -1, 0, (m_JoysticSt.GetPointOfViewControllers(0) / 300) + 1) '十字キー(-1:離す, 0上, 9000右, 18000下, 27000左)
        Console.WriteLine("stick  : LX" + SLX.ToString + " LY" + SLY.ToString + " RX" + SRX.ToString + " RY" + SRY.ToString)
        Console.WriteLine("trigger: LT" + m_JoysticSt.RotationX.ToString + " RT" + m_JoysticSt.RotationY.ToString)
        Console.WriteLine("cross  : " + If(m_JoysticSt.GetPointOfViewControllers(0) = -1, "-1", (m_JoysticSt.GetPointOfViewControllers(0) / 100).ToString) + "°")

        bs(14) = Chr(SL2) '左肩の感圧
        bs(15) = Chr(SR2) '右肩の感圧
        bs(16) = Chr(SLX) '左スティック
        bs(17) = Chr(SLY) '左スティック
        bs(18) = Chr(SRX) '右スティック
        bs(19) = Chr(SRY) '右スティック
        bs(20) = Chr(POV) '十字キー
        Console.WriteLine("bs send: " + bs)
        Serial_Send("b"c)
        Serial_Send(bs)
        State.Text = "スティック     左X" + SLX.ToString + " 左Y" + SLY.ToString + " 右X" + SRX.ToString + " 右Y" + SRY.ToString + vbCrLf +
                     "肩ボタン     左肩" + m_JoysticSt.RotationX.ToString + " 右肩" + m_JoysticSt.RotationY.ToString + vbCrLf +
                     "十字キー    " + If(m_JoysticSt.GetPointOfViewControllers(0) = -1, "押されていない", ((m_JoysticSt.GetPointOfViewControllers(0) / 100).ToString) + "°") + vbCrLf +
                     "送信データ  b" + bs
    End Sub
End Class