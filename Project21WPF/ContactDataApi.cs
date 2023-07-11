using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Project21WPF
{
    public class ContactDataApi
    {
        private HttpClient httpClient { get; set; }
        public ContactDataApi()
        {
            httpClient = new HttpClient();
        }

        public IEnumerable<Contact> GetContacts()
        {
            string url = @"https://localhost:7286/api/values";

            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);
        }

        public void AddContacts(Contact contact)
        {
            string url = @"https://localhost:7286/api/values";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }

        public void DeleteContact(int id)
        {
            string url = $"https://localhost:7286/api/values/{id}";
            var r = httpClient.DeleteAsync(
                requestUri: url);
        }

        public Contact FindContactById(int id)
        {
            string url = $"https://localhost:7286/api/values/Details/{id}";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<Contact>(json);
        }

        public void ChangeContact(string name, string surname,
            string fatherName, string telephoneNumber, string residenceAdress, string description, int id)
        {
            Contact contact = new Contact()
            {
                Name = name,
                Surname = surname,
                FatherName = fatherName,
                TelephoneNumber = telephoneNumber,
                ResidenceAdress = residenceAdress,
                Description = description
            };

            string url = $"https://localhost:7286/api/values/ChangeContactById/{id}";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }
    }
}
