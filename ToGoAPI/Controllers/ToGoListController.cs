using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using ToGoAPI.DAL;
using ToGoAPI.Models;
using System.Configuration;

namespace ToGoAPI.Controllers
{
    [Authorize]
    public class ToGoListController : ApiController
    {

        static ConcurrentBag<ToGo> todoBag = new ConcurrentBag<ToGo>();
        // GET: api/ToGoList
        public IEnumerable<ToGo> Get()
        {
            string owner = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            return from todo in todoBag
                   where todo.Owner == owner
                   select todo;
            //   IEnumerable<ToGo> currentUserToGos = db.ToGoes.Where(a => a.Owner == owner);
            //return currentUserToGos;
        }

        // GET: api/ToGoList/5
        public ToGo Get(int id)
        {
            string owner = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            ToGo toGo = todoBag.First(a => a.Owner == owner && a.ID == id);
            return toGo;
        }

        // POST: api/ToGoList
        public void Post(ToGo ToGo)
        {
            string owner = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            ToGo.Owner = owner;

            {
                todoBag.Add(ToGo);
            }
            //   db.ToGoes.Add(ToGo);
            //  db.SaveChanges();
        }

        public void Put(ToGo ToGo)
        {
            string owner = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            ToGo xToGo = todoBag.First(a => a.Owner == owner && a.ID == ToGo.ID);
            if (ToGo != null)
            {
                xToGo.Description = ToGo.Description;

            }
        }

        // DELETE: api/ToGoList/5
        public void Delete(int id)
        {
            string owner = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            ToGo ToGo = todoBag.First(a => a.Owner == owner && a.ID == id);
            if (ToGo != null)
            {
                //    todoBag.(ToGo);

            }
        }
    }
}
