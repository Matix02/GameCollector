using EWebApiTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EWebApiTwo.Controllers
{
    public class AvatarsController : ApiController
    {
        GgDbOneEntities1 ggDbOneEntities = new GgDbOneEntities1();

        public IHttpActionResult GetAvatars()
        {
            var games = ggDbOneEntities.Avatars;
            return Ok(games);
        }
        

    }
}
