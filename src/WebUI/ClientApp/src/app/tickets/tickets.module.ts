import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TicketsRoutingModule } from './tickets-routing.module';
import { TicketsComponent } from './tickets.component';
import {MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddTicketComponent } from './add-ticket/add-ticket.component';


@NgModule({
  declarations: [
    TicketsComponent,
    AddTicketComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    TicketsRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class TicketsModule { }
