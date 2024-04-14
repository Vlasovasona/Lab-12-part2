using Лаба12_часть2;
using Library_10;

namespace Хеш_таблица
{
    [TestClass]
    public class UnitTest1
    {
        //блок Exception
        [TestMethod]
        public void TestCreateException() //тестирование ошибки при попытке формирования пустой таблицы
        {
            Assert.ThrowsException<Exception>(() => {
                MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(-1);
            });
        }

        [TestMethod]
        public void TestPrintNullTableException() //тестирование ошибки при попытке печати пустой таблицы
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>();
            Assert.ThrowsException<Exception>(() => {
                table.Print();
            });
        }//блок Exception закончен

        [TestMethod]
        public void TestCreateTable() //тестирование конструктора для создания хеш-таблицы
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(5);
            Assert.AreEqual(table.Capacity, 5);
        }

        //тестривание AddPoint 
        [TestMethod]
        public void TestAddPointToHashTable() //тестирование добавления элемента в таблицу
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(5);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            Assert.IsTrue(table.Contains(tool)); 
        }

        //тестиование удаления элемента из таблицы
        [TestMethod]
        public void TestRemoveTruePointFromHashTable() //тестирование добавления удаления существующего элемента из таблицы
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(5);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            table.RemoveData(tool);
            Assert.IsFalse(table.Contains(tool));
        }

        [TestMethod]
        public void TestRemoveFalsePointFromHashTable() //тестирование удаления несуществующего элемента из таблицы
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(5);
            HandTool tool = new HandTool();
            Assert.IsFalse(table.RemoveData(tool));
        }

        [TestMethod]
        public void TestRemovePointFromHashTable() //если несколько элементов в цепочке и нам нужно удалить элемент из середины или из конца
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(5);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            table.AddPoint(tool);
            Assert.IsTrue(table.RemoveData(tool));
        }

        //тестирование метода Contains
        [TestMethod]
        public void TestContainsPointTrue() 
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            Assert.IsTrue(table.Contains(tool));
        }

        [TestMethod]
        public void TestContainsPointFalse()
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            HandTool tool = new HandTool();
            Assert.IsFalse(table.Contains(tool));
        }

        //тестирование ToString для PointHash
        [TestMethod]
        public void TestToStringPoint()
        {
            HandTool tool = new HandTool();
            PointHash<Library_10.Instrument> p = new PointHash<Library_10.Instrument>(tool);
            Assert.AreEqual(p.ToString(), tool.ToString());
        }

        [TestMethod]
        public void TestConstructWhithoutParamNext()
        {
            PointHash<Instrument> p = new PointHash<Instrument>();
            Assert.IsNull(p.Next);
        }

        [TestMethod]
        public void TestConstructWhithoutParamPred()
        {
            PointHash<Instrument> p = new PointHash<Instrument>();
            Assert.IsNull(p.Pred);
        }
    }
}