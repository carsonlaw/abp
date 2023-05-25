import { ModuleWithProviders, NgModule } from '@angular/core';
import { FREE_ERP_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class FreeERPConfigModule {
  static forRoot(): ModuleWithProviders<FreeERPConfigModule> {
    return {
      ngModule: FreeERPConfigModule,
      providers: [FREE_ERP_ROUTE_PROVIDERS],
    };
  }
}
