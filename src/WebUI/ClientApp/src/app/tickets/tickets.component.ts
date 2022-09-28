import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import * as moment from 'moment';
import { __values } from 'tslib';
import { TicketService } from '../services/ticket.service';
import { TicketBriefDto } from '../view-models/TicketBriefDto';
import { PaginatedListOfTicketBriefDto } from '../view-models/PaginatedListOfTicketBriefDto';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.scss'],
})
export class TicketsComponent implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns: string[] = [
    'id',
    'phone',
    'district',
    'city',
    'goverenorate',
    'isHandeled',
    'created',
    'statusColor',
  ];
  dataSource = new MatTableDataSource<TicketBriefDto>([]);
  pageEvent?: PageEvent;
  tickets: TicketBriefDto[];

  constructor(private ticketService: TicketService) {
    this.pageEvent = {
      length: 0,
      pageIndex: 1,
      pageSize: 5,
    };
  }
  ngOnInit() {
    this.getTickets(this.pageEvent.pageIndex, this.pageEvent.pageSize);
  }
  private getTickets(pageNumber: number, pageSize: number) {
    this.ticketService.getTickets(pageNumber, pageSize).subscribe({
      next: (data) => {
        this.tickets = data.items;

        this.dataSource.data = this.tickets;
        this.setPaginatorData(data);
      },
      error: (err) => {
        alert(err);
      },
    });
  }
  setPaginatorData(data: PaginatedListOfTicketBriefDto) {
    if (data && this.pageEvent) {
      this.pageEvent.pageIndex = data.pageNumber;
      this.pageEvent.length = data.totalCount;
    } else {
      this.pageEvent = undefined;
    }
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    setInterval(() => {
      this.dataSource.data = this.tickets;
    }, 3000);
  }

  changePage(pageEvent: PageEvent | undefined) {
    this.pageEvent = pageEvent;
    if (pageEvent) {
      this.getTickets(this.pageEvent.pageIndex, this.pageEvent.pageSize);
    }
  }
  getDateFromNow(ticket: TicketBriefDto): string {
    let _date = moment(ticket.created);
    let minutes: number = moment().diff(_date, 'minutes');
    ticket.color = getColorbasedOnMinutes(minutes);
    return _date.fromNow();
  }
  handleTicket(id: number) {
    if (!id) {
      return;
    }
    this.ticketService.handleTicket(id).subscribe({
      next: (res) => {
        this.getTickets(this.pageEvent.pageIndex, this.pageEvent.pageSize);
      },
      error: (err) => {
        alert(err);
      },
    });
  }
}
function getColorbasedOnMinutes(minutes: number): string {
  let color: string;
  if (minutes >= 60) {
    // Red if it was created 60 minutes ago
    color = 'red';
  } else if (minutes >= 45) {
    color = 'blue';
    // Blue if it was created 45 minutes ago
  } else if (minutes >= 30) {
    // Green if it was created 30 minutes ago
    color = 'green';
  } else if (minutes >= 15) {
    // yellow if it was created 15 minutes ago
    color = 'yellow';
  } else {
    color = 'gray';
  }
  return color;
}
