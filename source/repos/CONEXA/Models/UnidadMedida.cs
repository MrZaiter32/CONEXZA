namespace CONEXA.Data;

public class UnidadMedida
{
    public int Id { get; set; }
    public required string Nombre { get; set; } // Nombre de la unidad
    public string Descripcion { get; set; } = string.Empty; // Opcional
}
