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
        /// <typeparam name="TView"></typeparam>
        /// <param name="view"></param>
        /// <param name="mysqlViewField"></param>
        /// <returns></returns>
        public static TView AddField<TView>(this TView view, ViewField mysqlViewField)
            where TView : View
        {
            if (view.FieldList == null)
            {
                view.FieldList = new List<ViewField>();
            }

            view.FieldList.Add(mysqlViewField);

            return view;
        }

        /// <summary>
        /// AddField
        /// </summary>
        public static ViewField AddField<TView>(this TView mysqlView, string name, string tableFieldName)
            where TView : View
        {
            if (mysqlView.FieldList == null)
            {
                mysqlView.FieldList = new List<ViewField>();
            }

            ViewField viewField = new ViewField();
            viewField.Name = name;
            viewField.TableFieldName = tableFieldName;

            mysqlView.FieldList.Add(viewField);

            return viewField;
        }
    }
}
