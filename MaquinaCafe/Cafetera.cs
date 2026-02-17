namespace MaquinaCafe;

public class Cafetera
{
    public int CantidadCafe { get; private set; }

    public Cafetera(int cantidadCafe)
    {
        CantidadCafe = cantidadCafe;
    }

    public bool HasCafe(int cantidadSolicitada) => CantidadCafe >= cantidadSolicitada;

    public void GiveCafe(int cantidad)
    {
        if (cantidad < 0) throw new ArgumentOutOfRangeException(nameof(cantidad));
        CantidadCafe -= cantidad;
    }
}
