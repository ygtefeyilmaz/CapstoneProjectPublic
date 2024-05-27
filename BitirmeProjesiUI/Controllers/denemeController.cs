using Microsoft.AspNetCore.Mvc;
using Gurobi;
using BussinessLayer.Abstract;
using AutoMapper;
using BitirmeProjesi.Areas.Admin.Models;
using BitirmeProjesiUI.Models.Team;
using BussinessLayer.Abstract;
using BussinessLayer.ValidaitonsRules;
using DataAccessLayer.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using BitirmeProjesiUI.Models.Project;
using Microsoft.CodeAnalysis;


namespace BitirmeProjesiUI.Controllers
{
    public class denemeController : Controller
    {

        private readonly ITeamService _teamService;
        private readonly IProjectService _projectService;

        public denemeController(ITeamService teamService, IProjectService projectService)
        {
            _teamService = teamService;
            _projectService = projectService;
        }
        #region kod
        //public IActionResult Index(string[] args)
        //{ 
        //    try
        //    {
        //        var student_data = _teamService.TGetList().ToArray();
        //        var project_list = _projectService.TGetList().ToArray(); 
        //        int studentCount = student_data.Count();
        //        int projectCount = project_list.Count(); 
        //        List<UpdateTeamModel> list = new List<UpdateTeamModel>();
        //        foreach (var student in student_data)
        //        {
        //            string[] Shifts = new string[] { student.projectChoice1.ToString(), student.projectChoice2.ToString(), student.projectChoice3.ToString(),student.projectChoice4.ToString(),
        //            student.projectChoice5.ToString(), student.projectChoice6.ToString(), student.projectChoice7.ToString(),
        //             student.projectChoice8.ToString(), student.projectChoice9.ToString(), student.projectChoice10.ToString(),
        //          student.studentID1.ToString(),   student.studentID2.ToString(),  student.studentID3.ToString(), student.Team_ID.ToString()};
        //            list.Add(new UpdateTeamModel()
        //            {
        //                projectChoice1 = student.projectChoice1,
        //                projectChoice2 = student.projectChoice2,
        //                projectChoice3 = student.projectChoice3,
        //                projectChoice4 = student.projectChoice4,
        //                projectChoice5 = student.projectChoice5,
        //                projectChoice6 = student.projectChoice6,
        //                projectChoice7 = student.projectChoice7,
        //                projectChoice8 = student.projectChoice8,
        //                projectChoice9 = student.projectChoice9,
        //                projectChoice10 = student.projectChoice10, 
        //                studentID1 = student.studentID1,
        //                studentID2 = student.studentID2,
        //                studentID3 = student.studentID3,
        //                Team_ID = student.Team_ID, 
        //            });
        //        }
        //        list.Add(new UpdateTeamModel()); 
        //        List<UpdateProjectModel> projectList = new List<UpdateProjectModel>();
        //        foreach (var project in project_list)
        //        {
        //            string[] Workers = new string[] { project.Project_ID.ToString(), project.Department_ID.ToString(),
        //                project.DepartmentID2.ToString(), project.Project_Name.ToString(), project.Project_Description.ToString(),
        //                project.Instructor_ID.ToString(), project.Create_ID.ToString(), }; 
        //            projectList.Add(new UpdateProjectModel()
        //            {
        //                Project_ID = project.Project_ID,
        //                Department_ID = project.Department_ID,
        //                DepartmentID2 = project.DepartmentID2, 
        //                Project_Name = project.Project_Name,
        //                Project_Description = project.Project_Description,
        //                Instructor_ID = project.Instructor_ID,
        //                Update_ID = project.Create_ID, 
        //            }); 
        //        } 
        //        int nShifts = student_data.Count();
        //        int nWorkers = project_list.Count(); 
        //        // Number of workers required for each shift
        //        double[] shiftRequirements =
        //            new double[] { 3, 2, 4, 4, 5, 6, 5, 2, 2, 3, 4, 6, 7, 5 };
        //        // Amount each worker is paid to work one shift
        //        double[] pay = new double[] { 10, 12, 10, 8, 8, 9, 11 }; 
        //        // Worker availability: 0 if the worker is unavailable for a shift
        //        double[,] availability =
        //            new double[,] { { 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1 },
        //        { 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0 },
        //        { 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
        //        { 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1 },
        //        { 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1 },
        //        { 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1 },
        //        { 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } }; 
        //        // Model
        //        GRBEnv env = new GRBEnv();
        //        GRBModel model = new GRBModel(env); 
        //        model.ModelName = "assignment"; 
        //        // Assignment variables: x[w][s] == 1 if worker w is assigned
        //        // to shift s. Since an assignment model always produces integer
        //        // solutions, we use continuous variables and solve as an LP.
        //        GRBVar[,] x = new GRBVar[nWorkers, nShifts];
        //        for (int w = 0; w < nWorkers; ++w)
        //        {
        //            for (int s = 0; s < nShifts; ++s)
        //            {
        //                x[w, s] =
        //                    model.AddVar(0, availability[w, s], pay[w], GRB.CONTINUOUS,
        //                                 projectList[w] + "." + list[s]);
        //            }
        //        } 
        //        // The objective is to minimize the total pay costs
        //        model.ModelSense = GRB.MINIMIZE; 
        //        // Constraint: assign exactly shiftRequirements[s] workers
        //        // to each shift s
        //        for (int s = 0; s < nShifts; ++s)
        //        {
        //            GRBLinExpr lhs = 0.0;
        //            for (int w = 0; w < nWorkers; ++w)
        //                lhs.AddTerm(1.0, x[w, s]);
        //            model.AddConstr(lhs == shiftRequirements[s], list[s].ToString());
        //        } 
        //        // Optimize
        //        model.Optimize();
        //        int status = model.Status;
        //        if (status == GRB.Status.UNBOUNDED)
        //        {
        //            Console.WriteLine("The model cannot be solved "
        //                + "because it is unbounded"); 
        //        }
        //        if (status == GRB.Status.OPTIMAL)
        //        {
        //            Console.WriteLine("The optimal objective is " + model.ObjVal); 
        //        }
        //        if ((status != GRB.Status.INF_OR_UNBD) &&
        //            (status != GRB.Status.INFEASIBLE))
        //        {
        //            Console.WriteLine("Optimization was stopped with status " + status); 
        //        } 
        //        // Do IIS
        //        Console.WriteLine("The model is infeasible; computing IIS");
        //        model.ComputeIIS();
        //        Console.WriteLine("\nThe following constraint(s) "
        //            + "cannot be satisfied:");
        //        foreach (GRBConstr c in model.GetConstrs())
        //        {
        //            if (c.IISConstr == 1)
        //            {
        //                Console.WriteLine(c.ConstrName);
        //            }
        //        } 
        //        // Dispose of model and env
        //        model.Dispose();
        //        env.Dispose(); 
        //    }
        //    catch (GRBException e)
        //    {
        //        Console.WriteLine("Error code: " + e.ErrorCode + ". " +
        //            e.Message);
        //    } 
        //    return View();
        //}


