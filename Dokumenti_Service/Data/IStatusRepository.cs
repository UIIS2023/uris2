using Dokumenti_Service.Entities.Dokument;

namespace Dokumenti_Service.Data
{
    public interface IStatusRepository
    {
        List<Status> GetAllStatuses();
        public Status GetStatusEntityById(Guid status_id);
        Status CreateStatus(Status status);
        void UpdateStatus(Status status);
        void DeleteStatus(Guid status_id);
        bool SaveChanges();
    }
}
