using AutoMapper;
using BitirmeProjesiUI.Models.Optimization;
using BussinessLayer.Abstract;
using BussinessLayer.ValidaitonsRules;
using DataAccessLayer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BitirmeProjesiUI.Controllers
{
    public class OptimizationController : Controller
    {
        private readonly IOptimizationService _optimizationService;
        private readonly UserManager<AppUser> _UserManager;
        private readonly IMapper _mapper;

        public OptimizationController(IOptimizationService optimizationService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _optimizationService = optimizationService;
            _UserManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index2()
        {
            try
            {
                // Provide the absolute path to your Python script
                string pythonScriptPath = @"C:\ProjectGROUP\Module.py";

                // Execute the Python script using Process.Start
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "python"; // Assumes 'python' is in the system PATH
                start.Arguments = pythonScriptPath;
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        return Ok(new { Message = "Python script executed successfully", Output = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while executing the Python script", Message = ex.Message });
            }
        }


        public IActionResult Index()
        {
            var value = _optimizationService.TGetList();

            var count = value.Count();
            ViewBag.Count = count;

            return View(value);
        }


        [HttpGet]
        public IActionResult AddOptimization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOptimization(Optimization p)
        {
            try
            {

                {
                    p.P1_Weight = p.P1_Weight;
                    p.P2_Weight = p.P2_Weight;
                    p.P3_Weight = p.P3_Weight;
                    p.P4_Weight = p.P4_Weight;
                    p.P5_Weight = p.P5_Weight;
                    p.P6_Weight = p.P6_Weight;
                    p.P7_Weight = p.P7_Weight;
                    p.P8_Weight = p.P8_Weight;
                    p.P9_Weight = p.P9_Weight;
                    p.P10_Weight = p.P10_Weight;

                    p.G1_Penalty = p.G1_Penalty;
                    p.G2_Penalty = p.G2_Penalty;
                    p.G3_Penalty = p.G3_Penalty;
                    p.IsActive= true;

                    _optimizationService.TAdd(p);

                    return View(nameof(Index));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult UpdateOptimization(int id)
        {
            try
            {
                var values = _optimizationService.TGetById(id);
                var result = _mapper.Map<UpdateOptimizationModel>(values);

                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult UpdateOptimization(Optimization p, int id)
        {
            try
            {

                var value = _optimizationService.TGetById(id);

                p.Optimization_ID = id;
                p.P1_Weight = p.P1_Weight;
                p.P2_Weight = p.P2_Weight;
                p.P3_Weight = p.P3_Weight;
                p.P4_Weight = p.P4_Weight;
                p.P5_Weight = p.P5_Weight;
                p.P6_Weight = p.P6_Weight;
                p.P7_Weight = p.P7_Weight;
                p.P8_Weight = p.P8_Weight;
                p.P9_Weight = p.P9_Weight;
                p.P10_Weight = p.P10_Weight;

                p.G1_Penalty = p.G1_Penalty;
                p.G2_Penalty = p.G2_Penalty;
                p.G3_Penalty = p.G3_Penalty;
                p.IsActive = true;
                _optimizationService.TUpdate(p);

                return RedirectToAction("Index");


            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult DeleteOptimization(int id)
        {
            var value = _optimizationService.TGetById(id);
            _optimizationService.TDelete(value);

            return RedirectToAction("Index");
        }



    }
}
