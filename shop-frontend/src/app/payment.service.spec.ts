import { TestBed, inject } from '@angular/core/testing';

import { MockPaymentService } from './mock-payment.service';

describe('MockPaymentService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MockPaymentService]
    });
  });

  it('should be created', inject([MockPaymentService], (service: MockPaymentService) => {
    expect(service).toBeTruthy();
  }));
});
