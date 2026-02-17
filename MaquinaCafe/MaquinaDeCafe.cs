using Xunit;
namespace MaquinaCafe;

public class MaquinaDeCafe
{
    public Cafetera Cafetera { get; private set; } = new Cafetera(0);

    public Vaso VasosPequeno { get; private set; } = new Vaso(0, 0);
    public Vaso VasosMediano { get; private set; } = new Vaso(0, 0);
    public Vaso VasosGrande { get; private set; } = new Vaso(0, 0);

    public Azucarero Azucarero { get; private set; } = new Azucarero(0);

    public void SetCafetera(Cafetera cafetera) => Cafetera = cafetera;
    public void SetVasosPequeno(Vaso vaso) => VasosPequeno = vaso;
    public void SetVasosMediano(Vaso vaso) => VasosMediano = vaso;
    public void SetVasosGrande(Vaso vaso) => VasosGrande = vaso;
    public void SetAzucarero(Azucarero azucarero) => Azucarero = azucarero;

    public Vaso GetTipoDeVaso(string tipo)
    {
        tipo = (tipo ?? "").Trim().ToLowerInvariant();

        return tipo switch
        {
            "pequeno" => VasosPequeno,
            "mediano" => VasosMediano,
            "grande" => VasosGrande,
            _ => throw new ArgumentException("Tipo de vaso inválido", nameof(tipo))
        };
    }

    public string GetVasoDeCafe(Vaso vaso, int cantidadVasos, int cucharadasAzucar)
    {
        if (!vaso.HasVasos(cantidadVasos)) return "No hay Vasos";

        int cafeNecesario = vaso.ContenidoCafe * cantidadVasos;
        if (!Cafetera.HasCafe(cafeNecesario)) return "No hay Cafe";

        if (!Azucarero.HasAzucar(cucharadasAzucar)) return "No hay Azucar";

        vaso.GiveVasos(cantidadVasos);
        Cafetera.GiveCafe(cafeNecesario);
        Azucarero.GiveAzucar(cucharadasAzucar);

        return "Felicitaciones";
    }
}
