using OGCEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace OGCOdataAPI
{
    public class OGCController : ApiController
    {
        [EnableQuery(MaxAnyAllExpressionDepth = 2)]
        [Route("OdataGetThing")]
        public IHttpActionResult GetCodeFirstTest()
        {
            OGCDbContext db = new OGCDbContext();

            return Content(HttpStatusCode.OK, db.thing);
        }
    }
}
