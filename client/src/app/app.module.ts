import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwtModule } from '@auth0/angular-jwt';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaginationModule} from "ngx-bootstrap/pagination";
import { TabsModule} from "ngx-bootstrap/tabs";

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
import { ChartsModule } from 'ng2-charts';
import { AgeComponent } from './Statistics/graph/age/age.component';
import { GraphComponent } from './Statistics/graph/graph.component';
import { StatisticsSummaryComponent } from './Statistics/statisticsSummary/statisticsSummary.component';
import { GraphService } from './_services/Graph.service';

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
      RegistryDetailsComponent,
      AgeComponent,
      GraphComponent,
      StatisticsSummaryComponent,
   ],
  imports: [
    TabsModule.forRoot(),
    ChartsModule,
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
  providers: [AuthGuard,RegistryResolver, RegistryDetailsResolver, GraphService],
  bootstrap: [AppComponent]
})
export class AppModule { }
