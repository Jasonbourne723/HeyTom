using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyTom.Infra.MessageQueue;
using HeyTom.Infra.MessageQueue.RabbitMq;
using Microsoft.AspNetCore.Mvc;

namespace HeyTome.Service.Api.Controllers
{
	[RabbitMq("ExChangeTest1","queueTest1",routingKey:"nihao")]
	public class Student
	{
		public string name { get; set; }

		public int  age { get; set; }
	}

	[RabbitMq("ExChangeTest2", "queueTest2", "fanout",routingKey: "nihao")]
	public class Student1
	{
		public string name { get; set; }

		public int age { get; set; }
	}

	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IRabbitMqService _rabbitMqService;

		public ValuesController(IRabbitMqService rabbitMqService)
		{
			this._rabbitMqService = rabbitMqService;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<string> Get()
		{
			var test = "aaa";
			_rabbitMqService.Publish(new Student()
			{
				age = 1,
				name = "lilei"
			});
			_rabbitMqService.Subscribe<Student>(ea => {
				test = ea.name + ea.age;
			});
			return test;
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public aaa Post( )
		{
			return new aaa() { Id = 1,name = "taneli"};
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}

	public class aaa {
		public int Id { get; set; }

		public string name { get; set; }
	}
}
