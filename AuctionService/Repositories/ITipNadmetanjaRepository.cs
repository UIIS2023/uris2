using System;
using AuctionService.DtoModels;

namespace AuctionService.Repository
{
	public interface ITipNadmetanjaRepository
	{
		//get all tipvi javnog nadmetanja
		List<Entities.TipJavnogNadmetanja> getAllTipoviJavnogNadmetanja();

		//get tip javnog nadmetanja by id
		Entities.TipJavnogNadmetanja getTipJavnogNadmetanjaById(Guid id);

		//crete tip javnog nadmetanja
		TipJavnogNadmetanjaConformationDto postTipJavnogNadmetanja(Entities.TipJavnogNadmetanja tipJN);

		//update tip javnog nadmetanja
		TipJavnogNadmetanjaConformationDto updateTipJavnogNadmetanja(Entities.TipJavnogNadmetanja tipJN);

		//delete tip javnog nadmetanja
		void deleteTipJavnogNadmetanja(Guid id);

		//save changes
		bool SaveChanges();

	}
}

