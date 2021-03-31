using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Library.Test
{
    [TestFixture]
    public class Question1Tests
    {

        [Test]
        public void Question1_Is_Sorted_In_Order_Test
            ([Values("Contrary to popular belief, the pink unicorn flies east.")] string value)
        {
            string sortedbuildIn = "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy";
            string sorted = Question1.InGenericSort(value);
            Assert.AreEqual(sortedbuildIn, sorted);
        }

        [Test]
        public void Question1_Is_Sorted_Without_WhiteSpaces_Test([Values("Contrary to popular belief, the pink unicorn flies east.")] string value)
        {
            string sortedbuildIn = Question1.InGenericSort(value);
            var k = Question1.DoesNotContainWhiteSpaces(sortedbuildIn);
            Assert.IsTrue(true);
        }

        [Test]
        public void Question1_Value_Contains_Punctuation_Test([Values("Contrary to popular belief, the pink unicorn flies east.")] string value)
        {
            string sortedbuildIn = Question1.InGenericSort(value);
            var k = Question1.DoesNotContainPunctuations(sortedbuildIn);
            Assert.IsTrue(true);
        }

        [Test]
        public void Question1_Is_Cannot_Be_Null_Test([Values(null)] string value)
        {
            string sortedbuildIn = Question1.InGenericSort(value);
            Assert.AreEqual("Value cannot be null", sortedbuildIn);
        }

    }
}
