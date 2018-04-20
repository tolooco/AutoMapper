using AutoMapper;
using Tolooco.Domain.Models;
using Tolooco.ViewModels;

namespace Tolooco.Mvc.AutoMaaper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Gadget, GadgetViewModel>();
        }
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
    }
}