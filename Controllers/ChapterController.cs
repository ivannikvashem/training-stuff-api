using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using training_stuff_api.Models;

namespace training_stuff_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChapterController : ControllerBase
    {
        private readonly StuffTrainingPlatformContext context;

        public ChapterController(StuffTrainingPlatformContext context)
        {
            this.context = context;
        }
        

        [HttpGet]
        public IEnumerable<Chapter> GetChaptersList()
        {
            return context.Chapter.ToList();
        }

        [Authorize]
        [HttpPut]
        public ActionResult AddChapter(Chapter chapter)
        {
            context.Chapter.Add(chapter);
            try
            {
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(400);
            }
        }



        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteChapter(int id)
        {
            var chapter = context.Chapter.Find(id);

            if (chapter == null)
            {
                return NotFound();
            }

            var lessons = context.Lesson.Where(l => l.Chapter == id);
            context.Lesson.RemoveRange(lessons);
            context.Chapter.Remove(chapter);

            try
            {
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}
