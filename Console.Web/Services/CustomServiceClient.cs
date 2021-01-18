using Console.Web.Models;
using Custom.BL.Services;

namespace Console.Web.Services
{
    public class CustomServiceClient : ICustomServiceClient
    {
        private readonly ICustomService _service;

        public CustomServiceClient(ICustomService service)
        {
            _service = service;
        }

        public int GetResult(CustomViewModel model)
        {
            return model.CarType switch
            {
                CarType.Car => _service.GetCarCustomValue(model.FuelType, model.EngineVolume, model.Price, model.Year),
                CarType.Truck => _service.GetTruckCustomValue(model.Price, model.Year, model.EngineVolume, model.FuelWeight),
                CarType.Bus => _service.GetBusCustomValue(model.Price, model.Year, model.EngineVolume, model.FuelType),
                CarType.Bike => _service.GetBikeCustomValue(model.Price, model.Year, model.EngineVolume),
                _ => throw new System.NotImplementedException()    // TOOD: інтелісенс запропонував добавити (перербити throw)
            };
        }
    }
}
