using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mysql.Engine
{
    /// <summary>
    /// CreateViewExtensino
    /// </summary>
    public static class CreateViewExtensino
    {
        /// <summary>
        /// TransformText
        /// </summary>
        /// <param name="createView"></param>
        /// <returns></returns>
        public static string TransformText(this CreateView createView)
        {
            var builder = new StringBuilder();

            new CreateViewEngine().Generate(createView, builder);

            return builder.ToString();
        }
    }
}
