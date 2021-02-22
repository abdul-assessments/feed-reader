import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { MatCheckboxModule } from '@angular/material/checkbox';

import { AppComponent } from './app.component';
import { FeedItemComponent } from './components/feed-item/feed-item.component';
import { FeedListComponent } from './components/feed-list/feed-list.component';

@NgModule({
  declarations: [
    AppComponent,
    FeedItemComponent,
    FeedListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatCheckboxModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
