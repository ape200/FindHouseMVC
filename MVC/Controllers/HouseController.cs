using API.Models;
using CRM_MVC.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HouseController : Controller
    {
        #region 依赖注入
        private IConfiguration _configuration;

        public HouseController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        #endregion

        #region Session 存储
        public void GetSession()
        {
            string json = Encoding.UTF8.GetString(HttpContext.Session.Get("user"));
            EmployeeInfo em = JsonConvert.DeserializeObject<EmployeeInfo>(json);
            ViewBag.em = em;
            string result = APIClient.GetApiResult("get", "api/Values/GetMenu/" + em.EId);
            List<MenuInfo> list = JsonConvert.DeserializeObject<List<MenuInfo>>(result);
            ViewBag.menu = list;
            ViewBag.pmenu = list.Where(m => m.PId == 0).ToList();
        }
        #endregion


        #region  首页显示
        public ActionResult GetHouse()
        {
            string url = _configuration["apiUrl"];
            ViewBag.url = url;

            GetSession();

            return View();
        }
        #endregion

        #region  登录 权限显示
        //登录
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string pwd)
        {
            string json = APIClient.GetApiResult("get", $"api/Values/Login?name={username}&pass={pwd}");
            if (!string.IsNullOrEmpty(json))
            {
                HttpContext.Session.SetString("user", json);
                return RedirectToAction("GetHouse");
            }
            return View();
        }
        // 系统主页面_ls
        public IActionResult Index()
        {
            GetSession();
            return View();
        }

        #endregion

        #region 百度地图
        public IActionResult BaiDuMap()
        {
            GetSession();
            return View();
        }
        #endregion

        #region 张梦早 用户模块
        //用户列表显示
        public IActionResult UsersShow()
        {
            GetSession();
            return View();
        }
        //用户关注
        public IActionResult attentionshow(int id)
        {
            GetSession();
            ViewBag.id = id;
            return View();
        }
        //用户登录
        public IActionResult UserLogin()
        {
            return View();
        }
        //用户详情
        public ActionResult particulars(int id)
        {
            GetSession();
            ViewBag.id = id;
            return View();
        }
        //注册页面
        public ActionResult register()
        {
            GetSession();
            return View();
        }

        #endregion

        #region 张怡帆 二手房
        public ActionResult GetHouseSe()
        {
            GetSession();
            string url = _configuration["apiUrl"];
            ViewBag.url = url;
            return View();
        }
        #endregion

        #region 李乐楠 出租房
        /// <summary>
        /// 新房显示
        /// </summary>
        /// <returns></returns>
        public ActionResult AddResoldApartment()
        {
            GetSession();
            string url = _configuration["apiUrl"];
            ViewBag.url = url;
            return View();
        }
        #endregion

        #region 焦子涵 新房
        //显示
        public IActionResult NewHouseShow()
        {
            GetSession();
            return View();
        }
        //添加
        public IActionResult AddNewHome()
        {
            GetSession();
            return View();
        }
        /// <summary>
        /// 新房详细信息
        /// </summary>
        /// <returns></returns>
        public IActionResult NewHomeDetial(int id)
        {
            GetSession();
            ViewBag.id = id;
            return View();
        }
        #endregion

    }
}
