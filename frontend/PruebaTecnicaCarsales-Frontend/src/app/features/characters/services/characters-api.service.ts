import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { API_BASE_URL } from '../../../shared/tokens/api-base-url.token';
import { PagedResponse } from '../../../shared/models/paged-response.model';
import { Character } from '../../../shared/models/character.model';

@Injectable({ providedIn: 'root' })
export class CharactersApiService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = inject(API_BASE_URL);

  getCharacters(page: number, name?: string | null) {
    let params = new HttpParams().set('page', page);

    const n = (name ?? '').trim();
    if (n) params = params.set('name', n);

    return this.http.get<PagedResponse<Character>>(`${this.baseUrl}/characters`, { params });
  }
}