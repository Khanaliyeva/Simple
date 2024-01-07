using Microsoft.EntityFrameworkCore;
using Simple.Business.Services.Interfaces;
using Simple.Business.ViewModels.Cart;
using Simple.Core.Entities;
using Simple.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simple.Business.Services.Implimentations.CartService;

namespace Simple.Business.Services.Implimentations
{
    public class CartService : ICartService
    {

        private readonly ICartRepository _repo;

        public CartService(ICartRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CreateCartAsync(CreateCartVM cartVM)
        {
           // if (cartVM == null) throw new BrandExceptionNull();
            Cart cart = new Cart()
            {
                Name = cartVM.Name,
                Detail=cartVM.Detail,
                ImgUrl=cartVM.ImgUrl
            };
            await _repo.Create(cart);
            int result = await _repo.SaveChangesAsync();
            if (result > 0) { return true; }
            return false;
        }

        public Task<bool> CreateCart(CreateCartVM cartVM)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Cart>> GetAllAsync()
        {
            var cart = await _repo.GetAllAsync();
            return await cart.ToListAsync();
        }

      
    }
}
