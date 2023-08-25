import { TestBed } from '@angular/core/testing';

import { InternalService } from './internal.service';

describe('InternalService', () => {
  let service: InternalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InternalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
