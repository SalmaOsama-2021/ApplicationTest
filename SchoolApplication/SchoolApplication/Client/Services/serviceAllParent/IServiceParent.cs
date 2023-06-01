


using SchoolApplication.Shared;

namespace SchoolApplication.Client.Services.serviceAllParent
{
    public interface IServiceParent
    {
        List<Parent> parents { get; set; }
        Task Getparents();
        Task createAndUpdateparents(Parent parent);
        Task deleteparent(int id);
        Task<Parent> GetSingleParent(int id);    
    }
}
