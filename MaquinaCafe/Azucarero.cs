namespace MaquinaCafe;

public class Azucarero
{
    public int CantidadAzucar { get; private set; }

    public Azucarero(int cantidadAzucar)
    {
        CantidadAzucar = cantidadAzucar;
    }

    public bool HasAzucar(int cantidadSolicitada) => CantidadAzucar >= cantidadSolicitada;

    public void GiveAzucar(int cantidad)
    {
        if (cantidad < 0) throw new ArgumentOutOfRangeException(nameof(cantidad));
        CantidadAzucar -= cantidad;
    }
}
