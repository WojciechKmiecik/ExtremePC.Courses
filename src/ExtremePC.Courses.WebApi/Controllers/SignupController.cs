﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using ExtremePC.Courses.Definition.Messaging;
using ExtremePC.Courses.Definition.Services;
using ExtremePC.Courses.WebApi.Mappers;
using ExtremePC.Courses.WebApi.WebModels;
using ExtremePC.Courses.Shared.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExtremePC.Courses.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    public class SignupController : ControllerBase
    {
        private readonly ISignupService _signupService;
        private readonly ISignupProducer _signupProducer;
        private readonly ILogger<SignupController> _logger;

        public SignupController(ISignupService signupService, ISignupProducer signupProducer, ILogger<SignupController> logger)
        {
            _signupService = signupService;
            _signupProducer = signupProducer;
            _logger = logger;
        }

        [HttpPost("{courseId:long}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Text.Plain)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostSignup([FromRoute] long courseId, [FromBody] StudentSignUpWebModel student)
        {
            // validate request, use fluent validation or something

            var result = await _signupService.SignupStudentToCourseAsync(student.Map(courseId));
            
            if (result.Item1)
            {
                return Ok(result.Item2);
            }
            else
            {
                return StatusCode(StatusCodes.Status403Forbidden, result.Item2);
            }
        }
        // think about versioning the controller
        [HttpPost("PostAsync/{courseId:long}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Text.Plain)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostSignupAsync([FromRoute] long courseId, [FromBody] StudentSignUpWebModel student)
        {
            // validate request, use fluent validation or something
            var model = student.Map().Map();
            var result = await _signupProducer.SendRequest(model);
            if (result)
            {
                return Ok(model.Guid);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}