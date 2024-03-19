using Application.Common;
using Application.DTOs.StudentDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Interfaces;

namespace Application.Services;

public class StudentService(IStudentInterface studentInterface,
                            IMapper mapper,
                            IValidator<Student> validator)
    : IStudentService
{
    private readonly IStudentInterface _studentInterface = studentInterface;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<Student> _validator = validator;

    public async Task CreateAsync(AddStudentDto addStudentDto)
    {
        if (addStudentDto == null)
        {
            throw new StudentException("Student is null");
        }

        var model = _mapper.Map<Student>(addStudentDto);
        var result = await _validator.ValidateAsync(model);
        if (!result.IsValid)
        {
            throw new StudentException(result);
        }

        await _studentInterface.AddAsync(model);
    }

    public async Task DeleteAsync(int id)
    {
        var model = await _studentInterface.GetByIdAsync(id);
        if (model == null)
        {
            throw new NotFoundException("Student not found");
        }

        await _studentInterface.DeleteAsync(model);
    }

    public async Task<List<StudentDto>> GetAllAsync()
    {
        var list = await _studentInterface.GetAllAsync();
        var result = list.Select(_mapper.Map<StudentDto>).ToList();
        return result;
    }

    public async Task<StudentDto> GetByIdAsync(int id)
    {
        var model = await _studentInterface.GetByIdAsync(id);
        if (model == null)
        {
            throw new NotFoundException("Student not found");
        }
        return _mapper.Map<StudentDto>(model);
    }

    public async Task UpdateAsync(StudentDto updStudentDto)
    {
        var model = await _studentInterface.GetByIdAsync(updStudentDto.Id);
        if (model == null)
        {
            throw new NotFoundException("Student not found");
        }

        model.FullName = updStudentDto.FullName;
        model.Email = updStudentDto.Email;

        var result = await _validator.ValidateAsync(model);
        if (!result.IsValid)
        {
            throw new StudentException(result);
        }

        await _studentInterface.UpdateAsync(model);
    }
}
