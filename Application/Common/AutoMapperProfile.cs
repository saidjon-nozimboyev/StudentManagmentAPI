using Application.DTOs.StudentDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<StudentDto, StudentDto>().ReverseMap();
        CreateMap<Student, StudentDto>().ReverseMap();

        CreateMap<AddStudentDto, StudentDto>();
        CreateMap<Student, AddStudentDto>().ReverseMap();
    }
}
