import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from '../../data.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  username = '';
  password = '';

  constructor(
    private http: HttpClient,
    private router: Router,
    private dataService: DataService
  ) {}

  ngOnInit(): void {
    if (this.dataService.isLoggedIn()) {
      this.dataService.setUserInfo({} as User);
      localStorage.removeItem('token');
      localStorage.removeItem('user');
    }
  }

  login() {
    this.http
      .post<any>('https://localhost:7148/api/Login/LoginUser', {
        Username: this.username,
        Password: this.password,
      })
      .subscribe({
        next: (res) => {
          localStorage.setItem('user', JSON.stringify(res.userData));
          this.dataService.setUserInfo(res.userData);
          localStorage.setItem('token', res.token);
          this.router.navigate(['/dashboard']);
        },
        error: (err) => {
          alert(err.error.message || 'Login failed');
        },
      });
  }
}
