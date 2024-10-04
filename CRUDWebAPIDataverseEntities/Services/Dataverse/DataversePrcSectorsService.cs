using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;

namespace CRUDWebAPIDataverseEntities.Services.Dataverse
{
    using Microsoft.PowerPlatform.Dataverse.Client;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using CRUDWebAPIDataverseEntities.Entities;



    public class DataversePrcSectorsService: IDataversePrcSectorsService
    {
        private readonly ServiceClient _serviceClient;
        public DataversePrcSectorsService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Dataverse");
            _serviceClient = new ServiceClient(connectionString);
        }


        public async Task<Guid> CreatePrcSectorAsync(PrcSector prcSector)
        {
            var entity = new Entity("prc_sector"); // Replace with your entity logical name
            entity["prc_antenna_brand"] = prcSector.PrcAntennaBrand;
            

            return await Task.Run(() => _serviceClient.Create(entity));
        }

        public async Task<PrcSector> GetPrcSectorAsync(Guid id)
        {
            var columns = new ColumnSet("prc_antenna_brand");
            var entity = await Task.Run(() => _serviceClient.Retrieve("prc_sector", id, columns));

            if (entity == null) return null;

            return new PrcSector
            {
                Id = entity.Id,
                PrcAntennaBrand = entity.GetAttributeValue<string>("prc_antenna_brand"),
              
            };
        }

        public async Task UpdatePrcSectorAsync(PrcSector PrcSector)
        {
            var entity = new Entity("prc_sector", PrcSector.Id);
            entity["prc_antenna_brand"] = PrcSector.PrcAntennaBrand;
          

            await Task.Run(() => _serviceClient.Update(entity));
        }

        public async Task DeletePrcSectorAsync(Guid id)
        {
            await Task.Run(() => _serviceClient.Delete("prc_sector", id));
        }

        public async Task<List<PrcSector>> GetPrcSectorsAsync()
        {
            var query = new QueryExpression("prc_sector")
            {
                ColumnSet = new ColumnSet("prc_antenna_brand")
            };

            var entities = await Task.Run(() => _serviceClient.RetrieveMultiple(query));

            var PrcSectors = new List<PrcSector>();

            foreach (var entity in entities.Entities)
            {
                PrcSectors.Add(new PrcSector
                {
                    Id = entity.Id,
                    PrcAntennaBrand = entity.GetAttributeValue<string>("prc_antenna_brand"),
                    
                });
            }

            return PrcSectors;
        }

    }
}




