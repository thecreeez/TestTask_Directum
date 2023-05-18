using Microsoft.AspNetCore.Mvc;
using TestTask_Directum_1.Models;

namespace TestTask_Directum_1.Controllers
{
    public class ApiController : Controller
    {
        //
        // POST: /api/SaveUser
        [HttpPost]
        public string SaveUser(UserModel model)
        {
            string name = model.saveToJSON();
            return "Thanks. Your file is: "+name+" (In "+UserModel.getPathToSaveJSON()+ " folder).";
        }
    }
}