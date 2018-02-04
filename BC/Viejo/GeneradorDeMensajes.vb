Public Class GeneradorDeMensajes

    Public Function MensajeCampoRequerido() As String
        Return "Campo requerido."
    End Function

    Public Function MensajeMaximosHilera() As String
        Return "El valor debe ser menor a 20."
    End Function

    Public Function MensajeMinimosHilera() As String
        Return "El valor debe ser mayor a 5."
    End Function

    Public Function MensajeCaracteresInvalidos() As String
        Return "Solo se permite ingresar letras."
    End Function

    Public Function MensajeMinimoDecimal() As String
        Return "El valor debe ser mayor a 0.01"
    End Function

    Public Function MensajeMaximoDecimal() As String
        Return "El valor debe ser menor a 99.99"
    End Function

    Public Function MensajeParaCasoExtranno() As String
        Return "La lista debe contener 3 elementos y el año debe ser 2010."
    End Function
End Class
