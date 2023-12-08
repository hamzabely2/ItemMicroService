using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DetailsItem;
using Service.Interface;

namespace Api.PotShop.ItemMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        private readonly MaterialIService _materialService;

        public MaterialController(MaterialIService materialService)
        {
            _materialService = materialService;
        }


        /// get all materials <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(MaterialDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _materialService.GetAllMaterial();
                string message = "la liste des matériels";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        /// <summary>
        /// create material
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(MaterialDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> Create(MaterialDto request)
        {
            try
            {
                var result = await _materialService.CreateMaterial(request);
                string message = "le matériel a été ajoute avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        /// <summary>
        /// delete material
        /// </summary>
        /// <param name="materilId"></param>
        /// <returns></returns>
        [HttpDelete("delete/{materilId}")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(MaterialDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> Delete(int materilId)
        {
            try
            {
                var result = await _materialService.DeleteMaterial(materilId);
                string message = "le matériel a été supprime avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
