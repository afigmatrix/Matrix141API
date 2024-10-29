using AutoMapper;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Repository.Impl;
using Matrix1141EF.Repository.Interface;
using Matrix1141EF.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Impl
{
    public class StudentService : IStudentService
    {
        private readonly IMapper Mapper;
        private readonly IStudentRepository StudentRepository;

        public StudentService(IMapper mapper,IStudentRepository studentRepository)
        {
            Mapper = mapper;
            StudentRepository = studentRepository;
        }
        public async Task<List<StudentGetDTO>> GetAllUsers()
        {
            var Result = await StudentRepository.GetAllStudents();
            var ResultGetDTO = Mapper.Map<List<StudentGetDTO>>(Result);
            return ResultGetDTO;
        }
    }
}
