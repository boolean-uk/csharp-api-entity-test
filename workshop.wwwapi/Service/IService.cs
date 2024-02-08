using workshop.wwwapi.Models;

namespace workshop.wwwapi.Service
{
    public interface IService
    {
        Task<IEnumerable<TDto>> EntitiesToDto<TEntity, TDto>(IEnumerable<TEntity> data) where TDto : class;
        Task<TDto> EntityToDto<TEntity, TDto>(TEntity data) where TDto : class;
    }
}
