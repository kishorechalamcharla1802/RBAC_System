import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  exports: [MatToolbarModule, MatButtonModule, MatTableModule],
})
export class MaterialDependenciesModule {}
