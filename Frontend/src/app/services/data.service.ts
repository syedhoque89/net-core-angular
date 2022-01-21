import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class DataService {

  items: Object | undefined;

  constructor(private httpClient: HttpClient) {
  }

  getData() {
    return this.httpClient.get('http://localhost:5000/api/Product');
  }
}
