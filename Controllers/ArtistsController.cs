using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ngjs1.Data;
using ngjs1.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ngjs1.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly ngjs1Context _context;

        public ArtistsController(ngjs1Context context)
        {
            _context = context;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artist.ToListAsync());
        }
        // GET: Artists
        [HttpGet]
        [Route("Artists/NgIndex")]
        public string NgIndex()
        {
            var preJson = _context.Artist.ToListAsync();
            var convertedToJson = JsonSerializer.Serialize(preJson);
            return convertedToJson;
        }

        [HttpGet]
        [Route("Artists/Artists/NgIndex")]
        public string NgIndex2()
        {
            var preJson = _context.Artist.ToListAsync();
            var convertedToJson = JsonSerializer.Serialize(preJson);
            return convertedToJson;
        }

        [HttpGet]
        public Artist Details(int? id)
        {
            return _context.Artist
                .FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public IActionResult LastViewedRecord(int id)
        {
            LastViewed item = new LastViewed();
            item.ViewId = id;
            _context.Add(item);
            _context.SaveChanges();
            return this.Ok();
        }

        [HttpPost]
        public string SaveEdit(int id, string name, int rating)
        {
            Artist toSave = _context.Artist.FirstOrDefault(n => n.Id == id);
            toSave.Name = name;
            toSave.Rating = rating;
            _context.Update(toSave);
            _context.SaveChanges();
            return "ok";
        }

        [HttpGet]
        public string GetLastViewedRecord()
        {
            var returnee = _context.LastVieweds
                .ToList();
            if (returnee != null) 
            {
                var record = _context.Artist.FirstOrDefault(n => n.Id == returnee.Last().ViewId);

                var convertedToJson = JsonSerializer.Serialize(record);
                return convertedToJson;
            } 
            else
            {
                var blankReturnee = new Artist();
                var convertedToJson = JsonSerializer.Serialize(blankReturnee);
                return convertedToJson;
            }
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rating")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpDelete]
        public string Delete(int? id)
        {
            if (id == null)
            {
                return "not found";
            }

            var artist = _context.Artist
                .FirstOrDefault(m => m.Id == id);
            if (artist == null)
            {
                return "not found";
            }
            else
            {
                _context.Artist.Remove(artist);
                _context.SaveChanges();
            }

            return "ok";
        }

        private bool ArtistExists(int id)
        {
            return _context.Artist.Any(e => e.Id == id);
        }
    }
}
