Imports System
Imports NXOpen
Imports NXOpen.UF
Imports NXOpen.Annotations
Imports NXOpen.Utilities

Module report_notes_of_drawing_sheet

    Dim theSession As Session = Session.GetSession()
    Dim theUFSession As UFSession = UFSession.GetUFSession()

    Sub Main(ByVal args() As String)

        Dim displayPart As Part = theSession.Parts.Display

        Dim currentTag As NXOpen.Tag = NXOpen.Tag.Null

        Do
            theUFSession.Obj.CycleObjsInPart(displayPart.Tag, UFConstants.UF_dimension_type, currentTag)

            If currentTag = NXOpen.Tag.Null Then
                Exit Do
            End If

            Try
                Dim dimObj As NXOpen.Annotations.Dimension = _
                    CType(NXObjectManager.Get(currentTag), NXOpen.Annotations.Dimension)

                If dimObj IsNot Nothing Then
                    Dim mainText() As String
                    Dim dualText() As String

                    dimObj.GetDimensionText(mainText, dualText)

                    If mainText.Length > 0 Then
                        theSession.ListingWindow.Open()
                        theSession.ListingWindow.WriteLine("Dimension Text: " & mainText(0))
                    End If
                End If

            Catch ex As System.Exception
                theSession.ListingWindow.Open()
                theSession.ListingWindow.WriteLine("Error: " & ex.Message)
            End Try

        Loop

    End Sub

End Module

