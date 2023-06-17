using graduationProject.Bl.DTOs;
using graduationProject.Bl.DTOs.OrderDto;
using graduationProject.Shared.Enums;

namespace graduationProject.Bl.Managers.OrderManager
{
    public interface IOrderManager
    {
        Task<OrderReadDto> GetByIdAsync(int id);
        Task<IEnumerable<OrderReadDto>> GetByTraderIDAsync(int pageNumber, int pageSize ,string Traderid);
        Task<IEnumerable<OrderReadDto>> GetByRepresentativeIDAsync(int pageNumber, int pageSize ,string Representativeid);
        Task<IEnumerable<OrderReadDto>> GetByEmployeeIDAsync(int pageNumber, int pageSize );
        Task<IEnumerable<OrderGroupByKeyValueDto>> GetAllGroupByTraderID(string Traderid); 
        Task<IEnumerable<OrderGroupByKeyValueDto>> GetAllGroupByRepresentativeID(string RepresentativeID);
        Task<IEnumerable<OrderGroupByKeyValueDto>> GetAllGroupByEmployee();
        Task<PaginationDTO<OrderReadDto>> GetAllAsNoTrackingAsync(
          int pageNumber,
          int pageSize,
          OrderStatus Status = 0,
          DateTime? startdateTime = null,
          DateTime? enddateTime = null);
        Task<OrderWriteNewStatusDto> AddAsync(OrderWriteNewStatusDto entity);
        Task<OrderUpdateStatusGiveRepresentativeDto> UpdateStatusAndGiveRepresentativeAsync(OrderUpdateStatusGiveRepresentativeDto entity);
        Task<OrderUpdateStatusAndReceivedCostDto> UpdateStatusAndRecievedCostAsync(OrderUpdateStatusAndReceivedCostDto entity);
        Task<OrderUpdateStatusOnlyDto> UpdateStatusAsync(OrderUpdateStatusOnlyDto entity);
        Task DeleteAsync(OrderWriteNewStatusDto entity);
    }
}
