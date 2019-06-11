using IconPractice.Domain.Models;

namespace IconPractice.Domain
{
    public interface ICurrentService
    {
        StoryDomainModel GetStory();
    }
}