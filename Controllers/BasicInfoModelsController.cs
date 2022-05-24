﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SilvarBayAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace SilvarBayAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasicInfoModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BasicInfoModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BasicInfoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicInfoModel>>> GetBasicInfoModel()
        {
            return await _context.BasicInfoModel.ToListAsync();
        }

        // GET: api/BasicInfoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasicInfoModel>> GetBasicInfoModel(int id)
        {
            var basicInfoModel = await _context.BasicInfoModel.FindAsync(id);

            if (basicInfoModel == null)
            {
                return NotFound();
            }

            return basicInfoModel;
        }

        // PUT: api/BasicInfoModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasicInfoModel(int id, BasicInfoModel basicInfoModel)
        {
            if (id != basicInfoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(basicInfoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasicInfoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BasicInfoModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BasicInfoModel>> PostBasicInfoModel(BasicInfoModel basicInfoModel)
        {
            _context.BasicInfoModel.Add(basicInfoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasicInfoModel", new { id = basicInfoModel.Id }, basicInfoModel);
        }

        // DELETE: api/BasicInfoModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasicInfoModel(int id)
        {
            var basicInfoModel = await _context.BasicInfoModel.FindAsync(id);
            if (basicInfoModel == null)
            {
                return NotFound();
            }

            _context.BasicInfoModel.Remove(basicInfoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasicInfoModelExists(int id)
        {
            return _context.BasicInfoModel.Any(e => e.Id == id);
        }
    }
}
