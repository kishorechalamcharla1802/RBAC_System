import { Component, OnDestroy, OnInit } from '@angular/core';
import { MaterialDependenciesModule } from '../../../material-dependencies/material-dependencies.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { Router, RouterModule } from '@angular/router';

import { User } from '../../models/user.model';
import { CommonModule } from '@angular/common';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MaterialDependenciesModule,
    FlexLayoutModule,
    CommonModule,
    RouterModule,
  ], // Add any necessary Angular Material modules here
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent implements OnInit {
  showDetails = false;
  userData: User | null = null;

  constructor(private router: Router, private dataService: DataService) {}

  ngOnInit(): void {
    this.dataService.userInfo$.subscribe((user: User) => {
      if (user && user.role) {
        this.userData = user;
        this.showDetails = true;
      } else {
        this.showDetails = false;
        this.userData = null;
      }
    });
  }

  gotoDashboard() {
    this.router.navigate(['/dashboard']);
  }

  logout() {
    this.showDetails = false;
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.router.navigate(['/login']);
  }
}
