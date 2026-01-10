import { Component } from '@angular/core';
import { HomePage } from './features/home/pages/home-page';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HomePage],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {}
