using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ClosedXML.Excel;
using Core;
using MasyvaiPrasidedaVienetu.DAL;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.WebEndpoints.ExtensionMethods;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;
using MasyvaiPrasidedaVienetu.Logging;
using System.Collections;
using Services.Attributes;

namespace MasyvaiPrasidedaVienetu.Services
{
    [MethodLogger]
    public class ItemService : IItemService
    {
        private ItemRepository _rep;
        private ILogger _logger;

        public ItemService()
        {
            _rep = new ItemRepository();
            _logger = new FileLogger();
        }

        public async Task<ItemViewModel> AddItem(ItemViewModel item)
        {
            try
            {
                if (item.Name.Length == 0)
                    throw new NullReferenceException("Missing item to add!");
                var addedItem = await _rep.AddAsync(item.ToEntity());
                return addedItem.ToViewModel();
            }
            catch(NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<ItemViewModel> UpdateItem(ItemViewModel item)
        {
            try
            {
                if(item.Name.Length == 0)
                    throw new NullReferenceException("Missing item to update!");
                var updatedItem = await _rep.UpdateAsync(item.ToEntity());
                return updatedItem.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<ItemViewModel> DeleteItem(int id)
        {
            try
            {
                var deletedItem = await _rep.DeleteAsync(id);
                if(deletedItem == null)
                    throw new NullReferenceException("No item with id - " + id + "!");
                return deletedItem.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<ItemViewModel> GetItem(int id)
        {
            try
            {
                var item = await _rep.GetByIdAsync(id);
                if(item == null)
                    throw new NullReferenceException("No item with id - " + id +"!");
                return item.IsDisabled == false ? item.ToViewModel() : null;
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<IEnumerable<ItemViewModel>> GetAllItems()
        {
            try
            {
                var items = await _rep.GetAllAsync();
                if(!items.Any())
                    throw new NullReferenceException("There are no items!");
                return items.Where(x => !x.IsDisabled).Select(x => x.ToViewModel());
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<IEnumerable<ItemViewModel>> SearchItems(string key)
        {
            try
            {
                var items = await _rep.GetAllAsync();
                if(!items.Any())
                    throw new NullReferenceException("There is no item that contains - " + key + "!");
                return items.Where(x => !x.IsDisabled & x.Name.Contains(key)).Select(x => x.ToViewModel());
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<IEnumerable<Item>> GetItemsByIds(IEnumerable<ModelForOrder> orders)
        {
            try
            {
                List<int> ids = new List<int>();
                foreach(ModelForOrder order in orders)
                {
                    ids.Add(order.ItemId);
                }
                var items = await _rep.GetItemsByIds(ids);
                if (!items.Any())
                    throw new NullReferenceException("There is no items!");
                return items;
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<IEnumerable<ItemViewModel>> SearchItemsByCat(IEnumerable<CategoryViewModel> cats)
        {
            try
            {
                var items = await _rep.GetByCategoriesAsync(cats.Select(x => x.ToEntity()));
                if (!items.Any())
                    throw new NullReferenceException("There are no items in given categories");
                return items.Select(x => x.ToViewModel());
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }
    }
}