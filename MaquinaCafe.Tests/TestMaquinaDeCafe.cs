using Xunit;
using MaquinaCafe;

public class TestMaquinaDeCafe
{
    private Cafetera _cafetera;
    private Vaso _vasosPequeno;
    private Vaso _vasosMediano;
    private Vaso _vasosGrande;
    private Azucarero _azucarero;
    private MaquinaDeCafe _maquina;

    public TestMaquinaDeCafe()
    {
        _cafetera = new Cafetera(50);
        _vasosPequeno = new Vaso(5, 10);
        _vasosMediano = new Vaso(5, 20);
        _vasosGrande = new Vaso(5, 30);
        _azucarero = new Azucarero(20);

        _maquina = new MaquinaDeCafe();
        _maquina.SetCafetera(_cafetera);
        _maquina.SetVasosPequeno(_vasosPequeno);
        _maquina.SetVasosMediano(_vasosMediano);
        _maquina.SetVasosGrande(_vasosGrande);
        _maquina.SetAzucarero(_azucarero);
    }

    [Fact]
    public void DeberiaDevolverUnVasoPequeno()
    {
        var vaso = _maquina.GetTipoDeVaso("pequeno");
        Assert.Equal(_maquina.VasosPequeno, vaso);
    }

    [Fact]
    public void DeberiaDevolverUnVasoMediano()
    {
        var vaso = _maquina.GetTipoDeVaso("mediano");
        Assert.Equal(_maquina.VasosMediano, vaso);
    }

    [Fact]
    public void DeberiaDevolverUnVasoGrande()
    {
        var vaso = _maquina.GetTipoDeVaso("grande");
        Assert.Equal(_maquina.VasosGrande, vaso);
    }

    [Fact]
    public void DeberiaDevolverNoHayVasos()
    {
        var vaso = _maquina.GetTipoDeVaso("pequeno");

        string resultado = _maquina.GetVasoDeCafe(vaso, 10, 2);

        Assert.Equal("No hay Vasos", resultado);
    }

    [Fact]
    public void DeberiaDevolverNoHayCafe()
    {
        _cafetera = new Cafetera(5);
        _maquina.SetCafetera(_cafetera);

        var vaso = _maquina.GetTipoDeVaso("pequeno");

        string resultado = _maquina.GetVasoDeCafe(vaso, 1, 2);

        Assert.Equal("No hay Cafe", resultado);
    }

    [Fact]
    public void DeberiaDevolverNoHayAzucar()
    {
        _azucarero = new Azucarero(2);
        _maquina.SetAzucarero(_azucarero);

        var vaso = _maquina.GetTipoDeVaso("pequeno");

        string resultado = _maquina.GetVasoDeCafe(vaso, 1, 3);

        Assert.Equal("No hay Azucar", resultado);
    }

    [Fact]
    public void DeberiaRestarCafe()
    {
        var vaso = _maquina.GetTipoDeVaso("pequeno");
        _maquina.GetVasoDeCafe(vaso, 1, 3);

        int resultado = _maquina.Cafetera.CantidadCafe;

        Assert.Equal(40, resultado);
    }

    [Fact]
    public void DeberiaRestarVaso()
    {
        var vaso = _maquina.GetTipoDeVaso("pequeno");
        _maquina.GetVasoDeCafe(vaso, 1, 3);

        int resultado = _maquina.VasosPequeno.CantidadVasos;

        Assert.Equal(4, resultado);
    }

    [Fact]
    public void DeberiaRestarAzucar()
    {
        var vaso = _maquina.GetTipoDeVaso("pequeno");
        _maquina.GetVasoDeCafe(vaso, 1, 3);

        int resultado = _maquina.Azucarero.CantidadAzucar;

        Assert.Equal(17, resultado);
    }

    [Fact]
    public void DeberiaDevolverFelicitaciones()
    {
        var vaso = _maquina.GetTipoDeVaso("pequeno");

        string resultado = _maquina.GetVasoDeCafe(vaso, 1, 3);

        Assert.Equal("Felicitaciones", resultado);
    }
}
