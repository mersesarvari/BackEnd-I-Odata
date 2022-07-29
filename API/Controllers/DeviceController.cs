using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Model;
using Models;

namespace API.Controllers
{

    public class DeviceController : ODataController
    {

        private readonly ILogger<DeviceController> _logger;
        IDeviceRepository context;

        public DeviceController(ILogger<DeviceController> logger, IDeviceRepository repo)
        {
            _logger = logger;
            context = repo;
        }

        [EnableQuery]
        public IList<Device> Get()
        {
            var d = context.GetAll();
            ;
            return d;
        }


        public IActionResult Post(Device dev)
        {
            try
            {
                context.Post(dev);
                return Ok("Siker");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        public IActionResult Put([FromODataUri] int key, Device device)
        {
            try
            {
                context.Put(key,device);
                return Ok("Siker");
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }

        public IActionResult Delete([FromODataUri] int key)
        {
            try
            {
                context.Delete(key);
                return Ok("Siker");
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }
    }
}