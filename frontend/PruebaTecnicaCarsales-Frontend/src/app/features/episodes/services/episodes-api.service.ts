import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { API_BASE_URL } from '../../../shared/tokens/api-base-url.token';
import { PagedResponse } from '../../../shared/models/paged-response.model';
import { Episode } from '../../../shared/models/episode.model';

@Injectable({ providedIn: 'root' })
export class EpisodesApiService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = inject(API_BASE_URL);

  getEpisodes(page: number) {
    const params = new HttpParams().set('page', page);
    return this.http.get<PagedResponse<Episode>>(`${this.baseUrl}/episodes`, { params });
  }
}
