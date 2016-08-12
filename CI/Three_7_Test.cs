using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Three_7_Test
    {
        [TestMethod]
        public void TestMethod1() {
            IShelter shelter = new Shelter();
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

            shelter = new AltShelter();

            shelter.Enqueue(new Cat());//
            shelter.Enqueue(new Cat());//
            shelter.Enqueue(new Dog());//
            shelter.Enqueue(new Cat());//
            shelter.Enqueue(new Cat());//
            shelter.Enqueue(new Cat());
            shelter.Enqueue(new Dog());//
            shelter.Enqueue(new Dog());//
            shelter.Enqueue(new Dog());

            Assert.AreEqual(shelter.DequeueDog().Type, "Dog 5");//
            Assert.AreEqual(shelter.DequeueCat().Type, "Cat 6");//
            Assert.AreEqual(shelter.DequeueAny().Type, "Cat 7");//
            Assert.AreEqual(shelter.DequeueDog().Type, "Dog 6");//
            Assert.AreEqual(shelter.DequeueAny().Type, "Cat 8");//
            Assert.AreEqual(shelter.DequeueAny().Type, "Cat 9");//
            Assert.AreEqual(shelter.DequeueDog().Type, "Dog 7");//
            Assert.AreEqual(shelter.DequeueAny().Type, "Cat 10");//
            Assert.AreEqual(shelter.DequeueAny().Type, "Dog 8");//
        }
    }
}
