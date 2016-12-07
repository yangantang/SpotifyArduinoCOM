Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports Microsoft.VisualBasic.FileIO

Public Class Form1
    Dim currentSong As String
    Dim buffer As String
    Dim type As String = ""
    Delegate Sub myMethodDelegate(ByVal [text] As String)
    Dim hdlD As New myMethodDelegate(AddressOf processCommand)
    Dim WithEvents SerialPort As New IO.Ports.SerialPort
    Dim p() As Process

    Private Sub Form1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If SerialPort.IsOpen() Then
            SerialPort.Close()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ni.Visible = False
        GetSerialPortNames()
    End Sub

    Sub GetSerialPortNames()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            lstPorts.Items.Add(sp)
        Next
    End Sub

    Sub sendserialdata(ByVal port As String, ByVal data As String)
        If (SerialPort.IsOpen) Then
            SerialPort.Write(data)
        Else
            MsgBox("not connected to port.")
        End If
    End Sub

    Sub processCommand(ByVal myString As String)
        buffer = buffer + myString  'reads register buffer
        Dim str As String
        str = buffer
        If InStr(str, "|") Then
            Dim words As String() = str.Split(New Char() {"|"}) 'Splits up string into words when "|" is seen
            buffer = ""
            Dim word As String
            For Each word In words
                If (word.Length > 0) Then
                    Dim Spotify As New spotify()
                    Select Case word
                        Case "prev"
                            Spotify.PlayPrev()
                            lstConsole.Items.Add("Play previous song.")
                            type = "prev"
                        Case "next"
                            Spotify.PlayNext()
                            lstConsole.Items.Add("Play next song.")
                            type = "next"
                        Case "play"
                            Spotify.Play()
                            type = "play"
                        Case "pause"
                            Spotify.Pause()
                            type = "pause"
                            'lstConsole.Items.Add("Spotify paused.")
                        Case "speech"
                            type = "speech"
                            playSoundFile()
                            SerialPort.Write("1")
                        Case ""
                            '  received an Unknown command. Deal with it.
                            '  lstConsole.Items.Add("Received: " & word)
                        Case Else
                            'If (words(0) <> "MPDV") Then
                            '    Continue For
                            'End If
                            lstConsole.Items.Add("Latency: " + words(0) + " ms")
                            Create_CSV(type, words(0))
                    End Select
                End If
            Next
        End If

    End Sub

    Sub playSoundFile()
        Dim wavFile As String = "C:\Users\"
        wavFile = wavFile & Environment.UserName
        wavFile = wavFile & "\Desktop\sound.wav"
        My.Computer.Audio.Play(wavFile, AudioPlayMode.WaitToComplete)
    End Sub

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        Dim str As String = SerialPort.ReadExisting()

        Invoke(hdlD, str)   'invoke processCommand method
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        checkSongStatus()
    End Sub

    Private Sub checkSongStatus()
        p = Process.GetProcessesByName("Spotify")
        If p.Count > 0 Then
            lblStatus.Text = "Spotify is running."
            Dim Spotify As New spotify()
            If Spotify.Nowplaying() <> currentSong Then
                currentSong = Spotify.Nowplaying()
                If currentSong = "" Or currentSong = "Paused." Then
                    lstConsole.Items.Add("Spotify Paused.")
                Else
                    lstConsole.Items.Add("Song changed to: " & currentSong)
                    If (SerialPort.IsOpen()) Then
                        SerialPort.Write(currentSong & vbCrLf)
                    End If
                End If
            End If
        Else
            lblStatus.Text = "Spotify is NOT running."
        End If
    End Sub
    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
 Handles MyBase.SizeChanged

        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
            Me.ni.Visible = True
        End If

    End Sub
    Private Sub ni_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
 Handles ni.Click

        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.ni.Visible = False

    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        If lstPorts.SelectedIndex <> -1 Then
            Try
                If SerialPort.IsOpen Then
                    SerialPort.Close()
                    btnConnect.Text = "Connect"
                Else
                    SerialPort.PortName = lstPorts.SelectedItem.ToString
                    SerialPort.BaudRate = 9600
                    SerialPort.DataBits = 8
                    SerialPort.Parity = Parity.None
                    SerialPort.StopBits = StopBits.One
                    SerialPort.Handshake = Handshake.None
                    SerialPort.Encoding = System.Text.Encoding.Default
                    SerialPort.Open()
                    btnConnect.Text = "Disconnect"
                    lstConsole.Items.Add("press 1 then send to play/pause")
                    lstConsole.Items.Add("press 2 then send for next song")
                    lstConsole.Items.Add("press 3 then send for previous song")
                    lstConsole.Items.Add("press 4 then send for wake word test")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Please choose a serial port", vbInformation, "Serial Port")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Send.Click
        If (SerialPort.IsOpen) Then
            SerialPort.Write(inputText.Text)
        Else
            MsgBox("Not connected to port. Select COM port.")
        End If
    End Sub

    Private Sub Create_CSV(ByVal _type As String, ByVal _latency As String)
        Dim csvFile As String = "C:\Users\"
        csvFile = csvFile & Environment.UserName
        csvFile = csvFile & "\Desktop\latencyData.csv"

        If IO.File.Exists(csvFile) Then
            Dim objWriter As New StreamWriter(csvFile, True)
            objWriter.Write(DateTime.Now.ToString("MM/dd/yy") & ",")
            objWriter.Write(DateTime.Now.ToString("hh:mm:ss tt") & ",")
            objWriter.Write(_type & ",")
            objWriter.Write(_latency)
            objWriter.Write(Environment.NewLine)
            objWriter.Close()
        Else
            Dim objWriter As IO.StreamWriter = IO.File.AppendText(csvFile)
            objWriter.WriteLine("Date, Time, Command, Latency (ms)")
            objWriter.Write(DateTime.Now.ToString("MM/dd/yy") & ",")
            objWriter.Write(DateTime.Now.ToString("hh:mm:ss tt") & ",")
            objWriter.Write(_type & ",")
            objWriter.Write(_latency)
            objWriter.Write(Environment.NewLine)
            objWriter.Close()
        End If

        Console.WriteLine(My.Computer.FileSystem.ReadAllText(csvFile))
    End Sub
End Class