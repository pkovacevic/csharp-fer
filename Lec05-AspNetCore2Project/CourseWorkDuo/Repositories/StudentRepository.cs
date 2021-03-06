﻿using CourseWorkDuo.Entities;
using CourseWorkDuo.Entities.Db;
using CourseWorkDuo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWorkDuo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private CourseWorkDbContext _dbContext;

        public StudentRepository(CourseWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Edit(StudentVm vm)
        {
            Student trackedEntity = await _dbContext.Students.SingleAsync(x => x.Id == vm.Id);

            trackedEntity.FirstName = vm.FirstName;
            trackedEntity.LastName = vm.LastName;
            trackedEntity.StudentCode = vm.StudentCode;
            trackedEntity.Gender = vm.GenderValue;
            trackedEntity.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<StudentVm>> GetStudentList()
        {
            IList<Student> studentEntities = await _dbContext.Students.ToListAsync();
            IList<StudentVm> studentVms = studentEntities.Select(x => StudentVm.FromEntity(x)).ToList();

            return studentVms;
        }

        public async Task<StudentVm> GetSudentById(int id)
        {
            Student studentEntity = await _dbContext.Students.SingleAsync(x => x.Id == id);
            StudentVm studentVm = StudentVm.FromEntity(studentEntity);

            return studentVm;
        }

        public async Task Remove(int id)
        {
            Student deleteMe = await _dbContext.Students.SingleAsync(x => x.Id == id);
            _dbContext.Students.Remove(deleteMe);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Create(StudentVm vm)
        {
            Student createEntity = new Student
            {
                Id = vm.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                StudentCode = vm.StudentCode,
                Gender = vm.GenderValue,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            _dbContext.Students.Add(createEntity);
            await _dbContext.SaveChangesAsync();

            return createEntity.Id;
        }

    }
}
