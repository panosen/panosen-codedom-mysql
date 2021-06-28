using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Mysql.Engine.MSTest
{
    [TestClass]
    public class AddColumnEngineTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            AddColumn addColumn = new AddColumn();
            addColumn.TableName = "student";
            addColumn.FieldList = new System.Collections.Generic.List<Field>();
            addColumn.FieldList.Add(new Field
            {
                Name = "data_status",
                Comment = "Name",
                AfterField = "name",
                ColumnType = "varchar(20)"
            });

            var expected = @"ALTER TABLE `student`
ADD COLUMN `data_status` varchar(20) COMMENT 'Name' AFTER `name`;
";

            var actual = addColumn.TransformText();

            Assert.AreEqual(expected, actual);
        }
    }
}
