using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AxonCFS.Application.BindingModels;
using AxonCFS.Application.Results;
using AxonCFS.Application.Services.Interfaces;
using AxonCFS.Application.ViewModels;
using AxonCFS.Domain.Models;
using AxonCFS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AxonCFS.Application.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EventService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceResult<EventViewModel>> CreateEvent(string userId, PostEventBindingModel model)
        {
            var agency = await _dbContext
                .AgencyUsers
                    .Where(x => x.UserId == userId)
                    .Select(x => x.Agency)
                    .FirstOrDefaultAsync();

            if (agency == null)
                return new ServiceResult<EventViewModel>("Agency not found");

            var responder = await _dbContext.Responders
                .FirstOrDefaultAsync(x => x.Code == model.Responder);

            if (responder == null)
            {
                responder = new Responder()
                {
                    Code = model.Responder,
                    Agency = agency
                };

                _dbContext.Add(responder);
            }

            var eventType = await _dbContext.EventTypes
                .FirstOrDefaultAsync(x => x.Code == model.EventCode);

            if (eventType == null)
            {
                eventType = new EventType()
                {
                    Code = model.EventCode
                };

                _dbContext.Add(eventType);
            }

            var entity = new Event()
            {
                DispatchTime = model.DispatchTime,
                EventTime = model.EventTime,
                Number = model.EventNumber,
                Responder = responder,
                Type = eventType
            };

            _dbContext.Add(entity);
            var result = await _dbContext.SaveChangesAsync();

            if (result > 0)
                return new ServiceResult<EventViewModel>(_mapper.Map<EventViewModel>(entity));

            return new ServiceResult<EventViewModel>("An error occured.");
        }

        public async Task<ServiceResult<SearchEventViewModel>> GetEventByCriteria(
            string userId,
            string responder,
            DateTime? fromDate,
            DateTime? toDate,
            int offset,
            int limit)
        {
            var agency = await _dbContext
                .AgencyUsers
                    .Where(x => x.UserId == userId)
                    .Select(x => x.Agency)
                    .FirstOrDefaultAsync();

            if (agency == null)
                return new ServiceResult<SearchEventViewModel>("Agency not found");

            var query = _dbContext.Events
                .Include(x => x.Type)
                .Include(x => x.Responder)
                .ThenInclude(x => x.Agency)
                .Where(x => x.Responder.AgencyId == agency.Id);

            if (!string.IsNullOrEmpty(responder))
            {
                query = query.Where(x => x.Responder.Code.ToLower().Contains(responder.ToLower()));
            }

            if (fromDate.HasValue)
            {
                query = query.Where(x => x.EventTime >= fromDate || x.DispatchTime >= fromDate);
            }

            if (toDate.HasValue)
            {
                query = query.Where(x => x.EventTime <= toDate || x.DispatchTime <= toDate);
            }

            query = query.OrderByDescending(x => x.EventTime);

            var total = await query.CountAsync();

            if (limit > 0)
                query = query.Skip(offset).Take(limit);

            var data = await query.ToListAsync();

            var result = new SearchEventViewModel()
            {
                Events = _mapper.Map<List<EventViewModel>>(data),
                Total = total
            };
            return new ServiceResult<SearchEventViewModel>(result);
        }
    }
}