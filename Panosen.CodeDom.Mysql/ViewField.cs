using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mysql
{
    /// <summary>
    /// 视图的字段
    /// </summary>
    public class ViewField
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 表字段名称
        /// </summary>
        public string TableFieldName { get; set; }
    }

    /// <summary>
    /// MysqlViewFieldExtension
    /// </summary>
    public static class MysqlViewFieldExtension
    {
        /// <summary>
        /// SetName
        /// </summary>
        public static TMysqlViewField SetName<TMysqlViewField>(this TMysqlViewField mysqlViewField, string name)
            where TMysqlViewField : ViewField
        {
            mysqlViewField.Name = name;

            return mysqlViewField;
        }

        /// <summary>
        /// SetTableFieldName
        /// </summary>
        public static TMysqlViewField SetTableFieldName<TMysqlViewField>(this TMysqlViewField mysqlViewField, string tableFieldName)
            where TMysqlViewField : ViewField
        {
            mysqlViewField.TableFieldName = tableFieldName;

            return mysqlViewField;
        }
    }
}
