using System;
using System.Threading.Tasks;
using AxonCFS.Application.BindingModels;
using AxonCFS.Application.Results;
using AxonCFS.Application.ViewModels;

namespace AxonCFS.Application.Services.Interfaces
{
    public interface IEventService
    {
        Task<ServiceResult<SearchEventViewModel>> GetEventByCriteria(string userId, string responder, DateTime? fromDate, DateTime? toDate, int offset, int limit);

        Task<ServiceResult<EventViewModel>> CreateEvent(string userId, PostEventBindingModel model);
    }
}