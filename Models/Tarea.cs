namespace TPEXTRA.Models;

public class Tarea{
    public enum EstadoTarea{
        Pendiete,
        EnProgreso,
        Completado
    }
    private int id;
    private string? titulo;
    private string? descripcion;
    private EstadoTarea estado;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public EstadoTarea Estado { get => estado; set => estado = value; }
}