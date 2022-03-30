using System;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Astarte.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
namespace Astarte.Controllers
{
	[Authorize(Roles = "admin,user")]
	public class TranslatorController : Controller
	{
		public IActionResult Translate()
        {
			return View();
        }
	}
}

