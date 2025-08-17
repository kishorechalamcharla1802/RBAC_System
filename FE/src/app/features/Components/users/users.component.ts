import { Component, OnInit } from '@angular/core';
import { MaterialDependenciesModule } from '../../../material-dependencies/material-dependencies.module';
import { HttpClient } from '@angular/common/http';
import { User, UserInfo } from '../../../core/models/user.model';
import { DataService } from '../../../core/data.service';
import { MatTableDataSource } from '@angular/material/table';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [MaterialDependenciesModule, FormsModule, CommonModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css',
})
export class UsersComponent implements OnInit {
  dataSource = new MatTableDataSource<UserInfo>([]);
  displayedColumns: string[] = ['id', 'username', 'role', 'actions'];

  constructor(private http: HttpClient, private dataService: DataService) {}

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.http
      .get<any>('https://localhost:7148/api/UserRoles/GetUser')
      .subscribe({
        next: (res: User[]) => {
          this.dataSource.data = res.map((s) => ({ ...s, editing: false }));
        },
        error: (err) => {
          alert('Login failed');
        },
      });
  }

  editUser(element: any) {
    element.editing = true;
  }

  updateUser(element: any) {
    const payload = { ...element };
    delete payload.editing;
    this.http
      .put<any>('https://localhost:7148/api/UserRoles/UpdateUser', payload)
      .subscribe({
        next: (res) => {
          element.editing = false;
          this.getUsers();
        },
        error: (err) => {
          console.log(err);

          alert('Update failed');
        },
      });
  }
  cancelEdit(element: any) {
    element.editing = false;
    this.getUsers();
  }
  deleteUser(element: any) {
    this.http
      .delete<any>(
        `https://localhost:7148/api/UserRoles/DeleteUser/${element.id}`
      )
      .subscribe({
        next: (res) => {
          this.getUsers();
        },
        error: (err) => {
          alert('Delete failed');
        },
      });
  }
}
