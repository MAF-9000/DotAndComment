using DotAndComment.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotAndComment.Controllers
{
    public class DotAndCommentController : Controller
    {
        private IDotAndCommentService _dotAndCommentService;

        public DotAndCommentController(IDotAndCommentService dotAndCommentService)
        {
            _dotAndCommentService = dotAndCommentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            return Json(await _dotAndCommentService.GetAll());
        }

        [HttpPost]
        public void AddRandom()
        {
            _dotAndCommentService.AddRandom();
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(Guid Id)
        {
            if (await _dotAndCommentService.Delete(Id))
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
