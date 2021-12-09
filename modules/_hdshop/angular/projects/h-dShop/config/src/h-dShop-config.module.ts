import { ModuleWithProviders, NgModule } from '@angular/core';
import { HD_SHOP_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class HDShopConfigModule {
  static forRoot(): ModuleWithProviders<HDShopConfigModule> {
    return {
      ngModule: HDShopConfigModule,
      providers: [HD_SHOP_ROUTE_PROVIDERS],
    };
  }
}
