import { Component } from '@angular/core';
import { MaterialDependenciesModule } from '../../../material-dependencies/material-dependencies.module';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [MaterialDependenciesModule],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent {

}
