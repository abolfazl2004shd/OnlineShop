namespace OnlineShop.Areas.Managers.Controllers
{
    [Authorize]
    [Area(areaName: "Managers")]
    public class ProductsController(OnlineShopDbContext context) : Controller
    {
        private readonly OnlineShopDbContext _context = context;


        #region Show All Products

        public async Task<IActionResult> Index()
        {
            int managerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var products = await _context.Products
                .Include(p => p.Branch)
                .ThenInclude(p => p.Shop)
                .Where(p => p.Branch.Shop.ManagerId == managerId)
                .ToListAsync();
            return View(viewName: nameof(Index), model: products);
        }
        #endregion


        #region Show Product In Detailed

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Branch)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(viewName: nameof(Details), model: product);
        }

        #endregion


        #region Create New Product

        [HttpGet]

        public IActionResult Create()
        {
            ViewData["BranchName"] = new SelectList(_context.Branches, "BranchId", "BranchName");
            return View(viewName: nameof(Create));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,BranchId,ProductName,ImageSrc,Size,Color,Discount,ClothType,Description,ProducingCountry,Amount,Price")] Product product)
        {
            //     if (ModelState.IsValid)
            //   {
            _context.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(actionName: nameof(Index), controllerName: "Products", new
            {
                area = "Managers",
            });
            //    }
            //  ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchName", product.BranchId);
            //    return View(product);
        }

        #endregion


        #region Edit Product

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchName", product.BranchId);
            return View(viewName: nameof(Edit), model: product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,BranchId,ProductName,ImageSrc,Size,Color,Discount,ClothType,Description,ProducingCountry,Amount,Price")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View(viewName: nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchName", product.BranchId);
            return RedirectToAction(actionName: nameof(Index), controllerName: "Branches", new
            {
                area = "Managers",
            });
        }

        #endregion


        #region Delete Product

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Branch)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(viewName: nameof(Delete), model: product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(actionName: nameof(Index), controllerName: "Products", new
            {
                area = "Managers",
            });
        }

        #endregion

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
