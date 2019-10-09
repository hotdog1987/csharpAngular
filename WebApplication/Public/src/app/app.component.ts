import { Component, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit, OnDestroy {
  private apiSub: Subscription;
  public vm: any = {
    data: []
  };

  constructor(
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.apiSub = this.http.get('/api/TestOne').subscribe(data => this.vm.data = data);
  }

  ngOnDestroy(): void {
    this.apiSub.unsubscribe();
  }
}
