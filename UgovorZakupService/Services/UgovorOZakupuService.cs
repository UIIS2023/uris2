using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgovorZakupService.DtoModels;
using UgovorZakupService.Entities;
using UgovorZakupService.Repository;

namespace UgovorZakupService.Services
{
    public class UgovorOZakupuService : IUgovorOZakupuRepository
    {
        public static List<Entities.UgovorOZakupu> ugovoriOZakupu { get; set; } = new List<Entities.UgovorOZakupu>();
        private readonly UgovorOZakupuContext ugovorOZakupuContext;
        private readonly IMapper mapper;


        public UgovorOZakupuService(UgovorOZakupuContext context, IMapper mapper)
        {
            this.ugovorOZakupuContext = context;
            this.mapper = mapper;
            FillData();
        }

        private static void FillData()
        {
            ugovoriOZakupu.AddRange(new List<Entities.UgovorOZakupu>
            {
                new Entities.UgovorOZakupu
                {
                    ugovorOZakupuID = Guid.Parse("8132A67F-046E-450B-882B-71341519F871"),
                    javnoNadmetanjeID = Guid.Parse("9E42D535-1BA5-4BD2-A2F5-AFC7C61091B2"),
                    dokumentID = Guid.Parse("07852453-68D2-4D05-8379-B36AD7223DE2"),
                    tipGarancijeID = Guid.Parse("3F25BA56-68FF-44B5-AAC6-F422ED1B420E"),
                    kupacID = Guid.Parse("ACE4F1F7-8695-4843-9052-B38B3E71BF60"),
                    rokoviDospeca = new int[] { 1, 2, 3 },
                    zavodniBroj = "test zavodni broj",
                    datumZavodjenja = DateTime.Parse("2022-12-12"),
                    licnostID = Guid.Parse("6021B50D-BF85-4E40-889B-9D9F8A8203B7"),
                    rokVracanjeZemljista = DateTime.Parse("2022-12-12"),
                    mestoPotpisivanja = "test mesto potpisivanja",
                    datumPotpisa = DateTime.Parse("2022-12-12")
                },
                new Entities.UgovorOZakupu
                {
                    ugovorOZakupuID = Guid.Parse("39FDA303-9793-474B-A8A4-128F122DCF19"),
                    javnoNadmetanjeID = Guid.Parse("{C0C80C7F-06AA-44A3-8341-A3905A4A133B}"),
                    dokumentID = Guid.Parse("{FFD76ACB-8152-4143-9016-63DB4F8BAA75}"),
                    tipGarancijeID = Guid.Parse("{65CEFCAD-BC6C-4E8D-AF60-BC6D04450167}"),
                    kupacID = Guid.Parse("{1487E75E-0D36-4B5F-B998-1DB9F58AB36B}"),
                    rokoviDospeca = new int[] { 1, 2, 3 },
                    zavodniBroj = "test zavodni broj",
                    datumZavodjenja = DateTime.Parse("2022-12-12"),
                    licnostID = Guid.Parse("{C1B1336C-D101-468B-98AD-D529B3D872AF}"),
                    rokVracanjeZemljista = DateTime.Parse("2022-12-12"),
                    mestoPotpisivanja = "test mesto potpisivanja",
                    datumPotpisa = DateTime.Parse("2022-12-12")
                }
            });
        }

        public UgovorOZakupuConfirmationDto CreateUgovorOZakupu(UgovorOZakupu ugovorOZakupu)
        {
            ugovorOZakupu.ugovorOZakupuID = Guid.NewGuid();
            ugovoriOZakupu.Add(ugovorOZakupu);
            return mapper.Map<UgovorOZakupuConfirmationDto>(ugovorOZakupu);
        }

        public void DeleteUgovorOZakupu(Guid id)
        {
            Entities.UgovorOZakupu uz = GetUgovorOZakupuById(id);
            ugovorOZakupuContext.ugovoriOZakupu.Remove(uz);
        }

        public List<UgovorOZakupu> GetAllUgovorOZakupu()
        {
            return (from uz in ugovoriOZakupu select uz).ToList();
        }

        public UgovorOZakupu GetUgovorOZakupuById(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return ugovoriOZakupu.FirstOrDefault(uz => uz.ugovorOZakupuID == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public bool SaveChanges()
        {
            return true;
        }

        public UgovorOZakupuConfirmationDto UpdateUgovorOZakupu(UgovorOZakupu ugovorOZakupu)
        {
            throw new NotImplementedException();
        }
    }
}
