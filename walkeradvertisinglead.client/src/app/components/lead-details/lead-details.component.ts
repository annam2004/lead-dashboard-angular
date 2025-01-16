import { Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Lead } from '../../models/lead';
import { LeadService } from '../../services/lead.service';

@Component({
  selector: 'app-lead-details',
  standalone: false,
  
  templateUrl: './lead-details.component.html',
  styleUrl: './lead-details.component.css'
})
export class LeadDetailsComponent implements OnInit {
  lead: Lead | null = null;

  constructor(private route: ActivatedRoute, private leadService: LeadService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadLead(id);
    }
  }

  loadLead(id: string): void {
    this.leadService.getLeadById(id).subscribe((data) => {
      this.lead = data;
    });
  }
}
