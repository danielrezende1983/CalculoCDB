import { TestBed, async, inject } from '@angular/core/testing';
import { CdbService } from './cdb.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { API_PATH } from '../environments/environment';

describe('CdbService', () => {
  let service: CdbService;
  let httpController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CdbService],
      imports: [HttpClientTestingModule]
    });

    service = TestBed.inject(CdbService);
    httpController = TestBed.get(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should resgate aplicacao', () => {

    service.resgatarAplicacao(10, 1000).subscribe(response => {
      expect(response.valorBruto).toEqual(1101.5636241432533);
      expect(response.valorLiquido).toEqual(1081.2508993146025);
    });

  });

});