        #endregion

        #region kod2
        //public static void Main(string[] args)
        //{

        //    //var studentData = ReadStudentData("student_data.txt");
        //    //var projectList = ReadProjectData("project_list.txt");

        //    //var env = new GRBEnv();
        //    //var model = new GRBModel(env);
        //    //model.ModelName = "opt";

        //    //int numStudents = int.Parse(studentData[studentData.Count() - 1].Item1);
        //    //int numProjects = int.Parse(projectList[projectList.Count() - 1].Item1); 
        //    //var x = model.AddVars( numStudents, numProjects + 1, 0.0, 1.0, null, GRB.BINARY);  

        //    var studentData = ReadStudentData("student_data.txt");
        //    var projectList = ReadProjectData("project_list.txt");

        //    var env = new GRBEnv();
        //    var model = new GRBModel(env);
        //    model.ModelName = "opt";

        //    int numStudents = int.Parse(studentData[studentData.Count() - 1].Item1);
        //    int numProjects = int.Parse(projectList[projectList.Count() - 1].Item1);

        //    var x = model.AddVar(numStudents, numProjects + 1, 0.0, Convert.ToChar(1.0), null, Convert.ToString(GRB.BINARY));


        //    model.Optimize();

        //    PrintSolution(x, studentData, projectList);
        //}

        //private static List<Tuple<string, string, string, string>> ReadStudentData(string filePath)
        //{
        //    var data = new List<Tuple<string, string, string, string>>();
        //    using (var reader = new StreamReader(filePath))
        //    {
        //        string line;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            var parts = line.Split(',');
        //            data.Add(Tuple.Create(parts[0], parts[1], parts[2], parts[3]));
        //        }
        //    }
        //    return data;
        //}

        //private static List<Tuple<string, string, string, string, string, string, string, string>> ReadProjectData(string filePath)
        //{
        //    var list = new List<Tuple<string, string, string, string, string, string, string, string>>();
        //    using (var reader = new StreamReader(filePath))
        //    {
        //        string line;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            var parts = line.Split(',');
        //            list.Add(Tuple.Create(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7]));
        //        }
        //    }
        //    return list;
        //}

        //private static void PrintSolution(GRBVar[,] vars, List<Tuple<string, string, string, string>> studentData, List<Tuple<string, string, string, string, string, string, string, string>> projectList)
        //{
        //    using (var writer = new StreamWriter("output.txt"))
        //    {
        //        for (int j = 1; j <= projectList.Count; j++)
        //        {
        //            for (int i = 1; i <= studentData.Count; i++)
        //            {
        //                if (vars[i, j].Get(GRB.DoubleAttr.X) == 1)
        //                {
        //                    writer.WriteLine($"{studentData[i - 1].Item2}, {projectList[j - 1].Item2}");
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion




