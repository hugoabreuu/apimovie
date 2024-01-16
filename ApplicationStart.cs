using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;

namespace WebApi;
public static class ApplicationStart
{
    public static WebApplicationBuilder CustomWebAppBuilder(WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        string connectionString = builder.Configuration.GetConnectionString("csDB")!;

        #region default services
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        #endregion

        #region problema de referência circular
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        });
        #endregion

        #region Adicionando os contextos de banco de dados
        builder.Services.AddDbContext<AppDbContext>(x => x.UseLazyLoadingProxies().UseSqlServer(connectionString));
        builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));
        #endregion

        #region configurando Identity
        //configurando o identity
        builder.Services
            .AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();
            
        //configurações do padrão de senha 
        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        });
        #endregion

        #region configurando Mapper
        var asemblies = AppDomain.CurrentDomain.GetAssemblies();
        builder.Services.AddAutoMapper(asemblies);
        #endregion

        #region configurando jwt
        builder.Services.AddAuthentication(x =>
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme
        ).AddJwtBearer(options =>
        {
            //transferir chave para um secret
            var key = Encoding.UTF8.GetBytes("aLKvrZDNMteKav5uXPr4RbyBehFVivQj");

            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        });
        #endregion

        #region injetando os serviços
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<MovieService>();
        builder.Services.AddScoped<TokenService>();
        builder.Services.AddScoped<EnderecoService>();
        builder.Services.AddScoped<CinemaService>();
        builder.Services.AddScoped<SessaoService>();
        #endregion

        return builder;
    }
}
