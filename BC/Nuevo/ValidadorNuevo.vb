Imports System.Web

Public Class ValidadorNuevo
    Inherits System.Web.Mvc.Controller

    Dim diccionario As List(Of List(Of String))
    Dim ValidadorCampos As New ValidadorDeCamposNuevo
    Public Property elPasoUno As Integer
    Public Property elPasoDos As Integer

    Public Sub New()
        diccionario = New List(Of List(Of String))
        diccionario.Add(New List(Of String)(New String() {""}))
        diccionario.Add(New List(Of String)(New String() {"NombreDelCarro", "AnnoCreacion"}))
        diccionario.Add(New List(Of String)(New String() {"CantidadDeRuedas", "PorcentajeQueMeAlcanza"}))
        elPasoDos = 2
        elPasoUno = 1
    End Sub

    Public Function ValidaElModelo(modelo As Carro, elPaso As Integer) As List(Of ManejadorDeExcepciones)
        Me.ControllerContext = New Mvc.ControllerContext
        Dim elResultadoDeLaValidacions = TryValidateModel(modelo)
        Dim losErrores = ModelState.Where(Function(x) x.Value.Errors.Count > 0).[Select](Function(x) New With {x.Key, x.Value.Errors}).ToArray()

        Dim laListaConvertida As List(Of ManejadorDeExcepciones) = ConviertaAManejadorDeErrorComun(losErrores.ToList)
        Dim listaCasosEspeciales As List(Of ManejadorDeExcepciones) = ValidarCasosEspeciales(modelo, elPaso)

        Return UnaErroresFWKConErroresCasosEspeciales(laListaConvertida, listaCasosEspeciales, elPaso)
    End Function

    Public Function ValidarCasosEspeciales(elCarro As BC.Carro, elPaso As Integer) As List(Of ManejadorDeExcepciones)
        Dim laListaDeContenedores As New List(Of ManejadorDeExcepciones)
        Select Case elPaso
            Case elPasoUno
                Return laListaDeContenedores
            Case elPasoDos
                laListaDeContenedores.Add(ValidadorCampos.LaListaDeRuedasCumpleReglaExtranna(elCarro.CantidadDeRuedas, elCarro.AnnoCreacion))
        End Select

        Return laListaDeContenedores
    End Function


    'PARA MANTENER LA CONCISTENCIA CON EL VALIDADOR VIEJO

    Public Function ConviertaAManejadorDeErrorComun(laLista As IEnumerable(Of Object)) As List(Of ManejadorDeExcepciones)
        Dim laListaDeContenedores As New List(Of ManejadorDeExcepciones)
        For Each objetoDeError In laLista
            For contador As Integer = 0 To objetoDeError.Errors.count - 1
                Dim elContenedor As New ManejadorDeExcepciones(objetoDeError.Key, objetoDeError.Errors(contador).ErrorMessage, True)
                laListaDeContenedores.Add(elContenedor)
            Next
        Next

        Return laListaDeContenedores
    End Function

    Private Function UnaErroresFWKConErroresCasosEspeciales(laListaFWK As List(Of ManejadorDeExcepciones),
                                                        laListaCasosEspeciales As List(Of ManejadorDeExcepciones),
                                                        elPaso As Integer) As List(Of ManejadorDeExcepciones)
        Dim laListaDeContenedores As New List(Of ManejadorDeExcepciones)
        Dim listaFWKFiltrada = (From elemento In laListaFWK Where diccionario(elPaso).Contains(elemento.Campo) And elemento.Estado = True Select elemento Distinct).ToList
        Dim listaEspecialesFiltrada = (From elemento In laListaCasosEspeciales Where diccionario(elPaso).Contains(elemento.Campo) And elemento.Estado = True Select elemento).ToList

        laListaDeContenedores = listaFWKFiltrada.Union(listaEspecialesFiltrada).ToList
        Return laListaDeContenedores
    End Function

End Class
