Public Class Cylinder
    Public Property BoreDiameter As String
    Public Property RodDiameter As String
    Public Property StrokeLength As Double

    ' Constructor to initialize
    Public Sub New(bore As String, rod As String, stroke As Double)
        BoreDiameter = bore
        RodDiameter = rod
        StrokeLength = stroke
    End Sub

    ' Method to validate rod vs bore combination
    Public Sub ValidateRodDiameter()
        If BoreDiameter = "5""" Then
            If RodDiameter = "0.5""" Or RodDiameter = "1""" Or RodDiameter = "1.5""" Or RodDiameter = "4""" Then
                MsgBox("This rod diameter is not possible for 5"" bore, choose between 2"", 2.5"", 3"", 3.5"".")
                RodDiameter = "2"""
            End If
        ElseIf BoreDiameter = "6""" Then
            If RodDiameter = "0.5""" Or RodDiameter = "1""" Or RodDiameter = "1.5""" Or RodDiameter = "2""" Then
                MsgBox("This rod diameter is not possible for 6"" bore, choose between 2.5"", 3"", 3.5"", 4"".")
                RodDiameter = "2.5"""
            End If
        End If
    End Sub

    ' Method to validate stroke length per rod/bore
    Public Sub ValidateStroke()
        If BoreDiameter = "5""" And RodDiameter = "3""" And StrokeLength < 1.375 Then
            MsgBox("Minimum stroke length should be 1.375""")
        End If
        If BoreDiameter = "6""" And RodDiameter = "4""" And StrokeLength < 2 Then
            MsgBox("Minimum stroke length should be 2""")
        End If
    End Sub
End Class


Public Function update_cb(ByVal block As NXOpen.BlockStyler.UIBlock) As Integer
    Try
        If block Is roddiameter Or block Is strokelength Then
            Dim cyl As New Cylinder(borediameter.ValueAsString, roddiameter.ValueAsString, strokelength.Value)
            cyl.ValidateRodDiameter()
            cyl.ValidateStroke()
        End If
    Catch ex As Exception
        theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString)
    End Try
    Return 0
End Function

