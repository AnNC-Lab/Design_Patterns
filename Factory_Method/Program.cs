

using System.Linq.Expressions;

namespace FactoryMethod{
    class Program{
        #region interface Product
        public interface ITransport
        {
            void Deliver();

        }
        #endregion
        static void ExecuteDelivery(string transport, ConsoleColor color){
            Console.ForegroundColor = color;
            Console.WriteLine($"{transport} Transport");
            Console.ResetColor();
        }
        #region Concrete Products
        //Trien khai cua no
        public class Truck : ITransport
        {
            public void Deliver()
            {
                ExecuteDelivery("Truck",ConsoleColor.Red);
            }
        }
        public class Plane : ITransport
        {
            public void Deliver()
            {
                ExecuteDelivery("Plane",ConsoleColor.Green);
            }
        }
        public class Ship : ITransport
        {
            public void Deliver()
            {
                ExecuteDelivery("Ship",ConsoleColor.Blue);
            }
        }
        #endregion
        public enum TypeStyle{
            TRUCK,PLANE,SHIP
        }
        #region  Concrete creator
        public class Client{
            public static ITransport GetFactory(TypeStyle typeStyle){
                switch(typeStyle){
                    case TypeStyle.TRUCK : return new Truck();
                    case TypeStyle.PLANE : return new Plane();
                    case TypeStyle.SHIP : return new Ship();
                    default: throw new ArgumentOutOfRangeException("Not Transport");
                }
            }
        }
        #endregion

        static void Main(string[] args){
            ITransport transportFactory = Client.GetFactory(TypeStyle.TRUCK);
            transportFactory.Deliver();
        }
    }
}

