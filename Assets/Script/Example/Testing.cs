using UnityEngine;

public class Testing
{
    public const int value = 3;
    /// <summary Const----->
    /// Bir alanın derleme zamanında sabit değerle atanmasını sağlar.
    /// (Allows a field to be assigned with a constant value at compile time.)
    /// Değişken oluşturulduğu zamanki değer ile her zaman kalır.
    /// (The variable always remains with the value at the time it was created.)
    /// Başka bir yerden asla değiştirilmez.
    /// (It will never be changed from another place.)
    /// </summary>

    ///<summary Readonly----->
    /// sadece yapılandırıcıda atanabileceği anlamına gelir ve daha sonra başka bir yerde değiştirilemez.
    /// (it means that it can only be assigned in the configurator, and then it cannot be changed elsewhere.)
    /// Sınıf oluşturup içine tanımladığımız zaman bu sınıfı çağırdığımızda değiştirebiliriz.
    /// (When we create a class and define it into it, we can change it when we call this class.)
    /// Başka yerden erişip değiştiremeyiz. (We cannot access and change it from another place.)
    /// </summary>
    private MyClass _class = new MyClass(10);
}

class MyClass
{
    public readonly int myReadonlyInt;

    public MyClass(int value)
    {
        myReadonlyInt = value;
    }
}
