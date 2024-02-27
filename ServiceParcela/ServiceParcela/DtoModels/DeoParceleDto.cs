namespace ServiceParcela.DtoModels
{
    /// <summary>
    /// DeoParceleDto
    /// </summary>
    /// 
    public class DeoParceleDto
    {
        /// <summary>
        /// Id dela parcele
        /// </summary>
        /// 
        public Guid deoParceleID { get; set; }
        /// <summary>
        /// Id parcele
        /// </summary>
        /// 
        public Guid parcelaID { get; set; }
        /// <summary>
        /// Vrednost idealnog dela parcele
        /// </summary>
        /// 
        public int idealniDeoParcele { get; set; }
        /// <summary>
        /// Vrednost stvarnog dela parcele 
        /// </summary>
        /// 
        public int stvarniDeoParcele { get; set; }
    }
}
