using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class SortMaterials
    {
        public int totalVolume(string[] data, string[] requirements)
        {
            var parsedData = data.Select(s =>
            {
                string[] tokens = s.Split(' ');
                return new { Edge = int.Parse(tokens[0]), Quality = int.Parse(tokens[1]), Color = tokens[2] };
            });

            var parsedRequirements = requirements.Select(s =>
            {
                string[] tokens = s.Split('=');
                return new { Name = tokens[0], Value = tokens[1] };
            });

            var usableMaterials = parsedData.Where(s => parsedRequirements.All(t =>
            {
                switch (t.Name)
                {
                    case "EDGE":
                        return s.Edge == int.Parse(t.Value);
                    case "QUALITY":
                        return s.Quality >= int.Parse(t.Value);
                    case "COLOR":
                    default:
                        return s.Color == t.Value;

                }
            }));

            return usableMaterials.Sum(s => s.Edge * s.Edge * s.Edge);
        }
    }

    [TestClass]
    public class SortMaterialsTestClass
    {
        [TestMethod]
        public void SortMaterialsTest()
        {
            SortMaterialsTest(new string[] { "1 20 red", "2 30 blue", "10 1 green" }, new string[] { }, 1009);
            SortMaterialsTest(new string[] { "1 20 red", "2 30 blue", "10 1 green" }, new string[] { "QUALITY=20" }, 9);
            SortMaterialsTest(new string[] { "1 20 red", "2 30 blue", "10 1 green", "5 5 red", "5 6 red" }, new string[] { "COLOR=red", "EDGE=5" }, 250);
            SortMaterialsTest(new string[] { "1 20 red", "2 30 blue", "10 1 green", "5 5 red", "5 6 red" }, new string[] { "EDGE=1", "EDGE=5" }, 0);
        }

        private void SortMaterialsTest(string[] data, string[] requirements, int expected)
        {
            SortMaterials sortMaterials = new SortMaterials();
            Assert.AreEqual(expected, sortMaterials.totalVolume(data, requirements));
        }
    }
}
