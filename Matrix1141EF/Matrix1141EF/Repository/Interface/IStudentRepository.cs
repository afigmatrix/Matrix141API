using Matrix1141EF.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Interface
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();
    }
}
