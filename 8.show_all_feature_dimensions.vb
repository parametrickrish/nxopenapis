Imports System
Imports NXOpen
Imports NXOpen.UF
Imports NXOpen.UI
Imports NXOpen.Utilities
Imports NXOpen.Features
Module show_all_feature_dimensions_of_selected_features
    Sub Main()
        Dim s As Session = Session.GetSession()
        Dim ufs As UFSession = UFSession.GetUFSession()
        Dim dp As Part = s.Parts.Display
        Dim selectedFeatures() As Features.Feature =
        selectFeatures("Select the features to show feature dimensions")
        For ii As Integer = 0 To selectedFeatures.Length - 1
            selectedFeatures(ii).ShowDimensions()
        Next
    End Sub
    Function selectFeatures(ByVal prompt As String) As Features.Feature()

        Dim theUI As UI = UI.GetUI
        selectFeatures = Nothing
        theUI.SelectionManager.SelectFeatures(prompt,
        Selection.SelectionFeatureType.Browsable, selectFeatures)
    End Function
    Public Function GetUnloadOption(ByVal dummy As String) As Integer
        GetUnloadOption = UFConstants.UF_UNLOAD_IMMEDIATELY
    End Function
End Module