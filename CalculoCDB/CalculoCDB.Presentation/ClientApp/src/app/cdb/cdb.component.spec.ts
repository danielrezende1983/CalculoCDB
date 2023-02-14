import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CdbComponent } from './cdb.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('CdbComponent', () => {

  let component: CdbComponent;
  let fixture: ComponentFixture<CdbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CdbComponent],
      providers: [CdbComponent],
      imports: [HttpClientTestingModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CdbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  

});
