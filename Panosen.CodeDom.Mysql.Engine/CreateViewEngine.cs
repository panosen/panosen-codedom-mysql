using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mysql.Engine
{
    /// <summary>
    /// CreateViewEngine
    /// </summary>
    public class CreateViewEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="createView"></param>
        /// <param name="codeWriter"></param>
        public void Generate(CreateView createView, CodeWriter codeWriter)
        {
            if (createView.View == null)
            {
                return;
            }

            Generate(createView.View, codeWriter);
        }

        private void Generate(View view, CodeWriter codeWriter)
        {
            codeWriter.WriteLine($"CREATE VIEW `{view.Name ?? string.Empty}` AS")
                .WriteLine("SELECT");

            GenerateFieldList(view, codeWriter);

            codeWriter.WriteLine("FROM")
                .WriteLine($"  `{view.TableName}`;");
        }

        private void GenerateFieldList(View view, CodeWriter codeWriter)
        {
            if (view.FieldList == null || view.FieldList.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < view.FieldList.Count; i++)
            {
                var field = view.FieldList[i];

                codeWriter.Write($"  `{field.TableFieldName ?? string.Empty}` AS `{field.Name ?? string.Empty}`");

                if (i < view.FieldList.Count - 1)
                {
                    codeWriter.Write(",");
                }

                codeWriter.WriteLine();
            }
        }
    }
}
