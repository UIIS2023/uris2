using KomisijaService.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomisijaService.ServiceCalls
{
    public interface ILoggerService
    {
        void CreateMessage(Message message);
    }
}
