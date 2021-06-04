using System.Threading.Tasks;

namespace Application.Domain
{
    public class ValidationInteractor
    {
        private readonly IGetMaximumQuery _getMaximumQuery;

        public ValidationInteractor(IGetMaximumQuery getMaximumQuery)
        {
            _getMaximumQuery = getMaximumQuery;
        }

        public async Task<bool> Execute(int i)
        {
            var maximum = await _getMaximumQuery.Execute();
            return i < maximum;
        }
    }
}
