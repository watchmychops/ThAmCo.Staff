﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThAmCo.Staff.Models;
using ThAmCo.Staff.Services;

namespace ThAmCo.Staff.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IOrdersService _ordersService;
        public List<OrderGetDto> orders = new();
        public OrderGetDto order = new();

        public IndexModel(ILogger<IndexModel> logger, IOrdersService ordersService)
        {
            _logger = logger;
            _ordersService = ordersService;
        }

        public void OnGet()
        {
            orders = _ordersService.GetOrdersAsync().Result.ToList();
            order = _ordersService.GetOrderAsync(1).Result;
        }
    }
}