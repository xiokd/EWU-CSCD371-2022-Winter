using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Generics.Tests;
public class Container<T>
   where T : notnull
{
    T Value
    {
        get
        {
            return Value;
        }
        set
        {
            // Check for null
            if (Value.Equals(value))
            {
                Value = value;
            }
        }

    }
    private Container<T> Root { get; set; }

    Container(T value)
    {
        Value = value;
    }

    public class NodeCollectionFactory<T>
    {
        public Container<T> CreateNewNodeCollection(T item)
        {
            return new Container<T>(item);
        }
    }

}

[TestClass]
public class MoreGenericStuff
{

    [TestMethod]
    public void MyTestMethod()
    {
        Container<int?> container = null;
        if(container == null)
            {

            }
    }
}
