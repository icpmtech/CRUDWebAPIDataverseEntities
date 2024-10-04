using CRUDWebAPIDataverseEntities.Entities;

namespace CRUDWebAPIDataverseEntities.Services.Dataverse
{
    public interface IDataversePrcSectorsService
    {
        Task<Guid> CreatePrcSectorAsync(PrcSector prcSector);
        Task DeletePrcSectorAsync(Guid id);
        Task<PrcSector> GetPrcSectorAsync(Guid id);
        Task<List<PrcSector>> GetPrcSectorsAsync();
        Task UpdatePrcSectorAsync(PrcSector PrcSector);
    }
}