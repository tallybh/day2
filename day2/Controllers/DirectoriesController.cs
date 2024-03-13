using day2.Contracts;
using day2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoriesController : ControllerBase
    {
        IDirectoriesRepository _repository;
        public DirectoriesController(IDirectoriesRepository rep)
        {
            _repository = rep;
        }

        // GET: api/<DirectoriesController>
        [HttpGet]
        [Route("GetDirectories/{dirName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDirectories(string dirName)
        {
            if(!Directory.Exists(dirName))
            {
                return NotFound();
            }
            await Task.Delay(1000);

            var dirs = Directory.GetDirectories(dirName);
            return Ok(dirs);
        }

        [HttpGet]
        [Route("GetFiles/{dirName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MyFile>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFiles(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                return NotFound();
            }
            await Task.Delay(1000);

            var fileNames = Directory.GetFiles(dirName);

            List<MyFile> files = new();
            //var v  = new List<MyFile>();
            // List<MyFile> v1 = new List<MyFile>();
            MyFile myFile;
            foreach(var file in fileNames)
            {
                var info = new FileInfo(file);
                myFile = new MyFile { Extension = info.Extension , ModificationDate = info.LastWriteTime,
                    Path = info.Name, Size = info.Length};
                files.Add(myFile);

            }
            return Ok(files);
        }


        // DELETE api/<DirectoriesController>/5
        [HttpDelete("{fileName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string fileName)
        {
            if(!System.IO.File.Exists(fileName))
              return NotFound();
            await Task.Delay(1000);

            System.IO.File.Delete(fileName);
            return NoContent();

        }
    }
}
