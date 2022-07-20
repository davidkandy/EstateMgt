using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Data.CoreEntities;
using Server.Repository;
using Shared.Models.DTOs.Admin;

namespace Server.Data.Controllers
{
    [Route("api/estate")]
    [ApiController]
    public class EstatesController : Controller
    {
        private readonly IRepository<Estate> _repo;
        private readonly IMapper _mapper;

        public EstatesController(IRepository<Estate> repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<EstateDto>>> GetEstates()
        {
            IEnumerable<Estate> estates;

            estates = await _repo.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<EstateDto>>(estates));
        }

        [HttpGet("{estateId}")]
        public async Task<IActionResult> GetEstate(Guid estateId)
        {
            var estate = await _repo.GetByIdAsync(estateId);
            if (estate == null) return NotFound();
            return Ok(estate);
        }

        [HttpPost]
        //[Route("estate/Create")]
        public async Task<ActionResult<EstateDto>> CreateEstate(EstateForCreation estate)
        {

            if (estate == null) return UnprocessableEntity();

            var estateEntity = _mapper.Map<Estate>(estate);

            try
            {
                _repo.Insert(estateEntity);
                await _repo.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} $$$$$$$$$ {ex.InnerException}");
                return UnprocessableEntity();
            }
            var estateToReturn = _mapper.Map<EstateDto>(estateEntity);
            return CreatedAtRoute("GetEstate", new { estateId = estateToReturn.Id }, estateToReturn);
        }

        [HttpPut("{estateId}")]
        public async Task<IActionResult> UpdateEstate(Guid estateId, EstateForUpdate estate)
        {
            var estateFromRepo = await _repo.GetByIdAsync(estateId);

            //if (estateFromRepo == null)
            //{
            //    var estateToAdd = _mapper.Map<Estate>(estate);
            //    estateToAdd.Id = estateId;

            //    try
            //    {
            //        _repo.Insert(estateToAdd);
            //        await _repo.Save();
            //    }
            //    catch(Exception)
            //    {
            //        return UnprocessableEntity("An Error Occurred");
            //    }

            //    var estateToReturn = _mapper.Map<EstateDto>(estateToAdd);
            //    return CreatedAtRoute("GetEstate", new { estateId = estateToReturn.Id }, estateToReturn);
            //}

            //_mapper.Map(estate, estateFromRepo);

            try
            {
                _repo.Update(estateFromRepo);
                await _repo.Save();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
                throw;
            }
            return NoContent();
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(EstateForUpdate estate)
        //{
        //    _mapper.Map<Estate>(estate);

        //    var estateEntity = new Estate
        //    {
        //        Id = estate.Id,
        //        Name = estate.Name,
        //        Description = estate.Description,
        //        City = estate.City,
        //        Street = estate.Street,
        //        State = estate.State,
        //        Status = estate.Status,
        //        PostalCode = estate.PostalCode,
        //        StartDate = estate.StartDate,
        //        DateCompleted = estate.DateCompleted,
        //        Size = estate.Size,
        //        Geolocation = estate.Geolocation
        //    };

        //    if (estateEntity.Id != null)
        //        return View(estateEntity);
        //    else
        //        return View();
        //}

        [HttpDelete("{estateId}")]
        public async Task<IActionResult> Delete(Guid estateId)
        {
            var estate = await _repo.GetByIdAsync(estateId);

            if (estate == null) return NotFound();

            try
            {
                _repo.Delete(estateId);
                await _repo.Save();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

            return NoContent();
        }
    }
}