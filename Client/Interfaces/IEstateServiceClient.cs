using Shared.Models.DTOs.Admin;

namespace Client.Interfaces
{
    public interface IEstateServiceClient
    {
        Task<IEnumerable<EstateDto>> GetEstates();
        Task<EstateDto> GetEstate(Guid id);
        Task<EstateForUpdate> GetEstateForUpdate(Guid id);
        Task<EstateDto> CreateEstate(EstateForCreation estate);
        Task<EstateDto> UpdateEstate(Guid id, EstateForUpdate estate);
        Task DeleteEstate(Guid id);

        Task<IEnumerable<HousingBlockDto>> GetHousingBlocks();
        Task<HousingBlockDto> GetHousingBlock(Guid id);
        Task<HousingBlockForUpdate> GetHousingBlockForUpdate(Guid id);
        Task<HousingBlockDto> CreateHousingBlock(HousingBlockForCreation housingBlock);
        Task<HousingBlockDto> UpdateHousingBlock(Guid id, HousingBlockForUpdate housingBlock);
        Task DeleteHousingBlock(Guid id);

        Task<IEnumerable<HousingTypeDto>> GetHousingTypes();
        Task<HousingTypeDto> GetHouseType(Guid id);
        Task<HousingTypeForUpdate> GetHousingTypeForUpdate(Guid id);
        Task<HousingTypeDto> CreateHousingType(HousingTypeForCreation housingBlock);
        Task<HousingTypeDto> UpdateHousingType(Guid id, HousingTypeForUpdate housingBlock);
        Task DeleteHousingType(Guid id);

        Task<IEnumerable<HousingUnitDto>> GetHousingUnits();
        Task<HousingUnitDto> GetHousingUnit(Guid id);
        Task<HousingUnitForUpdate> GetHousingUnitForUpdate(Guid id);
        Task<HousingUnitDto> CreateHousingUnit(HousingUnitForCreation housingBlock);
        Task<HousingUnitDto> UpdateHousingUnit(Guid id, HousingUnitForUpdate housingBlock);
        Task DeleteHousingUnit(Guid id);


    }
}
