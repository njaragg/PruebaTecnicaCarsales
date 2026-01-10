import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharactersGrid } from './characters-grid';

describe('CharactersGrid', () => {
  let component: CharactersGrid;
  let fixture: ComponentFixture<CharactersGrid>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CharactersGrid]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharactersGrid);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
