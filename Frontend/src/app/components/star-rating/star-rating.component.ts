import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-star-rating',
  templateUrl: './star-rating.component.html',
  styleUrls: ['./star-rating.component.css']
})
export class StarRatingComponent implements OnInit {
  @Input() rating: any = '';

  constructor() {
  }

  ngOnInit(): void {
  }

  numSequence(): Array<number> {
    return Array(this.rating);
  }

}
