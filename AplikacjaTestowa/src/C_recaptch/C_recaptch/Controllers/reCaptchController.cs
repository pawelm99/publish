using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace C_recaptch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class reCaptchController: ControllerBase
    {
        [HttpPost("{EncodedResponse}")]
        public ActionResult Post(string EncodedResponse)
        {
            var PrivateKey = "6LdWjDMkAAAAAKmGxQ732D-_So6_7JL7PIoewYeO";
            

            var client = new System.Net.WebClient();


            var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey, EncodedResponse));
            var jobj = JObject.Parse(GoogleReply.ToString());
            var reCaptch = JsonConvert.DeserializeObject<reCaptchResponse>(jobj.ToString());
            return Ok(reCaptch);
        }
    }
}
