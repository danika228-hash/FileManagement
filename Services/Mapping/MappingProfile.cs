using AutoMapper;
using FileManagementApp.Models;
using System.IO;

namespace FileManagementApp.Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DirectoryInfo, DirectoryItem>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.FullName));

        CreateMap<FileInfo, FileItem>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Extension, opt => opt.MapFrom(src => src.Extension))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Length / 1024f));
    }
}