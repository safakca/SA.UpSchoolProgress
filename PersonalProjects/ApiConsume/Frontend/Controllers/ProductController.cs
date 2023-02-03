﻿using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Text.Json;

namespace Frontend.Controllers;

[Authorize(Roles = "Admin, Member")]

public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public async Task<IActionResult> List()
    {
        var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
        if (token != null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("http://localhost:5106/api/Product/List");


            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ProductListModel>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return View(result);
            }
        }
        return View();
    }


    public async Task<IActionResult> Remove(int id)
    {
        var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
        if (token != null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.DeleteAsync($"http://localhost:5106/api/Product/Delete/{id}");
        }
        return RedirectToAction("List");
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var model = new CreateProductModel();
        var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
        if (token != null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("http://localhost:5106/api/category/list");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                model.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(data, "Id", "Defination");

                return View(model);
            }
        }
        return RedirectToAction("List");
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateProductModel model)
    {
        var data = TempData["Categories"]?.ToString();
        if (data != null)
        {
            var categories = JsonSerializer.Deserialize<List<SelectListItem>>(data);
            model.Categories = new SelectList(categories, "Value", "Text");
        }
        if (ModelState.IsValid)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonSerializer.Serialize(model);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5106/api/product/create", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                ModelState.AddModelError("", "Happened Error");
            }
        }
        return View(model);
    }

    public async Task<IActionResult> Update(int id)
    {
        var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
        if (token != null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var responseProduct = await client.GetAsync($"http://localhost:5106/api/product/get/{id}");

            if (responseProduct.IsSuccessStatusCode)
            {
                var jsonData = await responseProduct.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<UpdateProductModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                var responseCategory = await client.GetAsync("http://localhost:5106/api/category/list");

                if (responseCategory.IsSuccessStatusCode)
                {
                    var jsonCategoryData = await responseCategory.Content.ReadAsStringAsync();

                    var data = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonCategoryData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    if (result != null)
                        result.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(data, "Id", "Defination");
                }
                return View(result);
            }
        }
        return RedirectToAction("List");
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductModel model)
    {
        var data = TempData["Categories"]?.ToString();
        if (data != null)
        {
            var categories = JsonSerializer.Deserialize<List<SelectListItem>>(data);
            model.Categories = new SelectList(categories, "Value", "Text", model.CategoryId);
        }


        if (ModelState.IsValid)
        {

            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonSerializer.Serialize(model);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await client.PutAsync("http://localhost:5106/api/product/update", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                ModelState.AddModelError("", "Error Happened");
            }

        }
        return View(model);
    }


}