using Matrix1141EF.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Interface
{
    public interface IStudentService
    {
        Task<List<StudentGetDTO>> GetAllUsers();

    }
}
