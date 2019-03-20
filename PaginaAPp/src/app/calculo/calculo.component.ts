import { Component, OnInit } from '@angular/core';
import { CalculoService } from '../compartilhado/calculo.service';

@Component({
  selector: 'app-calculo',
  templateUrl: './calculo.component.html',
  styles: []
})
export class CalculoComponent implements OnInit {

  Resultado: any;
  Parcelas[]: any;
  TipoJuros: any;

  constructor(public service: CalculoService) { }

  ngOnInit() {
  }

  onSubmitSimples() {

    this.service.calcula().subscribe(
      (res: any) => {
        this.Resultado = "Data de vencimento: " + res[0].dtVencimento + " - " +
          " Dias atraso: " + res[0].diasAtraso + " dias - " +
          " Valor original: " + res[0].valorOriginal + " - " +
          " Valor final: " + res[0].valorFinal + " - " +
          " Telefone de orientação para ligar e negociar com um colaborador: " + res[0].telefone;

      },
      err => {
        console.log(err);
      }
    );
  }
}
