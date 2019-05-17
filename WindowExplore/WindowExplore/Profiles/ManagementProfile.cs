using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AutoMapper;
using WindowExplore.ViewModel;

namespace WindowExplore.Profiles
{
    public class ManagementProfile : Profile
    {
        public ManagementProfile()
        {
            CreateMap<FileInfo, FileViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.DateCreate, opt => opt.MapFrom(src => src.CreationTime.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(dest => dest.DateModify, opt => opt.MapFrom(src => src.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType()))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Length));
        }
    }
}