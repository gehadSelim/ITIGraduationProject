using graduationProject.Bl.DTOs;
using graduationProject.Bl.DTOs.OrderDto;
using graduationProject.Bl.Managers;
using graduationProject.Bl.Managers.CityManager;
using graduationProject.Bl.Managers.OrderManager;
using graduationProject.DAL.Data.Models;
using graduationProject.Filters;
using graduationProject.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace graduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManager orderManager;
        private readonly ITraderManager traderManager;
        private readonly ICityManager cityManager;
        private readonly IShippingTypeManager shippingTypeManager;
        private readonly ISettingsManager settingsManager;

        public OrdersController(
            IOrderManager _orderManager
           ,ITraderManager _traderManager
            ,ICityManager _cityManager,
           IShippingTypeManager _shippingTypeManager
            ,ISettingsManager _settingsManager)
        {
            orderManager = _orderManager;
            traderManager = _traderManager;
            cityManager = _cityManager;
            shippingTypeManager = _shippingTypeManager;
            settingsManager = _settingsManager;
        }


        [HttpGet("GetAllOrderPaymentTypeAndOrderStatusAndOrderTypeDto")]
        public IActionResult GetAllOrderPaymentTypeAndOrderStatusAndOrderTypeDto()
        {
            OrderPaymentTypeAndOrderStatusAndOrderTypeDto orderPaymentTypeAndOrderStatusAndOrderTypeDto = new ();
            orderPaymentTypeAndOrderStatusAndOrderTypeDto.PaymentType = EnumExtensions.GetValues<PaymentType>();
            orderPaymentTypeAndOrderStatusAndOrderTypeDto.OrderStatus = EnumExtensions.GetValues<OrderStatus>();
            orderPaymentTypeAndOrderStatusAndOrderTypeDto.OrderType = EnumExtensions.GetValues<OrderType>();
            return Ok(orderPaymentTypeAndOrderStatusAndOrderTypeDto);
        }

        [HttpGet]
        [Route("GetAllAsNoTrakingAsync")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> GetAllAsNoTrakingAsync(
          int pageNumber = 1, 
          int pageSize = 10,
          OrderStatus status = 0,
          DateTime? startdateTime = null,
          DateTime? enddateTime = null)
        {
            return Ok(await orderManager.GetAllAsNoTrackingAsync(pageNumber, pageSize, status, startdateTime, enddateTime));
        }

        [HttpGet]
        [Route("GetAllByRepresentativeIDAsNoTrakingAsync")]
        [Authorize(Policy = "RepresentativeOnly")]
        public async Task<IActionResult> GetAllRepresentativeAsNoTrakingAsync(string RepresentativeID, int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await orderManager.GetByRepresentativeIDAsync(pageNumber, pageSize, RepresentativeID));
        }
        
        [HttpGet]
        [Route("GetAllByTraderIDAsNoTrakingAsync")]
        [Authorize(Policy = "TradersOnly")]
        public async Task<IActionResult> GetAllTraderAsNoTrakingAsync( string TraderID , int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await orderManager.GetByTraderIDAsync(pageNumber, pageSize, TraderID));
        }
        
        [HttpGet]
        [Route("GetAllByEmployeeAsNoTrakingAsync")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> GetAllEmployeeAsNoTrakingAsync(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await orderManager.GetByEmployeeIDAsync(pageNumber, pageSize));
        }
        
        [HttpGet]
        [Route("GetAllByRepresentativeIDGroupByStatusAsync")]
        [Authorize(Policy = "RepresentativeOnly")]
        public async Task<IActionResult> GetAllRepresentativeGroupByStatusAsync(string RepresentativeID)
        {
            return Ok(await orderManager.GetAllGroupByRepresentativeID(RepresentativeID));
        }

        [HttpGet]
        [Route("GetAllByTraderIDGroupByStatusAsync")]
        [Authorize(Policy = "TradersOnly")]
        public async Task<IActionResult> GetAllTraderGroupByStatusAsync(string TraderID)
        {
            return Ok(await orderManager.GetAllGroupByTraderID(TraderID));
        }

        [HttpGet]
        [Route("GetAllByEmployeeGroupByStatusAsync")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> GetAllEmployeeGroupByStatusAsync()
        {
            return Ok(await orderManager.GetAllGroupByEmployee());
        }

        [HttpGet]
        [Route("GetByIDAsync")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> GetByIDAsync(int id)
        {
            return Ok(await orderManager.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("Insert")]
        [Authorize(Policy = "TradersOnly")]
        public async Task<IActionResult> Insert([FromBody] OrderWriteNewStatusDto entity)
        {
            if (entity == null) { return BadRequest(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var Data=await InsertOrder(entity);
            return Ok(Data);

        }

        private async Task<OrderWriteNewStatusDto> InsertOrder(OrderWriteNewStatusDto entity)
        {
            entity.TotalWeight = entity.OrderItems.Select(oI => oI.ProductWeight * oI.ProductQuantity).Sum();

            double shippingCost = await traderManager.GetShippingCostAsync(entity.TraderId, entity.CityId);
            if (shippingCost == 0)
            {
                shippingCost = await cityManager.GetByIDAsync(entity.CityId);
            }
            shippingCost += shippingTypeManager.GetByIdAsync(entity.ShippingTypeId).Result.Cost;

            var Setting = await settingsManager.GetAsync();

            double OverWeight = entity.TotalWeight - Setting.DefaultWeight;

            if (OverWeight > 0)
            {
                shippingCost += OverWeight * Setting.OverCostPerKG;
            }
            if (entity.IsVillage)
            {
                shippingCost += Setting.VillageShipingCost;
            }
            entity.OrderShipingCost = shippingCost;
            entity.TotalCost = shippingCost + entity.OrderCost;
            var Data = await orderManager.AddAsync(entity);
            return Data;
        }

        [HttpPut]
        [Route("UpdateStatusGiveRepresentative")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> Update(OrderUpdateStatusGiveRepresentativeDto entity)
        {
            if (entity == null) { return BadRequest(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var Data = await orderManager.UpdateStatusAndGiveRepresentativeAsync(entity);
            return Ok(Data);
        }

        [HttpPut]
        [Route("UpdateStatusAndRecievedCost")]
        [Authorize(Policy = "RepresentativeOnly")]
        public async Task<IActionResult> Update(OrderUpdateStatusAndReceivedCostDto entity)
        {
            if (entity == null) { return BadRequest(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var Data = await orderManager.UpdateStatusAndRecievedCostAsync(entity);
            return Ok(Data);
        }

        [HttpPut]
        [Route("UpdateStatusOnlyByEmployee")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> UpdateByEmployee(OrderUpdateStatusOnlyDto entity)
        {
            if (entity == null) { return BadRequest(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var Data = await orderManager.UpdateStatusAsync(entity);
            return Ok(Data);
        }

        [HttpPut]
        [Route("UpdateStatusOnlyByRepresentative")]
        [Authorize(Policy = "RepresentativeOnly")]
        public async Task<IActionResult> UpdateByRepresentative(OrderUpdateStatusOnlyDto entity)
        {
            if (entity == null) { return BadRequest(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var Data = await orderManager.UpdateStatusAsync(entity);
            return Ok(Data);
        }

        [HttpPut]
        [Route("UpdateAllOrder")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> UpdateAllOrder(OrderWriteNewStatusDto entity)
        {
            if (entity == null) { return BadRequest(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
             orderManager.DeleteAsync(entity);
            entity.Id = 0;
            foreach(var item in entity.OrderItems.ToList())
            {
                item.Id = 0;
            }
            var Data = await InsertOrder(entity);
            return Ok(Data);
        }
    }
}
