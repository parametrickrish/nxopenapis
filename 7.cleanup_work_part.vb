Option Strict Off
Imports System
Imports NXOpen
Module cleanup_work_part
    Dim s As Session = Session.GetSession()
    Sub Main()
        Dim workPart As Part = s.Parts.Work
        Dim partCleanup1 As PartCleanup
        partCleanup1 = s.NewPartCleanup()
        partCleanup1.TurnOffHighlighting = True

        partCleanup1.DeleteUnusedObjects = True
        partCleanup1.DeleteUnusedExpressions = True
        partCleanup1.CleanupDraftingObjects = True
        partCleanup1.CleanupFeatureData = True
        partCleanup1.FixOffplaneSketchCurves = True
        partCleanup1.CleanupMatingData = True
        partCleanup1.DeleteUnusedFonts = True
        partCleanup1.CleanupCAMObjects = True
        partCleanup1.DoCleanup()
        partCleanup1.Dispose()
        Echo("Finished!")
    End Sub
    Sub Echo(ByVal output As String)
        s.ListingWindow.Open()
        s.ListingWindow.WriteLine(output)
        s.LogFile.WriteLine(output)
    End Sub
    Public Function GetUnloadOption(ByVal dummy As String) As Integer
        Return Session.LibraryUnloadOption.Immediately
    End Function
End Module