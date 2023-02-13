import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { take } from 'rxjs';
import { API_PATH } from '../environments/environment';
import { ICdb } from './ICdb';

@Injectable({
  providedIn: 'root'
})
export class CdbService {

  constructor(private httpClient: HttpClient) {
    /* document why this constructor is empty */
  }

  resgatarAplicacao(meses: number, valorInicial: number) {

    let params = new HttpParams()
      .append('ValorInicial', valorInicial)
      .append('MesesParaResgate', meses)
      .append('Id', 1);

    return this.httpClient.get<ICdb>(`${API_PATH}CalculoCdb`, { params: params }).pipe(take(1));

  }

}
