using MediatR;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Services.Services.SelfServiceDb
{
    public partial class SelfServiceDbService : ServiceBase<SelfServiceDbService>, ISelfServiceDbService
    {
        private readonly IMediator _mediator;

        public SelfServiceDbService(ILogger<SelfServiceDbService> logger, IMediator mediator) : base(logger)
        {
            this._mediator = mediator;
        }
    }
}
