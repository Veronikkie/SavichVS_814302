using LAMS.DataAccess.Common.Models.Work;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.UserForm;
using LAMS.WebApi.Areas.HttpResponses;
using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LAMS.WebApi.Controllers.api
{
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/userform")]
    public class UserFormController : ApiController
    {
        private readonly IUserFormService _service;

        public UserFormController(IUserFormService userformService)
        {
            _service = userformService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addinfo")]
        public async Task<IHttpActionResult> AddPersonalInfo([FromBody] PersonalInfoBLL info)
        {
            var _Id = await _service.AddPersonalInfoAsync(info);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("adduserproglang")]
        public async Task<IHttpActionResult> AddUserProgLang([FromBody] UserProgLangBLL info)
        {
            var _Id = await _service.AddUserProgLang(info);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getpersonalinfo")]
        public async Task<IHttpActionResult> GetPersonalInfo([FromUri] string UserId)
        {
            if (String.IsNullOrEmpty(UserId))
                return StatusCode(HttpStatusCode.NoContent);
         
            var info = await _service.GetPersonalInfo(UserId);

            return Ok(info);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("geteducation")]
        public async Task<IHttpActionResult> GetEducationInfo([FromUri] string UserId)
        {
            if (String.IsNullOrEmpty(UserId))
                return StatusCode(HttpStatusCode.NoContent);

            var info = await _service.GetEducationInfo(UserId);

            return Ok(info);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getlanguage")]
        public async Task<IHttpActionResult> GetLanguageInfo([FromUri] string UserId)
        {
            if (String.IsNullOrEmpty(UserId))
                return StatusCode(HttpStatusCode.NoContent);

            var info = await _service.GetLanguageInfo(UserId);

            return Ok(info);
        }


        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getexperience")]
        public async Task<IHttpActionResult> GetExperienceInfo([FromUri] string UserId)
        {
            if (String.IsNullOrEmpty(UserId))
                return StatusCode(HttpStatusCode.NoContent);

            var info = await _service.GetExperienceInfo(UserId);

            return Ok(info);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getuserproglang")]
        public async Task<IHttpActionResult> GetUserProgLangInfo([FromUri] string UserId)
        {
            if (String.IsNullOrEmpty(UserId))
                return StatusCode(HttpStatusCode.NoContent);

            var info = await _service.GetUserProgLangInfo(UserId);

            return Ok(info);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addeducation")]
        public async Task<IHttpActionResult> AddEducation([FromBody] EducationBLL info)
        {

            var _Id = await _service.AddEducationAsync(info);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addlanguage")]
        public async Task<IHttpActionResult> AddLanguage([FromBody] LanguageBLL info)
        {

            var _Id = await _service.AddLanguageAsync(info);

            return Ok(_Id);
        }


        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addexperience")]
        public async Task<IHttpActionResult> AddExperience([FromBody] ExperienceBLL info)
        {

            var _Id = await _service.AddExperienceAsync(info);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getusersform")]
        public async Task<IHttpActionResult> GetUsersForm()
        {

            var user = await _service.GetUsersForm();

            return Ok(user);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getusersformsee")]
        public async Task<IHttpActionResult> GetUsersFormSee()
        {

            var user = await _service.GetUsersFormSee();

            return Ok(user);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getusersformapprove")]
        public async Task<IHttpActionResult> GetUsersFormApprove()
        {

            var user = await _service.GetUsersFormApprove();

            return Ok(user);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getusersformreject")]
        public async Task<IHttpActionResult> GetUsersFormReject()
        {

            var user = await _service.GetUsersFormReject();

            return Ok(user);
        }


        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("seeform")]
        public async Task<IHttpActionResult> SeeForm([FromUri] string id)
        {
            int _count = await _service.SeeForm(id);

            return Ok(_count);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("approve")]
        public async Task<IHttpActionResult> Approve([FromUri] string UserId)
        {
            var id = UserId;
            int _count = await _service.Approve(id);

            return Ok(_count);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("reject")]
        public async Task<IHttpActionResult> Reject([FromUri] string UserId)
        {
            var id = UserId;
            int _count = await _service.Reject(id);

            return Ok(_count);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getuserstatus")]
        public async Task<IHttpActionResult> GetUserStatus([FromUri] string id)
        {
            var _count = await _service.GetUserStatus(id);

            return Ok(_count);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("uploadFiles")]
        public async Task<IHttpActionResult> PostUploadFiles()
        {
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                string id = httpRequest.Form.GetValues("UserId")[0];
                int totalCount = Int32.Parse(httpRequest.Form.GetValues("textsCount")[0]);
                var textIndex = httpRequest.Form.GetValues("textIndex")[0];
                if (!string.IsNullOrEmpty(id))
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var ext = file.Substring(file.LastIndexOf('.'), file.Length - file.LastIndexOf('.'));
                        var postedFile = httpRequest.Files[file];
                        var fileData = new MemoryStream();
                        postedFile.InputStream.CopyTo(fileData);

                        var doctext = new DocumentBLL { PersonalInfoId = id, Name = file, Extension = ext, Text = fileData.ToArray(), Number = Int32.Parse(textIndex), Status="Новая" };
                        int textId = await _service.AddTextAsync(doctext);
                    }

                    return Created("PostUploadFiles", id);
                }
                else
                    return BadRequest("Не валидный Id документа");
            }
            else
            {
                return BadRequest("Нет прикрепленных файлов");
            }
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getnamesoftext")]
        public async Task<IHttpActionResult> GetNamesOfTexts([FromUri] string UserId)
        {
            IEnumerable<DocumentBLL> textsInfo = await _service.GetNamesOfTextsAsync(UserId);
            if (textsInfo == null)
            {
                return BadRequest("Ошибка в запросе");
            }

            return Ok(textsInfo);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("gettextbyid")]
        public async Task<IHttpActionResult> GetTextById([FromUri] int id)
        {
            DocumentDb textArchive = _service.GetTextById(id);

            MemoryStream dataStream = new MemoryStream(textArchive.Text);


            return new FileActionResult(dataStream, Request, textArchive.Name);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addquestion")]
        public async Task<IHttpActionResult> AddQuestion([FromBody] QuestionBLL info)
        {
            var _Id = await _service.AddQuestion(info);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getquestion")]
        public async Task<IHttpActionResult> GetQuestion([FromUri] string Id)
        {
            if (String.IsNullOrEmpty(Id))
                return StatusCode(HttpStatusCode.NoContent);

            var info = await _service.GetQuestion(Id);

            return Ok(info);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("addanswer")]
        public async Task<IHttpActionResult> AddAnswer([FromBody] QuestionBLL question)
        {
            int _count = await _service.AddAnswer(question);

            return Ok(_count);
        }
    }
}