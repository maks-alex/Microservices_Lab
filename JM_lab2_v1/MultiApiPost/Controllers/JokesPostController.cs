﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiApiPost.Models;

namespace MultiApiPost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesPostController : ControllerBase
    {
        private readonly MultiApiPostContext _context;

        public JokesPostController(MultiApiPostContext context)
        {
            _context = context;
        }

        // GET: api/JokesPost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Joke>>> GetJoke()
        {
            return await _context.Joke.ToListAsync();
        }

        // GET: api/JokesPost/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Joke>> GetJoke(int id)
        {
            var joke = await _context.Joke.FindAsync(id);

            if (joke == null)
            {
                return NotFound();
            }

            return joke;
        }

        // PUT: api/JokesPost/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoke(int id, Joke joke)
        {
            if (id != joke.Id)
            {
                return BadRequest();
            }

            _context.Entry(joke).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JokeExists(id))
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

        // POST: api/JokesPost
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Joke>> PostJoke(Joke joke)
        {
            _context.Joke.Add(joke);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJoke", new { id = joke.Id }, joke);
        }

        // DELETE: api/JokesPost/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoke(int id)
        {
            var joke = await _context.Joke.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }

            _context.Joke.Remove(joke);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JokeExists(int id)
        {
            return _context.Joke.Any(e => e.Id == id);
        }
    }
}
