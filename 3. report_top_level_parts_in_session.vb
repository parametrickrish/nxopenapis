Option Strict Off
Imports System
Imports NXOpen
Imports NXOpen.UF
Imports NXOpen.UI
Imports NXOpen.Utilities
Module report_top_level_parts_in_session
    Dim theSession As Session = Session.GetSession()
    Dim ufs As UFSession = UFSession.GetUFSession()
    Sub Main()
        For Each thisPart As Part In theSession.Parts.ToArray()
            Dim occs() As Tag
            ufs.Assem.AskOccsOfPart(NXOpen.Tag.Null, thisPart.Tag, occs)
            If occs.GetUpperBound(0) < 0 Then
                'this part has no parent, so announce it
                Echo("TOP Part: " & thisPart.FullPath())
            End If

        Next
    End Sub
    Sub Echo(ByVal output As String)
        theSession.ListingWindow.Open()
        theSession.ListingWindow.WriteLine(output)
        theSession.LogFile.WriteLine(output)
    End Sub
    Public Function GetUnloadOption(ByVal dummy As String) As Integer
        Return Session.LibraryUnloadOption.Immediately
    End Function
End Module