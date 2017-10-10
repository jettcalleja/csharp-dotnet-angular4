using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;
using System.Web;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TopicController : Controller
    {
        private readonly TopicModel topicModel;

        public TopicController()
        {
            topicModel = new TopicModel();
        }    

        [HttpGet]
        public IEnumerable<TopicItem> GetAll()
        {
            return topicModel.GetAll();
        }

        [HttpGet("{id}", Name = "GetTopic")]
        public TopicItem GetById(int id)
        {
            return topicModel.GetByID(id);
        }   

        [HttpPost]
        public IActionResult Create([FromBody] TopicItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            topicModel.Add(item);

            return CreatedAtRoute("GetTopic", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TopicItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var topic = topicModel.GetByID(id);
            if (topic == null)
            {
                return NotFound();
            }

            topic.Title   = item.Title;
            topic.Content = item.Content;

            topicModel.Update(topic);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var topic = topicModel.GetByID(id);
            if (topic == null)
            {
                return NotFound();
            }

            topicModel.Delete(id);
            return new NoContentResult();
        }
    }
}