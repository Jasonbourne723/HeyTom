using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyTom.Infra.MessageQueue;
using HeyTom.Infra.MessageQueue.RabbitMq;
using HeyTom.Infra.Token;
using HeyTom.Infra.Util;
using Microsoft.AspNetCore.Authorization;
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
	public class ValuesController : BaseController
	{
		//private readonly IRabbitMqService _rabbitMqService;

		public ValuesController(
			//IRabbitMqService rabbitMqService
			)
		{
			//this._rabbitMqService = rabbitMqService;
		}

		[Route("[action]")]
		public ActionResult<string> Token()
		{
			return  TokenHelper.IssueJWT(new TokenModel() { Uid = 1,Icon = "sst",Phone = "16675566723",Sub= "Admin", Uname = "唐磊"}, new TimeSpan(1, 1, 1), new TimeSpan(1, 1, 1));
		}

		// GET api/values
		[HttpGet]
		//[Authorize(Roles = "Admin,Client")]
		[Authorize(policy:"Permission")]
		//[Authorize(Policy ="Admin")]
		public ActionResult<string> Get()
		{
			var test = "aaa";
			var aa = User.Identities;
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
