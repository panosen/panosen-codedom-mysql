using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mysql
{
    /// <summary>
    /// AddColumn
    /// </summary>
    public class AddColumn
    {
        /// <summary>
        /// Table
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// FieldList
        /// </summary>
        public List<Field> FieldList { get; set; }
    }
}
