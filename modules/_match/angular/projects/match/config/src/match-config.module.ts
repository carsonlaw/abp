import { ModuleWithProviders, NgModule } from '@angular/core';
import { MATCH_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class MatchConfigModule {
  static forRoot(): ModuleWithProviders<MatchConfigModule> {
    return {
      ngModule: MatchConfigModule,
      providers: [MATCH_ROUTE_PROVIDERS],
    };
  }
}
