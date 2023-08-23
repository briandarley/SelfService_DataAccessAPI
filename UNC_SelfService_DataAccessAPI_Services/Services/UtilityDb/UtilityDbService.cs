using MediatR;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Services.UtilityDb
{
    public partial class UtilityDbService : ServiceBase<UtilityDbService>, IUtilityDbService
    {
        private readonly IMediator _mediator;

        public UtilityDbService(ILogger<UtilityDbService> logger, IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }
    }
}
