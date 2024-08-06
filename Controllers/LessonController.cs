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
    public class LessonController : Controller
    {
        private readonly StuffTrainingPlatformContext context;

        public LessonController(StuffTrainingPlatformContext context)
        {
            this.context = context;
        }


        [HttpGet("{id}")]
        public ActionResult<Lesson> GetLessonById(int id)
        {
            var lesson = context.Lesson.FirstOrDefault(x => x.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return lesson;
        }

        [HttpGet]
        public IEnumerable<Lesson> GetLessonsList()
        {
            return context.Lesson.ToList();
        }


        [Authorize]
        [HttpPut]
        public ActionResult AddLesson(Lesson lesson)
        {
            context.Lesson.Add(lesson);
            

            try
            {
                context.SaveChanges();
                return Ok(lesson.Id);
            }
            catch
            {
                return StatusCode(400);
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateLesson(Lesson lesson)
        {
            var oldLesson = context.Lesson.Find(lesson.Id);
            if (oldLesson == null)
            {
                return NotFound();
            }

            oldLesson.Title = lesson.Title;
            oldLesson.LessonText = lesson.LessonText;

            try
            {
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteLesson(int id)
        {
            var lesson = context.Lesson.Find(id);
            if (lesson == null)
            {
                return NotFound();
            }

            context.Lesson.Remove(lesson);

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
