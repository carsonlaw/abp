import { TestBed } from '@angular/core/testing';

import { HDShopService } from './h-dShop.service';

describe('HDShopService', () => {
  let service: HDShopService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HDShopService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
