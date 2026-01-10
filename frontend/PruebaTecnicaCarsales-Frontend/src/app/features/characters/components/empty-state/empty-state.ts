import { Component, input } from '@angular/core';

@Component({
  selector: 'app-empty-state',
  standalone: true,
  templateUrl: './empty-state.html',
  styleUrl: './empty-state.css',
})
export class EmptyState {
  readonly title = input('No se encontraron personajes');
  readonly subtitle = input('Prueba con otro nombre o limpia el filtro.');
}
