using System.Threading.Tasks;

namespace XF.FluentUI.Services
{
    public interface IViewService
    {
        Task GoHome();
        Task ShowPageTwo(string message);
    }
}
