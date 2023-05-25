import { TestBed } from '@angular/core/testing';
import { FreeERPService } from './services/free-eRP.service';
import { RestService } from '@abp/ng.core';

describe('FreeERPService', () => {
  let service: FreeERPService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(FreeERPService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
