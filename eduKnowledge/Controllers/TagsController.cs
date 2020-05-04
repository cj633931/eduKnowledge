using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eduKnowledge.Contracts;
using eduKnowledge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eduKnowledge.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class TagsController : Controller
    {
        private readonly ITagRepository _repo;
        private readonly IMapper _mapper;

        public TagsController(ITagRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: Tags
        public ActionResult Index()
        {
            var tags = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Tag>, List<TagViewModel>>(tags);
            return View(model);
        }

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var tag = _mapper.Map<Tag>(model);
                var success = _repo.Create(tag);
                if (!success)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View(model);
            }
        }

        // GET: Tags/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var tag = _repo.FindById(id);
            var model = _mapper.Map<TagViewModel>(tag);
            return View(model);
        }

        // POST: Tags/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TagViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var tag = _mapper.Map<Tag>(model);
                var success = _repo.Update(tag);
                if (!success)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View(model);
            }
        }

        // GET: Tags/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var tag = _repo.FindById(id);
            var model = _mapper.Map<TagViewModel>(tag);
            return View(model);
        }

        // POST: Tags/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TagViewModel model) // model is empty, just to differentiate methods from above
        {
            try
            {
                var tag = _repo.FindById(id);
                if (tag == null)
                {
                    return NotFound();
                }
                var success = _repo.Delete(tag);
                if (!success)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View(model);
            }
        }
    }
}