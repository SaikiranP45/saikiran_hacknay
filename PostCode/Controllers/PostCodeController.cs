using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PostCode.Controllers
{
    public class PostCodeController : ControllerBase
    {
        public readonly IConfiguration _IConfiguration;
        public PostCodeController(IConfiguration config)
        {
            _IConfiguration = config;
        }


        [HttpGet]
        public JsonResult postCodeProperties(string postcode)
        {
            //if (Regex.IsMatch(postcode, "[A-Za-z][1-9] [1-9][A-Za-z]{2}"))
            //{
                HttpClient httpClient = new HttpClient();
                string apiPath = _IConfiguration.GetValue<string>("ApiPath");
                string authKey = _IConfiguration.GetValue<string>("apiAuthKey");
                httpClient.DefaultRequestHeaders.Authorization =
                      new AuthenticationHeaderValue("Bearer", authKey);
                apiPath = apiPath + "/?postcode=" + postcode;

                //This statement calls a not existing URL. This is just an example...
                var response = httpClient.GetAsync(apiPath).Result;

                return new JsonResult(response.Content.ReadAsStringAsync().Result);
            //}
           // return new JsonResult("Postcode validation error");
        }
    }
}


