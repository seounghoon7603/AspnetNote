using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.DataContext;
using AspnetNote.Models;
using AspnetNote.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspnetNote.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // ID, PW - 필수 ( Required 조건 체크 ) -- 기존 User 객체는 이름까지 Required 라서 ID , PW 만 필요한 View를 만들어준다.
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext()) // DB를 열고 닫겠다!
                {
                    // Linq 쿼리식 - 메서드 체이닝
                    // => : A Go to B
                    var user = db.Users.FirstOrDefault( u =>
                        u.UserId.Equals(model.UserId) && 
                        u.UserPassword.Equals(model.UserPassword)
                    );
                    if(user != null)
                    {
                        //로그인 성공
                        //HttpContext.Session.SetInt32(key, value); -- 세션에 등록하기
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);
                        return RedirectToAction("LoginSuccess", "Home"); // 로그인 성공 페이지로 이동
                        
                    }
                }
                //로그인 실패 
                ModelState.AddModelError(String.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }


        /// <summary>
        /// 회원가입 POST 전송
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using( var db = new AspnetNoteDbContext())
                {
                    db.Users.Add(model); // 메모리까지 올리고
                    db.SaveChanges();   // 실제 디비에 저장
                }
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

    }
}