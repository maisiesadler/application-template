using System.Threading.Tasks;
using Application.Domain;

namespace Application.Repositories
{
    public class GetMaximumQuery : IGetMaximumQuery
    {
        public Task<int> Execute() => Task.FromResult(10);
    }
}
