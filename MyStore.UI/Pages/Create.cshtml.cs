using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using MyStore.UI.Models;
using MyStore.UI.Services;

namespace MyStore.UI.Pages;


public class CreateModel : PageModel
{
    private ProductItem product1 = new(Guid.NewGuid(), "", Guid.NewGuid(), "");
    async Task Add(ProductsServiceProxy productsServiceProxy)
    {
        var product = new ProductItem(Guid.NewGuid(), product1.Name, Guid.NewGuid(), product1.Description);
        await productsServiceProxy.Create(product);
    }

}

