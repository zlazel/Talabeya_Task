import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateTicket } from '../view-models/CreateTicket';
import { PaginatedListOfTicketBriefDto } from '../view-models/PaginatedListOfTicketBriefDto';

import { WebApiService } from './web-api.service';

@Injectable({
  providedIn: 'root',
})
export class TicketService {
  api = 'tickets';
  constructor(private webApiService: WebApiService) {}
  getTickets(
    pageNumber: Number,
    pageSize: Number
  ): Observable<PaginatedListOfTicketBriefDto> {
    if (pageNumber == 0) {
      pageNumber = 1;
    }
    if (pageSize == 0) {
      pageSize = 5;
    }
    let url = `${this.api}?PageNumber=${pageNumber}&PageSize=${pageSize}`;
    return this.webApiService.get(url);
  }
  createTicket(createTicket: CreateTicket): Observable<number> {
    return this.webApiService.post(this.api, createTicket);
  }
  handleTicket(id: Number): Observable<number> {
    return this.webApiService.put(this.api, {id: id});
  }
}
