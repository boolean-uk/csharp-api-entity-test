using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Service
{
    public class Service : IService
    {
        public async Task<IEnumerable<TDto>> EntitiesToDto<TEntity, TDto>(IEnumerable<TEntity> data) where TDto : class
        {
            return await Task.Run(() =>
            {
                var output = new List<TDto>();
                foreach (var entity in data)
                {
                    output.Add((TDto)Activator.CreateInstance(typeof(TDto), entity));
                }
                return output;
            });
        }

        public async Task<TDto> EntityToDto<TEntity, TDto>(TEntity data) where TDto : class
        {
            return await Task.Run(() =>
            {
                return (TDto)Activator.CreateInstance(typeof(TDto), data);
            });
        }
    }
}
