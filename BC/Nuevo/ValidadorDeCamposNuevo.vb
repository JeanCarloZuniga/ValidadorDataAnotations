Public Class ValidadorDeCamposNuevo

    Dim reglas As New ReglasNuevo()
    Dim mensajes As New GeneradorDeMensajesNuevo()

    Public Function ValideLaCantidadDeRuedas(elCarro As Carro) As List(Of ManejadorDeExcepciones)
        Dim laListaDeErrores As New List(Of ManejadorDeExcepciones)
        laListaDeErrores.Add(LaListaDeRuedasCumpleReglaExtranna(elCarro.CantidadDeRuedas, elCarro.AnnoCreacion))
        Return (From elemento In laListaDeErrores Where elemento.Estado = True Select elemento).ToList
    End Function

    'VALIDACIONES ESPECIFICAS POR CAMPO

#Region "Region de la cantidad de rueda"
    Public Function LaListaDeRuedasCumpleReglaExtranna(laLista As List(Of Rueda), elAnno As Integer) As ManejadorDeExcepciones
        Dim contenedor As New ManejadorDeExcepciones("CantidadDeRuedas", "", False)
        If Not reglas.LaListaCumpleReglaExtranna(laLista.Count, elAnno) Then
            contenedor.Estado = True
            contenedor.MensajeError = mensajes.MensajeParaCasoExtranno
        End If
        Return contenedor
    End Function
#End Region


End Class
