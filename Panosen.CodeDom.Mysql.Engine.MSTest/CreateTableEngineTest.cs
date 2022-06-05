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

            createTable.Name = "student";
            createTable.FieldList = new System.Collections.Generic.List<Field>();
            createTable.FieldList.Add(new Field
            {
                Name = "id",
                Comment = "Id",
                ColumnType = "varchar(20)",
                AutoIncrement = true
            });
            createTable.FieldList.Add(new Field
            {
                Name = "data_status",
                Comment = "Name",
                ColumnType = "varchar(20)"
            });
            createTable.DefaultCharset = "utf8mb4";

            var expected = @"CREATE TABLE `student` (
  `id` varchar(20) AUTO_INCREMENT COMMENT 'Id',
  `data_status` varchar(20) COMMENT 'Name'
) DEFAULT CHARSET = utf8mb4;
";

            var actual = createTable.TransformText();

            Assert.AreEqual(expected, actual);
        }
    }
}
