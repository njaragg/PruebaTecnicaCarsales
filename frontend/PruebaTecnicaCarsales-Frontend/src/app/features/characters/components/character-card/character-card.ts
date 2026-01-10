import { Component, input } from '@angular/core';
import { Character } from '../../../../shared/models/character.model';

@Component({
  selector: 'app-character-card',
  standalone: true,
  templateUrl: './character-card.html',
  styleUrl: './character-card.css',
})
export class CharacterCard {
  readonly character = input.required<Character>();
}
