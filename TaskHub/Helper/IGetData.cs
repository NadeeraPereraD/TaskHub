using TaskHub.Model;

namespace TaskHub.Helper
{
    public interface IGetData
    {
        List<UserModel> GetUserData();
        List<ProjectModel> GetProjectData();
        List<TaskModel> GetTaskData();
    }
}
