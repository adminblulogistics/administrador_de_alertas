using LD.DataCotizador;
using LD.DataGB;
using LD.DataLD;
using LD.Integrations.Common;
using LD.Integrations.Common.Interfaces;
using LD.Integrations.SaleForce;
using LD.Repositories;
using LD.Repositories.Interfaces;
using LD.Services;
using LD.Services.Alarms;
using LD.Services.Auditoria;
using LD.Services.Chrontab;
using LD.Services.Companys;
using LD.Services.Contact;
using LD.Services.FTP;
using LD.Services.Instructives;
using LD.Services.Integration;
using LD.Services.Interfaces.Alarms;
using LD.Services.Interfaces.Auditoria;
using LD.Services.Interfaces.Companys;
using LD.Services.Interfaces.Contact;
using LD.Services.Interfaces.FTP;
using LD.Services.Interfaces.Instructives;
using LD.Services.Interfaces.Integration;
using LD.Services.Interfaces.Notifications;
using LD.Services.Interfaces.Organizations;
using LD.Services.Interfaces.Parameters;
using LD.Services.Interfaces.SendEmails;
using LD.Services.Interfaces.Users;
using LD.Services.Interfaces.xmlCargoWise;
using LD.Services.Notifications;
using LD.Services.Organizations;
using LD.Services.Parameters;
using LD.Services.SendEmails;
using LD.Services.Users;
using LD.Services.xmlCargoWise;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ListaDistribucionContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ListaDistribucionConnection")));
builder.Services.AddDbContext<GB_GLOBALContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GBConnection")));
builder.Services.AddDbContext<BPCotizadorContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CotizadorConnection")));
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IRepositoryInstructive, RepositoryInstructive>();
builder.Services.AddScoped<IRepositoryUserLD, RepositoryUserLD>();
builder.Services.AddScoped<IRepositoryUserGB, RepositoryUserGB>();
builder.Services.AddScoped<IRepositoryParameters, RepositoryParameters>();
builder.Services.AddScoped<IRepositoryCompany, RepositoryCompany>();
builder.Services.AddScoped<IRepositoryOrganizationLD, RepositoryOrganizationLD>();
builder.Services.AddScoped<IRepositoryOrganizationBODTER, RepositoryOrganizationBODTER>();
builder.Services.AddScoped<IRepositoryCustomerCT,RepositoryCustomerCT>();
builder.Services.AddScoped<IRepositoryContact, RepositoryContact>();
builder.Services.AddScoped<IRepositorySalesSupport, RepositorySalesSupport>();
builder.Services.AddScoped<IRepositoryAlarm, RepositoryAlarm>();
builder.Services.AddScoped<IRepositoryUserCOT, RepositoryUserCOT>();
builder.Services.AddScoped<IRepositoryAuditoria, RepositoryAuditoria>();

builder.Services.AddScoped<IInstructiveService, InstructiveService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IParametersService, ParametersService>();
builder.Services.AddScoped<IIntegrationService, IntegrationService>();
builder.Services.AddScoped<ICustomRest, CustomRest>();
builder.Services.AddScoped<IIntegrationSalesForce, IntegrationSalesForce>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IContactService, ContactService>(); 
builder.Services.AddScoped<IAlarmService, AlarmService>();
builder.Services.AddScoped<INotificationsService, NotificationsService>();
builder.Services.AddScoped<ISendEmailsService, SendEmailsService>();
builder.Services.AddScoped<IXMLCargoWiseService, XMLCargoWiseService>();
builder.Services.AddScoped<IAuditoriaService, AuditoriaService>();
builder.Services.AddScoped<IFTPManager, FTPManager>();
builder.Services.AddTransient<Microsoft.Extensions.Hosting.IHostedService, ScheduledTask>();


builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.ConfigureApplicationCookie(o =>
{
    o.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    o.SlidingExpiration = true;
});
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
