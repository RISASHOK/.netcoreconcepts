using Microsoft.AspNetCore.Mvc;
using Commercial_DataRepo.Repo_Interface;
using Commercial_DataRepo.Repo_Models;
using Commercial_DataRepo.Repo_Repos;

namespace CommercialMVC_Core.Controllers
{
    public class CommercialController : Controller
    { 
        private IProduct _product = new ProductRepo();
        private IProductDetails _productDetails = new ProductDetailsRepo();
        private SaleProductReo _saleDetail = new SaleProductReo();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int PId)
        {
            ViewBag.Pid = PId;
            List<Product> products = _product.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddDetail()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddDetail(Product product)
        {
            int value = _product.InsertNewProduct(product);

            return RedirectToAction(nameof(Details));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDetail productDetail)
        {
            string msg = _productDetails.AddProductDetails(productDetail);
            if (string.IsNullOrWhiteSpace(msg))
            {
                return RedirectToAction(nameof(Details), new { PId = productDetail.PId});
            }

            ViewBag.Message = msg;
            return View("Create", productDetail);       
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(SalesDetail saleDetail)
        {
            string msg = _saleDetail.SaleProductDetails(saleDetail);
            if (string.IsNullOrWhiteSpace(msg))
            {
                return RedirectToAction(nameof(Details), new { PId = saleDetail.PId });
            }

            ViewBag.Message = msg;
            return View("Edit", saleDetail);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = _product.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteProduct(int PId)
        {
            int nurseDeleted = _product.DeleteProduct(PId);
            return RedirectToAction(nameof(Details));
        }
    }
}

