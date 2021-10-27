using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VTS_TODO_API.Services;
using VTS_TODO_BusinessObjects;

namespace VTS_TODO_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TODOListsController : ControllerBase
    {
        ITODOListService _TODOList;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TODOList"></param>
        public TODOListsController(ITODOListService TODOList)
        {
            this._TODOList = TODOList;
        }

        // GET api/TODOLists
        /// <summary>
        /// Get all TODO lists(Case sensitive)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<TODOList> Get()
        {
           return _TODOList.GetLists().Select(x => (TODOList)x).ToList();
        }

        // GET api/TODOLists/foo
        /// <summary>
        /// Get TODO lists by owner name(Case sensitive) 
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetListByOwner")]
        public IQueryable<TODOList> Get(string UserName)
        {
            return _TODOList.GetListsByUser(UserName).Select(x => (TODOList)x); 
        }

        // POST api/TODOLists
        /// <summary>
        /// Creates new TODO list. ListTitle MUST BE UNIQUE! Consider ListTitle as the Primary Key for demo simplicity. Oly 1 list with the same ListTitle can exists in the memory store. (Case sensitive)
        /// </summary>
        /// <param name="ListTitle"></param>
        /// <param name="UserName">list owner</param>
        [HttpPost]
        public void Post(string ListTitle, string UserName)
        {
            _TODOList.Add(ListTitle, UserName);
        }

        // DELETE api/TODOLists/foo
        /// <summary>
        /// Remove TODO List with  title(Case sensitive)
        /// </summary>
        /// <param name="ListTitle"></param>
        [HttpDelete]
        public void Delete(string ListTitle)
        {
            _TODOList.Delete(ListTitle);
        }
    }
}
