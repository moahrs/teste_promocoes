using AutoMapper;
using Promocoes.Domain;
using Promocoes.MVC.ViewModels;

namespace Promocoes.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<ComprasViewModel, Produto>();
        }
    }
}