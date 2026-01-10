export type CharacterStatus = 'Alive' | 'Dead' | 'unknown';
export type CharacterGender = 'Male' | 'Female' | 'Genderless' | 'unknown';

export interface Character {
  id: number;
  name: string;
  status: CharacterStatus;
  species: string;
  gender: CharacterGender;
  image: string;
}
