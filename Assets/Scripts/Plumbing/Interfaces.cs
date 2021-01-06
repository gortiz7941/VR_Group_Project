using System.Collections;
using System.Collections.Generic;

public interface IAttachable {
    void Attach();
}

public class SomeClass {
    public T GenericMethod<T>(T param) where T : IAttachable {
        return param;
    }
}