using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Mysql.Engine.MSTest
{
    [TestClass]
    public class CreateViewEngineTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CreateView createView = new CreateView();

            var view = new View();
            createView.View = view;
            view.Name = "vstu";
            view.TableName = "student";
            view.AddField(new ViewField { Name = "tname", TableFieldName = "name" });
            view.AddField("tage", "age");

            var expected = @"CREATE VIEW `vstu` AS
SELECT
  `name` AS `tname`,
  `age` AS `tage`
FROM
  `student`;
";

            var actual = createView.TransformText();

            Assert.AreEqual(expected, actual);
        }
    }
}
