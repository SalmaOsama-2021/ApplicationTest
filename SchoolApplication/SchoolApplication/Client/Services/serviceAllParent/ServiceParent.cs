using Microsoft.AspNetCore.Components;
using SchoolApplication.Shared;
using System.Net.Http.Json;

namespace SchoolApplication.Client.Services.serviceAllParent
{
    public class ServiceParent : IServiceParent
    {
        private readonly HttpClient _http; 
        private readonly  NavigationManager _navigationManager ;   
        public ServiceParent(HttpClient http,NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager; 
        }
        public List<Parent> parents { get; set; }=new List<Parent>();

        public async Task createAndUpdateparents(Parent parent)
        {
            var result = await _http.PostAsJsonAsync("api/Parent/AddParents",parent);
            
            await setParent(result);    

        }
     private async Task setParent(HttpResponseMessage result)
        {
            _navigationManager.NavigateTo("parent");
            var response = await result.Content.ReadFromJsonAsync<List<Parent>>();
            parents = response;

        }
        public async Task deleteparent(int id)
        {
            var result = await _http.DeleteAsync($"api/Parent/{id}");
            await setParent(result);

        }

        public async Task Getparents()
        {
            var result = await _http.GetFromJsonAsync<List<Parent>>("api/Parent/getAllParent");
            if(result != null)
                 parents=result;    

        }

        public async Task<Parent> GetSingleParent(int id)
        {
            var result = await _http.GetFromJsonAsync<Parent>($"api/Parent/{id}");
            if (result != null)
                 return result;
            throw new Exception("not found");
        }
    }
}
