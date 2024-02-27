using System;
using AuctionService.DtoModels;

namespace AuctionService.Repository
{
	public interface IJavnoNadmetanjeRepository
	{
		//funkcija get all javno nadmetanje
		List<Entities.JavnoNadmetanje> getJavnaNadmetanja();

		//get javno nadmetanje by id
		Entities.JavnoNadmetanje getJavnoNadmetanjeByID(Guid id);

        //create javno nadmetanje
        JavnoNadmetanjeConformationDto postJavnoNadmetanje(Entities.JavnoNadmetanje jn);

		//update javno nadmetanje
		JavnoNadmetanjeConformationDto updateJavnoNadmetanje(Entities.JavnoNadmetanje jn);

		//delete javno nadmetanje
		void deleteJavnoNadmetanje(Guid id);

		//save javno nadmetanje
		bool saveChanges();

	}
}

