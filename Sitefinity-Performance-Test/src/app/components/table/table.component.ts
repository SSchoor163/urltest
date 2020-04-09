import { Component, OnInit, Input } from '@angular/core';
import {Company} from '../../interfaces/company';
import {CompanyService} from '../../services/company.service';
import {GtMetricsService} from '../../services/gt-metrics.service';
import {MatTableDataSource} from '@angular/material/table';
import {ActivatedRoute, ParamMap, Router} from '@angular/router'
import { GtMetrics } from 'src/app/interfaces/gt-metrics';
import { GtMetricsPost } from 'src/app/interfaces/gt-metrics-post';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {ResetService} from '../../services/reset.service'

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  constructor(private cService:CompanyService, private router:Router, private gtService:GtMetricsService, private modal:NgbModal, private resetService:ResetService) { }
 test:Company[];
 displayedColumns: string[] = ['name', 'address', 'business', 'contacted', 'speedScore', 'yslowScore', 'genReport', 'edit', 'delete'];
 dataSource = new MatTableDataSource<Company>();
reset:boolean
  ngOnInit(): void {
    this.cService.getAll().subscribe((data:Company[])=>{
      this.test = data;
      this.dataSource = new MatTableDataSource<Company>(data);
    });
    
  }

  onSelect(company:Company){
    this.router.navigate(["/company", company.id]);
  }
  onGen(company:Company){
    let post:GtMetricsPost =  {
      companyId: company.id,
      url: company.url
    }
    this.gtService.post(post).subscribe();
  }
  onEdit(company:Company){
    this.router.navigate(["/edit", company.id]);
  }
  onDelete(company:Company){
    this.cService.delete(company.id).subscribe();
    
    
    this.resetService.resetView();
    
    
  }

  

}
