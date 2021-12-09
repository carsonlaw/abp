import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { HDShopComponent } from './h-dShop.component';

describe('HDShopComponent', () => {
  let component: HDShopComponent;
  let fixture: ComponentFixture<HDShopComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ HDShopComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HDShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
