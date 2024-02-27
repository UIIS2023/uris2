using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AuctionService.DtoModels;

namespace AuctionService.Entities
{
	public class JavnoNadmetanje
	{
        /// <summary>
        /// Id javnog nadmetanja
        /// </summary>
		/// 
        //primatrni kljuc javnog nadmetanja
        [Key]
		public Guid javnoNadmetanjeID { get; set; }

        /// <summary>
        /// Datum pocetka javnog nadmetanja
        /// </summary>
        /// 
        public DateTime datum { get; set; }

        /// <summary>
        /// Vreme pocetka javnog nadmetanja
        /// </summary>
        /// 
        //vreme pocetka javnog nadmetanja
        public DateTime vremePocetka { get; set; }

        /// <summary>
        /// Vreme kraja javnog nadmetanja
        /// </summary>
        /// 
        //vreme kraja javnog nadmetanja
        public DateTime vremeKraja { get; set; }

        /// <summary>
        /// Pocetna cena javnog nadmetanja po hektaru
        /// </summary>
        /// 
      
        public int pocetnaCenaPoHektaru { get; set; }

        /// <summary>
        /// Da li je javno nadmetanje izuzeto ili nije
        /// </summary>
        /// 
     
        public bool izuzeto { get; set; }

        /// <summary>
        /// Izlicitirana cena javnog nadmetanja
        /// </summary>
        /// 

        /// <summary>
        /// Id tipa javnog nadmetanja
        /// </summary>
        /// 
        [ForeignKey("TipJavnogNadmetanja")]
        public Guid tipID { get; set; }
        //public TipJavnogNadmetanja tipNadmetanja { get; set; }

        public int izlicitiranaCena { get; set; }

        /// <summary>
        /// Period zakupa parcele iz javnog nadmetanja
        /// </summary>
        /// 
        //period zakupa zemljista
        public int periodZakupa { get; set; }

        /// <summary>
        /// Broj ucesnika u javnom nadmetanju
        /// </summary>
        /// 
        
        public int brojUcesnika { get; set; }

        /// <summary>
        /// Visina depozita javnog nadmetanja
        /// </summary>
        /// 
        
        public int visinaDopuneDepozita { get; set; }

        /// <summary>
        /// Krug javnog nadmetanja
        /// </summary>
        /// 
        
        public int krug { get; set; }

        //status nadmetanja
        /// <summary>
        /// Id statusa javnog nadmetanja
        /// </summary>
        /// 
        [ForeignKey("StatusNadmetanja")]
		public Guid statusNadmetanjaID { get; set; }
       // public StatusNadmetanja statusID { get; set; }

        /// <summary>
        /// Adresa javnog nadmetanja
        /// </summary>
        /// 
        public Guid adresaID { get; set; }


        /// <summary>
        /// Id ovlascenog lica javnog nadmetanja
        /// </summary>
        /// 

        public Guid ovlascenoLiceID { get; set; }

        /// <summary>
        /// Lista prijavljenih kupaca na javnom nadmetanju
        /// </summary>
        /// 
        [NotMapped]
		public List<Guid> prijavljeniKupciID { get; set; }

        
        //Najbolji ponudjac

        /// <summary>
        /// Id kupca koji je najbolji ponudjac na javnom nadmetanju
        /// </summary>
        /// 
        
        public Guid najboljiPonudjacID { get; set;}

        /// <summary>
        /// Lista parcela koje se nalaze na javnom nadmetanju
        /// </summary>
        /// 
		[NotMapped]
        public List<Guid> parceleID { get; set; }

        /// <summary>
        /// Ovlasceno lice 
        /// </summary>
        /// 
		[NotMapped]
		public OvlascenoLiceDto ovlascenoLice { get; set; }

        /// <summary>
        /// Parcele
        /// </summary>
        /// 
		[NotMapped]
		public List<ParcelaDto> parcele { get; set; }

        /// <summary>
        /// Najbolji ponudjac
        /// </summary>
        /// 
		[NotMapped]
		public KupacDto najboljiPonudjac { get; set; }

        /// <summary>
        /// Lista kupaca
        /// </summary>
        /// 
		[NotMapped]
		public List<KupacDto> prijavljeniKupci { get; set; }

        /// <summary>
        /// Adresa 
        /// </summary>
        /// 
		[NotMapped]
		public AdresaDto adreasa { get; set; }


    }
}

