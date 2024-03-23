using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using BenchmarkDotNet.Attributes;
using EfficientMapping.DTOs;
using EfficientMapping.Entities;
using EfficientMapping.Mappers.Mapperly;
using System.Xml.Linq;

namespace EfficientMapping.Benchmarks
{
    [MemoryDiagnoser]
    public class MappingBenchmark
    {
        private readonly IMapper _Mapper;

        public MappingBenchmark()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonDto>()
                                .ForMember(dest =>
                                    dest.PersonId,
                                    opt => opt.MapFrom(src => src.Id)
                                )
                                .ForMember(dest =>
                                    dest.Isd,
                                    opt => opt.MapFrom(src => src.Dis)
                                )
                                ;
                cfg.CreateMap<Tag, TagDto>()
                                .ForMember(dest =>
                                dest.Tag,
                                    opt => opt.MapFrom(src => $"Tag:{src.Name}")
                                )
                                ;
                cfg.CreateMap<MartialStatus, MartialStatusDto>()
                                .ConvertUsingEnumMapping(opt => opt
                                    // optional: .MapByValue() or MapByName(), without configuration MapByValue is used
                                    .MapByName()
                                )
                                ;
            });

            _Mapper = configuration.CreateMapper();
        }

        [Benchmark]
        public PersonDto Mapperly()
        {
            Person person = new()
            {
                Id = 1,
                Dis = 2,
                MartialStatus = MartialStatus.Married,
                Name = "Test",
                Tags = new List<Tag>() { new("1") }
            };

            return PersonMapper.PersonToDto(person);
        }

        [Benchmark]
        public PersonDto AutoMapper()
        {
            Person person = new()
            {
                Id = 1,
                Dis = 2,
                MartialStatus = MartialStatus.Married,
                Name = "Test",
                Tags = new List<Tag>() { new("1") }
            };

            return _Mapper.Map<PersonDto>(person);
        }
    }
}
