import { Component, OnInit, Input, forwardRef, Inject, OnChanges} from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import {Company} from '../../interfaces/company';
import {CompanyService} from '../../services/company.service';

@Component({
  selector: 'app-new-company',
  templateUrl: './new-company.component.html',
  styleUrls: ['./new-company.component.css']
})
export class NewCompanyComponent implements OnInit, OnChanges {
  newCompany:Company = {
    businessType: '',
    city: '',
    companyName: '',
    confirmedVersionDate: new Date(),
    contacted: false,
    country: '',
    endEnterpriseSupport: new Date(),
    notes: '',
    previousVersion: 0,
    rankingScale: 0,
    sfVersion: 0,
    sitefinityRetirmentDate: new Date(),
    state_Region: '',
    street: '',
    url: '',
    zipCode: '',
    gtMetrics: null,
    gtMetricsId: null,
    id: 0
  };
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
  }
  ngOnChanges(): void{

  }
  open(content){
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

  addCompany(){
    
    this.newCompany = this.assignCompany(this.newCompany);
    console.log(this.newCompany);
    this.cService.post(this.newCompany).subscribe();
    this.modal.dismissAll();
  }

  assignCompany(updatedCompany:Company):Company{
    console.log(this.companyName);
    if(this.companyName) updatedCompany.companyName = this.companyName;
    console.log(this.companyName);
    console.log(updatedCompany);
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
