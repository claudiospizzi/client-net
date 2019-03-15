using System.Threading.Tasks;
using ReportPortal.Client.Api.DataContract;
using ReportPortal.Client.Api.Log.DataContract;

namespace ReportPortal.Client.Api.Log
{
    public interface ILogApiClient
    {
        /// <summary>
        /// Returns a list of log items for specified test item.
        /// </summary>
        /// <param name="queryFilter">Specified criteria for retrieving log items.</param>
        /// <returns>A list of log items.</returns>
        Task<PagingContent<LogItemModel>> GetLogItemsAsync(QueryFilter queryFilter = null);

        /// <summary>
        /// Returns specified log item by ID.
        /// </summary>
        /// <param name="id">ID of the log item to retrieve.</param>
        /// <returns>A representation of log item/</returns>
        Task<LogItemModel> GetLogItemAsync(string id);

        /// <summary>
        /// Returns binary data of attached file to log message.
        /// </summary>
        /// <param name="id">ID of data.</param>
        /// <returns>Array of bytes.</returns>
        Task<byte[]> GetBinaryDataAsync(string id);

        /// <summary>
        /// Creates a new log item.
        /// </summary>
        /// <param name="model">Information about representation of log item.</param>
        /// <returns>Representation of just created log item.</returns>
        Task<LogItemModel> AddLogItemAsync(AddLogItemRequest model);

        /// <summary>
        /// Deletes specified log item.
        /// </summary>
        /// <param name="id">ID of the log item to delete.</param>
        /// <returns>A message from service.</returns>
        Task<Message> DeleteLogItemAsync(string id);
    }
}
