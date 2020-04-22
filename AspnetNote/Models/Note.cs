using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetNote.Models
{
    /// <summary>
    /// 게시판 객체
    /// </summary>
    public class Note
    {
        /// <summary>
        /// 게시물 번호
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        /// <summary>
        /// 게시물 제목
        /// </summary>
        [Required(ErrorMessage ="제목을 입력해주세요.")] // Not Null 어노테이션
        public String NoteTitle { get; set; }

        /// <summary>
        /// 게시물 내용
        /// </summary>
        [Required(ErrorMessage = "내용을 입력하세요.")] // Not Null 어노테이션
        public String NoteContents { get; set; }

        /// <summary>
        /// 작성자번호
        /// </summary>
        [Required] // Not Null 어노테이션
        public int UserNo { get; set; }

        [ForeignKey("UserNo")] // FK 설정 어노테이션
        public virtual User User { get; set; } // EntityFramework 에서는 다른 테이블의 것을 가지고 올때 virtual 적어주는걸 권장함


    }
}
