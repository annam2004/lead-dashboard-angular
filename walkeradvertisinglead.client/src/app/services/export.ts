import { Injectable } from '@angular/core';
import * as ExcelJS from 'exceljs';

@Injectable({
  providedIn: 'root'
})
export class ExportService {

  constructor() { }

  exportToExcel(data: any[], fileName: string): void {
    const workbook = new ExcelJS.Workbook();
    const worksheet = workbook.addWorksheet('Leads');

    // Define columns for the sheet
    worksheet.columns = [
      { header: 'Name', key: 'name', width: 20 },
      { header: 'Phone Number', key: 'phoneNumber', width: 15 },
      { header: 'Email', key: 'email', width: 25 },
      { header: 'Zip Code', key: 'zipCode', width: 10 },
      { header: 'Email Permission', key: 'hasEmailPermission', width: 20 },
      { header: 'Text Permission', key: 'hasTextPermission', width: 20 }
    ];

    // Add rows based on data
    data.forEach(lead => {
      worksheet.addRow(lead);
    });

    // Write the file and trigger download
    workbook.xlsx.writeBuffer().then((buffer) => {
      const blob = new Blob([buffer], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      const link = document.createElement('a');
      link.href = URL.createObjectURL(blob);
      link.download = fileName;
      link.click();
    });
  }
}
