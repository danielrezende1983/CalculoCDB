import { Component, OnInit } from '@angular/core';
import { CdbService } from '../cdb.service';
import { ICdb } from '../ICdb';

@Component({
  selector: 'app-cdb',
  templateUrl: './cdb.component.html',
  styleUrls: ['./cdb.component.css']
})
export class CdbComponent implements OnInit {

  valorInicial = 0;
  meses = 0;

  displayValorInicial = '';
  displayValorBruto = '';
  displayValorLiquido = '';
  displayErros = '';

  getValueValorInicial(val: string)
  {
    console.warn(val)
    this.valorInicial = Number(val);
    this.displayValorInicial = `Valor Inicial: R$ ${this.valorInicial.toFixed(2)}`;
  } 

  displayPrazo = '';
  getValuePrazo(val: string) {
    console.warn(val)
    this.meses = Number(val);
    if (val == '')
      this.displayPrazo = '';
    else
      this.displayPrazo = `Prazo em Meses: ${val} Meses`;
  } 

  constructor(private cdbService: CdbService) {
    this.inicialize();
  }

  ngOnInit(): void {
    this.inicialize();
  }

  inicialize(): void {
    this.displayValorInicial = '';
    this.displayValorBruto = '';
    this.displayValorLiquido = '';
    this.displayErros = '';
  }

  mostrarValores(cdb: ICdb): void {
    console.log(cdb);
    this.displayValorBruto = `Valor Bruto: R$ ${cdb.valorBruto.toFixed(2)}`;
    this.displayValorLiquido = `Valor Liquido: R$ ${cdb.valorLiquido.toFixed(2)}`;
  }

  mostrarErros(erros: string): void {
    console.error(erros);
    this.displayErros = erros
      .replace('Validation failed: ', '')
      .replace('Severity: Error', '')
      .replace('Severity', '')
      .replace(': Error', '')
      .replace('ValorInicial', 'Valor Inicial')
      .replace('MesesParaResgate', 'Prazo em Meses');
  }

  resgatarAplicacao() {

    this.inicialize();
    
    this.cdbService.resgatarAplicacao(this.meses, this.valorInicial).subscribe(
      success => this.mostrarValores(<ICdb>success),
      erro => {
        console.error(erro);        
        switch (erro.status) {
          case 400:
            this.mostrarErros(erro.error);
            break;
        }
      },
      () => console.log('request completo')
    );
  }  

}
