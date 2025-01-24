namespace CONEXA.Data;

public class Producto
{
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Nombre { get; set; }
    public string NumeroParte { get; set; }
    public string Equivalencia1 { get; set; }
    public string Equivalencia2 { get; set; }
    public string Marca { get; set; }
    public string Ubicacion { get; set; }
    public string Descripcion { get; set; }
    public int FamiliaId { get; set; }
    public Familia Familia { get; set; }
    public int UnidadMedidaId { get; set; }
    public UnidadMedida UnidadMedida { get; set; }
    public string Foto { get; set; }
}
