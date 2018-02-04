Public Class ValidadorDeCampos

    Dim reglas As New Reglas()
    Dim mensajes As New GeneradorDeMensajes()

    Public Function ValideElNombre(elCarro As Carro) As List(Of ManejadorDeExcepciones)
        Dim laListaDeErrores As New List(Of ManejadorDeExcepciones)
        laListaDeErrores.Add(ElNombreFueProporcionado(elCarro.NombreDelCarro))
        If laListaDeErrores.First.Estado = False Then
            laListaDeErrores.Add(ElNombreCumpleElMinimo(elCarro.NombreDelCarro.Count))
            laListaDeErrores.Add(ElNombreCumpleElMaximo(elCarro.NombreDelCarro.Count))
            laListaDeErrores.Add(ElNombreCumpleConElFormato(elCarro.NombreDelCarro))
        End If

        Return (From elemento In laListaDeErrores Where elemento.Estado = True Select elemento).ToList
    End Function

    Public Function ValideElAnno(elCarro As Carro) As List(Of ManejadorDeExcepciones)
        Dim laListaDeErrores As New List(Of ManejadorDeExcepciones)
        laListaDeErrores.Add(ElAnnoFueProporcionado(elCarro.AnnoCreacion))
        Return (From elemento In laListaDeErrores Where elemento.Estado = True Select elemento).ToList
    End Function

    Public Function ValideLaCantidadDeRuedas(elCarro As Carro) As List(Of ManejadorDeExcepciones)
        Dim laListaDeErrores As New List(Of ManejadorDeExcepciones)
        laListaDeErrores.Add(LaListaDeRuedasFueProporcionado(elCarro.CantidadDeRuedas))
        If laListaDeErrores.First.Estado = False Then
            laListaDeErrores.Add(LaListaDeRuedasCumpleReglaExtranna(elCarro.CantidadDeRuedas, elCarro.AnnoCreacion))
        End If
        Return (From elemento In laListaDeErrores Where elemento.Estado = True Select elemento).ToList
    End Function

    Public Function ValideElPorcentajeQueMeAlcanza(elCarro As Carro) As List(Of ManejadorDeExcepciones)
        Dim laListaDeErrores As New List(Of ManejadorDeExcepciones)
        laListaDeErrores.Add(ElPorcentajeFueProporcionado(elCarro.PorcentajeQueMeAlcanza))
        If laListaDeErrores.First.Estado = False Then
            laListaDeErrores.Add(ElPorcentajeCumpleElMinimo(elCarro.PorcentajeQueMeAlcanza))
            laListaDeErrores.Add(ElPorcentajeCumpleElMaximo(elCarro.PorcentajeQueMeAlcanza))
        End If

        Return (From elemento In laListaDeErrores Where elemento.Estado = True Select elemento).ToList
    End Function

    'VALIDACIONES ESPECIFICAS POR CAMPO

#Region "Region del nombre del carro"
    Public Function ElNombreFueProporcionado(elNombre As String) As ManejadorDeExcepciones
        Dim contenedor As New ManejadorDeExcepciones("NombreDelCarro", "", False)
        If reglas.ElTextoFueProporcionado(elNombre) Then
            contenedor.Estado = True
            contenedor.MensajeError = mensajes.MensajeCampoRequerido
        End If
        Return contenedor
    End Function

    Public Function ElNombreCumpleElMinimo(laCantidad As Integer) As ManejadorDeExcepciones
        Dim contenedor As New ManejadorDeExcepciones("NombreDelCarro", "", False)
        If Not reglas.ElTextoEsMayorAlMinimo(laCantidad) Then
            contenedor.Estado = True
            contenedor.MensajeError = mensajes.MensajeMinimosHilera
        End If
        Return contenedor
    End Function

    Public Function ElNombreCumpleElMaximo(laCantidad As Integer) As ManejadorDeExcepciones
        Dim contenedor As New ManejadorDeExcepciones("NombreDelCarro", "", False)
        If Not reglas.ElTextoEsMenorAlMaximo(laCantidad) Then
            contenedor.Estado = True
            contenedor.MensajeError = mensajes.MensajeMaximosHilera
        End If
        Return contenedor
    End Function

    Public Function ElNombreCumpleConElFormato(elNombre As String) As ManejadorDeExcepciones
        Dim contenedor As New ManejadorDeExcepciones("NombreDelCarro", "", False)
        If Not reglas.ElTextoNoTieneCaracteresEspeciales(elNombre) Then
            contenedor.Estado = True
            contenedor.MensajeError = mensajes.MensajeCaracteresInvalidos
        End If
        Return contenedor
    End Function
#End Region

#Region "Region del anno del carro"
    Public Function ElAnnoFueProporcionado(elAnno As Integer) As ManejadorDeExcepciones
        Dim contenedor As New ManejadorDeExcepciones("AnnoCreacion", "", False)
        If reglas.elValorEnteroFueProporcionado(elAnno) Then
            contenedor.Estado = True
            contenedor.MensajeError = mensajes.MensajeCampoRequerido
        End If
        Return contenedor
    End Function
#End Region

#Region "Region de la cantidad de rueda"
    Public Function LaListaDeRuedasFueProporcionado(laLista As List(Of Rueda)) As ManejadorDeExcepciones
        Dim contenedor As New ManejadorDeExcepciones("CantidadDeRuedas", "", False)
        If Not reglas.LaListaNoEstaVacia(laLista.Count) Then
            contenedor.Estado = True
            contenedor.MensajeError = mensajes.MensajeCampoRequerido
        End If
        Return contenedor
    End Function

    Public Function LaListaDeRuedasCumpleReglaExtranna(laLista As List(Of Rueda), elAnno As Integer) As ManejadorDeExcepciones
        Dim contenedor As New ManejadorDeExcepciones("CantidadDeRuedas", "", False)
        If Not reglas.LaListaCumpleReglaExtranna(laLista.Count, elAnno) Then
            contenedor.Estado = True
            contenedor.MensajeError = mensajes.MensajeParaCasoExtranno
        End If
        Return contenedor
    End Function
#End Region

#Region "Region del porcentaje"
    Public Function ElPorcentajeFueProporcionado(elPorcentaje As Decimal) As ManejadorDeExcepciones
        Dim contenedor As New ManejadorDeExcepciones("PorcentajeQueMeAlcanza", "", False)
        If reglas.ElValorFueProporcionado(elPorcentaje) Then
            contenedor.Estado = True
            contenedor.MensajeError = mensajes.MensajeCampoRequerido
        End If
        Return contenedor
    End Function

    Public Function ElPorcentajeCumpleElMinimo(elPorcentaje As Decimal) As ManejadorDeExcepciones
        Dim contenedor As New ManejadorDeExcepciones("PorcentajeQueMeAlcanza", "", False)
        If Not reglas.ElValorEsMayorAlMinimo(elPorcentaje) Then
            contenedor.Estado = True
            contenedor.MensajeError = mensajes.MensajeMinimoDecimal
        End If
        Return contenedor
    End Function

    Public Function ElPorcentajeCumpleElMaximo(elPorcentaje As Decimal) As ManejadorDeExcepciones
        Dim contenedor As New ManejadorDeExcepciones("PorcentajeQueMeAlcanza", "", False)
        If Not reglas.ElValorEsMenorAlMaximo(elPorcentaje) Then
            contenedor.Estado = True
            contenedor.MensajeError = mensajes.MensajeMaximoDecimal
        End If
        Return contenedor
    End Function
#End Region

End Class
