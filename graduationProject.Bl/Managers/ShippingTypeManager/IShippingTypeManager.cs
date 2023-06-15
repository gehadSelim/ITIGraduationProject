using graduationProject.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public interface IShippingTypeManager
    {
        Task<ShippingTypeReadDTO> GetByIdAsync(byte id);
        Task<IEnumerable<ShippingTypeReadDTO>> GetAllAsync();
        Task<ShippingTypeWriteDTO> AddAsync(ShippingTypeWriteDTO entity);
        Task<ShippingTypeUpdateDTO> UpdateAsync(ShippingTypeUpdateDTO entity);
        void Delete(byte id);
    }
}
