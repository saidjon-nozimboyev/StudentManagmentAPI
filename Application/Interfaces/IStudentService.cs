using Application.DTOs.StudentDTOs;

namespace Application.Interfaces;

public interface IStudentService
{
    Task<List<StudentDto>> GetAllAsync();
    Task<StudentDto> GetByIdAsync(int id);
    Task CreateAsync(AddStudentDto addStudentDto);
    Task UpdateAsync(StudentDto updStudentDto);
    Task DeleteAsync(int id);
}
