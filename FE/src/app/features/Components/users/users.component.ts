import { Component, OnInit } from '@angular/core';
import { MaterialDependenciesModule } from '../../../material-dependencies/material-dependencies.module';
import { HttpClient } from '@angular/common/http';
import { User } from '../../../core/models/user.model';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [MaterialDependenciesModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css',
})
export class UsersComponent implements OnInit {
  users: User[] = [];
  displayedColumns: string[] = ['id', 'username', 'role'];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.http
      .get<any>('https://localhost:7148/api/UserRoles/GetUser')
      .subscribe({
        next: (res: User[]) => {
          this.users = res;
        },
        error: (err) => {
          alert('Login failed');
        },
      });
  }
}
