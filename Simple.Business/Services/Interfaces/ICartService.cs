using Simple.Business.ViewModels.Cart;
using Simple.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Business.Services.Interfaces
{
    public interface ICartService
    {
        Task<ICollection<Cart>> GetAllAsync();
        Task<bool> CreateCartAsync(CreateCartVM cartVM);

    }
}
