import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
  exports: [
    MatToolbarModule,
    MatButtonModule,
    MatTableModule,
    MatIconModule,
    MatSelectModule,
    MatOptionModule,
    MatFormFieldModule,
  ],
})
export class MaterialDependenciesModule {}
