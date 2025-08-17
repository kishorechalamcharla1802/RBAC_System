import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { MaterialDependenciesModule } from '../../../material-dependencies/material-dependencies.module';
import { DataService } from '../../data.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule, MaterialDependenciesModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  username = '';
  password = '';
  role = '';
  payload: User = {} as User;
  showRegister: boolean = false;
  roles: string[] = ['Admin', 'Editor', 'Viewer'];

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

  register() {
    this.payload.username = this.username;
    this.payload.password = this.password;
    this.payload.role = this.role;
    this.http
      .post<User>('https://localhost:7148/api/UserRoles/AddUser', this.payload)
      .subscribe({
        next: (res) => {
          this.showRegister = false;
          this.username = '';
          this.password = '';
          this.role = '';
          alert('User registered successfully');
        },
        error: (err) => {
          alert('Register failed');
        },
      });
  }
}
