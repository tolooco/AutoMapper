using AutoMapper;
using Tolooco.Domain.Models;
using Tolooco.ViewModels;

namespace Tolooco.Mvc.AutoMaaper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GadgetFormViewModel, Gadget>()
               .ForMember(g => g.Name, map => map.MapFrom(vm => vm.GadgetTitle))
               .ForMember(g => g.Description, map => map.MapFrom(vm => vm.GadgetDescription))
               .ForMember(g => g.Price, map => map.MapFrom(vm => vm.GadgetPrice))
               .ForMember(g => g.Image, map => map.MapFrom(vm => vm.File.FileName))
               .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.GadgetCategory))
               //add initialize in bootstraper.
               .ForMember(g => g.Category, vm => vm.Ignore())
               .ForMember(g => g.GadgetID, vm => vm.Ignore());
        }
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
    }
}