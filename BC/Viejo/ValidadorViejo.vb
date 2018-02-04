Public Class ValidadorViejo

    Dim ValidadorCampos As New ValidadorDeCampos
    Public Function ValidaElPasoUno(model As Carro) As List(Of ManejadorDeExcepciones)
        Dim laListaDeErrores As New List(Of ManejadorDeExcepciones)
        laListaDeErrores.AddRange(ValidadorCampos.ValideElNombre(model))
        laListaDeErrores.AddRange(ValidadorCampos.ValideElAnno(model))

        Return laListaDeErrores
    End Function

    Public Function ValidaElPasoDos(model As Carro) As List(Of ManejadorDeExcepciones)
        Dim laListaDeErrores As New List(Of ManejadorDeExcepciones)
        laListaDeErrores.AddRange(ValidadorCampos.ValideElPorcentajeQueMeAlcanza(model))
        laListaDeErrores.AddRange(ValidadorCampos.ValideLaCantidadDeRuedas(model))

        Return laListaDeErrores
    End Function

End Class
