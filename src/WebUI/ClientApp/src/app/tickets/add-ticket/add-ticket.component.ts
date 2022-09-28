import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { City } from 'src/app/enums/City';
import { District } from 'src/app/enums/District';
import { Goverenorate } from 'src/app/enums/Goverenorate';
import { TicketService } from 'src/app/services/ticket.service';

@Component({
  selector: 'app-add-ticket',
  templateUrl: './add-ticket.component.html',
  styleUrls: ['./add-ticket.component.scss']
})
export class AddTicketComponent implements OnInit {
  ticketForm: FormGroup;
  districts = ToArray(District);
  cities = ToArray(City);
  goverenorates = ToArray(Goverenorate);
  constructor(private ticketService: TicketService,
    private router: Router) {

    this.ticketForm = new FormGroup({
      phone: new FormControl('', Validators.required),
      district: new FormControl(0, Validators.required),
      city: new FormControl(0, Validators.required),
      goverenorate: new FormControl(0, Validators.required),
    });
   }

  ngOnInit(): void {
  }

  addTicket() {
    if (this.ticketForm.invalid) {
      alert('fill all form data please');
      return;
    }
    this.ticketService.createTicket(this.ticketForm.value).subscribe({
      next: (res) => {
        alert('ticket added');
        this.router.navigateByUrl('/')
        },
      error: (err) => {
        alert(err);
      },
    });
  }
}

const StringIsNumber = (value) => isNaN(Number(value)) === false;

function ToArray(enumme) {
  return Object.keys(enumme)
    .filter(StringIsNumber)
    .map((key) => enumme[key]);
}
