import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { FreeERPComponent } from './components/free-eRP.component';
import { FreeERPService } from '@free-eRP';
import { of } from 'rxjs';

describe('FreeERPComponent', () => {
  let component: FreeERPComponent;
  let fixture: ComponentFixture<FreeERPComponent>;
  const mockFreeERPService = jasmine.createSpyObj('FreeERPService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [FreeERPComponent],
      providers: [
        {
          provide: FreeERPService,
          useValue: mockFreeERPService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FreeERPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
