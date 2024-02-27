using System;
using AuctionService.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.DtoModels
{
	public class JavnoNadmetanjeUpdateDto
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
        /// Da li je jn izuzeto ili ne
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
   
        public int periodZakupa { get; set; }

        /// <summary>
        /// Broj ucesnika na javnom nadmetanju
        /// </summary>
        /// 
        //broj ucesnika u licitaciji
        public int brojUcesnika { get; set; }

        /// <summary>
        /// Visina dopune depozita
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

        //Lista parcela koje se nalaze na tom javnom nadmetanju

        /// <summary>
        /// ID statusa nadetanja
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
        
        
        public Guid ovlascenoLiceID { get; set; }

        /// <summary>
        /// Lista id-jeva prijavljenih kupaca
        /// </summary>
        /// 
        
        
        public List<Guid> prijavljeniKupciID { get; set; }

        /// <summary>
        /// Adresa odrzavanja nadmetanja
        /// </summary>
        /// 
        //Adresa odrzavnja nadmetanja
       
        public Guid adresaID { get; set; }
        

        /// <summary>
        /// Id najboljeg ponudjaca
        /// </summary>
        /// 
        
        public Guid najboljiPonudjacID { get; set; }

        /// <summary>
        /// Lista id-jeva parcela na javnom nadmetanju
        /// </summary>
        /// 
        
        public List<Guid> parceleID { get; set; }


    }
}

