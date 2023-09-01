import { Component, Input } from "@angular/core";
import { TriangleGridService } from "../../service/trianglegrid.service";
import { ITriangle } from "../../interfaces/triangle";
import { IGridCoordinates } from "../../interfaces/grid-coordinates";

@Component({
  selector: 'triangle-grid',
  templateUrl: './triangle-grid.component.html',
  styleUrls: ['./triangle-grid.component.css']
})
export class TriangleGridComponent {
  @Input() gridSize!: number;
  @Input() triangleSideSize!: number;

  constructor(
    private readonly tgService: TriangleGridService
  ) { }

  triangleRow = 'A';
  triangleColumn = 1;

  requestTriangle: Array<{ x: number; y: number; }> = [{ x: 0, y: 0 }, { x: 10, y: 10 }, { x: 0, y: 10 }];

  triangleResult: ITriangle | undefined;
  gridResult: IGridCoordinates | undefined;

  errorMessage: string | undefined;
;

  trackBy(index: any, item: any) {
    return index;
  }

  getTriangle() {
    this.errorMessage = '';
    this.tgService.CalculateTriangleCoordinates({ column: this.triangleColumn, row: this.triangleRow, gridSize: { size: this.gridSize, triangleSideSize: this.triangleSideSize } })
      .subscribe(result => {
        this.triangleResult = result;
      },
        error => {
          this.errorMessage = error.error.detail ?? error.error.title;
        }
    );
  }

  getGrid() {
    this.errorMessage = '';
    this.tgService.CalculateGridCoordinates({ triangle: { coordinates: this.requestTriangle }, gridSize: { size: this.gridSize, triangleSideSize: this.triangleSideSize } })
      .subscribe(result => {
        this.gridResult = result;
      },
        error => {
          this.errorMessage = error.error.detail ?? error.error.title;
        }
      );
  }

}
