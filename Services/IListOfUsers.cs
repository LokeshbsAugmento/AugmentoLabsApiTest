using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RefitDemo3.Services
{
   public  interface IListOfUsers
    {
        [Get("/api/users")]
        Task<ApiResponse<string>> GetAllUsers(int page);

    }
}
