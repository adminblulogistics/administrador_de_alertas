using LD.Utilities.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Common
{
    public abstract partial class BaseServiceApplication<T> where T : class, new()
    {
        #region Metodo expuesto para Validaciones Crear, Editar y Eliminar
        /// <summary>
        /// Metodo expuesto para realizar implementaciones de negocio que permitan garantizar la Creación Correcta del oEntity
        /// </summary>
        /// <param name="entity">Referencia del objeto que se va a Crear</param>
        protected virtual void ValidationsToCreate(T entity) { entity.TrimAll(); }

        /// <summary>
        /// Metodo expuesto para realizar implementaciones de negocio que permitan garantizar la Edición Correcta del oEntity
        /// </summary>
        /// <param name="entity">Referencia del objeto que se va a Editar</param>
        protected virtual void ValidationsToEdit(T entity) { entity.TrimAll(); }

        /// <summary>
        /// Metodo expuesto para realizar implementaciones de negocio que permitan garantizar la Eliminación Correcta del oEntity
        /// </summary>
        /// <param name="entity">Referencia del objeto que se va a Eliminar.</param>
        protected virtual void ValidationsToDelete(T entity) { }
        #endregion
    }
}
