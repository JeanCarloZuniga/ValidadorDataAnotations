Imports System.ComponentModel.DataAnnotations

Public Class borra
    Inherits System.Web.Mvc.Controller

    Public Function ValidaElPasoUno(model As Carro) As List(Of Integer)
        Me.ControllerContext = New Mvc.ControllerContext
        Dim loba = TryValidateModel(model)
        Dim errors = ModelState.Where(Function(x) x.Value.Errors.Count > 0).[Select](Function(x) New With {x.Key, x.Value.Errors}).ToArray()
    End Function

    Public Function ValidaElPasoDos(modelo As Carro) As List(Of Integer)


    End Function

    Public Function ConviertaAManejadorDeErrorComun(laLista As List(Of Object)) As List(Of Integer)

    End Function
End Class
