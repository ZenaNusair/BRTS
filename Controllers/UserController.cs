
using BRTS_System.Date;
using BRTS_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BRTS_System.Controllers
{
    public class UserController : Controller
    {
        private SystemDbContext _context;

        public UserController(SystemDbContext context)
        {
            this._context = context;
        }

        

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            bool empty = checkEmpty(user);
            bool duplicat = checkUsername(user.Username);


            if (empty)
            {
                if (duplicat)
                {
                    _context.user.Add(user);
                    _context.SaveChanges();

                    TempData["Msg"] = "the data was saved";
                    return View();
                }
                else
                {
                    TempData["Msg"] = "Please Change the username";
                    return View();
                }
            }
            else
            {
                TempData["Msg"] = "Please fill all input ";
                return View();
            }



        }
        public bool checkUsername(string username)
        {
           
            User user = _context.user.Where(u => u.Username.Equals(username)).FirstOrDefault();
            if (user != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool checkEmpty(User user)
        {
            if (String.IsNullOrEmpty(user.Username)) return false;
            else if (String.IsNullOrEmpty(user.name)) return false;
            else if (String.IsNullOrEmpty(user.Email)) return false;
            else if (String.IsNullOrEmpty(user.PhoneNumber)) return false;
            else if (String.IsNullOrEmpty(user.Gender)) return false;
            else if (String.IsNullOrEmpty(user.password)) return false;

            else
                return true;
        }
        

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login userlogin)
        {
            if (ModelState.IsValid)
            {
                string username = userlogin.username;
                string password = userlogin.password;

                User user = _context.user.Where(
                     u => u.Username.Equals(username) &&
                     u.password.Equals(password)
                     ).FirstOrDefault();

                Admin admin = _context.admin.Where(
                    a => a.username.Equals(username)
                    &&
                    a.password.Equals(password)
                    ).FirstOrDefault();




                if (user != null)
                {
                    HttpContext.Session.SetInt32("userID", user.ID);

                    return RedirectToAction("BookingList");
                }
                else if (admin != null)
                {

                    HttpContext.Session.SetInt32("adminID", admin.ID);

                    return RedirectToAction("Index", "Trip");
                }
                else
                {
                    TempData["Msg"] = "The user Not Found";
                }


            }
            else
            {

            }
            return View();
        }
        public IActionResult BookingList()
        {
            int userID = (int)HttpContext.Session.GetInt32("userID");

            List<int> lst = _context.user_trip.Where(
                t => t.user.ID == userID
                ).Select(s => s.trip.TripID).ToList(); ;


            List<Trip> lst_trip = _context.trip.Where(
                t => lst.Contains(t.TripID) == false
                ).ToList(); ;

            return View(lst_trip);
        }

        public IActionResult booktrip(int id)
        {
            int tripID = id;

            int userID = (int)HttpContext.Session.GetInt32("userID");

            User_Trip user_trip = new User_Trip();
            user_trip.user = _context.user.Find(userID);
            user_trip.trip = _context.trip.Find(tripID);

            _context.user_trip.Add(user_trip);
            _context.SaveChanges();

            return RedirectToAction("BookinList");

        }

        public IActionResult BookinList()
        {
            int userID = (int)HttpContext.Session.GetInt32("userID");

            List<int> lst_team = _context.user_trip.Where(
               t => t.user.ID == userID
               ).Select(s => s.trip.TripID).ToList();


            List<Trip> lst = _context.trip.Where(
                t => lst_team.Contains(t.TripID)
                ).ToList();

            return View(lst);
        }

        public IActionResult deletebooking(int tripId)
        {
            int userID = (int)HttpContext.Session.GetInt32("userID");

            User_Trip user_trip = _context.user_trip.Where(
                t => t.user.ID == userID && t.trip.TripID == tripId
                ).FirstOrDefault();

            _context.user_trip.Remove(user_trip);
            _context.SaveChanges();

            return RedirectToAction("BookinList");
        }


    }
}
