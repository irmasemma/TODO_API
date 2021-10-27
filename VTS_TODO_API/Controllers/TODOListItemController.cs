using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VTS_TODO_API.Services;
using VTS_TODO_BusinessObjects;

namespace VTS_TODO_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TODOListItemController : ControllerBase
    {

        ITODOListItemService _TODOItemService;
        public TODOListItemController(ITODOListItemService TODOItem)
        {
            this._TODOItemService = TODOItem;
        }

        // GET api/TODOListItem/foo
        /// <summary>
        /// Get all list items for selected list(Case sensitive)
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<TODOListItem> Get(string ListTitle)
        {
            return _TODOItemService.Get(ListTitle).Select(x => (TODOListItem)x).ToList();
        }


        // POST api/TODOListItem
        /// <summary>
        /// Add new list item to selected list(Case sensitive)
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <param name="ItemTitle"></param>
        [HttpPost]
        public void Post(string ListTitle, string ItemTitle)
        {
            _TODOItemService.Add(ListTitle, ItemTitle);
        }

        // PUT api/TODOListItem/foo
        /// <summary>
        /// Set list item as completed(Case sensitive)
        /// </summary>
        /// <param name="ItemTitle"></param>
        /// <param name="ListTitle"></param>
        [HttpPut]
        public void Put(string ListTitle, string ItemTitle)
        {
            _TODOItemService.Complete(ListTitle, ItemTitle);
        }

        // DELETE api/TODOListItem/foo
        /// <summary>
        /// Delete list item from the list(Case sensitive)
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <param name="ItemTitle"></param>
        [HttpDelete]
        public void Delete(string ListTitle, string ItemTitle)
        {
            _TODOItemService.Delete(ListTitle, ItemTitle);
        }
    }
}
