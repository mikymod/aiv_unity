using System.Collections;
using System.Collections.Generic;

public interface IPrintable
{
    //Any class which implements IPrintable MUST have a public function which matches this signature
    void PrintContent();
}
