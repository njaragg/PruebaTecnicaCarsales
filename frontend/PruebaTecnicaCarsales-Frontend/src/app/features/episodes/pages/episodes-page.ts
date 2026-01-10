import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { finalize } from 'rxjs/operators';

import { Episode } from '../../../shared/models/episode.model';
import { EpisodesApiService } from '../services/episodes-api.service';

@Component({
  selector: 'app-episodes-page',
  standalone: true,
  templateUrl: './episodes-page.html',
  styleUrl: './episodes-page.css',
})
export class EpisodesPage implements OnInit {
  private readonly api = inject(EpisodesApiService);

  readonly isLoading = signal(false);
  readonly errorMessage = signal<string | null>(null);

  readonly page = signal(1);
  readonly pages = signal(1);
  readonly episodes = signal<Episode[]>([]);

  readonly canPrev = computed(() => this.page() > 1);
  readonly canNext = computed(() => this.page() < this.pages());

  ngOnInit(): void {
    this.load();
  }

  private load(): void {
    this.errorMessage.set(null);
    this.isLoading.set(true);

    this.api
      .getEpisodes(this.page())
      .pipe(finalize(() => this.isLoading.set(false)))
      .subscribe({
        next: (res) => {
          this.pages.set(res.pages);
          this.episodes.set(res.results);
        },
        error: () => {
          this.errorMessage.set('Error cargando episodios. Reintenta.');
          this.episodes.set([]);
        },
      });
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
}
