import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DetailComponent } from './components/detail/detail.component';
import { NewCompanyComponent } from './components/new-company/new-company.component';
import { TableComponent } from './components/table/table.component';
import { UpdateCompanyComponent } from './components/update-company/update-company.component';

import { MatTableModule} from '@angular/material/table';
import { CompanyService } from './services/company.service';
import{HttpClientModule} from '@angular/common/http';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { EditModalComponent } from './components/edit-modal/edit-modal.component';
import {FormsModule} from '@angular/forms';
import {MatCardModule} from '@angular/material/card';

@NgModule({
  declarations: [
    AppComponent,
    DetailComponent,
    NewCompanyComponent,
    TableComponent,
    UpdateCompanyComponent,
    EditModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    MatCardModule
  ],
  providers: [CompanyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
