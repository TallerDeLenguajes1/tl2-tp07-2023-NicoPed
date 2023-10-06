using Microsoft.AspNetCore.Mvc;
using TPEXTRA.Models;

namespace TPEXTRA.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
    private ManejoTareas manejoTareas;
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    private readonly ILogger<TareasController> _logger;

    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        var accesoADatos = new AccesoADatos();
        manejoTareas = new ManejoTareas(accesoADatos); 
    }

    [HttpPost("NewTarea")]
    public ActionResult<Tarea> NewTarea(Tarea tarea){
        Tarea nuevaTarea = manejoTareas.AddTarea(tarea);
        if (nuevaTarea != null)
        {
            return Ok(nuevaTarea);
        }
        return BadRequest("Algo ha salido mal");
    }
    
    [HttpGet("GetTareaPorId")]
    public ActionResult<Tarea> GetTareaPorId(int idTarea){
        var tareaBuscada = manejoTareas.ObtenerTareaPorId(idTarea);
        if ( tareaBuscada!= null )
        {
            return Ok(tareaBuscada);
        }
        return BadRequest("Tarea NO encontrada o inexistente");
    }
    
    [HttpGet("GetTareas")]
    public ActionResult<IEnumerable<Tarea>> GetTareas(){
        var listadoDeTareas = manejoTareas.ObtenerTareas;
        return Ok(listadoDeTareas);
    }
    
    
    [HttpGet("GetTareasCompletadas")]
    public ActionResult<IEnumerable<Tarea>> GetTareasCompletadas(){
        var listadoDeTareas = manejoTareas.ObtenerTareasCompletadas;
        return Ok(listadoDeTareas);
    }

    [HttpPut("UpdateTarea")]
    public ActionResult<Tarea> UpdateTarea(Tarea nuevaTarea){
        var resultado = manejoTareas.ActualizarTarea(nuevaTarea);
        if (resultado)
        {
            return Ok(nuevaTarea);
        }
            return BadRequest("Algo salio mal, compruebe los datos");
    } 
    [HttpDelete("DeleteTarea")]
    public ActionResult<string> DeleteTarea(int idTarea){
        var resultado = manejoTareas.EliminarTarea(idTarea);
        if (resultado)
        {
            return Ok($"Eliminado tarea de id = {idTarea}");
        }
            return BadRequest("Algo salio mal, No se logro eliminar la tarea");
    }
    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
}
