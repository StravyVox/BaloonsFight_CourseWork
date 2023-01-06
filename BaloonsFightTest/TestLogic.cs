using GameLogicClassLibrary;
using GameNetLibrary;
using System.Numerics;
namespace BaloonsFightTest
{
    [TestClass]
    public class TestLogic
    {
        [TestMethod]
        public void TestGraphicObject()
        {
            GraphicObject obj = new GraphicObject("test", new Vector2(0, 0), new Vector2(1, 1));
            Assert.AreEqual(obj.TexturePath, "test");
        }
        [TestMethod]
        public void TestGameObject()
        {
            GameObject obj = new GameObject("test", new Vector2(0, 0), new Vector2(1, 1));
            Assert.AreEqual(obj.HP, 0);
            Assert.AreEqual(obj.TexturePath, "test");
        }
        [TestMethod]
        public void TestBalloon()
        {
            Balloon balloon = new Balloon("test", new Vector2(0, 0));
            Assert.AreEqual(balloon.Fuel, 100);
        }
        [TestMethod]
        public void TestObjectMoverX()
        {
            Balloon balloon = new Balloon("test", new Vector2(0, 0));
            ObjectMover.MoveObjectByX(balloon, -1, 1);
            Assert.IsFalse(balloon.XPosition == 0);

        }
        [TestMethod]
        public void TestObjectMoverY()
        {
            Balloon balloon = new Balloon("test", new Vector2(0, 0));
            ObjectMover.MoveObjectByY(balloon, -1, 1);
            Assert.IsFalse(balloon.YPosition == 0);
        }
        [TestMethod]
        public void TestShoot()
        {
            PlayerObjectsOperator operObj = new PlayerObjectsOperator(0);
            operObj.LogicOperator.Shoot();
            Assert.IsTrue(operObj.GetBullets().Count == 1);

        }
        [TestMethod]
        public void TestObjectsOperator()
        {
            PlayerObjectsOperator operObj = new PlayerObjectsOperator(0);

            Assert.IsTrue(operObj.GetPlayers().Count == 2);
            Assert.IsTrue(operObj.GetBullets().Count == 0);

        }
        [TestMethod]
        public void TestSceneFrameObject()
        {
            SceneFrameObject frameObject = new SceneFrameObject(0);
            Assert.IsTrue(frameObject.Player == 0);
        }
        [TestMethod]
        public void TestBulletDecorator()
        {
            Bullet bullet = new Bullet(new Vector2(0, 0), 1);
            AbstractBullet modifiedbullet = new FastBullet(bullet);
            Assert.IsTrue(modifiedbullet.Speed > bullet.Speed);
        }
        [TestMethod]
        public void TestFabric()
        {
            AbstractBonus bonus = new ArmorBonusCreator().CreateBonus(new Vector2(0, 0));
            Assert.AreEqual(bonus, (ArmorBonus)bonus);
        }
    }
}