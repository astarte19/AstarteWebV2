using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Astarte.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Astarte.Controllers
{
	[Authorize(Roles = "admin,user")]
	public class FinanceController : Controller
	{
        private readonly FinanceContext _Db;


        public FinanceController(FinanceContext Db)
        {
            _Db = Db;
        }

        public IActionResult Helper()
        {
            try
            {


                var finList = from a in _Db.Finances


                              select new Finance
                              {
                                  ID = a.ID,
                                  Name = a.Name,
                                  Cost = a.Cost,
                                  DateTime = a.DateTime,

                                  Category = a.Category,
                              };


                return View(finList);
            }
            catch (Exception ex)
            {
                return View();

            }
        }

        public IActionResult Create(Finance finance)
        {
            return View(finance);
        }

        [HttpPost]
        public async Task<IActionResult> AddFinance(Finance finance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (finance.ID == 0)
                    {
                        _Db.Finances.Add(finance);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(finance).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("Helper");
                }

                return View(finance);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Helper");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var std = await _Db.Finances.FindAsync(id);
                if (std != null)
                {
                    _Db.Finances.Remove(std);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("Helper");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Helper");
            }
        }
    }
}

