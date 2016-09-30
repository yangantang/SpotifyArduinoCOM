<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lstConsole = New System.Windows.Forms.ListBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.lstPorts = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.ni = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.inputText = New System.Windows.Forms.TextBox()
        Me.Send = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'lstConsole
        '
        Me.lstConsole.BackColor = System.Drawing.Color.White
        Me.lstConsole.FormattingEnabled = True
        Me.lstConsole.ItemHeight = 16
        Me.lstConsole.Location = New System.Drawing.Point(28, 193)
        Me.lstConsole.Margin = New System.Windows.Forms.Padding(4)
        Me.lstConsole.Name = "lstConsole"
        Me.lstConsole.Size = New System.Drawing.Size(615, 308)
        Me.lstConsole.TabIndex = 5
        '
        'btnConnect
        '
        Me.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnect.Location = New System.Drawing.Point(288, 69)
        Me.btnConnect.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(127, 28)
        Me.btnConnect.TabIndex = 7
        Me.btnConnect.Text = "&Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'lstPorts
        '
        Me.lstPorts.FormattingEnabled = True
        Me.lstPorts.Location = New System.Drawing.Point(28, 69)
        Me.lstPorts.Margin = New System.Windows.Forms.Padding(4)
        Me.lstPorts.Name = "lstPorts"
        Me.lstPorts.Size = New System.Drawing.Size(240, 24)
        Me.lstPorts.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Select COM Port:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(31, 514)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(155, 17)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Spotify is NOT running."
        '
        'ni
        '
        Me.ni.Icon = CType(resources.GetObject("ni.Icon"), System.Drawing.Icon)
        Me.ni.Text = "ni"
        Me.ni.Visible = True
        '
        'inputText
        '
        Me.inputText.Location = New System.Drawing.Point(28, 145)
        Me.inputText.Multiline = True
        Me.inputText.Name = "inputText"
        Me.inputText.Size = New System.Drawing.Size(460, 22)
        Me.inputText.TabIndex = 10
        '
        'Send
        '
        Me.Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Send.Location = New System.Drawing.Point(526, 143)
        Me.Send.Name = "Send"
        Me.Send.Size = New System.Drawing.Size(110, 24)
        Me.Send.TabIndex = 11
        Me.Send.Text = "Send"
        Me.Send.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(669, 584)
        Me.Controls.Add(Me.Send)
        Me.Controls.Add(Me.inputText)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.lstPorts)
        Me.Controls.Add(Me.lstConsole)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Spotify - Arduino Remote"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lstConsole As System.Windows.Forms.ListBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents lstPorts As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ni As System.Windows.Forms.NotifyIcon
    Friend WithEvents inputText As TextBox
    Friend WithEvents Send As Button
    Friend WithEvents Timer2 As Timer
End Class
