using ChatApp.Server.Hubs;

namespace ChatApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add SignalR
            builder.Services.AddSignalR();

            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //    options.ListenLocalhost(7288, listenOptions =>
            //    {
            //        listenOptions.UseHttps(); // HTTPS on localhost:7288
            //    });
            //    options.ListenAnyIP(5022); // HTTP on any IP at port 5022
            //});

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.MapHub<ChatHub>("/chathub");

            app.Run();
        }
    }
}
