import { Component, input, output } from '@angular/core';

@Component({
  selector: 'app-characters-search',
  standalone: true,
  templateUrl: './characters-search.html',
  styleUrl: './characters-search.css',
})
export class CharactersSearch {
  // value actual del input (lo maneja el page)
  readonly value = input<string>('');

  // opcional: para deshabilitar al cargar
  readonly disabled = input(false);

  // eventos hacia el padre
  readonly valueChange = output<string>();
  readonly search = output<void>();
  readonly clear = output<void>();

  onInput(ev: Event) {
    const v = (ev.target as HTMLInputElement).value;
    this.valueChange.emit(v);
  }

  onEnter() {
    if (this.disabled()) return;
    this.search.emit();
  }

  onSearchClick() {
    if (this.disabled()) return;
    this.search.emit();
  }

  onClearClick() {
    if (this.disabled()) return;
    this.clear.emit();
  }
}
