
Public Class Form1
    Public Shared data As String
    Dim html() As String = {"assassination", "attack", "domestic security", "drill", "exercise", "cops", "law enforcement", "authorities", "disaster assistance", "disaster management", "DNDO", "domestic nuclear", "detection office", "national preparedness", "mitigation", "prevention", "response", "recovery", "dirty bomb", "domestic nuclear detection", "emergency management", "emergency response", "first responder", "homeland security", "maritime domain awareness", "MDA", "national preparedness", "initiative", "militia", "shooting", "shots fired", "evacuation", "deaths", "hostage", "explosion", "explosive", "police", "disaster medical assistance", "team", "DMAT", "organized crime", "gangs", "national security", "state of emergency", "security", "breach", "threat", "standoff", "SWAT", "screening", "lockdown", "bomb", "crash", "looting", "riot", "emergency landing", "pipe bomb", "incident", "facility"
}
    Dim html2() As String = {"hazmat", "nuclear", "chemical spill", "suspicious package", "suspicious device", "toxic", "national labratory", "nuclear facility", "nuclear threat", "cloud", "plume", "radiation", "radioactive", "leak", "biological infection", "biological event", "chemical", "chemical burn", "biological", "epidemic", "hazardous", "hazardous material", "industrial spill", "infection", "powder", "gas", "spillover", "anthrax", "blister agent", "chemical agent", "exposure", "burn", "nerve agent", "rcin", "sarin", "north korea"
}
    Dim html3() As String = {"outbreak", "pork", "contamination", "virus", "exposure", "evacuation", "bacteria", "recall", "ebola", "food poisoning", "foot and mouth", "FMD", "H5N", "avian", "flu", "salmonella", "small pox", "plague", "human to human", "human to animal", "influenza", "center for disease control", "CDC", "drug administration", "FDA", "public health", "toxic", "agro terror", "tuberculosis", "TB", "agriculture", "listeria", "symptoms", "mutation", "resistant", "antiviral", "wave", "pandemic", "infection", "air borne", "water borne", "sick", "swine", "strain", "quarantine", "H1N1", "vaccine", "tamiflu", "norvo virus", "epidemic", "world health organization", "WHO", "and components", "viral hemorrhagic fever", "ecoli"
}
    Dim html4() As String = {"infrastructure security", "airport", "CIKR", "critical infrastructure", "key resources", "AMTRAK", "collapse", "computer infrastructure", "communications", "infrastructure", "telecommunications", "national infrastructure", "metro", "WMATA", "airplane", "chemical fire", "subway", "BART", "MARTA", "port authority", "NBIC", "national biosurveillance integration center", "grid", "power", "smart", "body scanner", "electric", "failure or outage", "black out", "broen out", "port", "dock", "bridge", "cancelled", "delays", "service disruption", "power lines"
}
    Dim html5() As String = {"drug cartel", "violence", "gang", "drug", "narcotics", "cocaine", "marijuana", "heroin", "border", "mexico", "cartel", "southwest", "juarez", "sinaloa", "tijuana", "torreon", "yuma", "tuscon", "us consulate", "consular", "el paso", "fort hancook", "san diego", "ciudad juarez", "nogales", "sonora", "colombia", "mara salvatrucha", "MS13", "MS-13", "drug war", "mexican army", "methamphetamine", "de golfo", "gulf cartel", "la familia", "reynosa", "nuevo leon", "narcos", "narco banner", "los zetas", "shootout", "execution", "gunfight", "trafficking", "kidnap", "calderon", "reyosa", "bust", "tamaulipas", "meth lab", "drug trade", "illegal immigrants", "smuggling", "smugglers", "matamoros", "michoacana", "guzman", "arellano felix", "beltran leyva", "barrio azteca", "artistic assassins", "mexicles", "new federation"
}
    Dim html6() As String = {"terrorism", "al qaeda", "terror", "attack", "iraq", "afghanistan", "iran", "pakistan", "agro", "environmental terrorist", "eco terrorism", "conventional weapon", "target", "weapons grade", "dirty bomb", "enriched", "nuclear", "chemical weapon", "biological weapon", "ammonium nitrate", "improvised explosive device", "improvised", "abu sayyaf", "hames", "FARC", "forces", "IRA", "euskadi ta askatasuna", "basque seperatists", "hezbollah", "tamil tigers", "palestine liberation", "organization", "car bomb", "jihad", "taliban", "weapons cache", "suicide bomber", "suicide attack", "suspicious substance", "AQAP", "AQIM", "islamic maghreb", "TTP", "yemen", "pirates", "extremism", "somalia", "nigeria", "radicals", "al-shabaab", "home grown", "plot", "nationalist", "recruitment", "fundamentalism", "islamist"
}
    Dim html7() As String = {"emergency", "hurricane", "tornado", "twister", "tsunami", "earthquake", "tremor", "flood", "storm", "crest", "temblor", "extreme weather", "forest fire", "brush fire", "ice", "stranded", "stuck", "help", "hail", "wildfire", "tsunami warning", "magnitude", "avalanche", "typhoon", "shelter-in-place", "disaster", "snow", "blizzard", "sleet", "mudslide", "erosion", "power outage", "brown out", "warning", "watch", "lightning", "aid", "relief", "closure", "burst", "emergency broadcast system"
}
    Dim html8() As String = {"cyber security", "botnet", "DDOS", "denial of service", "malware", "virus", "trojan", "keylogger", "cyber command", "2600", "spammer", "phishing", "rootkit", "phreaking", "cain and abel", "brute forcing", "mysql injection", "cyber attack", "cyber terror", "hacker", "china", "conficker", "worm", "scammers", "social media"
}
    Public Sub SendintText(command As String)
        Try
            SendKeys.SendWait(command)
        Catch e As Exception
            MsgBox(e.StackTrace)
        End Try
    End Sub
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    Private Sub RichTextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles RichTextBox1.TextChanged
        Dim lstPoints As List(Of Point) = New List(Of Point)
        Dim i, S As Integer

        ' Moved to Public shared data
        ' Dim ALL list
        '''''''''''''''

        SendMessage(RichTextBox1.Handle, &HB, CType(0, IntPtr), IntPtr.Zero) 'To avoid flickering. 0xB = WM_SETREDRAW is set to false

        S = RichTextBox1.SelectionStart

        'Draw all RichTextBox1.text to RichTextBox1.ForeColor
        RichTextBox1.SelectionStart = 0
        RichTextBox1.SelectionLength = RichTextBox1.Text.Length
        RichTextBox1.SelectionColor = RichTextBox1.ForeColor

        'Find the positions of all words in html array in RichTextBox1.Text and store them into lstPoint
        If CheckBox1.Checked Then
            For i = 0 To html.Length - 1
                FindOccurrences(html(i), RichTextBox1.Text, lstPoints)
            Next
        Else 'MsgBox("disabled!")
        End If
        If CheckBox2.Checked Then
            For i = 0 To html2.Length - 1
                FindOccurrences(html2(i), RichTextBox1.Text, lstPoints)
            Next
        Else 'MsgBox("disabled!")
        End If
        If CheckBox3.Checked Then
            For i = 0 To html3.Length - 1
                FindOccurrences(html3(i), RichTextBox1.Text, lstPoints)
            Next
        Else 'MsgBox("disabled!")
        End If
        If CheckBox4.Checked Then
            For i = 0 To html4.Length - 1
                FindOccurrences(html4(i), RichTextBox1.Text, lstPoints)
            Next
        Else 'MsgBox("disabled!")
        End If
        If CheckBox5.Checked Then
            For i = 0 To html5.Length - 1
                FindOccurrences(html5(i), RichTextBox1.Text, lstPoints)
            Next
        Else 'MsgBox("disabled!")
        End If
        If CheckBox6.Checked Then
            For i = 0 To html6.Length - 1
                FindOccurrences(html6(i), RichTextBox1.Text, lstPoints)
            Next
        Else 'MsgBox("disabled!")
        End If
        If CheckBox7.Checked Then
            For i = 0 To html7.Length - 1
                FindOccurrences(html7(i), RichTextBox1.Text, lstPoints)
            Next
        Else 'MsgBox("disabled!")
        End If
        If CheckBox8.Checked Then
            For i = 0 To html8.Length - 1
                FindOccurrences(html8(i), RichTextBox1.Text, lstPoints)
            Next
        Else 'MsgBox("disabled!")
        End If
        'Draw green all the words that have been found
        For i = 0 To lstPoints.Count - 1
            RichTextBox1.SelectionStart = lstPoints(i).X
            RichTextBox1.SelectionLength = lstPoints(i).Y
            RichTextBox1.SelectionColor = Color.Red


        Next
        If RichTextBox1.SelectionColor = Color.Red Then
            Button1.BackColor = Color.Red
            'Label1.BackColor = Color.Red
            'Label1.Text = "WARNING"

        Else Button1.BackColor = Color.LawnGreen
        End If
        'Set cursor to initial position
        RichTextBox1.SelectionStart = S
        RichTextBox1.SelectionLength = 0

        RichTextBox1.SelectionColor = RichTextBox1.ForeColor

        'We finish. Now paint
        SendMessage(RichTextBox1.Handle, &HB, CType(1, IntPtr), IntPtr.Zero) '0xB = WM_SETREDRAW is set to True
        RichTextBox1.Invalidate()
    End Sub

    Private Sub FindOccurrences(ByVal word As String, ByVal txt As String, ByVal lstPoints As List(Of Point))
        Dim lengthW, lengthT, i, pos, count As Integer
        Dim fnd As Boolean = False

        count = 0
        pos = 0
        i = 0
        lengthW = word.Length
        lengthT = txt.Length

        While i < lengthT
            If txt(i) = word(count) Then
                If fnd = False Then
                    fnd = True
                    pos = i
                End If

                If count = lengthW - 1 Then 'a word is found 
                    lstPoints.Add(New Point(pos, lengthW))

                    fnd = False
                    pos = 0
                    count = 0
                Else 'we found another char match
                    count += 1
                End If

                i += 1
            Else
                If fnd = True Then 'Some chars matched the word but not all of them. Go back to the first char match and take the next char
                    fnd = False

                    i = pos + 1
                Else
                    i += 1
                End If

                count = 0
            End If
        End While

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Clipboard.SetText(RichTextBox1.Text)
        Catch
            MsgBox("No text to copy")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        aboutvb.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        donate.Show()
    End Sub

    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        TrackBar1.Minimum = 4
        Me.Opacity = TrackBar1.Value / TrackBar1.Maximum

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim rnd = New Random()
        For i As Int32 = 1 To 100
            Dim randomFruit = html(rnd.Next(0, html.Count))
            Dim randomFruit2 = html2(rnd.Next(0, html2.Count))
            RichTextBox1.Text = html(rnd.Next(0, html.Length)) & " " & html2(rnd.Next(0, html2.Length)) & " " & html3(rnd.Next(0, html3.Length)) & " " & html4(rnd.Next(0, html4.Length)) & " " & html5(rnd.Next(0, html6.Length)) & " " & html6(rnd.Next(0, html6.Length)) & " " & html7(rnd.Next(0, html7.Length)) & " " & html8(rnd.Next(0, html8.Length)) & " " & html(rnd.Next(0, html.Length)) & " " & html2(rnd.Next(0, html2.Length)) & " " & html3(rnd.Next(0, html3.Length)) & " " & html4(rnd.Next(0, html4.Length)) & " " & html5(rnd.Next(0, html6.Length)) & " " & html6(rnd.Next(0, html6.Length)) & " " & html7(rnd.Next(0, html7.Length)) & " " & html8(rnd.Next(0, html8.Length))

            ' RichTextBox1.Text = (randomFruit)
            ' RichTextBox1.Text = html(rnd.Next(0, html.Length)) & " " & html2(rnd.Next(0, html2.Length))
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class