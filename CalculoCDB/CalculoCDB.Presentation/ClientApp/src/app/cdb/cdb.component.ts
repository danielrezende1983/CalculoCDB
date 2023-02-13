import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cdb',
  templateUrl: './cdb.component.html',
  styleUrls: ['./cdb.component.css']
})
export class CdbComponent implements OnInit {

  tituloValorInicial = 'Get input box value';
  displayValorInicial = '';
  getValueValorInicial(val:string)
  {
    console.warn(val)
    this.displayValorInicial = val
  } 

  tituloPrazo = 'Get input box value';
  displayPrazo = '';
  getValuePrazo(val: string) {
    console.warn(val)
    this.displayPrazo = val
  } 

  constructor() { }

  ngOnInit(): void {
  }

}
