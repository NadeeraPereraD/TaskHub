using System.Data;
using TaskHub.Model;

namespace TaskHub.Helper
{
    public class GetData : DBTransaction, IGetData
    {
        public GetData(IConfiguration configuration) : base(configuration) { }

        public List<UserModel> GetUserData()
        {
            List<UserModel> lstUser = new List<UserModel>();
            DataSet dataSet = new DataSet();
            string sql = "SELECT * FROM tblUsers";
            dataSet = FillDataSet(sql, sql);
            DataTable dt = dataSet.Tables[0];
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UserModel userModel = new UserModel();
                    userModel.userID = (int)Convert.ToUInt16(dr["userID"].ToString());
                    userModel.firstName = dr["firstName"].ToString().Trim();
                    userModel.lastName = dr["lastName"].ToString().Trim();
                    userModel.preferedName = dr["PreferedName"].ToString().Trim();
                    lstUser.Add(userModel);
                }
            }
            return lstUser;
        }

        public List<ProjectModel> GetProjectData()
        {
            List<ProjectModel> lstProject = new List<ProjectModel>();
            DataSet dataSet = new DataSet();
            string sql = "SELECT * FROM tblProjects";
            dataSet = FillDataSet(sql, sql);
            DataTable dt = dataSet.Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ProjectModel projectModel = new ProjectModel();
                    projectModel.projectID = (int)Convert.ToInt64(dr["projectID"].ToString());
                    projectModel.projectName = dr["projectName"].ToString().Trim();
                    projectModel.startDate = dr["startDate"].ToString().Trim();
                    projectModel.endDate = dr["endDate"].ToString().Trim();
                    projectModel.status = dr["status"].ToString().Trim();
                    lstProject.Add(projectModel);
                }
            }
            return lstProject;
        }

        public List<TaskModel> GetTaskData()
        {
            List<TaskModel> lstTask = new List<TaskModel>();
            DataSet dataSet = new DataSet();
            string sql = "SELECT * FROM tblTask WHERE projectID = '1' AND isActive = 0";
            dataSet = FillDataSet(sql, sql);
            DataTable dt = dataSet.Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TaskModel taskModel = new TaskModel();
                    taskModel.taskID = (int)Convert.ToInt64(dr["taskID"].ToString());
                    taskModel.task = dr["task"].ToString().Trim();
                    taskModel.estimateStartDate = dr["estimateStartDate"].ToString().Trim();
                    taskModel.estimateEndDate = dr["estimateEndDate"].ToString().Trim();
                    taskModel.actualStartDate = dr["actualStartDate"].ToString().Trim();
                    taskModel.actualEndDate = dr["actualEndDate"].ToString().Trim();
                    taskModel.assigneeID = (int)Convert.ToInt64(dr["assigneeID"].ToString());
                    taskModel.status = dr["status"].ToString().Trim();
                    taskModel.completedPercentage = dr["completedPercentage"].ToString().Trim();
                    taskModel.projectID = (int)Convert.ToInt64(dr["projectID"].ToString()); ;
                    taskModel.isActive = (int)Convert.ToInt64(dr["isActive"].ToString());
                    lstTask.Add(taskModel);
                }
            }
            return lstTask;
        }
    }
}
