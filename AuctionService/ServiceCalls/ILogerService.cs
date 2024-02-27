using System;
using AuctionService.DtoModels;

namespace AuctionService.ServiceCalls
{
	public interface ILogerService
	{
		
		
            /// <summary>
            /// Metoda za kreiranje poruke logeru
            /// </summary>
            /// <param name="message"></param>
            void CreateMessage(Message message);
        

		
	}
}

