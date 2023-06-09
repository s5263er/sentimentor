﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sentimentor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using System.Net;
using bearish_model.Models;
using bullish_model.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace sentimentor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public async Task<IActionResult> Index()
    {
        List <Trending_Bullish> TickerData_param = new List<Trending_Bullish> ();

        var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();
        Console.WriteLine(configuration);
        string apiKey = configuration.GetValue<string>("ApiKey");

        //

        

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://finance-social-sentiment-for-twitter-and-stocktwits.p.rapidapi.com/get-sentiment-trending/bullish?social=twitter&isCrypto=false&timestamp=24h&limit=25"),
            Headers =
        {
            { "X-RapidAPI-Key", apiKey },
            { "X-RapidAPI-Host", "finance-social-sentiment-for-twitter-and-stocktwits.p.rapidapi.com" },
        },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            string jsonData = await response.Content.ReadAsStringAsync();
            //ViewData["trending_bullish"] = body;
            TickerData_param = JsonConvert.DeserializeObject<List<Trending_Bullish>>(jsonData);
           


        }
        return View(TickerData_param);
        
    }
    

    public async Task<IActionResult> trending_bearish()
    {
        List <Trending_Bearish> TickerData_param = new List<Trending_Bearish> ();

        var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();
        Console.WriteLine(configuration);
        string apiKey = configuration.GetValue<string>("ApiKey");
        

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://finance-social-sentiment-for-twitter-and-stocktwits.p.rapidapi.com/get-sentiment-trending/bearish?social=twitter&isCrypto=false&timestamp=24h&limit=25"),
            Headers =
        {
            { "X-RapidAPI-Key", apiKey },
            { "X-RapidAPI-Host", "finance-social-sentiment-for-twitter-and-stocktwits.p.rapidapi.com" },
        },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            string jsonData = await response.Content.ReadAsStringAsync();
            //ViewData["trending_bullish"] = body;
            TickerData_param = JsonConvert.DeserializeObject<List<Trending_Bearish>>(jsonData);
            foreach (var item in TickerData_param)
            {
                Console.WriteLine(item.Name);

            }


        }
        return View("trending_bearish_view",TickerData_param);
    
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
