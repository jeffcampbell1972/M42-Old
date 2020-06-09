import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sports',
  templateUrl: './sports.component.html'
})
export class SportsComponent {
  public sports: Sport[];
  public url: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'api/sports';
    http.get<Sport[]>(baseUrl + 'api/sports').subscribe(result => {
      this.sports = result;
    }, error => console.error(error));
  }
}

interface Sport {
  id: number;
  identifier: string;
  name: string;
}


