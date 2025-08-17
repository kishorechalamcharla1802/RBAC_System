import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { DataService } from '../../../core/data.service';
import { MaterialDependenciesModule } from '../../../material-dependencies/material-dependencies.module';
import { StepInfo } from '../../Models/step-info.model';

@Component({
  selector: 'app-content',
  standalone: true,
  imports: [MaterialDependenciesModule, FormsModule, CommonModule],
  templateUrl: './content.component.html',
  styleUrl: './content.component.css',
})
export class ContentComponent {
  dataSource = new MatTableDataSource<StepInfo>([]);
  displayedColumns: string[] = ['stepNo', 'description', 'command', 'actions'];
  canEdit: boolean = false;

  constructor(private http: HttpClient, private dataService: DataService) {}

  ngOnInit(): void {
    this.dataService.userInfo$.subscribe((user) => {
      if (user && user.role) {
        if (user.role === 'Admin' || user.role === 'Editor') {
          this.canEdit = true;
        } else {
          this.canEdit = false;
          this.displayedColumns = this.displayedColumns.filter(
            (col) => col !== 'actions'
          );
        }
        this.getSetupSteps();
      }
    });
  }

  getSetupSteps() {
    this.http
      .get<any>('https://localhost:7148/api/SetupSteps/GetSetupSteps')
      .subscribe({
        next: (res: StepInfo[]) => {
          this.dataSource.data = res.map((s) => ({
            id: s.stepNo,
            ...s,
            editing: false,
          }));
        },
        error: (err) => {
          alert('Login failed');
        },
      });
  }

  addSetupStep() {
    const newStep: any = {
      id: null,
      stepNo: this.dataSource.data.length + 1,
      description: '',
      command: '',
      editing: true,
    };
    this.dataSource.data.push(newStep);
    this.dataSource._updateChangeSubscription();
  }

  insertSetupStep(element: any) {
    const payload = { ...element };
    delete payload.id;
    delete payload.editing;
    this.http
      .post<any>('https://localhost:7148/api/SetupSteps/AddStep', payload)
      .subscribe({
        next: (res) => {
          element.editing = false;
          this.getSetupSteps();
        },
        error: (err) => {
          console.log(err);

          alert('Update failed');
        },
      });
  }

  editSetupStep(element: any) {
    element.editing = true;
  }

  updateSetupStep(element: any) {
    const payload = { ...element };
    if (!payload.id) {
      this.insertSetupStep(element);
    } else {
      delete payload.id;
      delete payload.editing;
      this.http
        .put<any>('https://localhost:7148/api/SetupSteps/UpdateStep', payload)
        .subscribe({
          next: (res) => {
            element.editing = false;
            this.getSetupSteps();
          },
          error: (err) => {
            console.log(err);

            alert('Update failed');
          },
        });
    }
  }

  cancelEdit(element: any) {
    if (element.id) {
      element.editing = false;
    } else {
      this.dataSource.data = this.dataSource.data.filter(
        (row) => row !== element
      );
    }
    this.dataSource._updateChangeSubscription(); // refresh table
  }

  deleteSetupStep(element: any) {
    this.http
      .delete<any>(
        `https://localhost:7148/api/SetupSteps/DeleteSetupStep/${element.id}`
      )
      .subscribe({
        next: (res) => {
          this.getSetupSteps();
        },
        error: (err) => {
          alert('Delete failed');
        },
      });
  }
}
