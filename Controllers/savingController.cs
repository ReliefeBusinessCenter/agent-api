using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System;
using broker.Data;
using broker.Models;
using AutoMapper;
using broker.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Controllers
{   
    // [Authorize]
    [Route("api/saving")]
    [ApiController]
    public class SavingController : ControllerBase
    { 
        private readonly IRepository<Saving> _savingRepository;
        private readonly IMapper _mapper;
        public SavingController(IRepository<Saving> repo, IMapper mapper)
        {
            _savingRepository = repo;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetSaving()
        {
            var model = await _savingRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<CityDto>>(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSavingById(int id)
        {
            Console.WriteLine("Returning technician of id" + id);
            var model = await _savingRepository.GetDataById(id);
            return Ok(_mapper.Map<CityDto>(model));
        }
        //  [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateSavings(SavingDto savingDto)
        {   
            Console.WriteLine("Creating new cities");
            var saving = _mapper.Map<Saving>(savingDto);
            await _savingRepository.UpdateData(saving);
            return Ok(savingDto);
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavings(int id)
        {
            var model = await _savingRepository.GetDataById(id);
            var savings = _mapper.Map<Saving>(model);

            await _savingRepository.DeleteData(savings);

            return Ok(model);
        }
        //   [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSavings(int id, SavingDto savingDto)
        {
            // Console.WriteLine(technician.AccepteStatus);
            var saving = _mapper.Map<Saving>(savingDto);
            await _savingRepository.UpdateData(saving);
            return Ok(saving);
        }
        
        
    }

}

