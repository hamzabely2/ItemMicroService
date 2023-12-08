using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Item;
using Service.Interface;

namespace Api.PotShop.ItemMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {

        private readonly ItemIService _itemService;

        public ItemController(ItemIService itemService)
        {
            _itemService = itemService;
        }



        /// get list item <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<ItemDetailsDto>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> GetList()
        {
            try
            {
                var result = await _itemService.GetListItem().ConfigureAwait(false);
                string message = "la liste des artciles";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// get item by id <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{itemId}")]
        [ProducesResponseType(typeof(IEnumerable<ItemDetailsDto>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> GetById(int itemId)
        {
            try
            {
                var result = await _itemService.GetItemById(itemId).ConfigureAwait(false);
                string message = "article";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// add item <summary>
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        [HttpPost("create")]
        //[Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(ItemDetailsDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> Create(ItemAdd request)
        {
            try
            {
                var result = await _itemService.CreateItem(request).ConfigureAwait(false);
                string message = "article a  été ajouté avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// update item <summary>
        /// </summary>
        /// <param name="itemDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("update/{itemId}")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(ItemDetailsDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> Update(ItemUpdate request, int itemId)
        {
            try
            {
                var result = await _itemService.UpdateItem(request, itemId);
                string message = "article a été modifie avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// delete item <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{itemId}")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(ItemDetailsDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> Delete(int itemId)
        {
            try
            {
                var result = await _itemService.DeleteItem(itemId);
                string message = "article a été supprime avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
