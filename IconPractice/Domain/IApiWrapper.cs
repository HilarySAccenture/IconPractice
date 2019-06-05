using System.Collections.Generic;
using IconPractice.DataObject;
using IconPractice.Domain.DataObject;

namespace IconPractice.Domain
{
    public interface IApiWrapper
    {
        List<ApiResponse> Convert(string jsonString); 
    }
}