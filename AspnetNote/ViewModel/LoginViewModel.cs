using System;
using System.ComponentModel.DataAnnotations;

namespace AspnetNote.ViewModel
{
    /// <summary>
    /// 로그인에 필요한 View모델을 만들어준다.
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage ="사용자 ID를 입력하세요.")]
        public String UserId { get; set; }

        [Required(ErrorMessage ="사용자 PW를 입력하세요.")]
        public String UserPassword { get; set; }
    }
}
