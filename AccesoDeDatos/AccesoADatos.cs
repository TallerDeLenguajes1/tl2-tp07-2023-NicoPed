using System.Text.Json;

namespace TPEXTRA.Models;
public class AccesoADatos{
private string nombreArchivo = "tareas.json";
    public List<Tarea> Obtener (){
        string? archivo;
        List<Tarea> nuevaListaDeTareas = new List<Tarea>();
        if (File.Exists(nombreArchivo))
        {   
            using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    archivo = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
                nuevaListaDeTareas = JsonSerializer.Deserialize<List<Tarea>>(archivo);
            }
        }
        return nuevaListaDeTareas;
    }
    public void Guardar(List<Tarea> listadoTareas){
        if (!File.Exists(nombreArchivo))
        {
            File.Create(nombreArchivo).Close();
        }
        string json = JsonSerializer.Serialize(listadoTareas);
        File.WriteAllText(nombreArchivo,json);
    }
}