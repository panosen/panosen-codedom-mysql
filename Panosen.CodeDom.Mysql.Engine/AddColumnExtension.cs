using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mysql.Engine
{
    /// <summary>
    /// AddColumnExtension
    /// </summary>
    public static class AddColumnExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        /// <param name="addColumn"></param>
        /// <returns></returns>
        public static string TransformText(this AddColumn addColumn)
        {
            var builder = new StringBuilder();

            new AddColumnEngine().Generate(addColumn, builder);

            return builder.ToString();
        }
    }
}
