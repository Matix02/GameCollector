using EWebApiTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EWebApiTwo.Controllers
{
    public class GamesController : ApiController
    {
        GgDbOneEntities1 ggDbOneEntities = new GgDbOneEntities1();

          public IHttpActionResult GetGames()
          {
              var games = ggDbOneEntities.Games;
              return Ok(games);
          }

        [Route("games/{name}")]
        public IHttpActionResult GetGames(string name)
        {
            var games = (from c in ggDbOneEntities.Games
                                                     where c.Title == name
                                                     select c);
            if (name == null)
                return NotFound();
            return Ok(games);
        }

    }
}
