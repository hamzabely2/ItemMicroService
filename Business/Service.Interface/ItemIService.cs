using Model.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ItemIService
    {
        Task<List<ItemDetailsDto>> GetListItem();
        Task<ItemDetailsDto> GetItemById(int itemId);
        Task<ItemDetailsDto> UpdateItem(ItemUpdate request, int itemId);
        Task<ItemDetailsDto> DeleteItem(int itemId);
        Task<ItemDetailsDto> CreateItem(ItemAdd request);
    }
}
