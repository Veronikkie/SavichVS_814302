using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.Admin;
using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LAMS.WebApi.Controllers.api
{
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService adminService)
        {
            _service = adminService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addproglang")]
        public async Task<IHttpActionResult> AddProgLang([FromBody] ProgLangBLL info)
        {
            var _Id = await _service.AddProgLangAsync(info);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getproglangs")]
        public async Task<IHttpActionResult> GetProgLangs()
        {

            var info = await _service.GetProgLangs();

            return Ok(info);
        }
    }
}