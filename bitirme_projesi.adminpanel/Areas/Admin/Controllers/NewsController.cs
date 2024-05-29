﻿using bitirme_projesi.adminpanel.Dtos.NewsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using System.Text;

namespace bitirme_projesi.adminpanel.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[Area]/[Controller]/[Action]/{id?}")]
	public class NewsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
        public NewsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7272/api/News");
			if(responseMessage.IsSuccessStatusCode) 
			{ 
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultNewsDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateNews()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateNews(CreateNewsDto createNewsDto)
		{
			var client = _httpClientFactory.CreateClient();	
			var jsonData = JsonConvert.SerializeObject(createNewsDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7272/api/News", content);
			if(responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", new {area = "Admin"});
			}
			return View();
		}
		public async Task<IActionResult> DeleteNews(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7272/api/News?id="+id);
			if(responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
            return View();
        }
		[HttpGet]
		public async Task<IActionResult> UpdateNews(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7272/api/News?id=" + id);
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateNewsDto>(jsonData);
                return View(values);
            }
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> UpdateNews(UpdateNewsDto updateNewsDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateNewsDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7272/api/News", stringContent);
			if(responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
            return View();
        }
	}
}
