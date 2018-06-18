import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeriesCatalogComponent } from './series-catalog.component';

describe('SeriesCatalogComponent', () => {
  let component: SeriesCatalogComponent;
  let fixture: ComponentFixture<SeriesCatalogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeriesCatalogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeriesCatalogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
