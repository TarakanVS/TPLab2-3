using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Stories.MainStories;
using Lab2_3Web.Models;
using Domain.Models;
using AutoMapper;
using Services.Stories.PurchaseStories;
using System.Diagnostics;

namespace Lab2_3Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string promoCode)
        {
            ShowProductsByPromocodeStory story = new ShowProductsByPromocodeStory();
            story.Code = promoCode;
            var response = await _mediator.Send(story);

            var productsViewModel = new List<ProductViewModel>();
            var productView = new ProductViewModel();

            if (response == null)
            {
                return View(productsViewModel);
            }

            foreach (Product x in response)
            {
                ProductViewModel newProductVievModel = new ProductViewModel { Id = x.Id, Name = x.Name, Price = x.Price};
                productsViewModel.Add(newProductVievModel);
            }

            return View(productsViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Buy(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Buy(PurchaseViewModel purchaseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            purchaseViewModel.Date = DateTime.Now;
            CreatePurchaseStory story = new CreatePurchaseStory
            {
                Address = purchaseViewModel.Address,
                Date = purchaseViewModel.Date,
                Person = purchaseViewModel.Person,
                ProductId = purchaseViewModel.ProductId
            };

            var response = await _mediator.Send(story);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}