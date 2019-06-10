using System.Collections.Generic;
using IconPractice.DataObject;
using IconPractice.Domain.DataObject;
using Newtonsoft.Json;

namespace IconPractice.Domain
{
    public class ApiWrapper : IApiWrapper
    {
        public List<ApiResponse> Convert(string jsonString)
        {
            var wrapper = JsonConvert.DeserializeObject<ArticleWrapper>(jsonString);

            if (wrapper.Status == "ok")
            {
                return wrapper.Articles;
            }
            return null;
        }
    }
}