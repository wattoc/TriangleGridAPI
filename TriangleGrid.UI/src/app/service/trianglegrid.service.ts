import { HttpClient } from "@angular/common/http";
import { ITriangle } from "../interfaces/triangle";
import { Observable } from "rxjs";
import { IGridCoordinates } from "../interfaces/grid-coordinates";
import { ICalculateTriangleCoordinatesRequest } from "../interfaces/calculate-triangle-coordinates-request";
import { ICalculateGridCoordinatesRequest } from "../interfaces/calculate-grid-coordinates-request";
import { Injectable } from "@angular/core";

@Injectable()
export class TriangleGridService {

  constructor(
    private readonly http: HttpClient
  ) { }

  public CalculateTriangleCoordinates(calculateTriangleCoordinatesRequest: ICalculateTriangleCoordinatesRequest): Observable<ITriangle> {
    return this.http.post<ITriangle>('/api/TriangleGrid/CalculateTriangleCoordinates', calculateTriangleCoordinatesRequest);
  }

  public CalculateGridCoordinates(calculateGridCoordinatesRequest: ICalculateGridCoordinatesRequest): Observable<IGridCoordinates> {
    return this.http.post<IGridCoordinates>('/api/TriangleGrid/CalculateGridCoordsForTriangle', calculateGridCoordinatesRequest);
  }
}
