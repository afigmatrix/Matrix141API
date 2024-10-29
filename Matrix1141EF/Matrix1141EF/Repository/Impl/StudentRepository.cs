using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Impl
{
    public class StudentRepository : IStudentRepository
    {
        public AppDbContext Context { get; set; }
        public StudentRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var StudentEntity = await Context.Students.ToListAsync();
            if (StudentEntity == null)
            {
                throw new Exception("Students not found!");
            }
            return StudentEntity;
        }
    }
}
