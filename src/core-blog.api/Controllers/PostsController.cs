﻿using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Business.Services;
using System.Collections.Generic;

namespace core_blog.api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [AcceptVerbs("OPTIONS")]
        public IActionResult Options()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            return new StatusCodeResult(200);
        }

        [HttpGet]
        [Produces(typeof(List<Dto.Post>))]
        public IActionResult Get()
        {
            var posts = _postService.GetAll().ToArray();
            var dtos = _mapper.Map<Domain.Post[], Dto.Post[]>(posts);
            return new OkObjectResult(dtos);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            _postService.DeleteAll();
            return new NoContentResult();
        }

        [HttpGet("featured")]
        public IActionResult GetFeatured()
        {
            var featuredPosts = _postService.GetFeatured();
            return new OkObjectResult(featuredPosts);
        }
    }
}
