using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class StudentRepository(AppDbContext dbContext) 
    : Repository<Student> (dbContext) , IStudentInterface
{
}
