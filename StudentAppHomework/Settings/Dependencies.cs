using Core.Services;
using StudentAppHomework.Repositories;
using StudentAppHomework.Services;
using StudentAppHomework.DBContext;

namespace StudentAppHomework.Settings
{
    public class Dependencies
    {
        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();
            applicationBuilder.Services.AddDbContext<StudentAppContext>();

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddScoped<AuthorizationService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
            services.AddScoped<RepositoryBase>();
            services.AddScoped<ClassRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<StudentRepository>();   
            services.AddScoped<GradeRepository>();   
        }
    }
}
