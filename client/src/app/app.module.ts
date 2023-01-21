import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwtModule } from '@auth0/angular-jwt';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaginationModule} from "ngx-bootstrap/pagination";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './Login/Login.component';
import { AboutComponent } from './About/About.component';
import { StatisticsComponent } from './Statistics/Statistics.component';
import { RegistriesComponent } from './Registries/Registries.component';
import { AuthGuard } from './_guards/auth.guard';
import { RegistryResolver } from './_resolvers/Registry.resolver';
import { FormsModule } from '@angular/forms';
import { RegistryDetailsComponent } from './RegistryDetails/RegistryDetails.component';
import { RegistryDetailsResolver } from './_resolvers/RegistryDetails.resolver';

export function tokenGetter() { return localStorage.getItem('token'); }




@NgModule({
  declarations: [								
    AppComponent,
      NavMenuComponent,
      HomeComponent,
      RegisterComponent,
      LoginComponent,
      AboutComponent,
      StatisticsComponent,
      RegistriesComponent,
      RegistryDetailsComponent
   ],
  imports: [
    FormsModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    PaginationModule.forRoot(),
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    JwtModule.forRoot({
      config: {
          tokenGetter: tokenGetter,
          allowedDomains: ["localhost:5000"],
          disallowedRoutes: ["localhost:5000/api/auth"],
        
      },
     
  }),

  ],
  providers: [AuthGuard,RegistryResolver, RegistryDetailsResolver],
  bootstrap: [AppComponent]
})
export class AppModule { }
