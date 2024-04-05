using AutoMapper;
using ItemBoxStore.Contracts.StorageFiles;
using ItemBoxStore.Domain.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль работы с файлами.
    /// </summary>
    public class StorageFileProfile : Profile
    {
        public StorageFileProfile()
        {
            CreateMap<StorageFile, FileInfoDto>()
                .ForMember(s => s.Name, map => map.MapFrom(s => s.FileName))
                .ForMember(s => s.Length, map => map.MapFrom(s => s.Content.Length));

            CreateMap<StorageFile, FileDto>()
                .ForMember(s => s.Name, map => map.MapFrom(s => s.FileName));

            CreateMap<FileDto, StorageFile>()
                .ForMember(s => s.Id, map => map.MapFrom(s => Guid.NewGuid()))
                .ForMember(s => s.FileName, map => map.MapFrom(s => s.Name))
                .ForMember(s => s.FileLength, map => map.MapFrom(s => s.Content.Length))
                .ForMember(s => s.FilePath, map => map.MapFrom(s => ""))
                .ForMember(s => s.CreatedAt, map => map.MapFrom(s => DateTime.UtcNow))
                .ForMember(s => s.UpdatedAt, map => map.MapFrom(s => DateTime.UtcNow));
        }
    }
}
