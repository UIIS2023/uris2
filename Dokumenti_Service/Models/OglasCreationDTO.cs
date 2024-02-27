namespace Dokumenti_Service.Models
{
    public class OglasCreationDTO
    {
        public string tekstOglasa { get; set; }


        public Guid oglasnaTablaId { get; set; }

        public Guid? dokumentId { get; set; }
    }
}
