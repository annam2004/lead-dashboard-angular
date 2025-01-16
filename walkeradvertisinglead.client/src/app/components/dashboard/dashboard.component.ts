import { Component, OnInit } from '@angular/core';
import { Lead } from '../../models/lead';
import { LeadService } from '../../services/lead.service';
import { ExportService } from '../../services/export';


@Component({
  selector: 'app-dashboard',
  standalone: false, 
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})


export class DashboardComponent implements OnInit {
  leads: Lead[] = [];

  constructor(private leadService: LeadService, private exportService: ExportService) { } // Inject LeadService here

  ngOnInit(): void {
    this.loadLeads(); // Fetch the data when the component initializes
  }



  loadLeads(): void {
    this.leadService.getLeads().subscribe(
      (data) => {
        console.log('Leads data:', data);   // This logs the data returned from the API
        this.leads = data;  // This logs the data returned from the API
      },
      (error) => {
        console.error('Error fetching leads:', error);
      }
    );
  }


  exportToExcel(): void {
    this.exportService.exportToExcel(this.leads, 'leads_data.xlsx');
  }

}
