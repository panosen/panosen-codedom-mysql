using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Mysql.Engine.MSTest
{
    [TestClass]
    public class CreateTableEngineTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CreateTable createTable = new CreateTable();

            var table = new Table();
            createTable.Table = table;
            table.Name = "student";
            table.FieldList = new System.Collections.Generic.List<Field>();
            table.FieldList.Add(new Field
            {
                Name = "id",
                Comment = "Id",
                ColumnType = "varchar(20)",
                AutoIncrement = true
            });
            table.FieldList.Add(new Field
            {
                Name = "data_status",
                Comment = "Name",
                ColumnType = "varchar(20)"
            });

            var expected = @"CREATE TABLE `student` (
  `id` varchar(20) AUTO_INCREMENT COMMENT 'Id',
  `data_status` varchar(20) DEFAULT NULL COMMENT 'Name'
) DEFAULT CHARSET=utf8mb4;
";

            var actual = createTable.TransformText();

            Assert.AreEqual(expected, actual);
        }
    }
}
