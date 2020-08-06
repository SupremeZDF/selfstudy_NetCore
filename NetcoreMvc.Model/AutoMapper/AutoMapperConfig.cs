using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace NetcoreMvc.Model.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Student, StudentView>();
        }
    }

    public class StudentService
    {
        IMapper _mapper;
        public StudentService(IMapper mapper) 
        {
            _mapper = mapper;
        }

        public void GetStudentInfo() 
        {
            Student student = new Student() {Name="张国荣",Age=18 }; 
            StudentView studentView = new StudentView();
            _mapper.Map(student,studentView);
        }
    }
}
