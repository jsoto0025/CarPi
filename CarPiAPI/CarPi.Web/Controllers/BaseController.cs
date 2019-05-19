using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarPi.Web.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarPi.Web.Controllers
{
	[Authorize(Policy = "AdministratorsOnlyAllowed")]
	public class BaseController : Controller
	{

	}
}