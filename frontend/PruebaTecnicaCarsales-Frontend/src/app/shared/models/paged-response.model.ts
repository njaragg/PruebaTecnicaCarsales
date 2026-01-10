export interface PagedResponse<T> {
  count: number;
  pages: number;
  next: string | null;
  prev: string | null;
  results: T[];
}
