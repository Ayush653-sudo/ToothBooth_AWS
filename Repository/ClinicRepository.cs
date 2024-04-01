using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using dynamodb_sample;
using serverless_dotnet;
using serverless_dotnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tooth_Booth_API.Models;


namespace Tooth_Booth_API.Repository
{
    public class ClinicRepository:IRepository<Clinic, int>
    {
        private readonly IDynamoDBContext dynamoDBContext;
        private readonly IMapper _mapper;

        public ClinicRepository( 
           IDynamoDBContext dynamoDBContext, 
           IMapper mapper)
        {

            this.dynamoDBContext = dynamoDBContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Clinic>>GetAll(string node="jaipur")
        {
            node = "Clinics#" + node;
            var data = await dynamoDBContext.QueryAsync<ToothBoothDB>(node)
                .GetRemainingAsync();
            var listOfClinics = _mapper.Map<IEnumerable<Clinic>>(data);
            return listOfClinics;

        }

        public async Task AddAsync(Clinic clinic)
        {
         
        }

        public async Task DeleteAsync(string node , int id)
        {

           node = "Clinics#" + node;
           var specificItem = await dynamoDBContext.LoadAsync<ToothBoothDB>(node,id.ToString());
           await dynamoDBContext.DeleteAsync(specificItem);
           
            node = "Clinics#" + specificItem.ClinicAdminId;
            var specificItem2 = await dynamoDBContext.LoadAsync<ToothBoothDB>(node, id.ToString());
            await dynamoDBContext.DeleteAsync(specificItem2);
        }
        public async Task Update(Clinic clinic)
        {
          var data =  await dynamoDBContext.LoadAsync<ToothBoothDB>("Clinics#"+clinic.ClinicCity,clinic.ClinicId.ToString());
            data.Description = clinic.Description;
            data.ClinicCity = clinic.ClinicCity;
            data.Isverified = clinic.Isverified;
            data.ClinicName = clinic.ClinicName;
            await dynamoDBContext.SaveAsync(data);
            data = await dynamoDBContext.LoadAsync<ToothBoothDB>("Clinics#" + clinic.ClinicAdminId, clinic.ClinicId.ToString());
            data.Description = clinic.Description;
            data.ClinicCity = clinic.ClinicCity;
            data.Isverified = clinic.Isverified;
            data.ClinicName = clinic.ClinicName;
            await dynamoDBContext.SaveAsync(data);


        }
    }
}
