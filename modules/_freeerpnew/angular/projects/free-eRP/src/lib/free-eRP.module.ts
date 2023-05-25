import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { FreeERPComponent } from './components/free-eRP.component';
import { FreeERPRoutingModule } from './free-eRP-routing.module';

@NgModule({
  declarations: [FreeERPComponent],
  imports: [CoreModule, ThemeSharedModule, FreeERPRoutingModule],
  exports: [FreeERPComponent],
})
export class FreeERPModule {
  static forChild(): ModuleWithProviders<FreeERPModule> {
    return {
      ngModule: FreeERPModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<FreeERPModule> {
    return new LazyModuleFactory(FreeERPModule.forChild());
  }
}
