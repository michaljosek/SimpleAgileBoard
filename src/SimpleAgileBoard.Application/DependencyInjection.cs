using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Common.Behaviours;
using SimpleAgileBoard.Application.Lanes.Services;
using SimpleAgileBoard.Application.Notes.Services;
using SimpleAgileBoard.Application.User.Services;

namespace SimpleAgileBoard.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddTransient<IBoardRepository, BoardRepository>();
            services.AddTransient<ILaneRepository, LaneRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();

            services.AddTransient<IUserManagerWrapper, UserManagerWrapper>();
            
            return services;
        }

    }
}
