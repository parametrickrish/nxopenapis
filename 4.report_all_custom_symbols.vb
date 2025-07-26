Imports System
Imports NXOpen
Imports NXOpen.Annotations
Imports NXOpen.UI
Imports NXOpen.Utilities
Imports NXOpen.UF
Module report_all_custom_symbols
    Dim s As Session = Session.GetSession()
    Dim ufs As UFSession = UFSession.GetUFSession()
    Dim lw As ListingWindow = s.ListingWindow
    Dim wp As Part = s.Parts.Work
    Sub Main()
        Dim symbol As NXOpen.Tag
        lw.Open()
        Dim custSymCol As CustomSymbolCollection =
        s.Parts.Work.Annotations().CustomSymbols()
        For Each cs1 As CustomSymbol In custSymCol
            lw.WriteLine(vbCrLf + "Symbol: " & cs1.ToString())
            lw.WriteLine(" Symbol Name: " + cs1.SymbolName)
            lw.WriteLine(" Custom Name: " + cs1.Name)
            Dim csBuilder1 As DraftingCustomSymbolBuilder =
            wp.Annotations.CustomSymbols.CreateDraftingCustomSymbolBuilder(cs1)

            lw.WriteLine(" MasterSymbolName: " + csBuilder1.MasterSymbolName)
            lw.WriteLine(" MasterSymbolPath: " + csBuilder1.MasterSymbolPath)
            csBuilder1.Destroy()
            Dim vw_status As Integer
            Dim vw_name As String
            ufs.View.AskViewDependentStatus(cs1.Tag, vw_status, vw_name)
            lw.WriteLine(" View Dependent: " + vw_status.ToString())
            lw.WriteLine(" View: " + vw_name)
            Dim csData1 As Annotations.CustomSymbolData = cs1.GetSymbolData()
            Dim scale1 As Double = csData1.Scale
            Dim angle1 As Double = csData1.Angle
            Dim origin1 As Point3d = cs1.AnnotationOrigin
            lw.WriteLine(" AnnotationOrigin: " & origin1.ToString())
            lw.WriteLine(" Angle: " & angle1.ToString())
            lw.WriteLine(" Scale: " & scale1.ToString())
            Dim textdata1() As Annotations.CustomSymbolTextData
            textdata1 = csData1.GetTextData()
            For Each td As Annotations.CustomSymbolTextData In textdata1
                lw.WriteLine(" text type: " & [Enum].GetName(GetType(TextType),
                td.TextType))
                Dim text() As String
                text = td.GetText()
                For Each t As String In text
                    lw.WriteLine(" text: " & t)
                Next
            Next
            cs1.UpdateSymbolGeometry(origin1, scale1, angle1)
            csData1.SetTextData(textdata1)
        Next
    End Sub
    Public Function GetUnloadOption(ByVal dummy As String) As Integer
        GetUnloadOption = UFConstants.UF_UNLOAD_IMMEDIATELY
    End Function
End Module