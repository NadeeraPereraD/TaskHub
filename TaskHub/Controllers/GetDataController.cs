using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskHub.Helper;
using TaskHub.Model;

namespace TaskHub.Controllers
{
    [Route("api/GetData")]
    [ApiController]
    public class GetDataController : ControllerBase
    {
        private IGetData _iGetData = null;

        public GetDataController(IGetData iGetData)
        {
            _iGetData = iGetData;
        }

        [HttpGet("GetUsers")]
        public List<UserModel> GetUsers()
        {
            List<UserModel> lstUser = _iGetData.GetUserData();
            return lstUser;
        }

        [HttpGet("GetProjects")]
        public List<ProjectModel> GetProjects()
        {
            List<ProjectModel> lstProject = _iGetData.GetProjectData();
            return lstProject;
        }
        [HttpGet("GetTasks")]
        public List<TaskModel> GetTask()
        {
            List<TaskModel> lstTask = _iGetData.GetTaskData();
            return lstTask;
        }
    }
}
