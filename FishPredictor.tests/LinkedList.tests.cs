

namespace FishPredictor.tests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void Add_AddsElementToList()
        {
            // Arrange
            LinkedList<int> list = new LinkedList<int>();

            // Act
            list.Add(1);

            // Assert
            Assert.AreEqual(1, list.LongCount()); // Добавил вызов метода LongCount()
        }

        [Test]
        public void Remove_RemovesElementFromList()
        {
            // Arrange
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);

            // Act
            bool result = list.Remove(1);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, list.LongCount()); // Добавил вызов метода LongCount()
        }
    }
}