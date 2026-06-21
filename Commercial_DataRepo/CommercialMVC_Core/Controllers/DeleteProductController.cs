using Commercial_DataRepo.Repo_Interface;
using Commercial_DataRepo.Repo_Models;
using Commercial_DataRepo.Repo_Repos;
using Microsoft.AspNetCore.Mvc;

namespace CommercialMVC_Core.Controllers
{
    public class DeleteProductController : Controller
    {
        private IProduct _product = new ProductRepo();

       
    }
}
