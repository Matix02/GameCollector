using EWebApiTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EWebApiTwo.Controllers
{
    public class UsersController : ApiController
    {
        GgDbOneEntities1 ggDbOneEntities = new GgDbOneEntities1();

        public IHttpActionResult GetGames()
        {
            var games = ggDbOneEntities.UserGames;
            return Ok(games);
        }
      /*  public IHttpActionResult GetGames(int id)
        {
            var games = (from c in ggDbOneEntities.UserGames
                         where c.ID == id
                         select c);
            if (id == 0)
                return NotFound();
            return Ok(games);
        }*/
        public IHttpActionResult GetUser(int id)
        {
            var users = (from c in ggDbOneEntities.Users
                         where c.ID == id
                         select c);
            if (id == 0)
                return NotFound();
            return Ok(users);
        }
        [Route("AllUsers")]
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            var users = ggDbOneEntities.Users;
            return Ok(users);
        }
        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public IHttpActionResult Regiser([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ggDbOneEntities.Users.Add(user);
            ggDbOneEntities.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }
        [HttpPost]
        public IHttpActionResult PostGame([FromBody]UserGame userGame)
        {
              if (!ModelState.IsValid)
                  return BadRequest(ModelState);

              ggDbOneEntities.UserGames.Add(userGame);
              ggDbOneEntities.SaveChanges();
              return StatusCode(HttpStatusCode.Created);
        }
        [HttpPost]
        [Route("api/dlc")]
        public IHttpActionResult PostDlc([FromBody]UserDlc userDlcs)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

 
            ggDbOneEntities.UserDlcs.Add(userDlcs);
            ggDbOneEntities.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }
        [HttpDelete]
        public IHttpActionResult DeleteGame(int id)
        {
            var game = ggDbOneEntities.UserGames.Find(id);
            ggDbOneEntities.UserGames.Remove(game);
            ggDbOneEntities.SaveChanges();
            return Ok("Game Deleted");
        }
        [HttpDelete]
        [Route("api/dlc/{id}")]
        public IHttpActionResult DeleteDlcs(int id)
        {
            var dlc = ggDbOneEntities.UserDlcs.Find(id);
            ggDbOneEntities.UserDlcs.Remove(dlc);
            ggDbOneEntities.SaveChanges();
            return Ok("Dlc Deleted");
        }
        public IHttpActionResult PutAvatar(int id, [FromBody]User user)
        {
            var entity = ggDbOneEntities.Users.FirstOrDefault(q => q.ID == id);
            entity.Avatar = user.Avatar;
            ggDbOneEntities.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [Route("RateGame/{id}")]
        public IHttpActionResult PutGame(int id, [FromBody]UserGame userGame)
        {
            var entity = ggDbOneEntities.UserGames.FirstOrDefault(q => q.ID == id);
            entity.Rate = userGame.Rate;
            ggDbOneEntities.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [Route("RateDlc/{id}")]
        public IHttpActionResult PutGame(int id, [FromBody]UserDlc userDlc)
        {
            var entity = ggDbOneEntities.UserDlcs.FirstOrDefault(q => q.ID == id);
            entity.Rate = userDlc.Rate;
            ggDbOneEntities.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [Route("ChangeList/{id}")]
        public IHttpActionResult PutList(int id, [FromBody]UserGame userGame)
        {
            var entity = ggDbOneEntities.UserGames.FirstOrDefault(q => q.ID == id);
            entity.List = userGame.List;
            ggDbOneEntities.SaveChanges();
            return Ok();
        }
    }
}
