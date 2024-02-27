
using System;
using AuctionService.DtoModels;

namespace AuctionService.Repository
{
	public interface IStatusNadmetanjaRepository
	{
		//get all statusi nadmetanja
		List<Entities.StatusNadmetanja> getAllStatusiNadmetanja();

		//get statusi nadmetanja byID
		Entities.StatusNadmetanja getStatusNadmetanjaByID(Guid id);

		//create status nadmetanja
		StatusNadmetanjaConformationDto postStatusNadmetanja(Entities.StatusNadmetanja status);

		//update status nadmetanja
		StatusNadmetanjaConformationDto updateStatusNadmetanja(Entities.StatusNadmetanja status);

		//delete status nadmetanja
		void deleteStatusNadmetanja(Guid id);

		//save changes
		bool SaveChanges();
	}
}

