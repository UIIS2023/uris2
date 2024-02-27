using System;
using AuctionService.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuctionService.DtoModels
{
    public class JavnoNadmetanjeCreationDto
    {

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
        /// Da li je javno nadmetanje izuzeto iz javnog nadmetanja
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
        /// Period zakupa javnog nadmetanja
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
        /// Id statusa javnog nadmetanja
        /// </summary>
        /// 
        //status nadmetanja 
        
        public Guid statusNadmetanjaID { get; set; }
        

        /// <summary>
        /// Id tipa javnog nadmetanja
        /// </summary>
        /// 
        
        public Guid tipID { get; set; }
      

        /// <summary>
        /// ID ovlascenog lica javnog nadmetanja
        /// </summary>
        /// 
        //Ovlascena lica javnog nadmetanja (licitanti)
        
        public Guid ovlascenoLiceID { get; set; }

        /// <summary>
        /// Lista prijavljenih kupaca na javno nadmetanje
        /// </summary>
        /// 
        //Prijavljeni kupci na javno nadmetanje
        
        public List<Guid> prijavljeniKupciID { get; set; }

        /// <summary>
        /// Adresa odrzavanja javnog nadmetanja
        /// </summary>
        /// 
        
       
        public Guid adresaID { get; set; }
        //Najbolji ponudjac

        /// <summary>
        /// Najbolji ponudjac na javnom nadmetanju
        /// </summary>
        /// 
        
        public Guid najboljiPonudjacID { get; set; }

        /// <summary>
        /// Lista parcela na javnom nadmetanju
        /// </summary>
        /// 
        
        public List<Guid> parceleID { get; set; }


    }
}

