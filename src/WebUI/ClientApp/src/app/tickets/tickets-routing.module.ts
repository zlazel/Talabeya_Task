import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddTicketComponent } from './add-ticket/add-ticket.component';
import { TicketsComponent } from './tickets.component';

const routes: Routes = [
  { path: '', component: TicketsComponent },
  { path: 'add-ticket', component: AddTicketComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TicketsRoutingModule {}
