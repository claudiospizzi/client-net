using System.Threading.Tasks;
using ReportPortal.Client.Api.User.DataContract;

namespace ReportPortal.Client.Api.User
{
    public interface IUserApiClient
    {
        Task<UserModel> GetUserAsync();
    }
}
