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
        public void Generate(CreateTable createTable, CodeWriter codeWriter)
        {
            if (createTable == null)
            {
                return;
            }

            codeWriter.WriteLine($"CREATE TABLE `{createTable.Name ?? string.Empty}` (");

            GenerateFields(createTable.FieldList, createTable.PrimaryKey, codeWriter);

            if (!string.IsNullOrEmpty(createTable.PrimaryKey))
            {
                codeWriter.WriteLine($"  PRIMARY KEY (`{createTable.PrimaryKey}`)");
            }

            codeWriter.Write($")");

            if (!string.IsNullOrEmpty(createTable.DefaultCharset))
            {
                codeWriter.Write(" DEFAULT CHARSET = ").Write(createTable.DefaultCharset);
            }

            if (!string.IsNullOrEmpty(createTable.Comment))
            {
                codeWriter.Write($" COMMENT='{createTable.Comment}'");
            }

            codeWriter.WriteLine(";");
        }

        private void GenerateFields(List<Field> fieldList, string primaryKey, CodeWriter codeWriter)
        {
            if (fieldList == null || fieldList.Count <= 0)
            {
                return;
            }

            var firstField = fieldList.FirstOrDefault(v => v.AutoIncrement);
            var otherFields = fieldList.Where(v => !v.AutoIncrement).ToList();

            List<Field> fields = new List<Field>();
            if (firstField != null)
            {
                fields.Add(firstField);
            }
            if (otherFields.Count > 0)
            {
                fields.AddRange(otherFields);
            }

            for (int i = 0; i < fields.Count; i++)
            {
                var field = fields[i];

                GenerateField(field, codeWriter);

                if (i < fields.Count - 1 || !string.IsNullOrEmpty(primaryKey))
                {
                    codeWriter.Write(",");
                }

                codeWriter.WriteLine();
            }
        }

        private void GenerateField(Field field, CodeWriter codeWriter)
        {
            codeWriter.Write($"  `{field.Name ?? string.Empty}` {field.ColumnType ?? string.Empty}");

            //if (!string.IsNullOrEmpty(field.CharacterSet))
            //{
            //    codeWriter.Write(" CHARACTER SET ").Write(field.CharacterSet);
            //}
            //if (!string.IsNullOrEmpty(field.Collate))
            //{
            //    codeWriter.Write(" COLLATE ").Write(field.Collate);
            //}

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

            if (!string.IsNullOrEmpty(field.OnUpdate))
            {
                codeWriter.Write(" ON UPDATE ").Write(field.OnUpdate);
            }

            if (!string.IsNullOrEmpty(field.Comment))
            {
                codeWriter.Write($" COMMENT '{field.Comment}'");
            }
        }
    }
}
