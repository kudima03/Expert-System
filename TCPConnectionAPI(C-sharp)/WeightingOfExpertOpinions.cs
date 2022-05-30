using ClassLibraryForTCPConnectionAPI_C_sharp_;
using System;
using DatabaseEntities;
namespace TCPConnectionAPI_C_sharp_
{
    public class WeightingOfExpertOpinions : IExpertMethod
    {
        IDataModifyPermission dbConnection = new DatabaseContext();
        public void Rate(ref Vehicle obj, Expert expert, float rate)
        {
            Rate newRate = new Rate(rate * expert.RateWeight);
            newRate.Expert = expert;
            newRate.Vehicle = obj;
            newRate.TimeOfCommit = DateTime.Now;
            obj.Rate.Add(newRate);
            dbConnection.UpdateVehicle(obj);
            Recount();

        }
        public void Recount()
        {
            var allEntities = dbConnection.FindVehiclesWhere(c => c != null);
            double rateSum = 0;
            foreach (var entity in allEntities)
            {
                foreach (var rate in entity.Rate)
                {
                    rateSum += rate.Value;
                }
            }
            foreach (var item in allEntities)
            {
                double currentEntityRate = 0;
                foreach (var currentRate in item.Rate)
                {
                    currentEntityRate += currentRate.Value;
                }
                item.TotalRate = currentEntityRate / rateSum;
                dbConnection.UpdateVehicle(item);
            }
        }
    }
}
