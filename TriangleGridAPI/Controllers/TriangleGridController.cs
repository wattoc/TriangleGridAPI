using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriangleGrid.Core.Interfaces;
using TriangleGrid.Core.Models;
using TriangleGrid.Core.Services;
using TriangleGrid.WebAPI.DTOs;

namespace TriangleGridAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriangleGridController : ControllerBase
    {
        private readonly ITriangleGridService _triangleGridService;
        public TriangleGridController(ITriangleGridService triangleGridService) 
        {
            _triangleGridService = triangleGridService;
        }


        /// <summary>
        /// Calculate the coordinates of a Triangle for a given Grid and Coordinates
        /// </summary>
        /// <param name="calculateTriangleCoordinatesReq"></param>   
        /// <returns>A Triangle</returns>
        /// <response code="200">Returns the Triangle response model</response>
        /// <response code="400">When an error occurred processing the request</response>   
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TriangleDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CalculateTriangleCoordinates")]
        [HttpPost]
        public IActionResult CalculateTriangleCoordinates([FromBody] CalculateTriangleCoordinatesDTO calculateTriangleCoordinatesReq)
        {
            try
            {
                var triangle = _triangleGridService.GetTriangleAtGridCoordinates(calculateTriangleCoordinatesReq.GridSize.Size, calculateTriangleCoordinatesReq.GridSize.TriangleSideSize, new GridCoordinate(calculateTriangleCoordinatesReq.Row, calculateTriangleCoordinatesReq.Column));
                return Ok(new TriangleDTO(triangle));
            }
            catch (Exception ex)
            {
                return Problem(detail:ex.Message, type: ex.GetType().Name, statusCode: StatusCodes.Status400BadRequest);
            }
        }

        /// <summary>
        /// Calculates the Grid Value of a shape given the Coordinates.
        /// </summary>
        /// <remarks>
        /// A Triangle Shape must have 3 vertices, in this order: Top Left Vertex, Outer Vertex, Bottom Right Vertex.
        /// </remarks>
        /// <param name="gridCoordsReq"></param>   
        /// <returns>A Grid Value response with a Row and a Column.</returns>
        /// <response code="200">Returns the Grid Value response model.</response>
        /// <response code="400">When an error occurred processing the request</response>   
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GridCoordinate))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CalculateGridCoordsForTriangle")]
        [HttpPost]
        public IActionResult CalculateGridCoordsForTriangle([FromBody] CalculateGridCoordinatesDTO gridCoordsReq)
        {
            try
            {
                var triangle = _triangleGridService.GetGridCoordinateForTriangle(gridCoordsReq.GridSize.Size, gridCoordsReq.GridSize.TriangleSideSize, gridCoordsReq.Triangle.AsTriangle());
                return Ok(triangle);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, type: ex.GetType().Name, statusCode: StatusCodes.Status400BadRequest);
            }
        }
    }
}
