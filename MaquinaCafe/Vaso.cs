namespace MaquinaCafe;

public class Vaso
{
    public int CantidadVasos { get; private set; }
    public int ContenidoCafe { get; } // lo que consume por cada vaso

    public Vaso(int cantidadVasos, int contenidoCafe)
    {
        CantidadVasos = cantidadVasos;
        ContenidoCafe = contenidoCafe;
    }

    public bool HasVasos(int cantidadSolicitada) => CantidadVasos >= cantidadSolicitada;

    public void GiveVasos(int cantidad)
    {
        if (cantidad < 0) throw new ArgumentOutOfRangeException(nameof(cantidad));
        CantidadVasos -= cantidad;
    }
}
