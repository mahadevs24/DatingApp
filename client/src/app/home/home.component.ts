import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  registerMode = false;
  users: any;

  regiterToggle() {
    this.registerMode = !this.registerMode;
  }
  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: (respose) => (this.users = respose),
      error: (error) => console.log(error),
      complete: () => console.log('completed'),
    });
  }
  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }
}
