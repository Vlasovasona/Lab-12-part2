using Лаба12_часть2;
using Library_10;

namespace Хеш_таблица
{
    [TestClass]
    public class UnitTest1
    {
        //блок Exception
        [TestMethod]
        public void Test_CreateTable_Exception() //тестирование ошибки при попытке формирования пустой таблицы
        {
            Assert.ThrowsException<Exception>(() =>
            {
                MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(-1);
            });
        }

        [TestMethod]
        public void Test_AddExistingElement_Exception() //тестирование ошибки при попытке формирования пустой таблицы
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            Instrument tool = new Instrument("q", 1);
            table.AddPoint(tool);
            Assert.ThrowsException<Exception>(() =>
            {
                table.AddPoint(tool);
            });
        }

        [TestMethod]
        public void Test_PrintNullTable_Exception() //тестирование ошибки при попытке печати пустой таблицы
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>();
            Assert.ThrowsException<Exception>(() =>
            {
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

        [TestMethod]
        public void TestAddCount() //тестирование увеличения Count после добавления элемента в таблицу
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(5);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            Assert.AreEqual(6, table.Count);
        }

        //тестиование удаления элемента из таблицы
        [TestMethod]
        public void TestRemovePointFromHashTableTrue() //тестирование добавления удаления существующего элемента из таблицы
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            table.RemoveData(tool);
            Assert.IsFalse(table.Contains(tool));
        }

        [TestMethod]
        public void TestRemovePointFromHashTable_False() //тестирование удаления несуществующего элемента из таблицы
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            table.RemoveData(tool);
            Assert.IsFalse(table.Contains(tool));
        }

        [TestMethod]
        public void TestRemovePointFromHashTable_OutOfKey_False() //тестирование удаления несуществующего элемента из таблицы
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            Instrument tool = new Instrument("Бензопила дружба нового поколения", 9999);
            Assert.IsFalse(table.RemoveData(tool));
        }

        [TestMethod]
        public void TestRemovePoint_FromBeginingOfTableTable() //тестирование удаления первого в цепочке элемента из таблицы
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            Instrument tool2 = new Instrument("Перфоратор", 98);
            Instrument tool3 = new Instrument("Штангенциркуль", 85);
            Instrument tool4 = new Instrument("Микрометр", 41);
            Instrument tool5 = new Instrument("RRR", 1234);
            Instrument tool6 = new Instrument("RRR", 1235);

            table.AddPoint(tool2);
            table.AddPoint(tool3);
            table.AddPoint(tool4);
            table.AddPoint(tool5);
            table.AddPoint(tool6);

            PointHash<Instrument> tool = new PointHash<Instrument>();
            PointHash<Instrument> pointHash = table.GetFirstValue();
            tool = pointHash;
            table.RemoveData(tool.Data);
            Assert.IsFalse(table.Contains(tool.Data));
        }


        //тестирование метода Contains
        [TestMethod]
        public void TestContainsPointTrue() //метод Contains когда элемент есть в таблице
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            Assert.IsTrue(table.Contains(tool));
        }

        [TestMethod]
        public void TestContainsPointFalse() //когда элемента нет в таблице
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            HandTool tool = new HandTool();
            Assert.IsFalse(table.Contains(tool));
        }

        //тестирование ToString для PointHash
        [TestMethod]
        public void TestToStringPoint() //тестирование ToString для класса узла
        {
            HandTool tool = new HandTool();
            PointHash<Library_10.Instrument> p = new PointHash<Library_10.Instrument>(tool);
            Assert.AreEqual(p.ToString(), tool.ToString());
        }

        [TestMethod]
        public void TestConstructWhithoutParamNext() //конструктор узла без параметров, Next = null
        {
            PointHash<Instrument> p = new PointHash<Instrument>();
            Assert.IsNull(p.Next);
        }

        [TestMethod]
        public void TestConstructWhithoutParamPred() //конструктор узла без параметров, Pred = null
        {
            PointHash<Instrument> p = new PointHash<Instrument>();
            Assert.IsNull(p.Pred);
        }

        //тестирование методов ToString и GetHashCode для класса PointHash
        [TestMethod]
        public void ToString_WhenDataIsNull_ReturnEmptyString() //конструктор без параметров метод ToString
        {
            PointHash<Instrument> point = new PointHash<Library_10.Instrument>();
            string result = point.ToString();
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void ToString_WhenDataIsNotNull_ReturnDataToString()
        {
            Library_10.Instrument tool = new Instrument();
            tool.RandomInit();
            PointHash<Instrument> point = new PointHash<Instrument>(tool);
            string result = point.ToString();
            Assert.AreEqual(tool.ToString(), result);
        }

        [TestMethod]
        public void GetHashCode_WhenDataIsNull_ReturnZero() //тестирование GetHashCode для узла, созданного с помощью конструктора без параметров
        {
            PointHash<Instrument> point = new PointHash<Library_10.Instrument>();
            int result = point.GetHashCode();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetHashCode_WhenDataIsNotNull_ReturnDataHashCode() //тестиование GetHashCode для заполненного узла
        {
            Library_10.Instrument tool = new Instrument();
            tool.RandomInit();
            PointHash<Instrument> point = new PointHash<Library_10.Instrument>(tool);
            int result = point.GetHashCode();
            Assert.AreEqual(tool.GetHashCode(), result);
        }
    }
}
