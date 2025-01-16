using System.Collections.Concurrent;
using WalkerAdvertisingLead.Server.Models;

namespace WalkerAdvertisingLead.Server.BLL
{
    public class LeadManagement
    {
        private readonly ConcurrentDictionary<string, Lead> _leads = new();
        public IEnumerable<Lead> GetAllLeads()
        {
            return _leads.Values;
        }
        public Lead? GetLeadbyId(Guid id)
        {
            return _leads.TryGetValue(id.ToString(), out var lead) ? lead : null;
        }

        public Lead AddLead(Lead lead)
        {
            lead.Id = Guid.NewGuid(); // Get a new unique ID
            _leads[lead.Id.ToString()] = lead;
            return lead;
        }
    }
}
