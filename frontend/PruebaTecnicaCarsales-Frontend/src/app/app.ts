import { Component } from '@angular/core';
import { CharactersPage } from './features/characters/pages/characters-page';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CharactersPage],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {}
