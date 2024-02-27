using System;
using AuctionService.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.DtoModels
{
	public class JavnoNadmetanjeDto
	{

        /// <summary>
        /// Id javnog nadmetanja
        /// </summary>
        /// 
        //primatrni kljuc javnog nadmetanja
        
        public Guid javnoNadmetanjeID { get; set; }

        /// <summary>
        /// Datum javnog nadmetanja
        /// </summary>
        /// 
        //datum javnog nadmetanja
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
        /// Pocetna cena po hektaru
        /// </summary>
        /// 
        //pocetna cena po hekraru
        public int pocetnaCenaPoHektaru { get; set; }

        /// <summary>
        /// Da li je javno nadmetanje izuzeto 
        /// </summary>
        /// 
        //Izuzeto sa javnog nadmetanja
        public bool izuzeto { get; set; }

        /// <summary>
        /// Izlicitirana cena na javnom nadmetanju
        /// </summary>
        /// 
        //izlicitirana cena
        public int izlicitiranaCena { get; set; }

        /// <summary>
        /// Period zakupa parcele
        /// </summary>
        /// 
        //period zakupa zemljista
        public int periodZakupa { get; set; }

        /// <summary>
        /// Broj ucesnika na javnom nadmetanju
        /// </summary>
        /// 
        //broj ucesnika u licitaciji
        public int brojUcesnika { get; set; }

        /// <summary>
        /// Visina depozita za uplatu
        /// </summary>
        /// 
        //visina dopune depozita
        public int visinaDopuneDepozita { get; set; }

        /// <summary>
        /// Krug javnog nadmetanja
        /// </summary>
        /// 
        //krug nadmetanja
        public int krug { get; set; }

        /// <summary>
        /// Id statusa nadmetanja
        /// </summary>
        /// 
        //status nadmetanja 
        
        public Guid statusNadmetanjaID { get; set; }
        

        /// <summary>
        /// Id tipa nadmetanja
        /// </summary>
        /// 
        
        public Guid tipID { get; set; }
       

        /// <summary>
        /// Id ovlascenog lica
        /// </summary>
        /// 
        //Ovlascena lica javnog nadmetanja (licitanti)
        
        public Guid ovlascenoLiceID { get; set; }

        /// <summary>
        /// Lista id-jeva kupaca koji ucestvuju na javnom nadmetanju
        /// </summary>
        /// 
       
        
        public List<Guid> prijavljeniKupciID { get; set; }

        /// <summary>
        /// Id adrese javnog nadmetanja
        /// </summary>
        /// 
        
        
        public Guid adresaID { get; set; }
        //Najbolji ponudjac

        /// <summary>
        /// Id kupca koji je najbolji ponudjac
        /// </summary>
        /// 
        
        public Guid najboljiPonudjacID { get; set; }

        /// <summary>
        /// Lista id-jeva parcela koje ucestvuju na javnom nadmetanju
        /// </summary>
        /// 
        
        public List<Guid> parceleID { get; set; }

        /// <summary>
        /// Ovlasceno lice
        /// </summary>
        /// 
        [NotMapped]
        public OvlascenoLiceDto ovlascenoLice { get; set; }

        /// <summary>
        /// Lista parcela 
        /// </summary>
        /// 
        [NotMapped]
        public List<ParcelaDto> parcele { get; set; }

        /// <summary>
        /// Kupac koji je najbolji ponudjac
        /// </summary>
        /// 
        [NotMapped]
        public KupacDto najboljiPonudjac { get; set; }

        /// <summary>
        /// Lista prijavljenih kupaca 
        /// </summary>
        /// 
        [NotMapped]
        public List<KupacDto> prijavljeniKupci { get; set; }

        /// <summary>
        /// Adresa javnog nadmetanja
        /// </summary>
        /// 
        [NotMapped]
        public AdresaDto adreasa { get; set; }




    }
}

