using System.Collections;
using System.Collections.Generic;

public class Generics
{
    public T GMethod<T>(T parameter)
    {
        return parameter;
    }
    public T GMethodMultipleParameters<T, U, V>(T param1, U param2, V param3)
    {
        //Do stuff with param1,2,3
        return param1;
    }

    //1
    public T GMethodWithReferenceType<T>(T parameter) where T : class
    {
        return parameter;
    }
    public T GMethodWithValueType<T>(T parameter) where T : struct
    {
        return parameter;
    }
    public T GMethodWithSpecificClass<T>(T parameter) where T : ClassA
    {
        return parameter;
    }
    public T GMethodWithSpecificInterface<T>(T parameter) where T : IPrintable
    {
        return parameter;
    }
    public T GMethodWithDefaultContructor<T>(T parameter) where T : new()
    {
        return parameter;
    }

    public T GMethodWithReferenceTypeAndValueType<T, U>(T parameter, U value)   where T : class
                                                                                where U : struct
    {
        return parameter;
    }
}
