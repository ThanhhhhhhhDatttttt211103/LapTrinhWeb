using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using QuanLySanBong.Models;
using System.Net;

namespace QuanLySanBong.Data
{
    public class DbInitializer
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using (var context = new FootballContext(serviceProvider
                .GetRequiredService<DbContextOptions<FootballContext>>()))
            {
                context.Database.EnsureCreated(); // Kiểm tra xem có cơ sở dữ liệu chưa thì thêm vào
                // look for any learners
                if (context.User.Any())
                {
                    return;
                }
                var users = new User[]
                {
                    new User{Username = "thanhdat1", Password = "12345678", PhoneNumber = "09855921360", LoaiUser = false},
                    new User{Username = "vanhoan1", Password = "12345678", PhoneNumber = "09855921360", LoaiUser = true},
                };
                foreach (var user in users)
                {
                    context.User.Add(user);
                }
                context.SaveChanges();

                var PlayGrounds = new PlayGround[]
                {
                    new PlayGround{PlayGroundName = "Sân bóng Thành Phát", PhoneNumber = "0985592136", Address = "Thường Tín1",  Image = "Anhtest1", Description = "ghiChuTest1"},
                    new PlayGround{PlayGroundName = "Sân bóng Yên Hòa", PhoneNumber = "0985592136", Address = "Thường Tín2", Image = "Anhtest2", Description = "ghiChuTest2"},

                };
                foreach (var playGround in PlayGrounds)
                {
                    context.PlayGround.Add(playGround);
                }
                context.SaveChanges();            
            }
        }
    }
}
