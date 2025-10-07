using AutoMapper;
using Skola.Core.student.Queries.Dtos;
using Skola.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skola.Core.student.commands;
using Skola.Core.student.commands.models;

namespace Skola.Core.MappingProfiles
{
	public class StudentProfile :Profile
	{
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(s=>s.DepartmentName, source =>source.MapFrom(s=>s.Localize(s.Department.NameAr,s.Department.NameEn)))
                .ForMember(s=>s.Name,source=>source.MapFrom(s=>s.Localize(s.NameAr,s.NameEn)));

            CreateMap<AddStudentCommand, Student>()
                .ForMember(d => d.DepartmentId, s => s.MapFrom(s => s.DepartmentId));

            CreateMap<EditStudentCommand, Student>()
                .ForMember(d => d.DepartmentId, s => s.MapFrom(s => s.DepartmentId))
                .ForMember(d=>d.Id , s=>s.MapFrom(s=>s.Id));

            
        }
    }
}
