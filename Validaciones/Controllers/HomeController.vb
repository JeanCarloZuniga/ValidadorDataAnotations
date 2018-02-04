Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Dim modelo As BC.Carro
        modelo = GenerarElModeloDeTrabajo()

        Dim listaDeErroresConValidacionVieja As List(Of BC.ManejadorDeExcepciones)
        Dim listaDeErroresConValidacionNueva As List(Of BC.ManejadorDeExcepciones)

        listaDeErroresConValidacionVieja = ValideDeLaFormaVieja(modelo)
        listaDeErroresConValidacionNueva = ValideDeLaFormaNueva(modelo)


        Return View("Home")
    End Function

#Region "Modelo de trabajo"
    Private Function GenerarElModeloDeTrabajo() As BC.Carro
        Dim elModelo As New BC.Carro
        elModelo.NombreDelCarro = Nothing
        elModelo.AnnoCreacion = 0
        elModelo.PorcentajeQueMeAlcanza = 0.5
        elModelo.CantidadDeRuedas = GeneraRueda(3)

        Return elModelo
    End Function

    Private Function GeneraRueda(laCantidadDeRuedas As Integer) As List(Of BC.Rueda)
        Dim laListaDeRuedas As New List(Of BC.Rueda)
        For contador = 1 To laCantidadDeRuedas
            Dim rueda As New BC.Rueda
            laListaDeRuedas.Add(rueda)
        Next
        Return laListaDeRuedas
    End Function
#End Region

#Region "Validadores"
    Private Function ValideDeLaFormaVieja(modelo As BC.Carro) As List(Of BC.ManejadorDeExcepciones)
        Dim elValidadorDelBC As New BC.ValidadorViejo
        Dim laListaDeErrores As New List(Of BC.ManejadorDeExcepciones)

        laListaDeErrores.AddRange(elValidadorDelBC.ValidaElPasoUno(modelo))
        laListaDeErrores.AddRange(elValidadorDelBC.ValidaElPasoDos(modelo))

        Return laListaDeErrores
    End Function

    Private Function ValideDeLaFormaNueva(modelo As BC.Carro) As List(Of BC.ManejadorDeExcepciones)
        Dim elValidadorDelBC As New BC.ValidadorNuevo
        Dim laListaDeErrores As New List(Of BC.ManejadorDeExcepciones)

        laListaDeErrores.AddRange(elValidadorDelBC.ValidaElModelo(modelo, elValidadorDelBC.elPasoUno))
        laListaDeErrores.AddRange(elValidadorDelBC.ValidaElModelo(modelo, elValidadorDelBC.elPasoDos))

        Return laListaDeErrores
    End Function

#End Region

End Class
