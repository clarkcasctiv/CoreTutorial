using CoreTutorial.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTutorial.Data
{
    public class ArtRepository : IArtRepository
    {
        private readonly ArtContext _ctx;
        private readonly ILogger<ArtRepository> _logger;

        public ArtRepository(ArtContext ctx, ILogger<ArtRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                try
                {
                    _logger.LogInformation("Get All Orders was Called");
                    return _ctx.Orders
                        .Include(o => o.Items)
                        .ThenInclude(i => i.Product)
                                .ToList();
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Failed to get all orders: {ex}");
                    return null;
                }
            }
            else
            {
                return _ctx.Orders
                                .ToList();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Get All Products was Called");
                return _ctx.Products
                            .OrderBy(p => p.Title)
                            .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to get all products: {ex}");
                return null;
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                _logger.LogInformation("Get Order By Id was Called");
                return _ctx.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .Where(o => o.Id == id)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to get Order: {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}