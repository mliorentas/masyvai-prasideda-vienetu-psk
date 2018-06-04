using System.Collections.Generic;
using System.Threading.Tasks;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;
using Core;

namespace MasyvaiPrasidedaVienetu.Interfaces
{
    public interface IItemService
    {
        Task<ItemViewModel> AddItem(ItemViewModel item);
        Task<ItemViewModel> UpdateItem(ItemViewModel item);
        Task<ItemViewModel> DeleteItem(int id);
        Task<ItemViewModel> GetItem(int id); 
        Task<IEnumerable<ItemViewModel>> GetAllItems();
        Task<IEnumerable<ItemViewModel>> SearchItems(string key);
        Task<IEnumerable<ItemViewModel>> SearchItemsByCat(IEnumerable<CategoryViewModel> cats);
        Task<IEnumerable<Item>> GetItemsByIds(IEnumerable<ModelForOrder> order);
    }
}
