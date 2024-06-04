using System.ComponentModel.DataAnnotations;
namespace ABMcliente.Models
{
    public class ClienteModel
    {
        public int Id_cliente { get; set; }
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo Fecha es obligatorio")]
        public DateTime? Fecha { get; set; }
        
    }
}
