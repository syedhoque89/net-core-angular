import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-lead-products',
  templateUrl: './lead-products.component.html',
  styleUrls: ['./lead-products.component.css']
})
export class LeadProductsComponent implements OnInit {
  @Input() nights: string = '';
  @Input() rounds: string = '';
  @Input() price: string = '';

  constructor() {
  }

  ngOnInit(): void {
  }

}
