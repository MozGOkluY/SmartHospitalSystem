using AutoMapper;
using SmartHospitalSystem.Api.Requests;
using SmartHospitalSystem.Api.Responses;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Api.Mapper
{
    /// <summary>
    /// Standert mapper profile
    /// </summary>
    public class StandartProfile : Profile
    {
        /// <summary>
        /// Ctor for profile
        /// </summary>
        public StandartProfile()
        {
            CreateMap<CreateDepartmentRequest, DepartmentModel>();
            CreateMap<DepartmentModel, CreateDepartmentResponse>();
        }
    }
}
