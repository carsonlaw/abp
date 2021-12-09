import { Component, OnInit } from '@angular/core';
import { HDShopService } from '../services/h-dShop.service';

@Component({
  selector: 'lib-h-dShop',
  template: ` <p>h-dShop works!</p> `,
  styles: [],
})
export class HDShopComponent implements OnInit {
  constructor(private service: HDShopService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
