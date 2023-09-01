import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TriangleGridService } from './service/trianglegrid.service';
import { TriangleGridComponent } from './components/triangle-grid/triangle-grid.component';

@NgModule({
  declarations: [
    AppComponent,
    TriangleGridComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [TriangleGridService],
  bootstrap: [AppComponent]
})
export class AppModule { }
