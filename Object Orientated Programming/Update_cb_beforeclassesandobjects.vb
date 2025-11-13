Public Function update_cb(ByVal block As NXOpen.BlockStyler.UIBlock) As Integer
    Try

        If block Is integer0 Then
            '---- Enter your code here -----

        ElseIf block Is mountingstyle Then
            '---- Enter your code here -----

        ElseIf block Is borediameter Then
            '---- Enter your code here -----

        ElseIf block Is roddiameter Then
            '---- Enter your code here -----
            If borediameter.ValueAsString = "1.5""" Then
            ElseIf borediameter.ValueAsString = "2""" Then
            ElseIf borediameter.ValueAsString = "2.5""" Then
            ElseIf borediameter.ValueAsString = "3.25""" Then
            ElseIf borediameter.ValueAsString = "4""" Then
            ElseIf borediameter.ValueAsString = "5""" Then

                roddiameter.Enable = False
                If roddiameter.ValueAsString = "0.5""" Or roddiameter.ValueAsString = "1""" Or roddiameter.ValueAsString = "1.5""" Or roddiameter.ValueAsString = "4""" Then
                    MsgBox("this rod diameter is not possible for 5"" bore, choose rod diameter between 2"", 2.5"", 3"", 3.5""")
                    roddiameter.ValueAsString = "2"""
                End If
            ElseIf borediameter.ValueAsString = "6""" Then
                If roddiameter.ValueAsString = "0.5""" Or roddiameter.ValueAsString = "1""" Or roddiameter.ValueAsString = "1.5""" Or roddiameter.ValueAsString = "2""" Then
                    MsgBox("this rod diameter is not possible for 6"" bore, choose rod diameter between 2.5"", 3"", 3.5"", 4""")
                    roddiameter.ValueAsString = "2.5"""
                End If
            End If

        ElseIf block Is pistonseal Then
            '---- Enter your code here -----

        ElseIf block Is strokelength Then
            '---- Enter your code here -----
            If borediameter.ValueAsString = "1.5""" Then
            ElseIf borediameter.ValueAsString = "2""" Then
            ElseIf borediameter.ValueAsString = "2.5""" Then
            ElseIf borediameter.ValueAsString = "3.25""" Then
            ElseIf borediameter.ValueAsString = "4""" Then
            ElseIf borediameter.ValueAsString = "5""" Then

                If roddiameter.ValueAsString = "2.5""" Then
                    If strokelength.Value < 1 Then
                        MsgBox("minimum stroke length should be 1""")
                    End If
                End If
                If roddiameter.ValueAsString = "3""" Then
                    If strokelength.Value < 1.375 Then
                        MsgBox("minimum stroke length should be 1.375""")
                    End If
                End If
                If roddiameter.ValueAsString = "3.5""" Then
                    If strokelength.Value < 1.625 Then
                        MsgBox("minimum stroke length should be 1.625""")
                    End If
                End If


            ElseIf borediameter.ValueAsString = "6""" Then
                If roddiameter.ValueAsString = "3""" Then
                    If strokelength.Value < 1.375 Then
                        MsgBox("minimum stroke length should be 1.375""")
                    End If
                End If
                If roddiameter.ValueAsString = "3.5""" Then
                    If strokelength.Value < 1.375 Then
                        MsgBox("minimum stroke length should be 1.375""")
                    End If
                End If
                If roddiameter.ValueAsString = "4""" Then
                    If strokelength.Value < 2 Then
                        MsgBox("minimum stroke length should be 2""")
                    End If
                End If
            End If

        End If

    Catch ex As Exception

        '---- Enter your exception handling code here -----
        theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString)
    End Try
    update_cb = 0
End Function

