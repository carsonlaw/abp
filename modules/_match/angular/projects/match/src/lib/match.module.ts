import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { MatchComponent } from './components/match.component';
import { MatchRoutingModule } from './match-routing.module';

@NgModule({
  declarations: [MatchComponent],
  imports: [CoreModule, ThemeSharedModule, MatchRoutingModule],
  exports: [MatchComponent],
})
export class MatchModule {
  static forChild(): ModuleWithProviders<MatchModule> {
    return {
      ngModule: MatchModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<MatchModule> {
    return new LazyModuleFactory(MatchModule.forChild());
  }
}
