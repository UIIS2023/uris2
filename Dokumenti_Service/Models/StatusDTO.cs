namespace Dokumenti_Service.Models
{
    public class StatusDTO
    {
        public Guid statusID { get; set; }

        /// <summary>
        /// Status - Status dokumenta
        /// Example:Usvojen
        /// </summary>
        public string status { get; set; }
    }
}
