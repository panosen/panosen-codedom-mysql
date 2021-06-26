using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Mysql.Engine
{
    /// <summary>
    /// CreateTableEngine
    /// </summary>
    public class CreateTableEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="createTable"></param>
        /// <param name="codeWriter"></param>
        public void Generate(CreateTable createTable, CodeWriter codeWriter)
        {
            Generate(createTable.Table, codeWriter);
        }

        private void Generate(Table table, CodeWriter codeWriter)
        {
            if (table == null)
            {
                return;
            }

            codeWriter.WriteLine($"CREATE TABLE `{table.Name ?? string.Empty}` (");

            GenerateFields(table.FieldList, table.PrimaryKey, codeWriter);

            if (!string.IsNullOrEmpty(table.PrimaryKey))
            {
                codeWriter.WriteLine($"  PRIMARY KEY (`{table.PrimaryKey}`)");
            }

            codeWriter.Write($") DEFAULT CHARSET=utf8mb4");

            if (!string.IsNullOrEmpty(table.Comment))
            {
                codeWriter.Write($" COMMENT='{table.Comment}'");
            }

            codeWriter.WriteLine(";");
        }

        private void GenerateFields(List<Field> fieldList, string primaryKey, CodeWriter codeWriter)
        {
            if (fieldList == null || fieldList.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < fieldList.Count; i++)
            {
                var field = fieldList[i];

                GenerateField(field, codeWriter);

                if (i < fieldList.Count - 1 || !string.IsNullOrEmpty(primaryKey))
                {
                    codeWriter.Write(",");
                }

                codeWriter.WriteLine();
            }
        }

        private void GenerateField(Field field, CodeWriter codeWriter)
        {
            codeWriter.Write($"  `{field.Name ?? string.Empty}` {field.ColumnType ?? string.Empty}");

            if (field.NotNull)
            {
                codeWriter.Write(" NOT NULL");
            }

            if (field.AutoIncrement)
            {
                codeWriter.Write(" AUTO_INCREMENT");
            }
            else if (field.DefaultValue != null)
            {
                codeWriter.Write($" DEFAULT {field.DefaultValue}");
            }
            else if (!field.NotNull)
            {
                codeWriter.Write(" DEFAULT NULL");
            }

            if (!string.IsNullOrEmpty(field.Comment))
            {
                codeWriter.Write($" COMMENT '{field.Comment}'");
            }
        }
    }
}
