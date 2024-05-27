

using AutoMapper;
using BitirmeProjesiUI.Models.Department;
using BitirmeProjesiUI.Models.Instructor;
using BitirmeProjesiUI.Models.Optimization;
using BitirmeProjesiUI.Models.Project;
using BitirmeProjesiUI.Models.Result;
using BitirmeProjesiUI.Models.Student;
using BitirmeProjesiUI.Models.Team;
using EntityLayer.Concrete; 

namespace Pit2mKurumsalWebSiteUI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, AddDepartmentModel>().ReverseMap();
            CreateMap<Department, UpdateDepartmentModel>().ReverseMap();

            CreateMap<Instructor, AddInstructorModel>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorModel>().ReverseMap();

            CreateMap<Project, AddProjectModel>().ReverseMap();
            CreateMap<Project, UpdateProjectModel>().ReverseMap();

            CreateMap<Student, AddStudentModel>().ReverseMap();
            CreateMap<Student, UpdateStudentModel>().ReverseMap();

            CreateMap<Team, AddTeamModel>().ReverseMap();
            CreateMap<Team, UpdateTeamModel>().ReverseMap();

            CreateMap<Result, AddResultModel>().ReverseMap();
            CreateMap<Result, UpdateResultModel>().ReverseMap();

            CreateMap<Optimization, AddOptimizationModel>().ReverseMap();
            CreateMap<Optimization, UpdateOptimizationModel>().ReverseMap();

            
            
        }


    }
}
