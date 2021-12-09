import { Component, OnInit } from '@angular/core';
import { MatchService } from '../services/match.service';

@Component({
  selector: 'lib-match',
  template: ` <p>match works!</p> `,
  styles: [],
})
export class MatchComponent implements OnInit {
  constructor(private service: MatchService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
