using System.Collections.Generic;
using System.Threading.Tasks;
using ReportPortal.Client.Api.DataContract;
using ReportPortal.Client.Api.Filter.DataContract;

namespace ReportPortal.Client.Api.Filter
{
    public interface IFilterApiClient
    {
        /// <summary>
        /// adds the specified user filter
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<List<FilterModel>> AddUserFilterAsync(AddUserFilterRequest model);

        /// <summary>
        /// gets all user filters
        /// </summary>
        /// <param name="queryFilter"></param>
        /// <returns></returns>
        Task<PagingContent<FilterModel>> GetUserFiltersAsync(QueryFilter queryFilter = null);

        /// <summary>
        /// deletes the specified filter by id
        /// </summary>
        /// <param name="filterId"></param>
        /// <returns></returns>
        Task<Message> DeleteUserFilterAsync(string filterId);
    }
}
