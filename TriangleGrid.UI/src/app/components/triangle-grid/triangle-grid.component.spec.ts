import { TestBed } from '@angular/core/testing';
import { TriangleGridComponent } from './triangle-grid.component';
import { TriangleGridService } from '../../service/trianglegrid.service';

describe('TriangleGridComponent', () => {
  let MockTriangleGridService: any;


  beforeEach(() => TestBed.configureTestingModule({
    declarations: [TriangleGridComponent],
    providers: [{ provide: TriangleGridService, useValue: MockTriangleGridService}]
  }));

  it('should create the component', () => {
    const fixture = TestBed.createComponent(TriangleGridComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });
});
