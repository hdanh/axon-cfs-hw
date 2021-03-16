using System.Threading.Tasks;
using AxonCFS.Application.BindingModels;
using AxonCFS.Application.Services.Interfaces;
using AxonCFS.Application.ViewModels;

namespace AxonCFS.Application.Services
{
    public class AccountService : IAccountService
    {
        public async Task<LoginViewModel> Login(LoginBindingModel model)
        {
            await Task.FromResult(1);
            return null;
        }
    }
}
