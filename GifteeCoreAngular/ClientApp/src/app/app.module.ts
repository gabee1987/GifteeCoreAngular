import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler, NgZone } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';

// External Angular modules components
import { ToastyModule } from 'ng2-toasty';

// Giftee components and services
import { AppErrorHandler } from './app.error-handler';
// User
import { UserListComponent } from './components/user-list/user-list.component';
import { UserListService } from './services/userList.service';
// Giftee
import { GifteeFormComponent } from './components/giftee-form/giftee-form.component';
import { GifteeFormService } from './services/giftee-form.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    // Giftee Components
    UserListComponent,
    GifteeFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    ToastyModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      // Giftee paths
      { path: 'users/get', component: UserListComponent },
      { path: 'giftees/new', component: GifteeFormComponent },
      { path: 'giftees/:id', component: GifteeFormComponent }
    ])
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler },
    UserListService,
    GifteeFormService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
