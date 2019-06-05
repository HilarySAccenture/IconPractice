using System.Collections.Generic;
using IconPractice.Domain.DataObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IconPractice.DataObject
{
    public class ArticleWrapper
    {
        public List<ApiResponse> News { get; set; }
        
        public string Status { get; set; }
     

    }
}