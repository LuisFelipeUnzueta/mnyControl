using mnyControl.Core.Models;
using mnyControl.Core.Requests.Transactions;
using mnyControl.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnyControl.Core.Handlers
{
    public interface ITransactionHandler
    {
        Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
        Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
        Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
        Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request);
        Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request);
    }
}
