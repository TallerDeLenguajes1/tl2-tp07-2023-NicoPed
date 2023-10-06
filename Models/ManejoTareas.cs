namespace TPEXTRA.Models;

public class ManejoTareas{
    private AccesoADatos accesoADatos;
    public ManejoTareas(AccesoADatos accesoADatos)
    {
        this.accesoADatos = accesoADatos;
    }

    public Tarea AddTarea(Tarea tarea){
        var listadoTareas = accesoADatos.Obtener();
        listadoTareas.Add(tarea);
        // var newId = listadoTareas.Max(t => t.Id);
        // newId ++;
        // tarea.Id ++;
        tarea.Id = listadoTareas.Count;
        accesoADatos.Guardar(listadoTareas);
        return tarea;
    }
    public Tarea ObtenerTareaPorId(int idBuscado){
        var listadoTareas = accesoADatos.Obtener();
        var tareaBuscada = listadoTareas.FirstOrDefault(t=> t.Id == idBuscado);
        return tareaBuscada;
    }
    public bool ActualizarTarea(Tarea nuevaTarea){
        var listadoTareas = accesoADatos.Obtener();
        var viejaTarea = listadoTareas.FirstOrDefault(t=> t.Id ==nuevaTarea.Id);
        if (viejaTarea!=null)
        {
            //UNA FORMA PERO NO ES RECOMENDABLE YA QUE SI EN ALGUN MOMENTO CAMBIAN LOS CAMPOS DEBEMOS CAMBIAR TODO ESTO
            // viejaTarea.Titulo = nuevaTarea.Titulo;
            // viejaTarea.Descripcion = nuevaTarea.Descripcion;
            // viejaTarea.Estado = nuevaTarea.Estado;
            // accesoADatos.Guardar(listadoTareas);

            // OTRA FORMA :ELIMINAR TAREA VIEJA E INSERTAR NUEVAAAAAAAA
            if (listadoTareas.Remove(viejaTarea))
            {
                listadoTareas.Add(nuevaTarea);
                accesoADatos.Guardar(listadoTareas);
                return true;
            }
        }
        return false;
    }
    public bool EliminarTarea(int idTarea){
        var listadoTareas = accesoADatos.Obtener();
        var tareaAEliminar = listadoTareas.FirstOrDefault(t=> t.Id == idTarea);
        if (tareaAEliminar != null)
        {
            listadoTareas.Remove(tareaAEliminar);
            accesoADatos.Guardar(listadoTareas);
            return true;
        }
        return false;
    }
    public List<Tarea> ObtenerTareas(){
        var listadoTareas = accesoADatos.Obtener();
        return listadoTareas;
    }
    public List<Tarea> ObtenerTareasCompletadas(){
        var listadoTareas = accesoADatos.Obtener();
        var listadoTareasCompletas = listadoTareas.FindAll(t=> t.Estado == Tarea.EstadoTarea.Completado); 
        return listadoTareasCompletas;
    }
}