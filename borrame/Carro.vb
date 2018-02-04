Imports System.ComponentModel.DataAnnotations

Public Class Carro

    <Required(ErrorMessage:="Campo requerido")>
    <StringLength(5, ErrorMessage:="El tamaño máximo es 5")>
    Public Property Modelo As String


End Class
