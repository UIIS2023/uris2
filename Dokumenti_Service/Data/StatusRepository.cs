using AutoMapper;
using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities;
using Dokumenti_Service.Models;
using Dokumenti_Service.Entities.Zalba;

namespace Dokumenti_Service.Data
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;



        public StatusRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Status CreateStatus(Status status)
        {
            status.statusID = Guid.NewGuid();
            var createdStatus = context.Add(status);
            return mapper.Map<Status>(createdStatus.Entity);
        }



        public void DeleteStatus(Guid status_id)
        {
            var statusDel = GetStatusEntityById(status_id);
            context.Remove(statusDel);
        }

        public List<Status> GetAllStatuses()
        {
            return context.Status.ToList();
        }

        public Status GetStatusEntityById(Guid status_id)
        {
            return context.Status.FirstOrDefault(e => e.statusID == status_id);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        

        public void  UpdateStatus(Status status)
        {
           
        }
    }
}
