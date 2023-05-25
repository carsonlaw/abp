import { Component, OnInit } from '@angular/core';
import { FreeERPService } from '../services/free-eRP.service';

@Component({
  selector: 'lib-free-eRP',
  template: ` <p>free-eRP works!</p> `,
  styles: [],
})
export class FreeERPComponent implements OnInit {
  constructor(private service: FreeERPService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
