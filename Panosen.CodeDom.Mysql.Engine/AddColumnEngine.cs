using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mysql.Engine
{
    /// <summary>
    /// AddColumnEngine
    /// </summary>
    public class AddColumnEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="addColumn"></param>
        /// <param name="codeWriter"></param>
        public void Generate(AddColumn addColumn, CodeWriter codeWriter)
        {
            codeWriter.WriteLine($"ALTER TABLE `{addColumn.TableName}`");

            for (int i = 0; i < addColumn.FieldList.Count; i++)
            {
                var field = addColumn.FieldList[i];

                Generate(field, codeWriter);

                if (i < addColumn.FieldList.Count - 1)
                {
                    codeWriter.Write(",");
                }
                else
                {
                    codeWriter.Write(";");
                }

                codeWriter.WriteLine();
            }
        }

        private void Generate(Field field, CodeWriter codeWriter)
        {
            codeWriter.Write($"ADD COLUMN `{field.Name}` {field.ColumnType}");

            if (field.NotNull)
            {
                codeWriter.Write(" NOT NULL");
            }

            if (field.AutoIncrement)
            {
                codeWriter.Write(" AUTO_INCREMENT");
            }

            if (field.DefaultValue != null)
            {
                codeWriter.Write($" DEFAULT '{field.DefaultValue}'");
            }

            if (!string.IsNullOrEmpty(field.Comment))
            {
                codeWriter.Write($" COMMENT '{field.Comment}'");
            }

            codeWriter.Write($" AFTER `{field.AfterField}`");
        }
    }
}
