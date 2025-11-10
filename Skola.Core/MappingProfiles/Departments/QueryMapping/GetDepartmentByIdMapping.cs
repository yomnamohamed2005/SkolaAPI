
using Skola.Core.Fearures.Department.Queries;
using Skola.Data.Entities;
namespace Skola.Core.MappingProfiles.Departments
{
    public partial class  DepartmentProfile 
    {   
    public void GetDepartmentByIdMapping()

        {
            CreateMap<Department, GetByDepartmentByIdResponse>()
                       .ForMember(des => des.Id, src => src.MapFrom(src => src.Id))
                       .ForMember(des => des.Name, src => src.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
                       .ForMember(des => des.ManagerName, src => src.MapFrom(src => src.DepartmentManager.Localize(src.DepartmentManager.NameAr, src.DepartmentManager.NameEn)))
                     //  .ForMember(des => des.StudentList, src => src.MapFrom(src => src.Student))
                       .ForMember(des => des.SubjectList, src => src.MapFrom(src => src.Subjects))
                       .ForMember(des => des.InstructorList, src => src.MapFrom(src => src.Instructors));

           // CreateMap<Student, studentresponse>()
              //  .ForMember(des => des.Id, src => src.MapFrom(src => src.Id))
              //  .ForMember(des => des.Name, src => src.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

            CreateMap<DepartmentSubject, subjectresponse>()
                .ForMember(des => des.Id, src => src.MapFrom(src => src.Subject.Id))
                .ForMember(des => des.Name, src => src.MapFrom(src => src.Subject.Localize(src.Subject.NameAr, src.Subject.NameEn)));

            CreateMap<Instructor, instructorresponse>()
                .ForMember(des => des.Id, src => src.MapFrom(src => src.Id))
                .ForMember(des => des.Name, src => src.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

            
        }

    }
}
