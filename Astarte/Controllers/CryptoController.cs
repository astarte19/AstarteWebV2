using System;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Astarte.Models;
using Microsoft.AspNetCore.Identity;
using Astarte.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Astarte.Controllers
{
	[Authorize(Roles = "admin,user")]
	public class CryptoController : Controller
	{
		string[] ids = { "bitcoin", "ethereum", "solana", "binancecoin", "litecoin", "polkadot", "cardano", "dogecoin", "tron", "ripple" };

		public async Task<IActionResult> Cryptos(CryptoRateViewModel model)
		{
			//USD
			for (int i = 0; i < 10; i++)
			{
				string path = ids[i] + ".usd";
				var value = JObject.Parse(makeRequest(ids, "usd", i)).SelectToken(path);
				switch (i)
				{
					case 0:
						model.BTCUSDT = value.ToString();
						break;
					case 1:
						model.ETHUSDT = value.ToString();
						break;
					case 2:
						model.SOLUSDT = value.ToString();
						break;
					case 3:
						model.BNBUSDT = value.ToString();
						break;
					case 4:
						model.LTCUSDT = value.ToString();
						break;
					case 5:
						model.DOTUSDT = value.ToString();
						break;
					case 6:
						model.ADAUSDT = value.ToString();
						break;
					case 7:
						model.DOGEUSDT = value.ToString();
						break;
					case 8:
						model.TRXUSDT = value.ToString();
						break;
					case 9:
						model.XRPUSDT = value.ToString();
						break;

				}
			}
			//RUB
			for (int i = 0; i < 10; i++)
			{
				string path = ids[i] + ".rub";
				var value = JObject.Parse(makeRequest(ids, "rub", i)).SelectToken(path);
				switch (i)
				{
					case 0:
						model.BTCRUB = value.ToString();
						break;
					case 1:
						model.ETHRUB = value.ToString();
						break;
					case 2:
						model.SOLRUB = value.ToString();
						break;
					case 3:
						model.BNBRUB = value.ToString();
						break;
					case 4:
						model.LTCRUB = value.ToString();
						break;
					case 5:
						model.DOTRUB = value.ToString();
						break;
					case 6:
						model.ADARUB = value.ToString();
						break;
					case 7:
						model.DOGERUB = value.ToString();
						break;
					case 8:
						model.TRXRUB = value.ToString();
						break;
					case 9:
						model.XRPRUB = value.ToString();
						break;
				}



			}
			return View(model);
		}


		public static string makeRequest(string[] _ids, string _targetcurr, int i)
		{
			var URL = new UriBuilder("https://api.coingecko.com/api/v3/simple/price");
			var queryString = HttpUtility.ParseQueryString(string.Empty);
			queryString["ids"] = _ids[i];
			queryString["vs_currencies"] = _targetcurr;
			URL.Query = queryString.ToString();
			var client = new WebClient();
			client.Proxy = new System.Net.WebProxy();
			client.Headers.Add("Accepts", "application/json");
			return client.DownloadString(URL.ToString());
		}

		public static string makeRequest(string left_side, string right_side)
		{
			var URL = new UriBuilder("https://api.coingecko.com/api/v3/simple/price");
			var queryString = HttpUtility.ParseQueryString(string.Empty);
			queryString["ids"] = left_side;
			queryString["vs_currencies"] = right_side;
			URL.Query = queryString.ToString();
			var client = new WebClient();
			client.Proxy = new System.Net.WebProxy();
			client.Headers.Add("Accepts", "application/json");
			return client.DownloadString(URL.ToString());
		}

		public async Task<IActionResult> CalcResult(CryptoRateViewModel model, string left_select, string right_select, string ammount)
		{

			double _ammount = Convert.ToDouble(ammount);
			string path = left_select + $".{right_select}";
			double value = Convert.ToDouble(JObject.Parse(makeRequest(left_select, right_select)).SelectToken(path)) * _ammount;

			model.ResultCulc = value.ToString() + " " + right_select.ToString();
			return Content(model.ResultCulc);
		}

	}
}

