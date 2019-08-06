using AutoMapper;
using SmartHospitalSystem.Api.Requests;
using SmartHospitalSystem.Api.Responses;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Api.Mapper
{
    public class StandartProfile : Profile
    {
        public StandartProfile()
        {
            CreateMap<CreateDepartmentRequest, DepartmentModel>();
            CreateMap<DepartmentModel, CreateDepartmentResponse>();
        }
    }
}
