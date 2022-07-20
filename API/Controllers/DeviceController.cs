using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Model;
using Models;
using System.Web.Http;

namespace API.Controllers
{
    [ApiController]
    public class DeviceController : ODataController
    {

        private readonly ILogger<DeviceController> _logger;
        IDeviceRepository context;

        public DeviceController(ILogger<DeviceController> logger, IDeviceRepository repo)
        {
            _logger = logger;
            context = repo;
        }

        //[EnableQuery]
        public IList<Device> Get()
        {
            var d = context.GetAll();
            ;
            return d;
        }


        
        [EnableQuery]
        public IActionResult Put(Device dev)
        {
            try
            {
                context.Put(dev);
                return Ok("Siker");
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }

        [EnableQuery]
        public IActionResult Delete(int id)
        {
            try
            {
                context.Delete(id);
                return Ok("Siker");
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }
    }
}