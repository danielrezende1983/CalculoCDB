import { TestBed, } from '@angular/core/testing';
import { CdbService } from './cdb.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';
import { API_PATH } from '../environments/environment';

describe('CdbService', () => {
  let service: CdbService;
  let http: HttpClient;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CdbService],
      imports: [HttpClientTestingModule]
    });

    service = TestBed.inject(CdbService); 
    http = TestBed.inject(HttpClient);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('teste resgate aplicacao', () => {

    service.resgatarAplicacao(10, 1000).subscribe(response => {
      expect(response.valorBruto).toEqual(1101.5636241432533);
      expect(response.valorLiquido).toEqual(1081.2508993146025);
    });

  });

  it('deve chamar um GET com o endpoint correto', () => {
    const spy = spyOn(http, 'get').and.callThrough();
    service.resgatarAplicacao(10, 1000);
    expect(spy).toHaveBeenCalledWith(`${API_PATH}CalculoCdb`);
  });

});
