﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using ExtremePC.Courses.Definition.Services;
using ExtremePC.Courses.WebApi.WebModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExtremePC.Courses.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly ISignupService _signupService;
        private readonly ILogger<SignupController> _logger;

        public SignupController(ISignupService signupService, ILogger<SignupController> logger)
        {
            _signupService = signupService;
            _logger = logger;
        }

        [HttpPost("{courseId:long}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Text.Plain)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostSignup([FromRoute] long courseId, [FromBody] StudentSignUpWebModel student)
        {
            // validate request, use fluent validation or something
            //var result = await _signupService.SignupStudentToCourseAsync();
            bool result = false;
            if (result)
            {
                return Ok();
            }
            else
            {
                return Forbid();
            }
        }
        // think about versioning the controller
        [HttpPost("{courseId:long}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Text.Plain)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostSignupAsync([FromRoute] long courseId, [FromBody] StudentSignUpWebModel student)
        {
            // validate request, use fluent validation or something
            //var result = await _signupService.SendSignupStudentMessageAsync();
            bool result = false;
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}