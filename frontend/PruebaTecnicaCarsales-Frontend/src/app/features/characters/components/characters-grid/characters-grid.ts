import { Component, input } from '@angular/core';
import { Character } from '../../../../shared/models/character.model';
import { CharacterCard } from '../character-card/character-card';


@Component({
  selector: 'app-characters-grid',
  imports: [CharacterCard],
  templateUrl: './characters-grid.html',
  styleUrl: './characters-grid.css',
})
export class CharactersGrid {
  readonly characters = input.required<Character[]>();
}
