using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mysql
{
    /// <summary>
    /// mysql 视图
    /// </summary>
    public class View
    {
        /// <summary>
        /// 视图名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 来源表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public List<ViewField> FieldList { get; set; }
    }

    /// <summary>
    /// ViewExtension
    /// </summary>
    public static class ViewExtension
    {
        /// <summary>
        /// AddField
        /// </summary>
        /// <typeparam name="TMysqlView"></typeparam>
        /// <param name="mysqlView"></param>
        /// <param name="mysqlViewField"></param>
        /// <returns></returns>
        public static TMysqlView AddField<TMysqlView>(this TMysqlView mysqlView, ViewField mysqlViewField)
            where TMysqlView : View
        {
            if (mysqlView.FieldList == null)
            {
                mysqlView.FieldList = new List<ViewField>();
            }

            mysqlView.FieldList.Add(mysqlViewField);

            return mysqlView;
        }

        /// <summary>
        /// AddField
        /// </summary>
        /// <typeparam name="TMysqlView"></typeparam>
        /// <param name="mysqlView"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ViewField AddField<TMysqlView>(this TMysqlView mysqlView, string name)
            where TMysqlView : View
        {
            if (mysqlView.FieldList == null)
            {
                mysqlView.FieldList = new List<ViewField>();
            }

            ViewField mysqlViewField = new ViewField();
            mysqlViewField.Name = name;

            mysqlView.FieldList.Add(mysqlViewField);

            return mysqlViewField;
        }
    }
}
