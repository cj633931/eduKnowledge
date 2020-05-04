using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eduKnowledge.Contracts;
using eduKnowledge.Data;
using eduKnowledge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eduKnowledge.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public ArticlesController(IArticleRepository repo,
                                  IMapper mapper,
                                  UserManager<IdentityUser> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: Articles
        public ActionResult Index()
        {
            var articles = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Article>, List<ArticleViewModel>>(articles);
            return View(model);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var article = _repo.FindById(id);
            var model = _mapper.Map<ArticleViewModel>(article);
            return View(model);
        }

        // GET: Articles/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(ArticleViewModel model)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var today = DateTime.Now;
                var content = model.Content;

                var articleModel = new ArticleViewModel
                {
                    Title = model.Title,
                    AuthorId = user.Id,
                    DateDrafted = today,
                    DatePublished = null,
                    LastEdited = today,
                    Content = content
                };

                var article = _mapper.Map<Article>(articleModel);
                var success = _repo.Create(article);
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

        // GET: Articles/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            if (!_repo.Exists(id)) // First have to figure out if the request exists
            {
                return NotFound();
            }
            var article = _repo.FindById(id);
            var model = _mapper.Map<ArticleViewModel>(article);
            return View(model);
        }

        // POST: Articles/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Article model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var article = _mapper.Map<Article>(model);
                article.LastEdited = DateTime.Now;
                var success = _repo.Update(article);
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

        // GET: Articles/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var article = _repo.FindById(id);
            var model = _mapper.Map<ArticleViewModel>(article);
            return View(model);
        }

        // POST: Articles/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ArticleViewModel model)
        {
            try
            {
                var article = _repo.FindById(id);
                if (article == null)
                {
                    return NotFound();
                }
                var success = _repo.Delete(article);
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