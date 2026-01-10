import { Component, signal } from '@angular/core';
import { CharactersPage } from '../../characters/pages/characters-page';
import { EpisodesPage } from '../../episodes/pages/episodes-page';

type HomeTab = 'characters' | 'episodes';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [CharactersPage, EpisodesPage],
  templateUrl: 'home-page.html',
  styleUrl: 'home-page.css',
})
export class HomePage {
  readonly activeTab = signal<HomeTab>('characters');

  setTab(tab: HomeTab): void {
    this.activeTab.set(tab);
  }
}
