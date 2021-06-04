using System;
using System.Threading.Tasks;

namespace Application.Domain
{

    public interface IGetMaximumQuery
    {
        Task<int> Execute();
    }
}
