using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Contexts;
using MyPortfolio.Models.Blog;
using Microsoft.Extensions.PlatformAbstractions;

namespace MyPortfolio.Controllers
{
    public class BlogsController : Controller
    {
        private readonly BloggingContext _context;

        public BlogsController(BloggingContext context)
        {
            _context = context;    
        }

        // GET: Blogs
        public async Task<IActionResult> Index(Tags tag, string currentTag)
        {
            var allPostsInCurrentTag = GetAllPostsInCurrentTag(tag);
            switch (tag)
            {
                case Tags.DSP2017:
                    allPostsInCurrentTag = await GetAllPostsInCurrentTagAsync(Tags.DSP2017);
                    break;

                case Tags.CSHARP:
                    allPostsInCurrentTag = await GetAllPostsInCurrentTagAsync(Tags.CSHARP);
                    break;

                case Tags.QA:
                    allPostsInCurrentTag = await GetAllPostsInCurrentTagAsync(Tags.QA);
                    break;

                default:
                    allPostsInCurrentTag = GetAllPostsInCurrentTag(tag);
                    break;
            } 

            return View(allPostsInCurrentTag);
        }

        private async Task<List<Post>> GetAllPostsInCurrentTagAsync(Tags tag)
        {
            return await Task.Run(() => GetAllPostsInCurrentTag(tag));
        }


        private List<Post> GetAllPostsInCurrentTag(Tags tag)
        {
            List<Post> allPostsInCurrentTag = new List<Post>();
            //Eagerloading
            var postsWithTags = _context.Posts.Include(m => m.Tags);
            foreach (Post post in postsWithTags)
            {
                if (post.Tags != null)
                {
                    foreach (Tag t in post.Tags)
                    {
                        if (t != null && t.TagCategory.Equals(tag))
                        {
                            allPostsInCurrentTag.Add(post);
                        }
                    }
                }
            }
            return allPostsInCurrentTag;
        }
        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .SingleOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogId,Url")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.SingleOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogId,Url")] Blog blog)
        {
            if (id != blog.BlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.BlogId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .SingleOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.SingleOrDefaultAsync(m => m.BlogId == id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogId == id);
        }
    }
}
