Imports System.Text.RegularExpressions.Regex
Imports System.Text.RegularExpressions

Friend Class ReglasNuevo
    Public Function LaListaCumpleReglaExtranna(laCantidad As Integer, elAnno As Integer) As Boolean
        Return IIf(laCantidad = 3 And elAnno = 2010, True, False)
    End Function
End Class
