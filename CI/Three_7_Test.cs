using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Three_7_Test
    {
        [TestMethod]
        public void TestMethod1() {
            var shelter = new Shelter();
            shelter.Enqueue(new Cat());//
            shelter.Enqueue(new Cat());//
            shelter.Enqueue(new Dog());//
            shelter.Enqueue(new Cat());//
            shelter.Enqueue(new Cat());//
            shelter.Enqueue(new Cat());
            shelter.Enqueue(new Dog());//
            shelter.Enqueue(new Dog());//
            shelter.Enqueue(new Dog());

            Assert.AreEqual(shelter.DequeueDog().Type,"Dog 1");//
            Assert.AreEqual(shelter.DequeueCat().Type, "Cat 1");//
            Assert.AreEqual(shelter.DequeueAny().Type, "Cat 2");//
            Assert.AreEqual(shelter.DequeueDog().Type, "Dog 2");//
            Assert.AreEqual(shelter.DequeueAny().Type, "Cat 3");//
            Assert.AreEqual(shelter.DequeueAny().Type, "Cat 4");//
            Assert.AreEqual(shelter.DequeueDog().Type, "Dog 3");//
            Assert.AreEqual(shelter.DequeueAny().Type, "Cat 5");//
            Assert.AreEqual(shelter.DequeueAny().Type, "Dog 4");//
        }
    }
}
