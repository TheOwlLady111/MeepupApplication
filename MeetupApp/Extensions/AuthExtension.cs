using Business.Additional;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MeetupApp.Extensions
{
    public static class AuthExtension
    {
        public static void AddJwtBearerAuth(this IServiceCollection services, JwtOptions options)
        {
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.RequireHttpsMetadata = false;
                op.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = options.Issuer,

                    ValidateAudience = true,
                    ValidAudience = options.Audience,

                    ValidateLifetime = true,

                    IssuerSigningKey = options.SymmetricSecurityKey,
                    ValidateIssuerSigningKey = true,

                    ClockSkew = TimeSpan.Zero
                };
            });

        }


        public static void AddPoliciesService(this IServiceCollection services)
        {
            services.AddAuthorization(op =>
            {
                op.AddPolicy(Policy.ForAdminOnly,
                p => p.RequireRole(Policy.ForAdminOnly));

                op.AddPolicy(Policy.ForUserOnly,
                p => p.RequireRole(Policy.ForUserOnly));
            });

        }
    }
}