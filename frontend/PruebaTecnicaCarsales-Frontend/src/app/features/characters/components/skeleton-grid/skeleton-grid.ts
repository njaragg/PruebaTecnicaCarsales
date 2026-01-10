import { Component, input } from '@angular/core';

@Component({
  selector: 'app-skeleton-grid',
  standalone: true,
  templateUrl: './skeleton-grid.html',
  styleUrl: './skeleton-grid.css',
})
export class SkeletonGrid {
  // cantidad de skeletons a mostrar
  readonly count = input(6);

  // helper para iterar @for
  items(): number[] {
    const n = Math.max(1, this.count());
    return Array.from({ length: n }, (_, i) => i);
  }
}
