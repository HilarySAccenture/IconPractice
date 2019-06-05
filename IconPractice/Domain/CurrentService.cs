using System.Collections.Generic;
using IconPractice.Domain.DataObject;
using IconPractice.Models;

namespace IconPractice.Domain
{
    public class CurrentService
    {
        private IApiCaller _caller;
        private IApiWrapper _wrapper;

        public CurrentService(IApiCaller caller, IApiWrapper wrapper)
        {
            _caller = caller;
            _wrapper = wrapper;
        }
        public StoryDomainModel GetStory()
        {
            var apiResponse = _caller.GetNewsAsJson();

            var convertedResponse = _wrapper.Convert(apiResponse);

            var storyModel = CreateStoryModel(convertedResponse);

            return storyModel;
        }

        private StoryDomainModel CreateStoryModel(List<ApiResponse> convertedResponse)
        {
            return new StoryDomainModel {Title = convertedResponse[0].Title};
        }
    }
}