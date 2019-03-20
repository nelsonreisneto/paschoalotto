import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CalculoComponent } from './calculo/calculo.component';
import { RegistroComponent } from './calculo/registro/registro.component';

const routes: Routes = [
  { path: '', redirectTo: '/calculo/registro', pathMatch:'full' },
  {
    path: 'calculo', component: CalculoComponent,
    children: [
      { path: 'registro', component: RegistroComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
