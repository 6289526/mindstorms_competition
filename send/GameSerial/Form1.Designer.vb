<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EV3
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Controller = New System.Windows.Forms.PictureBox()
        Me.ComNum = New System.Windows.Forms.ComboBox()
        Me.Connect = New System.Windows.Forms.Button()
        Me.ConsoleBox = New System.Windows.Forms.TextBox()
        Me.State = New System.Windows.Forms.TextBox()
        CType(Me.Controller, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SerialPort
        '
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 100000
        '
        'Controller
        '
        Me.Controller.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controller.Image = Global.GameSerial.My.Resources.Resources.Red
        Me.Controller.InitialImage = Global.GameSerial.My.Resources.Resources.Red
        Me.Controller.Location = New System.Drawing.Point(0, 0)
        Me.Controller.Name = "Controller"
        Me.Controller.Size = New System.Drawing.Size(284, 219)
        Me.Controller.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Controller.TabIndex = 20
        Me.Controller.TabStop = False
        Me.Controller.WaitOnLoad = True
        '
        'ComNum
        '
        Me.ComNum.FormattingEnabled = True
        Me.ComNum.Location = New System.Drawing.Point(0, 0)
        Me.ComNum.Name = "ComNum"
        Me.ComNum.Size = New System.Drawing.Size(90, 20)
        Me.ComNum.TabIndex = 22
        '
        'Connect
        '
        Me.Connect.Location = New System.Drawing.Point(107, -2)
        Me.Connect.Name = "Connect"
        Me.Connect.Size = New System.Drawing.Size(75, 23)
        Me.Connect.TabIndex = 0
        Me.Connect.Text = "接続！"
        Me.Connect.UseVisualStyleBackColor = True
        '
        'ConsoleBox
        '
        Me.ConsoleBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ConsoleBox.Location = New System.Drawing.Point(0, 225)
        Me.ConsoleBox.MaxLength = 100
        Me.ConsoleBox.Multiline = True
        Me.ConsoleBox.Name = "ConsoleBox"
        Me.ConsoleBox.ReadOnly = True
        Me.ConsoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ConsoleBox.Size = New System.Drawing.Size(284, 150)
        Me.ConsoleBox.TabIndex = 25
        '
        'State
        '
        Me.State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.State.Location = New System.Drawing.Point(0, 381)
        Me.State.MaxLength = 100
        Me.State.Multiline = True
        Me.State.Name = "State"
        Me.State.ReadOnly = True
        Me.State.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.State.Size = New System.Drawing.Size(284, 79)
        Me.State.TabIndex = 26
        '
        'EV3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(284, 461)
        Me.Controls.Add(Me.State)
        Me.Controls.Add(Me.ConsoleBox)
        Me.Controls.Add(Me.Connect)
        Me.Controls.Add(Me.ComNum)
        Me.Controls.Add(Me.Controller)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EV3"
        Me.ShowIcon = False
        Me.Text = "EV3"
        CType(Me.Controller, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialPort As IO.Ports.SerialPort
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Controller As PictureBox
    Friend WithEvents ComNum As ComboBox
    Friend WithEvents Connect As Button
    Friend WithEvents ConsoleBox As TextBox
    Friend WithEvents State As TextBox
End Class
