using Microsoft.AspNetCore.Mvc;
using WalkerAdvertisingLead.Server.BLL;
using WalkerAdvertisingLead.Server.Models;

namespace WalkerAdvertisingLead.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : Controller
    {
        private readonly LeadManagement _leadManagement;
        private readonly ILogger<LeadsController> _logger;

        // Inject dependances into the constructor
        public LeadsController(LeadManagement leadManagement, ILogger<LeadsController> logger)
        {
            _leadManagement = leadManagement;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllLeads()
        {
            var leads = _leadManagement.GetAllLeads();
            return Ok(leads);
        }

        [HttpGet("{id}")]
        public IActionResult GetLeadById(Guid id)
        {
            var lead = _leadManagement.GetLeadbyId(id);
            if (lead == null)
            {
                return BadRequest();
            }

            return Ok(lead);
        }

        [HttpPost]
        public IActionResult CreateLead([FromBody] Lead lead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // return validation errors
            }

            var createdLead = _leadManagement.AddLead(lead);

            // log when lead is created
            _logger.LogInformation("Lead created successfully: {LeadId}", createdLead.Id);

            // handle email notification
            SendEmail(createdLead);

            //handle text notification
            SendText(createdLead);

            return CreatedAtAction(nameof(GetLeadById), new { id = createdLead.Id }, createdLead);
        }


        private void SendEmail(Lead lead)
        {
            if (lead.HasEmailPermission)
            {
                if (string.IsNullOrWhiteSpace(lead.Email))
                {
                    _logger.LogWarning("Email permission granted, but no email address provided. Skipping email notification.");
                }
                else
                {
                    _logger.LogInformation($"Email has been sent to: {lead.Email}");
                }
            }
            else
            {
                _logger.LogWarning("Email notification skipped due to lack of email permission.");
            }

        }

        private void SendText(Lead lead)
        {
            if (lead.HasTextPermission)
            {
                _logger.LogInformation($"Text message notification has been sent to: {lead.PhoneNumber}");
            }
            else
            {
                _logger.LogWarning("Text message notification skipped due to lack of text permission.");
            }
        }
    }
}
