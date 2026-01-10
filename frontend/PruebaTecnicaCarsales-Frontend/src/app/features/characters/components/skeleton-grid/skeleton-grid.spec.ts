import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SkeletonGrid } from './skeleton-grid';

describe('SkeletonGrid', () => {
  let component: SkeletonGrid;
  let fixture: ComponentFixture<SkeletonGrid>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SkeletonGrid]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SkeletonGrid);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
