Imports System.Text.RegularExpressions.Regex
Imports System.Text.RegularExpressions

Friend Class Reglas

    Public Function ElTextoFueProporcionado(elTexto As String) As Boolean
        Return String.IsNullOrEmpty(elTexto)
    End Function

    Public Function ElTextoEsMayorAlMinimo(elTamano As Integer) As Boolean
        Return elTamano > 5
    End Function

    Public Function ElTextoEsMenorAlMaximo(elTamano As Integer) As Boolean
        Return elTamano < 20
    End Function

    Public Function ElTextoNoTieneCaracteresEspeciales(elTexto As String) As Boolean
        Static emailExpression As New Regex("^[A-z]+$")
        Return emailExpression.IsMatch(elTexto)
    End Function

    Public Function ElValorEsMayorAlMinimo(elValor As Decimal) As Boolean
        Return elValor > 0.01
    End Function

    Public Function ElValorEsMenorAlMaximo(elValor As Decimal) As Boolean
        Return elValor < 99.99
    End Function

    Public Function ElValorFueProporcionado(elValor As Decimal) As Boolean
        Return String.IsNullOrEmpty(elValor.ToString)
    End Function

    Public Function elValorEnteroFueProporcionado(elValor As Integer) As Boolean
        Return String.IsNullOrEmpty(elValor.ToString)
    End Function

    Public Function LaListaNoEstaVacia(laCantidad As Integer) As Boolean
        Return laCantidad > 0
    End Function

    Public Function LaListaCumpleReglaExtranna(laCantidad As Integer, elAnno As Integer) As Boolean
        Return IIf(laCantidad = 3 And elAnno = 2010, True, False)
    End Function
End Class
