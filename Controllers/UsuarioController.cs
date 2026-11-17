using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DbUsuContext _context;

        public UsuarioController(DbUsuContext context){
          _context = context;  
        }

        [HttpGet("Listar")]
       public async Task<ActionResult<IEnumerable<Usuary>>> ListarUsuario(){

            var usuarios= await _context.Usuaries.ToListAsync();
            return Ok(usuarios); //200
        }

        [HttpPost("Guardar")]

        public async Task<ActionResult<Usuary>> GuardarUsuario(Usuary usuary)
        {
            usuary.FechaCreate = DateTime.Now;
            _context.Usuaries.Add(usuary);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, usuary);
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult> ActualizarUsuarios(int id, Usuary usuary)
        {
            var usuarioActualizado = await _context.Usuaries.FindAsync(id);

            if (usuarioActualizado == null)
            {
                return NotFound(); // 404
            }

            usuarioActualizado.Nombres = usuary.Nombres;
            usuarioActualizado.Apellidos = usuary.Apellidos;
            usuarioActualizado.Correo = usuary.Correo;
            usuarioActualizado.Username = usuary.Username;

            await _context.SaveChangesAsync();

            return Ok(usuarioActualizado);

        }

        [HttpDelete("Eliminar/{id}")]

        public async Task<ActionResult> EliminarUsuario(int id)
        {
            var usuario = await _context.Usuaries.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(); // 404
            }

            _context.Usuaries.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();


        }

    }
}
