using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.DataContext;
using AspnetNote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspnetNote.Controllers
{
    public class NoteController : Controller
    {
        /// <summary>
        /// 게시판 리스트 출력
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                // 로그인 안된 상태
                return RedirectToAction("Login", "Account");
            }
            using (var db = new AspnetNoteDbContext())
            {
                var list = db.Notes.ToList();
                return View(list);
            }
        }

        /// <summary>
        /// 게시물 상세내용
        /// </summary>
        /// <param name="noteNo"></param>
        /// <returns></returns>
        public IActionResult Detail(int noteNo)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                // 로그인 안된 상태
                return RedirectToAction("Login", "Account");
            }

            using(var db = new AspnetNoteDbContext())
            {
                var note = db.Notes.FirstOrDefault(n => n.NoteNo.Equals(noteNo));
                return View(note);
            }

        }

        /// <summary>
        /// 게시물 추가
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                // 로그인 안된 상태
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(Note model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                // 로그인 안된 상태
                return RedirectToAction("Login", "Account");
            }

            model.UserNo = int.Parse( HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString() );

            // Note 에서 받아야할 모든 값을 받았는지 체크 ( Note의 [Reqired] 가 있는 컬럼들 )
            if (ModelState.IsValid)
            {
                using ( var db = new AspnetNoteDbContext())
                {
                    db.Notes.Add(model);
                    if(db.SaveChanges() > 0) // 성공개수 반환함.
                    {
                        return Redirect("Index"); // 동일한 컨트롤러면 RedirectToAction 안 써도 됨
                    }
                }
                ModelState.AddModelError(String.Empty, "게시물을 저장할 수 없습니다."); // 전역적 에러 메세지
            }
            return View(model); // 뭔가 잘못된게 있으면 model 넘겨서 어떤게 잘못된지 찾는다.
        }


        /// <summary>
        /// 게시물 수정
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// 게시물 삭제
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete()
        {
            return View();
        }
    }
}