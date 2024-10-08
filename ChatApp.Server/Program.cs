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

            // Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://localhost:5001")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(5002); // HTTP
                options.ListenAnyIP(5000, listenOptions =>
                {
                    listenOptions.UseHttps(); // HTTPS
                });
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.MapHub<ChatHub>("/chathub");

            app.Run();
        }
    }
}
