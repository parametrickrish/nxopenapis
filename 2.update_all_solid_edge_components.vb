Option Strict Off
Imports System
Imports NXOpen
Imports NXOpen.UF
Imports NXOpen.Assemblies

Module update_all_solid_edge_components
    Dim s As Session = Session.GetSession()
    Dim ufs As UFSession = UFSession.GetUFSession()
    Dim lw As ListingWindow = s.ListingWindow
    Sub Main()
        lw.Open()
        Dim root As Component =
        s.Parts.Display.ComponentAssembly.RootComponent
        If Not root Is Nothing Then
            lw.WriteLine(root.DisplayName())
            reportChildrensBodyStatus(root, 1)
        Else
            lw.WriteLine("The displayed part is not an assembly.")
        End If
    End Sub
    Sub reportChildrensBodyStatus(ByVal comp As Component, ByVal indent As Integer)
        Dim space As String = Nothing
        For ii As Integer = 1 To indent
            space = space & " "
        Next
        For Each child As Component In comp.GetChildren()
            Try
                Dim cPart As Part = child.Prototype
                Dim num_bodies_before = cPart.Bodies.ToArray().Length
                ufs.Modl.EditImportBodyFeature(cPart.Tag,
                UFModl.ImportBodyFeatureEditOption.ImportBodyFeatureUpdateLink,
                Nothing)
                Dim num_bodies_after = cPart.Bodies.ToArray().Length
                If num_bodies_before <> num_bodies_after Then
                    Dim num_bodies_loaded = num_bodies_after -
                    num_bodies_before

                    lw.WriteLine(space & child.DisplayName() &
                    " was updated with " &
                    num_bodies_loaded.ToString() & " bodies.")
                End If
            Catch ex As Exception
                lw.WriteLine("Error: " & ex.Message)
            End Try
            reportChildrensBodyStatus(child, indent + 1)
        Next
    End Sub
    Public Function GetUnloadOption(ByVal dummy As String) As Integer
        Return Session.LibraryUnloadOption.Immediately
    End Function
End Module