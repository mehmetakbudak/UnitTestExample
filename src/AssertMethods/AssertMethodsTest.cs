namespace AssertMethods.Test
{
    public class AssertMethodsTest
    {
        [Fact]
        public void ContainsTest()
        {
            var values = new[] { 3, 5, 7, -10 };

            Assert.Contains<int>(values, value => value == 3);
        }

        [Fact]
        public void DoesNotContainsTest()
        {
            var values = new[] { 2, 4, 6 };

            Assert.DoesNotContain<int>(values, value => value == 3);
        }

        [Fact]
        public void TrueTest()
        {
            //Assert.True(5 > 3);
            Assert.True("".GetType() == typeof(string));
        }

        [Fact]
        public void FalseTest()
        {
            //Assert.False(2 < 1);
            Assert.False("".GetType() == typeof(int));
        }

        [Fact]
        public void MatchesTest()
        {
            var regex = "^th";

            Assert.Matches(regex, "this");
        }

        [Fact]
        public void DoesNotMatches()
        {
            var regex = "^th";

            Assert.DoesNotMatch(regex, "does");
        }

        [Fact]
        public void StartWithTest()
        {
            Assert.StartsWith("M", "Mehmet");
        }

        [Fact]
        public void EndWithTest()
        {
            Assert.EndsWith("t", "Mehmet");
        }

        [Fact]
        public void EmptyTest()
        {
            var list = new List<object>();
            Assert.Empty(list);
        }

        [Fact]
        public void NotEmptyTest()
        {
            var list = new List<object> { 3 };
            Assert.NotEmpty(list);
        }

        [Fact]
        public void InRangeTest()
        {
            Assert.InRange(10, 2, 20);
        }

        [Fact]
        public void NotInRangeTest()
        {
            Assert.NotInRange(10, 12, 20);
        }

        [Fact]
        public void SingleTest()
        {
            var list = new List<object> { 3 };
            Assert.Single(list);
        }

        [Fact]
        public void IsTypeTest()
        {
            Assert.IsType<string>("Mehmet");
        }

        [Fact]
        public void IsNotTypeTest()
        {
            Assert.IsNotType<int>("Mehmet");
        }

        [Fact]
        public void IsAssignableFromTest()
        {
            Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());
        }

        [Fact]
        public void NullTest()
        {
            string value = null;
            Assert.Null(value);
        }

        [Fact]
        public void NotNullTest()
        {
            string value = "Mehmet";
            Assert.NotNull(value);
        }

        [Fact]
        public void EqualTest()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void NotEqualTest()
        {
            Assert.NotEqual(1, 2);
        }
    }
}
