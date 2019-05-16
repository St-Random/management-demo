using AutoMapper;
using iTechArt.ManagementDemo.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Web.Infrastructure.ServiceAdaptors
{
    public abstract class AbstractServiceAdapter<TDTO, TModel>
        : IService<TModel>
    {
        protected readonly IMapper _mapper;
        private readonly IService<TDTO> _service;


        public AbstractServiceAdapter(
            IMapper mapper, IService<TDTO> service)
        {
            _mapper = mapper ?? throw new NullReferenceException();
            _service = service ?? throw new NullReferenceException();
        }


        public async Task DeleteAsync(int id) =>
            await _service.DeleteAsync(id);

        public async Task<TModel> FindAsync(int id) =>
            _mapper.Map<TModel>(
                await _service.FindAsync(id));

        public async Task<int> SaveAsync(TModel item) =>
            await _service.SaveAsync(
                _mapper.Map<TDTO>(item));
    }
}
