import { IGridSize } from "./grid-size";

export interface ICalculateTriangleCoordinatesRequest {
  row: string;
  column: number;
  gridSize: IGridSize;
}
