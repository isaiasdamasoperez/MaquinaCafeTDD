using Xunit;
using MaquinaCafe;

public class TestAzucarero
{
    private Azucarero _azucarero;

    public TestAzucarero()
    {
        _azucarero = new Azucarero(10);
    }

    [Fact]
    public void DeberiaDevolverVerdaderoSiHaySuficienteAzucarEnElAzucarero()
    {
        bool resultado = _azucarero.HasAzucar(5);
        Assert.True(resultado);

        resultado = _azucarero.HasAzucar(10);
        Assert.True(resultado);
    }

    [Fact]
    public void DeberiaDevolverFalsoPorqueNoHaySuficienteAzucarEnElAzucarero()
    {
        bool resultado = _azucarero.HasAzucar(15);
        Assert.False(resultado);
    }

    [Fact]
    public void DeberiaRestarAzucarAlAzucarero()
    {
        _azucarero.GiveAzucar(5);
        Assert.Equal(5, _azucarero.CantidadAzucar);

        _azucarero.GiveAzucar(2);
        Assert.Equal(3, _azucarero.CantidadAzucar);
    }
}
