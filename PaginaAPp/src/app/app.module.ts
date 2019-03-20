import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CalculoComponent } from './calculo/calculo.component';
import { RegistroComponent } from './calculo/registro/registro.component';
import { CalculoService } from './compartilhado/calculo.service';

@NgModule({
  declarations: [
    AppComponent,
    CalculoComponent,
    RegistroComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [CalculoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
