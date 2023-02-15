﻿using LearningResourcesApi.Adapters;
using LearningResourcesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningResourcesApi.Controllers;

public class ResourcesController : ControllerBase
{
    private readonly LearningResourcesDataContext _context;

    public ResourcesController(LearningResourcesDataContext context)
    {
        _context = context;
    }

    [HttpGet("/resources")]
    public async Task<ActionResult> GetResources()
    {
        var items = await _context.Items
            .Select(item => new GetResourceItem
            {
                Id = item.Id.ToString(),
                Description = item.Description,
                Link = item.Link,
                Type = item.Type
            }).ToListAsync();

        var response = new GetResourcesResponse { Items = items };
        return Ok(response);
    }
}