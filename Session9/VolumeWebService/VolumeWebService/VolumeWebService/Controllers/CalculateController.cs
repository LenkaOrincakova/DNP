using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolumeWebService.Controllers
{
    [ApiController]

    public class CalculateController : ControllerBase
    {
        private Calculator calculator;

        public CalculateController(Calculator calculator)
        {
            this.calculator = calculator;
        }

        [HttpGet]
        [Route ("[controller]/cylinder")]
        public ActionResult<VolumeResult> CalculateCylinderVolume([FromQuery] double height, [FromQuery] double radius)
        {
            if(height > 0 && radius > 0)
            {
                var volume = calculator.CalculateVolumeCylinder(radius, height);
                var result = CreateVolumeResult("cylinder", height, radius, volume);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route ("[controller]/cone")]
        public ActionResult<VolumeResult> CalculateConeVolume([FromQuery] double height, [FromQuery] double radius)
        {
            if(height>0 && radius > 0)
            {
                var volume = calculator.CalculateVolumeCone(radius, height);
                var result = CreateVolumeResult("cone", height, radius, volume);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("[controller]/cylinder")]
        public async Task<ActionResult<VolumeResult>> CalculateAndSaveCylinderVolumeAsync ([FromQuery] double height, [FromQuery] double radius)
        {
            if(height >0 && radius>0)
            {
                var volume = calculator.CalculateVolumeCylinder(radius, height);
                var result = CreateVolumeResult("cylinder", height, radius, volume);
                return Created($"http://localhost:5000/calculate/cylinder?height={height}&radius={radius}", result);

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("[controller]/cone")]
        public async Task<ActionResult<VolumerResult>> CalculateAndSaveConeVolumeAsync([FromQuery] double height, [FromQuery] double radius)
        {
            if(height >0 && radius>0)
            {
                var volume = calculator.CalculateVolumeCone(radius, height);
                var result = CreateVolumeResult("cone", height, radius, volume);
                return Created($"http://localhost:5000/calculate/cone?height={height}&radius={radius}", result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
