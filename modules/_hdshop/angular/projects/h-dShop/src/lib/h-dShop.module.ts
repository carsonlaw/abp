import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { HDShopComponent } from './components/h-dShop.component';
import { HDShopRoutingModule } from './h-dShop-routing.module';

@NgModule({
  declarations: [HDShopComponent],
  imports: [CoreModule, ThemeSharedModule, HDShopRoutingModule],
  exports: [HDShopComponent],
})
export class HDShopModule {
  static forChild(): ModuleWithProviders<HDShopModule> {
    return {
      ngModule: HDShopModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<HDShopModule> {
    return new LazyModuleFactory(HDShopModule.forChild());
  }
}
