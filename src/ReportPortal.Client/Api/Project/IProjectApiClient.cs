using System.Threading.Tasks;
using ReportPortal.Client.Api.Project.Model;
using ReportPortal.Client.Api.Project.Request;

namespace ReportPortal.Client.Api.Project
{
    public interface IProjectApiClient
    {
        /// <summary>
        /// Updates the project preference for user
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<UpdatePreferencesResponse> UpdatePreferencesAsync(UpdatePreferenceRequest model, string userName);

        /// <summary>
        /// Gets user's preferences.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<Preference> GetPreferencesAsync(string userName);
    }
}
