Imports System.ComponentModel.DataAnnotations

Public Class Carro

    <Required(ErrorMessage:="Campo requerido")>
    <MinLength(5, ErrorMessage:="El tamaño mínimo es 5")>
    <MaxLength(20, ErrorMessage:="El tamaño máximo es 20")>
    <RegularExpression("^[A-z]+$", ErrorMessage:="El campo solo permite letras")>
    Public Property NombreDelCarro As String

    <Required(ErrorMessage:="Campo requerido")>
    Public Property AnnoCreacion As Integer

    <Required(ErrorMessage:="Campo requerido")>
    Public Property CantidadDeRuedas As List(Of Rueda)

    <Range(0.01, 99.99, ErrorMessage:="El Valor debe ser mayor a 0.01 y menor a 99.99")>
    <Required(ErrorMessage:="Campo requerido")>
    Public Property PorcentajeQueMeAlcanza As Decimal

End Class
