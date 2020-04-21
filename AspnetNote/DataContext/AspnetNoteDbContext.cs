using AspnetNote.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.DataContext
{
    public class AspnetNoteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            // https://www.connectionstrings.com/ 에 가서 sql server 에서 복사해오기
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=AspnetNoteDb;User Id=sa;Password=tjdgns18!;");
            
            // 패키지 관리자 콘솔에서 마이그레이션 해줘야 한다.
            // add-migration 이름

            // 마이그레이션 폴더 생성되면 실제 DB 만들어줘야한다.
            // update-database
        }

    }
}
