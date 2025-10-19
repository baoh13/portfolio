//using BlazorApp.Interfaces;
//using BlazorApp.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

namespace BlazorApp.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class ContactController(IEmailService emailService, ILogger<ContactController> logger) : ControllerBase
//{
//    private readonly IEmailService _emailService = emailService;
//    private readonly ILogger<ContactController> _logger = logger;

//    [HttpPost]
//    public async Task<IActionResult> SubmitContact([FromBody] ContactRequest? contactRequest)
//    {
//        if (!ModelState.IsValid)
//        {
//            var errors = GetModelErrors();
//            _logger.LogWarning(
//                "Invalid contact form submission from {Email}: {Errors}",
//                contactRequest?.Email ?? "unknown",
//                string.Join(", ", errors));

//            return BadRequest(new { success = false, errors });
//        }

//        ArgumentNullException.ThrowIfNull(contactRequest);

//        contactRequest.SubmittedAt = DateTime.UtcNow;

//        try
//        {
//            var success = await _emailService.SendContactEmailAsync(contactRequest);

//            if (success)
//            {
//                _logger.LogInformation(
//                    "Contact form processed successfully for {Name} ({Email})",
//                    contactRequest.Name,
//                    contactRequest.Email);

//                return Ok(new { success = true, message = "Contact form submitted successfully" });
//            }

//            _logger.LogError(
//                "Failed to process contact form for {Name} ({Email})",
//                contactRequest.Name,
//                contactRequest.Email);

//            return StatusCode(500, new { success = false, message = "Failed to process contact form" });
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(
//                ex,
//                "Exception occurred while processing contact form for {Name} ({Email})",
//                contactRequest.Name,
//                contactRequest.Email);

//            return StatusCode(500, new { success = false, message = "An error occurred while processing your request" });
//        }
//    }

//    private List<string> GetModelErrors()
//    {
//        return ModelState.Values
//            .SelectMany(value => value.Errors)
//            .Select(error => string.IsNullOrWhiteSpace(error.ErrorMessage) ? "Invalid input." : error.ErrorMessage)
//            .ToList();
//    }
//}
