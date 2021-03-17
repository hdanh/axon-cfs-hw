using System;
using System.Threading.Tasks;
using AxonCFS.Application.Results;
using AxonCFS.Application.Services.Interfaces;
using AxonCFS.Application.ViewModels;

namespace AxonCFS.Application.Services
{
    public class EventService : IEventService
    {
        public Task<ServiceResult<SearchEventViewModel>> GetEventByCriteria(string userId, string responder = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            throw new NotImplementedException();
        }
    }
}