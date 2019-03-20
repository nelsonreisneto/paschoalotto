import { Injectable, Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ValidaData } from '../calculo/registro/validaData';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CalculoService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  readonly BaseURI = "https://localhost:44338";

  formModel = this.fb.group({
    Resultado: ['', Validators.required],
   
  });

  calcula() {    
    return this.http.get(this.BaseURI +"/api/Divida");
  }

  parcelas() {
    return this.http.get(this.BaseURI + "/api/Parcela");
  }
}
