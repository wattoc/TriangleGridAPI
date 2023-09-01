import { ITriangle } from "./triangle";
import { IGridSize } from "./grid-size";

export interface ICalculateGridCoordinatesRequest {
  triangle: ITriangle;
  gridSize: IGridSize;
}
