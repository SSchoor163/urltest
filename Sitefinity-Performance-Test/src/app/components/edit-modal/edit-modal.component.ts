import { Component, OnInit, Input, forwardRef, Inject, OnChanges} from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import {Company} from '../../interfaces/company';
import {CompanyService} from '../../services/company.service';
import {GtMetricsService} from '../../services/gt-metrics.service';

@Component({
  selector: 'app-edit-modal',
  templateUrl: './edit-modal.component.html',
  styleUrls: ['./edit-modal.component.css']
})
export class EditModalComponent implements OnInit, OnChanges{
  @Input() company;
  companyName:string;
  closeResult:string;
  businessType:string;
  city:string;
  confirmedVersionDate:Date;
  contacted:boolean;
  country:string;
  endEnterpriseSupport:Date;
  notes:string;
  previousVersion:number;
  rankingScale:number;
  sfVersion:number;
  sitefinityRetirmentDate:Date;
  state_Region:string;
  street:string;
  url:string;
  zipCode:string;
  constructor(@Inject(forwardRef(() => NgbModal)) private modal: NgbModal, private cService:CompanyService) { }

  ngOnInit(): void {
    this.contacted = this.company.contacted;
    this.confirmedVersionDate = this.company.confirmedVersionDate;
    this.endEnterpriseSupport = this.company.endEnterpriseSupport;
    this.sitefinityRetirmentDate = this.company.sitefinityRetirmentDate;
    
  }

  ngOnChanges(){
    
  }

  open(content){
    this.contacted = this.company.contacted;
    this.modal.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then(
      (result)=>{
        this.closeResult = `Closed with: ${result}`
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    
  }
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }
  editCompany(){
    let updatedCompany:Company = {
      id:this.company.id,
      businessType:this.company.businessType,
      city: this.company.city,
      companyName:this.company.companyName,
      confirmedVersionDate:this.company.confirmedVersionDate,
      contacted:this.company.contacted,
      country:this.company.country,
      endEnterpriseSupport:this.company.endEnterpriseSupport,
      gtMetrics:this.company.gtMetrics,
      gtMetricsId:this.company.gtMetricsId,
      notes:this.company.notes,
      previousVersion:this.company.previousVersion,
      rankingScale:this.company.rankingScale,
      sfVersion:this.company.sfVersion,
      sitefinityRetirmentDate:this.company.sitefinityRetirmentDate,
      state_Region:this.company.state_Region,
      street:this.company.street,
      url:this.company.url,
      zipCode:this.company.zipCode
    };
    updatedCompany = this.assignCompany(updatedCompany);
    console.log(updatedCompany.companyName);
    this.cService.update(updatedCompany, this.company.id).subscribe();
    this.modal.dismissAll();
  }

  assignCompany(updatedCompany:Company):Company{
    if(this.companyName) updatedCompany.companyName = this.companyName;
    if(this.businessType) updatedCompany.businessType = this.businessType;
    if(this.city) updatedCompany.city = this.city;
    if(this.confirmedVersionDate) updatedCompany.confirmedVersionDate = this.confirmedVersionDate;
    if(this.contacted) updatedCompany.contacted = this.contacted;
    if(this.country) updatedCompany.country = this.country;
    if(this.endEnterpriseSupport) updatedCompany.endEnterpriseSupport = this.endEnterpriseSupport;
    if(this.notes) updatedCompany.notes = this.notes;
    if(this.previousVersion) updatedCompany.previousVersion = this.previousVersion;
    if(this.rankingScale) updatedCompany.rankingScale = this.rankingScale;
    if(this.sfVersion) updatedCompany.sfVersion = this.sfVersion;
    if(this.sitefinityRetirmentDate) updatedCompany.sitefinityRetirmentDate = this.sitefinityRetirmentDate;
    if(this.state_Region) updatedCompany.state_Region = this.state_Region;
    if(this.street) updatedCompany.street = this.street;
    if(this.url) updatedCompany.url = this.url;
    if(this.zipCode) updatedCompany.zipCode = this.zipCode;
    return updatedCompany;
  }
}
