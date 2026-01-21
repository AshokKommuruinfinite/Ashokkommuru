using CC9.Models;
using CC9.Repositories;
using System.Web.Http;

namespace CC9.Controllers
{
    [RoutePrefix("api/country")]
    public class CountryController : ApiController
    {

        private readonly CountryRepository _repo = new CountryRepository();

        // GET api/country
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
            => Ok(_repo.GetAll());

        // GET api/country/5
        [HttpGet, Route("{id:int}", Name = "GetCountryById")]
        public IHttpActionResult GetById(int id)
        {
            var item = _repo.Get(id);

            return item == null ? (IHttpActionResult)NotFound() : Ok(item);
        }

        // POST api/country
        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody] Country country)

        {
            if (country == null) return BadRequest("Payload is required.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = _repo.Add(country);
            return CreatedAtRoute("GetCountryById", new { id = created.Id }, created);
        }

        // PUT api/country/5
        [HttpPut, Route("{id:int}")]

        public IHttpActionResult Update(int id, [FromBody] Country country)
        {
            if (country == null) return BadRequest("Payload is required.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ok = _repo.Update(id, country);
            return ok ? StatusCode(System.Net.HttpStatusCode.NoContent) : (IHttpActionResult)NotFound();
        }

        // DELETE api/country/5
        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var ok = _repo.Delete(id);
            return ok ? StatusCode(System.Net.HttpStatusCode.NoContent) : (IHttpActionResult)NotFound();
        }
    }
}












