namespace OnlineShop.Areas.Managers.Controllers
{
    [Authorize]
    [Area(areaName: "Managers")]
    public class BranchesController(OnlineShopDbContext context) : Controller
    {
        private readonly OnlineShopDbContext _context = context;

        // GET: Managers/Branches
        public async Task<IActionResult> Index()
        {
            var onlineShopDbContext = _context.Branches.Include(b => b.Shop);
            return View(await onlineShopDbContext.ToListAsync());
        }

        // GET: Managers/Branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branches
                .Include(b => b.Shop)
                .FirstOrDefaultAsync(m => m.BranchId == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // GET: Managers/Branches/Create
        public IActionResult Create()
        {
            int managerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            ViewData["ShopId"] = new SelectList(_context.Shops.Where(shop => shop.ManagerId == managerID).ToList(), "ShopId", "Name");
            return View();
        }

        // POST: Managers/Branches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BranchId,ShopId,BranchName,RegistrationDate,PostalCode,PhoneNumber,City,Street,Plaque")] Branch branch)
        {
            //      if (ModelState.IsValid)
            //    {
            _context.Add(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //  }
            // //  ViewData["ShopId"] = new SelectList(_context.Shops, "ShopId", "Name", branch.ShopId);
            //  return View(branch);
        }

        // GET: Managers/Branches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            int managerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            ViewData["ShopId"] = new SelectList(_context.Shops.Where(shop => shop.ManagerId == managerID).ToList(), "ShopId", "Name");
            return View(branch);
        }

        // POST: Managers/Branches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BranchId,ShopId,BranchName,RegistrationDate,PostalCode,PhoneNumber,City,Street,Plaque")] Branch branch)
        {
            if (id != branch.BranchId)
            {
                return NotFound();
            }

            //   if (ModelState.IsValid)
            //    {
            try
            {
                _context.Entry(branch).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(actionName: "Details", controllerName: "Branches", new
                {
                    area = "Managers"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(branch.BranchId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                //   }
                //   return RedirectToAction(nameof(Index));
            }
            ViewData["ShopId"] = new SelectList(_context.Shops, "ShopId", "Name", branch.ShopId);
            return View(branch);
        }

        // GET: Managers/Branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branches
                .Include(b => b.Shop)
                .FirstOrDefaultAsync(m => m.BranchId == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // POST: Managers/Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch != null)
            {
                _context.Branches.Remove(branch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchExists(int id)
        {
            return _context.Branches.Any(e => e.BranchId == id);
        }

    }
}
