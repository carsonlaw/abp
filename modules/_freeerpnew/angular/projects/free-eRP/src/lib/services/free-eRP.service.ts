import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class FreeERPService {
  apiName = 'FreeERP';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/FreeERP/sample' },
      { apiName: this.apiName }
    );
  }
}
