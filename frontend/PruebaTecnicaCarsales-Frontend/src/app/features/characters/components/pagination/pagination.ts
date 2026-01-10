import { Component, input, output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  standalone: true,
  templateUrl: './pagination.html',
  styleUrl: './pagination.css',
})
export class Pagination {
  readonly page = input.required<number>();
  readonly pages = input.required<number>();

  readonly canPrev = input<boolean>(true);
  readonly canNext = input<boolean>(true);

  readonly prev = output<void>();
  readonly next = output<void>();

  onPrev() {
    if (!this.canPrev()) return;
    this.prev.emit();
  }

  onNext() {
    if (!this.canNext()) return;
    this.next.emit();
  }
}
