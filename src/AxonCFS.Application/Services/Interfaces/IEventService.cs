using System;
using System.Threading.Tasks;
using AxonCFS.Application.Results;
using AxonCFS.Application.ViewModels;

namespace AxonCFS.Application.Services.Interfaces
{
    public interface IEventService
    {
        Task<ServiceResult<SearchEventViewModel>> GetEventByCriteria(string userId, string responder = null, DateTime? fromDate = null, DateTime? toDate = null);
    }
}