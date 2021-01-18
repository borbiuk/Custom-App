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

        public int GetResult(CustomViewModel model) =>
            model.CarType switch
            {
                CarType.Car => _service.GetCarCustomValue(model.FuelType, model.EngineVolume, model.Price, model.Year),
                CarType.Truck => _service.GetTruckCustomValue(model.Price, model.Year, model.EngineVolume, model.FuelWeight),
                CarType.Bike => _service.GetBikeCustomValue(model.Price, model.Year, model.EngineVolume),
                CarType.Bus => _service.GetBusCustomValue(model.Price, model.Year, model.EngineVolume, model.FuelType),
                _ => throw new System.NotImplementedException()    // TOOD: інтелісенс запропонував добавити (перербити throw)
            };
    }
}
