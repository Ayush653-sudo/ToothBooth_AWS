using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using dynamodb_sample;
using serverless_dotnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tooth_Booth_API.Repository
{
    public class DentistRepository:IRepository<Dentist,string>
    {

        private readonly IDynamoDBContext dynamoDBContext;
        private readonly IMapper _mapper;

        public DentistRepository(
           IDynamoDBContext dynamoDBContext,
           IMapper mapper)
        {

            this.dynamoDBContext = dynamoDBContext;
            _mapper = mapper;
        }

        public async  Task<IEnumerable<Dentist>> GetAll(string node)
        {
            if (node.Length != 0)
                node = "Dentists#" + node;
            else
                node = "Dentists";
            var data = await dynamoDBContext.QueryAsync<ToothBoothDB>(node)
               .GetRemainingAsync();
            var listOfDentists = _mapper.Map<IEnumerable<Dentist>>(data);
            return listOfDentists;
        }

        public async Task AddAsync(Dentist dentist)
        {
          //  await _dbContext.Dentists.AddAsync(dentist);
        }

        public async Task DeleteAsync(string node ,string id)
        {
            node = "Dentists";
            var specificItem = await dynamoDBContext.LoadAsync<ToothBoothDB>(node, id);
            await dynamoDBContext.DeleteAsync(specificItem);
            node ="Dentists#"+specificItem.ClinicId;
            specificItem = await dynamoDBContext.LoadAsync<ToothBoothDB>(node, id);
            await dynamoDBContext.DeleteAsync(specificItem);
        }
        public async Task Update(Dentist dentist)
        {
            var data = await dynamoDBContext.LoadAsync<ToothBoothDB>("Dentists#" + dentist.ClinicID.ToString(), dentist.Id);
            data.Availability = dentist.Availability;
            data.MaxAppointment = dentist.MaxAppointment;
            await dynamoDBContext.SaveAsync(data);
            data = await dynamoDBContext.LoadAsync<ToothBoothDB>("Dentists",dentist.Id);
            data.Availability = dentist.Availability;
            data.MaxAppointment = dentist.MaxAppointment;
            await dynamoDBContext.SaveAsync(data);
        }
    }
}
