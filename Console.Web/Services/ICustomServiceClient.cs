using Console.Web.Models;

namespace Console.Web.Services
{
    public interface ICustomServiceClient
    {
        int GetResult(CustomViewModel model);
    }
}