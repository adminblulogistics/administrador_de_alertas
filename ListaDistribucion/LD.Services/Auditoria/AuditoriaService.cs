using LD.Entities;
using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using LD.Services.Interfaces.Auditoria;
using LD.Services.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Auditoria
{
    public class AuditoriaService : IAuditoriaService
    {
        private readonly IRepositoryAuditoria _repositoryAuditoria;
        IUserService _userService;
        private readonly IHttpContextAccessor _context;
        public AuditoriaService(IRepositoryAuditoria repositoryAuditoria, IUserService userService ,IHttpContextAccessor context)
        {
            _repositoryAuditoria = repositoryAuditoria;
            _userService = userService;
            _context = context;
        }
        public Respuesta insertarAuditoria(ACTIVITY_LOG log)
        {
            var user = _context.HttpContext.Session.GetInt32("IdUsuario");
            log.ID_USER = Convert.ToInt32(user);
            return _repositoryAuditoria.insertarAuditoria(log);
        }

        public List<ACTIVITY_LOG> obtenerAuditoriaPorOrganizacion(long id)
        {
            var lstLogs = _repositoryAuditoria.obtenerAuditoriaPorOrganizacion(id);
            foreach (var lst in lstLogs)
            {
                var user = _userService.obtenerUsuarioGBPorId(lst.ID_USER);
                lst.NAME_USER = user != null ? user.use_name + " " + user.use_lastName : "";
            }
            return lstLogs;
        }

        public Respuesta insertarAuditoriaStatusAlarm(STATUS_ALARMS_LOG log)
        {
            return _repositoryAuditoria.insertarAuditoriaStatusAlarm(log);
        }
    }
}
