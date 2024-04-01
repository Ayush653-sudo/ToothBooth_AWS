using AutoMapper;
using dynamodb_sample;
using serverless_dotnet.Models;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;

namespace serverless_dotnet.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ToothBoothDB, Clinic>();
            CreateMap<Clinic, ToothBoothDB>();
            CreateMap<ClinicDTO, Clinic>();
            CreateMap<Clinic, ClinicDTO>();
            CreateMap<Dentist, ToothBoothDB>();
            CreateMap<ToothBoothDB, Dentist>();
            CreateMap<DentistDTO, Dentist>();
            CreateMap<Dentist,DentistDTO>();

        }
    }
}
