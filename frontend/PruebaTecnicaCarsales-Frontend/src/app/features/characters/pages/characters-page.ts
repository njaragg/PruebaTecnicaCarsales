import { Component, computed, signal, inject, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';

import { Character } from '../../../shared/models/character.model';
import { CharactersGrid } from '../components/characters-grid/characters-grid';
import { CharactersSearch } from '../components/characters-search/characters-search';
import { Pagination } from '../components/pagination/pagination';
import { EmptyState } from '../components/empty-state/empty-state';
import { SkeletonGrid } from '../components/skeleton-grid/skeleton-grid';

import { CharactersApiService } from '../services/characters-api.service';

@Component({
  selector: 'app-characters-page',
  standalone: true,
  imports: [CharactersGrid, CharactersSearch, Pagination, EmptyState, SkeletonGrid],
  templateUrl: './characters-page.html',
  styleUrl: './characters-page.css',
})
export class CharactersPage implements OnInit {
  private readonly api = inject(CharactersApiService);

  // ---- UI state
  readonly isLoading = signal(false);
  readonly errorMessage = signal<string | null>(null);

  // ---- paginación
  readonly page = signal(1);
  readonly pages = signal(1);

  // ---- búsqueda (se manda al backend)
  readonly searchText = signal('');
  readonly appliedName = signal('');

  // ---- data (viene del backend)
  private readonly allCharacters = signal<Character[]>([]);

  // ---- derived state
  readonly canPrev = computed(() => this.page() > 1);
  readonly canNext = computed(() => this.page() < this.pages());

  readonly filteredCharacters = computed(() => this.allCharacters());

  ngOnInit(): void {
    this.load();
  }

  private load(): void {
    this.errorMessage.set(null);
    this.isLoading.set(true);

    this.api
      .getCharacters(this.page(), this.appliedName())
      .pipe(finalize(() => this.isLoading.set(false)))
      .subscribe({
        next: (res) => {
          this.pages.set(res.pages);
          this.allCharacters.set(res.results);
        },
        error: () => {
          this.errorMessage.set('Error cargando personajes. Reintenta.');
          this.allCharacters.set([]);
        },
      });
  }

  // ---- actions
  onSearch(): void {
    this.appliedName.set(this.searchText().trim());
    this.page.set(1);
    this.load();
  }

  onClear(): void {
    this.searchText.set('');
    this.appliedName.set('');
    this.page.set(1);
    this.load();
  }

  prevPage(): void {
    if (!this.canPrev()) return;
    this.page.set(this.page() - 1);
    this.load();
  }

  nextPage(): void {
    if (!this.canNext()) return;
    this.page.set(this.page() + 1);
    this.load();
  }

  // Helpers (opcional) para simular estados visuales
  simulateLoading(): void {
    this.errorMessage.set(null);
    this.isLoading.set(true);
    setTimeout(() => this.isLoading.set(false), 900);
  }
}