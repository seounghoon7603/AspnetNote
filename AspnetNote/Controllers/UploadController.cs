using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspnetNote.Controllers
{
    public class UploadController : Controller
    {
        // asp.net 의 환경을 알려줌.. ( 어느 폴더에 접근하고 싶으면 손쉽게 접근할 수 있게 해줌 )
        private readonly IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        // route 는 url이 너무 길때 재정의 해줄 수 있음.
        [HttpPost, Route("api/upload")]
        public async Task<IActionResult> ImageUpload(IFormFile file) // input 박스의 파일을 파라미터로 받아줄수 있도록 해줌 asp.net core 에만 있음
        {
            // # 이미지나 파일을 업로드 할 때 필요한 구성
            // 1. Path(경로) - 어디에 저장할지 결정
            var path = Path.Combine(_environment.WebRootPath, @"images\upload");
            // 2. Name(이름) - DateTime, GUID + GUID( 난수생성 )
            // 3. Extension(확장자) - jpg, png... txt
            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";

            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Ok(new { file="/images/upload/" + fileName, success= true });

            // # URL 접근 방식
            // ASP.NET - 호스트명/ + api/upload
            // Javascript - 호스트명 + /api/upload
            // --- ASP.nET은 호스트명 끝에 자동으로 / 가 붙지만 javascript 에서는 붙지않는다.

        }
    }
}