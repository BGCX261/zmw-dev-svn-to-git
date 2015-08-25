using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace zmw.dev.Controllers.API
{
    public class UserController : ApiController
    {
        public Form Form;


        // GET api/user
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/user/5
        public string Get(Form form)
        {

            var name = form.Name;
            var foo = Request;
            return "value";
        }

        // POST api/user
        [System.Web.Mvc.HttpPost]
        public dynamic Post(Form form)
        {
            var foo = Request.Headers.GetValues("name");
            return foo;
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
    public class Form
    {
        public string Name { get; set; }
    }


}
