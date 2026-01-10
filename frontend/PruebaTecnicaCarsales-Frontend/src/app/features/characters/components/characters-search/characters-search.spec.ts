import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharactersSearch } from './characters-search';

describe('CharactersSearch', () => {
  let component: CharactersSearch;
  let fixture: ComponentFixture<CharactersSearch>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CharactersSearch]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharactersSearch);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
