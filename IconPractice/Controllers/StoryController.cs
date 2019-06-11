using System;
using IconPractice.Domain;
using IconPractice.Domain.Models;
using IconPractice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IconPractice.Controllers
{
    public class StoryController : Controller
    {
        private ICurrentService _service;

        public StoryController(ICurrentService service)
        {
            _service = service;
        }

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
                throw ex;
            }


            return View("Story", viewModel);
        }
    }
}