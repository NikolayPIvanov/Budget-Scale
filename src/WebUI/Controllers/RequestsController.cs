﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BudgetScale.WebUI.Controllers
{
    public class RequestsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}