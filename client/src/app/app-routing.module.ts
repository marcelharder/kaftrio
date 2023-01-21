import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './About/About.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './Login/Login.component';
import { RegisterComponent } from './register/register.component';
import { RegistriesComponent } from './Registries/Registries.component';
import { RegistryDetailsComponent } from './RegistryDetails/RegistryDetails.component';
import { StatisticsComponent } from './Statistics/Statistics.component';
import { AuthGuard } from './_guards/auth.guard';
import { RegistryResolver } from './_resolvers/Registry.resolver';
import { RegistryDetailsResolver } from './_resolvers/RegistryDetails.resolver';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'about', component: AboutComponent },
  {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
         
          { path: 'statistics', component: StatisticsComponent },
          { path: 'listOfRegistries', component: RegistriesComponent, resolve: {regs: RegistryResolver} },
          { path: 'registry/:id', component: RegistryDetailsComponent, resolve: {reg: RegistryDetailsResolver} },

 /*
          { path: 'settings', component: SettingsComponent },
          { path: 'tutorials', component: TutorialsComponent },
          { path: 'statistics', component: StatisticsComponent },
          { path: 'companysettings/:id', component: SettingsCompanyComponent },
          { path: 'expiry/:id', component: ExpiryComponent },
          { path: 'addProduct/:id', component: AddProductComponent, resolve: {valve: ValveResolver} },
 */

      ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
