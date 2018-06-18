import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MusicsDetailsComponent } from './musics-details.component';

describe('MusicsDetailsComponent', () => {
  let component: MusicsDetailsComponent;
  let fixture: ComponentFixture<MusicsDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MusicsDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MusicsDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
