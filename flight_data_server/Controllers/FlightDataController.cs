using flight_data_server.Interface;
using flight_data_server.Models;
using flight_data_server.Models.FlightData;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace flight_data_server.Controllers
    {

    [Route("api/FlightData")]
    [ApiController]
    public class FlightDataController : ControllerBase
        {

        protected APIResponse _response;
        private readonly IFlightDataDBFunctions _dbFlightData;

        public FlightDataController(IFlightDataDBFunctions dbFlightData)
            {
            this._dbFlightData = dbFlightData;
            this._response = new();
            }

        [HttpGet]
        public async Task<ActionResult<FlightData>> GetFlightData()
            {
            try
                {
                IEnumerable<FlightData> flightDataList = await _dbFlightData.GetAllAsync();
                _response.Result = flightDataList;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
                }
            catch
                {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_response);
                }



            }


        [HttpPost]
        public async Task<ActionResult<FlightData> > PostFlightData([FromBody] FlightData flighData)
            {

            try { 
                
                 if (flighData == null)
                    {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                    }
                await _dbFlightData.CreateAsync(flighData);
                _response.StatusCode = HttpStatusCode.Created;

                return Ok(_response);
                } catch {

                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
                }

            }

        }
    }