        public IActionResult Index() 
        //static void Main(string[] args)
        {


            string filePath = "student_data.txt";
            List<(string, string, string, string, string, string, string, string, string, string, string, string, string)> studentData = ReadStudentData(filePath);

            string filePath2 = "project_list.txt";
            List<(string, string, string, string, string, string, string, string)> projectList = ReadProjectData(filePath2);

            try
            {
                GRBEnv env = new GRBEnv();
                GRBModel model = new GRBModel(env);

                int numStudents = studentData.Count;
                int numProjects = projectList.Count;

                // Create variables
                GRBVar[,] x = new GRBVar[numStudents + 1, numProjects + 1];
                GRBVar[] y = new GRBVar[numProjects + 1];

                for (int i = 1; i <= numStudents; i++)
                {
                    for (int j = 1; j <= numProjects; j++)
                    {
                        x[i, j] = model.AddVar(0, 1, 0, GRB.BINARY, $"x_{i}_{j}");
                    }
                }

                for (int j = 1; j <= numProjects; j++)
                {
                    y[j] = model.AddVar(0, GRB.INFINITY, 0, GRB.INTEGER, $"y_{j}");
                }

                // Add constraints and objective function (similar to the Python code)
                // (Implementation details here)

                // Optimize
                model.Optimize();
                model.Write("model.lp");

                // Output results
                // (Implementation details here)

                model.Dispose();
                env.Dispose();
                return View();
            }
            catch (GRBException e)
            {
                Console.WriteLine("Error code: " + e.ErrorCode + ". " + e.Message);
                return View();
            }
            return View();
        }

        static List<(string, string, string, string, string, string, string, string, string, string, string, string, string)> ReadStudentData(string filePath)
        {
            var studentData = new List<(string, string, string, string, string, string, string, string, string, string, string, string, string)>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    studentData.Add((parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], parts[12]));
                }
            }
            return studentData;
        }

        static List<(string, string, string, string, string, string, string, string)> ReadProjectData(string filePath)
        {
            var projectList = new List<(string, string, string, string, string, string, string, string)>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    projectList.Add((parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7]));
                }
            }
            return projectList;
        }
 







        //public IActionResult Index()
        //{
        //    try
        //    {

        //        Random rastgele = new Random();


        //        // Print the selected random numbers


        //        string userName = User.Identity.Name;
        //        var hasUser = await _UserManager.FindByNameAsync(userName);
        //        var userID = hasUser.Id;
        //        var user = await _UserManager.FindByIdAsync(userID);
        //        var roles = await _UserManager.GetRolesAsync(user);
        //        var getRole = roles.FirstOrDefault();


        //        TeamValidator bcv = new TeamValidator();
        //        ValidationResult result = bcv.Validate(p);
        //        if (result.IsValid)
        //        {
        //            string name = "A";
        //            for (int i = 0; i < 100; i++)
        //            {
        //                int[] numbers = Enumerable.Range(1, 31).ToArray();
        //                int[] randomNumbers = numbers.OrderBy(x => rastgele.Next()).Take(10).ToArray();


        //                int Department_ID = rastgele.Next(1, 8);
        //                int Team_Capacity = rastgele.Next(1, 4);



        //                int uzunluk = 15;
        //                string rasgeleString1 = "";
        //                string rasgeleString2 = "";
        //                string rasgeleString3 = "";
        //                for (int j = 0; j < uzunluk; j++)
        //                {
        //                    rasgeleString1 += (char)rastgele.Next(65, 91);
        //                    rasgeleString2 += (char)rastgele.Next(65, 91);
        //                    rasgeleString3 += (char)rastgele.Next(65, 91);
        //                }

        //                p.Team_Name = name + i;
        //                p.AssignedProjectID = 0;
        //                p.Department_ID = Department_ID;
        //                p.Team_Capacity = Team_Capacity;
        //                p.Team_Description = "Denmee";

        //                for (int e = 0; e < 11; e++)
        //                {
        //                    p.projectChoice1 = randomNumbers[0];
        //                    p.projectChoice2 = randomNumbers[1];
        //                    p.projectChoice3 = randomNumbers[2];
        //                    p.projectChoice4 = randomNumbers[3];
        //                    p.projectChoice5 = randomNumbers[4];
        //                    p.projectChoice6 = randomNumbers[5];
        //                    p.projectChoice7 = randomNumbers[6];
        //                    p.projectChoice8 = randomNumbers[7];
        //                    p.projectChoice9 = randomNumbers[8];
        //                    p.projectChoice10 = randomNumbers[9];
        //                }


        //                p.studentID1 = rasgeleString1;
        //                p.studentID2 = rasgeleString2;
        //                p.studentID3 = rasgeleString3;



        //                p.Create_ID = hasUser.Id;
        //                p.Create_Date = DateTime.Now;
        //                p.Update_ID = null;
        //                p.Update_Date = DateTime.Now;

        //                p.IsDelete = false;
        //                p.IsDelete_ID = null;
        //                p.IsDelete_Date = DateTime.Now;
        //                p.IsActive = true;

        //                _teamService.TAdd(p);

        //                p.Team_ID = 0;


                         

        //            }


        //        }
        //        else
        //        {
        //            foreach (var item in result.Errors)
        //            {
        //                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //                //hata mesajı ve log yaz
        //            }

        //        }

        //        return View();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return View();
        //}


}
}
