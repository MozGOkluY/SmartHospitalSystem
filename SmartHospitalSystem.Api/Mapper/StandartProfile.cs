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
            // departments
            CreateMap<CreateDepartmentRequest, DepartmentModel>();
            CreateMap<UpdateDepartmentRequest, DepartmentModel>();

            CreateMap<DepartmentModel, CreateDepartmentResponse>();
            CreateMap<DepartmentModel, UpdateDepartmentResponse>();
            CreateMap<DepartmentModel, DepartmentResponse>();

            // beds
            CreateMap<CreateBedRequest, BedModel>();
            CreateMap<UpdateBedRequest, BedModel>();

            CreateMap<BedModel, CreateBedResponse>();
            CreateMap<BedModel, UpdateBedResponse>();
            CreateMap<BedModel, BedResponse>();
        }
    }
}
