Public Class ManejadorDeExcepciones

    Public Property Campo As String
    Public Property MensajeError As String
    Public Property Estado As Boolean

    Public Sub New(_Campo As String, _MensajeError As String, _Estado As Boolean)
        Me.Campo = _Campo
        Me.MensajeError = _MensajeError
        Me.Estado = _Estado
    End Sub

End Class
