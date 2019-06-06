using System;
using IconPractice.Domain;
using IconPractice.Domain.Models;
using IconPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace IconPractice.Controllers
{
    public class StoryController : Controller
    {
        private CurrentService _service = new CurrentService();

        public IActionResult GetStory()
        {
            var viewModel = new StoryViewModel();

            try
            {
                StoryDomainModel model = null;
                model = _service.GetStory();
                viewModel.Title = model.Title;
            }
            catch (Exception ex)
            {
            }

            return View("Story", viewModel);
        }
    }
}