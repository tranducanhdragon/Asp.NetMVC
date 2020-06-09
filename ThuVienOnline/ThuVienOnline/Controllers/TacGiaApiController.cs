using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model.EF;
using Model.DAO;
using ThuVienOnline.Areas.Admin.Models;
using PagedList;

namespace ThuVienOnline.Controllers
{
    public class TacGiaApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<TacGiaApi> Get()
        {
            var li_tacgia = new TacGiaDAO().ListAll();
            List<TacGiaApi> li_tgApi = new List<TacGiaApi>();
            foreach(TacGia tg in li_tacgia)
            {
                TacGiaApi tgApi = new TacGiaApi();
                tgApi.MaTG = tg.MaTG;
                tgApi.HoTen = tg.HoTen;
                li_tgApi.Add(tgApi);
            }
            return li_tgApi;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}