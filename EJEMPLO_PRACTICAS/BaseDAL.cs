using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace EJEMPLO_PRACTICAS
{
    public class BaseDAL
    {
        public static List<T> ConsultarLista<T>() where T : class, new()
        {
            try
            {
                var context = new DBEJEMPLO();
                var query = context.Set<T>();
                return query.ToList<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        public static List<T> ConsultarLista<T, TKey>(Expression<Func<T, TKey>> orden) where T : class, new()
        {
            try
            {
                var context = new DBEJEMPLO();
                var query = context.Set<T>().OrderBy(orden);
                return query.ToList<T>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        public static List<T> ConsultarListaDesc<T, TKey>(Expression<Func<T, TKey>> orden) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().OrderByDescending(orden);
                    return query.ToList<T>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }
        public static List<T> ConsultarListaDesc<T, TKey>(Expression<Func<T, bool>> condicion, Expression<Func<T, TKey>> orden) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().Where(condicion).OrderByDescending(orden);
                    return query.ToList<T>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        public static List<T> ConsultarLista<T>(Expression<Func<T, bool>> condicion) where T : class, new()
        {
            try
            {
                var context = new DBEJEMPLO();
                var query = context.Set<T>().Where(condicion);
                return query.ToList<T>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static List<T> ConsultarListaDistinct<T>(Expression<Func<T, bool>> condicion) where T : class, new()
        {
            try
            {
                var context = new DBEJEMPLO();
                var query = context.Set<T>().Where(condicion).Distinct();
                return query.ToList<T>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static List<T> ConsultarLista<T, TKey>(int seleccion, Expression<Func<T, bool>> condicion, Expression<Func<T, TKey>> orden) where T : class, new()
        {
            try
            {
                var context = new DBEJEMPLO();
                var query = context.Set<T>().Where(condicion).OrderBy(orden).Take(seleccion);
                return query.ToList<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static List<T> ConsultarLista<T, TKey>(int seleccion, Expression<Func<T, TKey>> orden) where T : class, new()
        {
            try
            {
                var context = new DBEJEMPLO();
                var query = context.Set<T>().OrderBy(orden).Take(seleccion);
                return query.ToList<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Metodo que devuelve una lista de objetos recibe como parametros una condicion y un orden
        /// </summary> 
        /// <param name="condicion">condición </param>
        /// <param name="orden">orden que le daremos a la tabla</param>
        /// <param name="exp"></param>
        /// <returns>Lista generica</returns>
        public static List<T> ConsultarLista<T, TKey>(Expression<Func<T, bool>> condicion, Expression<Func<T, TKey>> orden) where T : class, new()
        {
            try
            {
                var context = new DBEJEMPLO();
                var query = context.Set<T>().Where(condicion).OrderBy(orden);
                return query.ToList<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static List<T> ConsultarListaDistinct<T, TKey>(Expression<Func<T, bool>> condicion, Expression<Func<T, TKey>> orden) where T : class, new()
        {
            try
            {
                var context = new DBEJEMPLO();

                var query = context.Set<T>().Where(condicion).OrderBy(orden).Distinct();
                return query.ToList<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static List<object> ConsultarLista<T, TKey>(Expression<Func<T, TKey>> orden, Expression<Func<T, object>> filtro) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().OrderBy(orden).Select(filtro);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public static List<object> ConsultarLista<T>(Expression<Func<T, bool>> condicion, Expression<Func<T, object>> filtro) where T : class, new()
        {
            try
            {
                var context = new DBEJEMPLO();
                var query = context.Set<T>().Where(condicion).Select(filtro);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static List<object> ConsultarLista<T>(Expression<Func<T, object>> filtro) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().Select(filtro);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static List<object> ConsultarLista<T, TKey>(Expression<Func<T, bool>> condicion, Expression<Func<T, TKey>> orden, Expression<Func<T, object>> filtro) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().Where(condicion).OrderBy(orden).Select(filtro);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static List<TKey> ConsultarEscalar<T, TKey>(Expression<Func<T, TKey>> filtro) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().Select(filtro);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static List<TKey> ConsultarEscalar<T, TKey>(Expression<Func<T, bool>> condicion,
            Expression<Func<T, TKey>> filtro) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().Where(condicion).Select(filtro);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static List<TKey> ConsultarEscalarDictinct<T, TKey>(Expression<Func<T, bool>> condicion,
            Expression<Func<T, TKey>> filtro) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().Where(condicion).Select(filtro).Distinct();
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static List<TKey> ConsultarEscalarDisct<T, TKey>(Expression<Func<T, bool>> condicion,
            Expression<Func<T, TKey>> filtro) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().Where(condicion).Select(filtro).Distinct();
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static List<TKey> ConsultarEscalar<T, TKey, TOrder>(Expression<Func<T, bool>> condicion,
            Expression<Func<T, TKey>> filtro, Expression<Func<T, TOrder>> orden) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().Where(condicion).OrderBy(orden).Select(filtro);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static List<TKey> ConsultarEscalar<T, TKey, TOrder>(Expression<Func<T, TKey>> filtro, Expression<Func<T, TOrder>> orden) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().OrderBy(orden).Select(filtro);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static List<TKey> ConsultarEscalarDesc<T, TKey, TOrder>(Expression<Func<T, bool>> condicion,
            Expression<Func<T, TKey>> filtro, Expression<Func<T, TOrder>> orden) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().Where(condicion).OrderByDescending(orden).Select(filtro);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }




        /// <summary>
        /// Metodo para Eliminar Todos los Registros que cumplen con la condición
        /// </summary>
        /// <typeparam name="T">Clase</typeparam>
        /// <param name="condicion">Expresion lambda la cual expresa una condición</param>
        /// <returns>Devuelve un booleano el cual nos dice si se eliminaron los registros correctamente</returns>
        public static bool EliminarTodos<T>(Expression<Func<T, bool>> condicion) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var objDelete = context.Set<T>().Where(condicion);

                    foreach (var objT in objDelete)
                    {
                        if (objT != null) context.Set<T>().Remove(objT);
                    }

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public static bool EliminarTodos2<T>(Expression<Func<T, bool>> condicion) where T : class
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var query = context.Set<T>().Where(condicion);

                    string selectSql = query.ToString();
                    string deleteSql = "DELETE [Extent1] " + selectSql.Substring(selectSql.IndexOf("FROM"));

                    var internalQuery = query.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(field => field.Name == "_internalQuery").Select(field => field.GetValue(query)).First();
                    var objectQuery = internalQuery.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(field => field.Name == "_objectQuery").Select(field => field.GetValue(internalQuery)).First() as ObjectQuery;
                    var parameters = objectQuery.Parameters.Select(p => new SqlParameter(p.Name, p.Value)).ToArray();

                    return context.Database.ExecuteSqlCommand(deleteSql, parameters) > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public static bool Eliminar<T>(Expression<Func<T, bool>> condicion) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var objDelete = context.Set<T>().Where(condicion).FirstOrDefault();

                    if (objDelete != null) context.Set<T>().Remove(objDelete);

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static bool Agregar<T>(T objT) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    context.Set<T>().Add(objT);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static bool AddOrUpdate<T>(T obj, Func<T, bool> match) where T : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var lstObjT = (from objeto in context.Set<T>().Where<T>(match)
                                   select objeto).ToList();

                    if (lstObjT.Count > 0)
                    {
                        var dbEntityEntry = context.Entry<T>(obj);
                        if (dbEntityEntry.State == EntityState.Detached)
                        {
                            var set = context.Set<T>();
                            T attachedEntity = set.Local.SingleOrDefault(match);

                            if (attachedEntity != null)
                            {
                                var attachedEntry = context.Entry(attachedEntity);
                                attachedEntry.CurrentValues.SetValues(obj);
                                return context.SaveChanges() > 0;
                            }
                            dbEntityEntry.State = EntityState.Modified; // This should attach entity
                            return context.SaveChanges() > 0;
                        }
                        dbEntityEntry.State = EntityState.Added;
                        return context.SaveChanges() > 0;
                    }
                    context.Set<T>().Add(obj);
                    return context.SaveChanges() > 0;
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return false;
        }

        internal static EntitySetBase GetEntitySet<TEntity>(ObjectContext context)
        {
            var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
            var baseType = GetBaseType(typeof(TEntity));
            var entitySet = container.BaseEntitySets
                      .Where(item => item.ElementType.Name.Equals(baseType.Name))
                      .FirstOrDefault();

            return entitySet;
        }

        private static Type GetBaseType(Type type)
        {
            var baseType = type.BaseType;
            if (baseType != null && baseType != typeof(EntityObject))
            {
                return GetBaseType(type.BaseType);
            }
            return type;
        }

        /// <summary>
        /// Metodo que implementa Joins LEFT (tabla1, tabla2, tipo de dato de la union, object)
        /// </summary> 
        /// <param name="join1">expresión lambda </param>
        /// <param name="join2">expresión lambda </param>
        /// <param name="exp"></param>
        /// <returns>Colección generica</returns>
        public static List<TResult> GetDataTable<T, T1, TKey, TResult>(Expression<Func<T, TKey>> join1, Expression<Func<T1, TKey>> join2, Expression<Func<T, T1, TResult>> exp)
            where T : class, new()
            where T1 : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var dbQuery = context.Set<T>().Join<T, T1, TKey, TResult>(context.Set<T1>(), join1, join2, exp);
                    return (from obj in dbQuery
                            orderby obj
                            select obj).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }



        }

        public static List<TResult> GetDataTable2<T, T1, TKey, TResult>(Expression<Func<T, TKey>> join1, Expression<Func<T1, TKey>> join2, Expression<Func<T, T1, TResult>> exp, Expression<Func<T, bool>> match)
            where T : class, new()
            where T1 : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var dbQuery = context.Set<T>().Where<T>(match).Join<T, T1, TKey, TResult>(context.Set<T1>(), join1, join2, exp);
                    return (from obj in dbQuery
                            orderby obj
                            select obj).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public static List<TResult> GetDataTable<T, T1, TKey, TResult>(Expression<Func<T, TKey>> join1, Expression<Func<T1, TKey>> join2, Expression<Func<T, T1, TResult>> exp, Expression<Func<T, bool>> match)
            where T : class, new()
            where T1 : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var dbQuery = context.Set<T>().Where<T>(match).Join<T, T1, TKey, TResult>(context.Set<T1>(), join1, join2, exp);
                    return (from obj in dbQuery
                            orderby obj
                            select obj).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public static List<TResult> GetDataTable<T, T1, TKey, TResult, TOrder>(Expression<Func<T, TKey>> join1, Expression<Func<T1, TKey>> join2, Expression<Func<T, T1, TResult>> exp, Expression<Func<T, bool>> match, Expression<Func<T, TOrder>> order)
            where T : class, new()
            where T1 : class, new()
        {
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var dbQuery = context.Set<T>().Where<T>(match).OrderBy(order).Join<T, T1, TKey, TResult>(context.Set<T1>(), join1, join2, exp);
                    return (from obj in dbQuery
                            orderby obj
                            select obj).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public static DataTable ObtenDataTable()
        {
            var dbTable = new DataTable();
            var dt = new DataColumn();
            var row = dbTable.NewRow();

            dbTable.Columns.Add(dt);
            dt.ColumnName = "nombres";
            row["nombres"] = "sergio";
            dbTable.Rows.Add(row);
            return dbTable;
        }


        //nuevos 
        public static bool ActualizaMultiple<T>(Expression<Func<T, bool>> condicion, Action<T> action) where T : class, new()
        {
            try
            {
                var context = new DBEJEMPLO();
                var lista = context.Set<T>().Where(condicion).ToList<T>();
                lista.ForEach(action);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static bool ActualizaTodos<T>(Expression<Func<T, bool>> match, Action<T> action)
        where T : class, new()
        {
            var resp = false;
            try
            {
                using (var context = new DBEJEMPLO())
                {
                    var items = context.Set<T>().Where(match);

                    foreach (var item in items)
                    {
                        action(item);
                    }

                    resp = context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error: {0}", ex.Message));
            }

            return resp;

        }
    }
}
