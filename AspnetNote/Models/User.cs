using System;
using System.ComponentModel.DataAnnotations;

namespace AspnetNote.Models
{
    /// <summary>
    /// 사용자 객체
    /// </summary>
    public class User
    {
        /// <summary>
        /// 사용자 번호 
        /// </summary>
        [Key]   // PK 설정 어노테이션
        public int UserNo { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required(ErrorMessage ="사용자 이름을 입력하세요.")]  // Not Null 설정 어노테이션
        public String UserName { get; set; }

        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required(ErrorMessage ="사용자 ID를 입력하세요.")]  // Not Null 설정 어노테이션
        public String UserId { get; set; }

        /// <summary>
        /// 사용자 비밀번호
        /// </summary>
        [Required(ErrorMessage ="사용자 비밀번호를 입력하세요.")]  // Not Null 설정 어노테이션
        public String UserPassword { get; set; }
    }
}
