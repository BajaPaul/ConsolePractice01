ConsolePractice01:

 /*
    Classes that you declare directly within a namespace, not nested within other classes, can be either public or internal.
    Classes are internal by default.  Class members, including nested classes, can be public, protected internal, protected,
    internal, or private. Members are private by default.  https://msdn.microsoft.com/en-us/library/0b0thckt.aspx

    A static class is basically the same as a non-static class, but there is one difference: A static class cannot be instantiated.
    In other words, you cannot use the new keyword to create a variable of the class type.  Because there is no instance variable,
    you access the members of a static class by using the class name itself.  A static class can be used as a convenient container 
    for sets of methods that just operate on input parameters and do not have to get or set any internal instance fields.  All members
    in a static class must be static.  https://msdn.microsoft.com/en-us/library/79b3xss3.aspx
    
    A static member is callable on a class even when no instance of the class has been created. The static member is always accessed by
    the class name, not the instance name. Only one copy of a static member exists, regardless of how many instances of the class are
    created. Static methods and properties cannot access non-static fields and events in their containing type, and they cannot access
    an instance variable of any object unless it is explicitly passed in a method parameter.

    A 'const' field is essentially static in its behavior. It belongs to the type, not to instances of the type. Therefore, const fields
    can be accessed by using the same ClassName.MemberName notation that is used for static fields. No object instance is required.
    */
