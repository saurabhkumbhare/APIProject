using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopBridge.API.Data;
using ShopBridge.API.Model;
using ShopBridge.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Repository
{
    public class RepositoryItem : IRepository<ItemVM>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public RepositoryItem(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ItemVM> Create(ItemVM _object)
        {
            ValidateItem(_object);

            if (await _dbContext.Items.AnyAsync(x => x.is_active == true && x.item_code == _object.item_code))
                throw new Exception("Item already exists");

            Item item = _mapper.Map<Item>(_object);
            item.item_id = new Guid();
            item.is_active = true;
            item.created_on = DateTime.Now;
            item.modified_on = DateTime.Now;

            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();

            return _mapper.Map<ItemVM>(item);
        }

        private static void ValidateItem(ItemVM _object)
        {
            if (string.IsNullOrEmpty(_object.item_code))
                throw new ArgumentException("Item Code is required");
            if (string.IsNullOrEmpty(_object.item_desc))
                throw new ArgumentException("Item Description is required");
            if (_object.sales_price <= 0)
                throw new ArgumentException("Invalid sales price");
            if (string.IsNullOrEmpty(_object.hsn_code))
                throw new ArgumentException("Invalid HSN Code");
        }

        public async Task<bool> Delete(Guid item_id)
        {
            Item item = await GetItemById(item_id);
            item.is_active = false;
            item.modified_on = DateTime.Now;

            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<ItemVM>> GetAll()
        {
            List<Item> items = await _dbContext.Items.Where(x => x.is_active == true).ToListAsync();
            return _mapper.Map<List<ItemVM>>(items);
        }

        public async Task<ItemVM> Update(ItemVM _object)
        {
            ValidateItem(_object);

            Item item = await GetItemById(_object.item_id);
            item.item_code = _object.item_code;
            item.item_desc = _object.item_desc;
            item.sales_price = _object.sales_price;
            item.unit_of_measurement = _object.unit_of_measurement;
            item.hsn_code = _object.hsn_code;
            item.item_category = _object.item_category;
            item.modified_on = DateTime.Now;

            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return _mapper.Map<ItemVM>(item);
        }

        private async Task<Item> GetItemById(Guid Id)
        {
            Item item = await _dbContext.Items.FirstOrDefaultAsync(x => x.is_active == true && x.item_id == Id);
            if (item == null)
                throw new KeyNotFoundException("Item does not exists");

            return item;
        }
    }
}
