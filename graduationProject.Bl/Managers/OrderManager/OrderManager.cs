using graduationProject.Bl.DTOs.OrderDto;
using graduationProject.DAL.Data.Models;
using graduationProject.DAL;
using AutoMapper;
using graduationProject.Bl.DTOs.CityDTO;
using graduationProject.Bl.DTOs;
using graduationProject.Shared.Enums;
using System.Linq.Expressions;

namespace graduationProject.Bl.Managers.OrderManager
{
    public class OrderManager : IOrderManager
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderManager(IRepository<Order> repository, IRepository<OrderItem> orderItemRepository, IMapper mapper)
        {
            _repository = repository;
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }
        public async Task<PaginationDTO<OrderReadDto>> GetAllAsNoTrackingAsync(
          int pageNumber,
          int pageSize,
          OrderStatus Status = 0,
          DateTime? startdateTime = null,
          DateTime? enddateTime = null)
        {
            Expression<Func<Order, bool>> expression = o => o.OrderStatus == Status;

            if (startdateTime != null && enddateTime != null)
                expression = o => o.OrderStatus == Status && o.Date.Date >= startdateTime.Value.Date && o.Date.Date <= enddateTime.Value.Date;

            var entity = await _repository.GetAllAsNoTrackingAsync(
                pageNumber, pageSize, new[] { "ShippingType", "Branch", "City", "State", "OrderItems" },
                expression);

            int totalPages = _repository.GetTotalPages(pageSize);

            PaginationDTO<OrderReadDto> result = new()
            {
                TotalPages = totalPages,
                Data = _mapper.Map<IList<OrderReadDto>>(entity)
            };

            return result;
        }
        public async Task<IEnumerable<OrderReadDto>> GetByTraderIDAsync(int pageNumber, int pageSize ,string Traderid)
        {
            var entity = await _repository.GetAllAsNoTrackingAsync(
                pageNumber, pageSize, new[] { "ShippingType", "Branch", "City", "State", "OrderItems" }, T => T.TraderId == Traderid);
            return _mapper.Map<IList<OrderReadDto>>(entity);
        }

        public async Task<IEnumerable<OrderReadDto>> GetByRepresentativeIDAsync(int pageNumber, int pageSize, string Representativeid)
        {
            var entity = await _repository.GetAllAsNoTrackingAsync(
                pageNumber, pageSize, new[] { "ShippingType", "Branch", "City", "State", "OrderItems" }, R => R.RepresentativeID == Representativeid);
            return _mapper.Map<IList<OrderReadDto>>(entity);
        }

        public async Task<IEnumerable<OrderReadDto>> GetByEmployeeIDAsync(int pageNumber, int pageSize)
        {
            var entity = await _repository.GetAllAsNoTrackingAsync(
                pageNumber, pageSize, new[] { "ShippingType", "Branch", "City", "State", "OrderItems" });
            return _mapper.Map<IList<OrderReadDto>>(entity);
        }
        public async Task<OrderReadDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByCriteriaAsync(o => o.Id == id, new[] { "ShippingType", "Branch", "City", "State", "OrderItems" });
            return _mapper.Map<OrderReadDto>(entity);
        }

        public async Task<OrderWriteNewStatusDto> AddAsync(OrderWriteNewStatusDto entity)
        {
            var Model = _mapper.Map<Order>(entity);
            await _repository.AddAsync(Model);
            _repository.SaveChanges();
            return entity;
        }
        public async Task<OrderUpdateStatusGiveRepresentativeDto> UpdateStatusAndGiveRepresentativeAsync(OrderUpdateStatusGiveRepresentativeDto entity)
        {
            var order = _repository.GetByIdAsync(entity.Id).Result;
            var Model = _mapper.Map<Order>(order);
            Model.OrderStatus = entity.OrderStatus;
            Model.RepresentativeID = entity.RepresentativeID;
            await _repository.UpdateAsync(Model);
            _repository.SaveChanges();
            return entity;
        }

        public async Task<OrderUpdateStatusAndReceivedCostDto> UpdateStatusAndRecievedCostAsync(OrderUpdateStatusAndReceivedCostDto entity)
        {
            var order = _repository.GetByIdAsync(entity.Id).Result;
            var Model = _mapper.Map<Order>(order);
            Model.OrderStatus = entity.OrderStatus;

            #region Compare recieved cost
            if (Model.OrderCost < entity.ReceivedCost)
                Model.ReceivedCost = Model.OrderCost;
            else if(entity.ReceivedCost < 0)
                Model.ReceivedCost = 0;
            else
                Model.ReceivedCost = entity.ReceivedCost;
            #endregion

            #region Compare recieved shipping cost
            if (Model.OrderShipingCost < entity.ReceivedShippingCost)
                Model.ReceivedShipingCost = Model.OrderShipingCost;
            else if (entity.ReceivedShippingCost < 0)
                Model.ReceivedShipingCost = 0;
            else
                Model.ReceivedShipingCost = entity.ReceivedShippingCost;
            #endregion

            await _repository.UpdateAsync(Model);
            _repository.SaveChanges();
            return entity;
        }

        public async Task<OrderUpdateStatusOnlyDto> UpdateStatusAsync(OrderUpdateStatusOnlyDto entity)
        {
            var order = _repository.GetByIdAsync(entity.Id).Result;
            var Model = _mapper.Map<Order>(order);
            Model.OrderStatus = entity.OrderStatus;
            await _repository.UpdateAsync(Model);
            _repository.SaveChanges();
            return entity;
        }

        public async Task DeleteAsync(OrderWriteNewStatusDto entity)
        {
            var Model = _mapper.Map<Order>(entity);
            _orderItemRepository.DeleteRange(Model.OrderItems.ToList());
             _repository.DeleteById(Model);
            _repository.SaveChanges();
        }

        public async Task<IEnumerable<OrderGroupByKeyValueDto>> GetAllGroupByTraderID(string Traderid)
        {
            var Model =  _repository.GetGrouped(
                e => e.OrderStatus
                , g => new OrderGroupByKeyValueDto 
                { 
                    OrderStatus = g.Key.ToString(),
                    NumberOrder = g.Count() 
                }
                ,t=>t.TraderId==Traderid);
            return Model;
        }

        public async Task<IEnumerable<OrderGroupByKeyValueDto>> GetAllGroupByRepresentativeID(string RepresentativeID)
        {
            var Model = _repository.GetGrouped(
                           e => e.OrderStatus
                           , g => new OrderGroupByKeyValueDto
                           {
                               OrderStatus = g.Key.ToString(),
                               NumberOrder = g.Count()
                           }
                           , t => t.RepresentativeID==RepresentativeID );
            return Model;
        }

        public async Task<IEnumerable<OrderGroupByKeyValueDto>> GetAllGroupByEmployee()
        {
            var Model = _repository.GetGrouped(
                                    e => e.OrderStatus
                                    , g => new OrderGroupByKeyValueDto
                                    {
                                        OrderStatus = g.Key.ToString(),
                                        NumberOrder = g.Count()
                                    }
                                    );
            return Model;
        }
    }
}
