Option Strict Off
Imports System
Imports NXOpen
Imports NXOpen.Drawings
Imports NXOpen.UI
Imports NXOpen.Utilities
Module update_all_out_of_date_drafting_views_explicitly
    Dim s As Session = Session.GetSession()
    Sub Main()
        For Each dwg As DrawingSheet In s.Parts.Display.DrawingSheets
            If dwg.IsOutOfDate Then
                For Each dv As DraftingView In dwg.GetDraftingViews()
                    If dv.IsOutOfDate Then
                        dv.Update()
                    End If
                Next
            End If
        Next
    End Sub

    Public Function GetUnloadOption(ByVal dummy As String) As Integer
        Return Session.LibraryUnloadOption.Immediately
    End Function
End Module