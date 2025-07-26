Option Strict Off
Imports NXOpen
Imports System
Imports System.IO
Imports System.Environment
Imports System.Windows.Forms
Module export_expressions_from_work_part
    Dim theSession As Session = Session.GetSession()
    Dim workPart As Part = theSession.Parts.Work
    Sub Main()
        Dim filename As String = ""
        If (save_file(filename) <> DialogResult.OK) Then
            Echo("Input canceled...exit")
        Else
            workPart.Expressions.ExportToFile(ExpressionCollection.ExportMode.WorkPart, filename,
                                                          ExpressionCollection.SortType.AlphaNum)
        End If
    End Sub
    Public Function save_file(ByRef filename) As DialogResult
        Dim SaveExpFileDlg As SaveFileDialog = New SaveFileDialog()
        Dim result As DialogResult
        SaveExpFileDlg.Title = "Export Expressions File"
        SaveExpFileDlg.AddExtension = True
        SaveExpFileDlg.Filter = "Expression Data Files (*.exp)| *.exp"
        SaveExpFileDlg.FilterIndex = 1
        SaveExpFileDlg.InitialDirectory = "c:\users\"
        result = SaveExpFileDlg.ShowDialog()
        filename = SaveExpFileDlg.FileName
        SaveExpFileDlg.Dispose()
        Return result
    End Function
    Sub Echo(ByVal output As String)
        theSession.ListingWindow.Open()
        theSession.ListingWindow.WriteLine(output)
        theSession.LogFile.WriteLine(output)
    End Sub
    Public Function GetUnloadOption(ByVal dummy As String) As Integer
        GetUnloadOption = NXOpen.Session.LibraryUnloadOption.Immediately
    End Function
End Module