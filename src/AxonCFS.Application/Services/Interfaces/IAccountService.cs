using System.Threading.Tasks;
using AxonCFS.Application.BindingModels;
using AxonCFS.Application.ViewModels;

namespace AxonCFS.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<LoginViewModel> Login(LoginBindingModel model);
    }
}
