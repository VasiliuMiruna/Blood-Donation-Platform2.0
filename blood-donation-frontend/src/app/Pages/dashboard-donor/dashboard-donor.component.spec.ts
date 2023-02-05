import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardDonorComponent } from './dashboard-donor.component';

describe('DashboardDonorComponent', () => {
  let component: DashboardDonorComponent;
  let fixture: ComponentFixture<DashboardDonorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardDonorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashboardDonorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
