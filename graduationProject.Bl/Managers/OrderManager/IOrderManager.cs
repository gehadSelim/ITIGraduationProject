using graduationProject.Bl.DTOs;
using graduationProject.Bl.DTOs.OrderDto;
using graduationProject.Shared.Enums;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers.OrderManager
{
    public interface IOrderManager
    {
        Task<OrderReadDto> GetByIdAsync(int id);
        Task<PaginationDTO<OrderReadDto>?> GetByTraderIDAsync(int pageNumber, int pageSize ,string Traderid);
        Task<PaginationDTO<OrderReadDto>?> GetByRepresentativeIDAsync(int pageNumber, int pageSize ,string Representativeid);
        Task<PaginationDTO<OrderReadDto>?> GetByEmployeeIDAsync(int pageNumber, int pageSize );
        Task<PaginationDTO<OrderReadDto>?> GetByTraderIDWithStatusAsync(int pageNumber, int pageSize, string Traderid,OrderStatus orderStatus);
        Task<PaginationDTO<OrderReadDto>?> GetByRepresentativeIDWithStatusAsync(int pageNumber, int pageSize, string Representativeid, OrderStatus orderStatus);
        Task<PaginationDTO<OrderReadDto>?> GetByEmployeeIDWithStatusAsync(int pageNumber, int pageSize, OrderStatus orderStatus);
        Task<IEnumerable<OrderGroupByKeyValueDto>> GetAllGroupByTraderID(string Traderid); 
        Task<IEnumerable<OrderGroupByKeyValueDto>> GetAllGroupByRepresentativeID(string RepresentativeID);
        Task<IEnumerable<OrderGroupByKeyValueDto>> GetAllGroupByEmployee();
        Task<PaginationDTO<OrderReportDto>> GetAllReportAsNoTrackingAsync(
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
