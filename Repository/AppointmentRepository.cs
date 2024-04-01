using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using dynamodb_sample;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.Repository
{
    public class AppointmentRepository : IRepository<Appointment, int>
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        private readonly IMapper _mapper;
        public AppointmentRepository(
            IDynamoDBContext dynamoDBContext
            )
        {

            this._dynamoDBContext = dynamoDBContext;

        }

        public async Task<IEnumerable<Appointment>> GetAll(string node)
        {
            node = "Appointments#" + node;
            var listOfAppointments = await _dynamoDBContext.QueryAsync<Appointment>(node)
                .GetRemainingAsync();
          
            return listOfAppointments;
        }

        public async Task AddAsync(Appointment appointment)
        {

        }

        public async Task DeleteAsync(string node, int id)
        {
            node = "Appointments#" + node;
            var specificItem = await _dynamoDBContext.LoadAsync<Appointment>(node, id.ToString());
            await _dynamoDBContext.DeleteAsync(specificItem);
            node = "Appointments#" + specificItem.AppointmentId;
            var specificItem2 = await _dynamoDBContext.LoadAsync<Appointment>(node, id.ToString());
            await _dynamoDBContext.DeleteAsync(specificItem2);
        }
        public async Task Update(Appointment appointment)
        {

        }

    }
}