'------------------------------------------------------------------------------
'Callback Name: ok_cb
'------------------------------------------------------------------------------
Public Function ok_cb() As Integer
    Dim errorCode As Integer = 0
    Try

        Dim htE As Hashtable = New Hashtable()
        htE.Add("1.5""", 2.5)
        htE.Add("2""", 3)
        htE.Add("2.5""", 3.5)
        htE.Add("3.25""", 4.5)
        htE.Add("4""", 5)
        htE.Add("5""", 6.5)
        htE.Add("6""", 7.5)

        Dim htF As Hashtable = New Hashtable()
        htF.Add("1.5""", 0.38)
        htF.Add("2""", 0.63)
        htF.Add("2.5""", 0.63)
        htF.Add("3.25""", 0.75)
        htF.Add("4""", 0.88)
        htF.Add("5""", 0.88)
        htF.Add("6""", 1)

        Dim htFB As Hashtable = New Hashtable()
        htFB.Add("1.5""", 0.44)
        htFB.Add("2""", 0.56)
        htFB.Add("2.5""", 0.56)
        htFB.Add("3.25""", 0.69)
        htFB.Add("4""", 0.69)
        htFB.Add("5""", 0.94)
        htFB.Add("6""", 1.06)

        Dim htG As Hashtable = New Hashtable()
        htG.Add("1.5""", 1.75)
        htG.Add("2""", 1.75)
        htG.Add("2.5""", 1.75)
        htG.Add("3.25""", 2)
        htG.Add("4""", 2)
        htG.Add("5""", 2)
        htG.Add("6""", 2.25)

        Dim htJ As Hashtable = New Hashtable()
        htJ.Add("1.5""", 1.5)
        htJ.Add("2""", 1.5)
        htJ.Add("2.5""", 1.5)
        htJ.Add("3.25""", 1.75)
        htJ.Add("4""", 1.75)
        htJ.Add("5""", 1.75)
        htJ.Add("6""", 2.25)

        Dim htK As Hashtable = New Hashtable()
        htK.Add("1.5""", 0.38)
        htK.Add("2""", 0.44)
        htK.Add("2.5""", 0.44)
        htK.Add("3.25""", 0.56)
        htK.Add("4""", 0.56)
        htK.Add("5""", 0.81)
        htK.Add("6""", 0.88)

        Dim htR As Hashtable = New Hashtable()
        htR.Add("1.5""", 1.63)
        htR.Add("2""", 2.05)
        htR.Add("2.5""", 2.55)
        htR.Add("3.25""", 3.25)
        htR.Add("4""", 3.82)
        htR.Add("5""", 4.95)
        htR.Add("6""", 5.73)

        Dim htTF As Hashtable = New Hashtable()
        htTF.Add("1.5""", 3.44)
        htTF.Add("2""", 4.13)
        htTF.Add("2.5""", 4.63)
        htTF.Add("3.25""", 5.88)
        htTF.Add("4""", 6.38)
        htTF.Add("5""", 8.19)
        htTF.Add("6""", 9.44)

        Dim htUF As Hashtable = New Hashtable()
        htUF.Add("1.5""", 4.25)
        htUF.Add("2""", 5.13)
        htUF.Add("2.5""", 5.63)
        htUF.Add("3.25""", 7.13)
        htUF.Add("4""", 7.63)
        htUF.Add("5""", 9.75)
        htUF.Add("6""", 11.25)

        Dim htLB As Hashtable = New Hashtable()
        htLB.Add("1.5""", 5)
        htLB.Add("2""", 5.25)
        htLB.Add("2.5""", 5.38)
        htLB.Add("3.25""", 6.25)
        htLB.Add("4""", 6.63)
        htLB.Add("5""", 7.13)
        htLB.Add("6""", 8.38)

        Dim htP As Hashtable = New Hashtable()
        htP.Add("1.5""", 2.88)
        htP.Add("2""", 2.88)
        htP.Add("2.5""", 3)
        htP.Add("3.25""", 3.5)
        htP.Add("4""", 3.75)
        htP.Add("5""", 4.25)
        htP.Add("6""", 4.88)


        For Each expr As NXOpen.Expression In theSession.Parts.Work.Expressions
            If expr.Name = "E" Then
                expr.Value = htE(borediameter.ValueAsString)
            End If
            If expr.Name = "F" Then
                expr.Value = htF(borediameter.ValueAsString)
            End If
            If expr.Name = "FB" Then
                expr.Value = htFB(borediameter.ValueAsString)
            End If
            If expr.Name = "G" Then
                expr.Value = htG(borediameter.ValueAsString)
            End If
            If expr.Name = "J" Then
                expr.Value = htJ(borediameter.ValueAsString)
            End If
            If expr.Name = "K" Then
                expr.Value = htK(borediameter.ValueAsString)
            End If
            If expr.Name = "LB" Then
                expr.Value = htLB(borediameter.ValueAsString)
            End If
            If expr.Name = "R" Then
                expr.Value = htR(borediameter.ValueAsString)
            End If
            If expr.Name = "TF" Then
                expr.Value = htTF(borediameter.ValueAsString)
            End If
            If expr.Name = "UF" Then
                expr.Value = htUF(borediameter.ValueAsString)
            End If

        Next

        For Each expstroke As NXOpen.Expression In theSession.Parts.Work.Expressions
            If expstroke.Name = "STROKE" Then
                expstroke.Value = strokelength.Value
            End If
        Next

        Dim boredia As Double = Replace(borediameter.ValueAsString, """", "")

        For Each expboredia As NXOpen.Expression In theSession.Parts.Work.Expressions
            If expboredia.Name = "BOREDIA" Then
                expboredia.Value = boredia
            End If
        Next



        For Each tempFeat As NXOpen.Features.Feature In theSession.Parts.Work.Features

            'If mountingstyle.ValueAsString.ToLower = contains(tempFeat.Name.ToLower) Then
            '    tempFeat.Unsuppress()
            'End If




            'style j1
            'style j2
            'style j3

            'If mountingstyle.ValueAsString.ToLower = "style j" Then
            '    If tempFeat.Name.tolower = "style j" Then
            '        tempFeat.unSuppress()
            '    End If
            'End If
            'If mountingstyle.ValueAsString.ToLower = "style t" Then
            '    If tempFeat.Name.tolower = "style t" Then
            '        tempFeat.unSuppress()
            '    End If
            'End If
        Next


        SwithDraftingView()



        '---- Enter your callback code here -----
        errorCode = apply_cb()

    Catch ex As Exception

        '---- Enter your exception handling code here -----
        errorCode = 1
        theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString)
    End Try
    ok_cb = errorCode
End Function