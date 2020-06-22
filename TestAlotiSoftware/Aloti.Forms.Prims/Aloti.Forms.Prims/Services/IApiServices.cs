using Shared.Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aloti.Forms.Prims.Services
{
    public interface IApiServices
    {
        Task<Response> GetListAsync<T>(
                                        string urlBase,
                                        string servicePrefix,
                                        string controller);

        Task<bool> CheckConnectionAsync(string url);
    }
}
