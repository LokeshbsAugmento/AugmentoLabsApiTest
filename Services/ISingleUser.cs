using Refit;
using RefitDemo3.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowApiReFit.Services
{
  public   interface ISingleUser
    {
        [Get("/api/users/2")]
        Task<ApiResponse<ReqResApi>> GetSingleUser();
    }
}
