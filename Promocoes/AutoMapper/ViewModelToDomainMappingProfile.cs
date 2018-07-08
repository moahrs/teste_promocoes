using AutoMapper;
using Promocoes.Domain;
using Promocoes.MVC.ViewModels;

namespace Promocoes.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Produto, ComprasViewModel>();
        }
    }
}