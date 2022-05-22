using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Tringle.API.Filters;
using Tringle.API.Modules;
using Tringle.Core.ResponseDtos;
using Tringle.Service.Exceptions;
using Tringle.Service.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Fluent Validation yapýlandýrmasý
builder.Services.AddControllers(p => p.Filters.Add(new AsyncValidationFilter())).AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    config.ValidatorOptions.DefaultClassLevelCascadeMode = FluentValidation.CascadeMode.Continue;
    config.ValidatorOptions.DefaultRuleLevelCascadeMode = FluentValidation.CascadeMode.Stop;
    config.DisableDataAnnotationsValidation = true;
}).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Autofac yapilandirmasi
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(builder =>
            builder.RegisterModule(new AutofacModule()
        ));

// AutoMapper yapilandirmasi
builder.Services.AddAutoMapper(assemblies =>
                    assemblies.AddMaps
                    (
                        typeof(AccountMapProfile),
                        typeof(TransactionMapProfile)
                    ));

// Route url lower case olacak sekilde yapilandirildi
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Exception yapýlandýrmasý, ilerleyen zamnanlarda extension olarak yazýlabilir
app.UseExceptionHandler(option => option.Run(async context =>
{
    context.Response.ContentType = "application/json";

    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

    context.Response.StatusCode = exceptionFeature?.Error switch
    {
        ClientSideException => 400,
        UnauthorizedException => 401,
        ForbidException => 403,
        NotFoundException => 404,
        _ => 500,
    };

    var response = new ErrorDetailDto()
    {
        StatusCode = context.Response.StatusCode,
        Message = exceptionFeature?.Error.Message,
    };

    await context.Response.WriteAsJsonAsync(response);
}));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
