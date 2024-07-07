namespace intermediate
{
    // Generics allow you define one class or method that can take different types as arguments.
    // Eg. List<> is generics. You can set it co contain structs or reference types and it will work
    // with all of them, but won't have performance problems caused by casting or boxing.
    //
    // These are mostly "used", not so often created from scratch.

    internal class GenericOneType<T>
    {
        // Because generic-ness is declared at class, we can have fields of that type.
        public T? someField;

        // Generic-ness is declared at class, so T can be used without any additional declarations,
        public void SomeMethod(T unknown, int known)
        {
            // T will be known at runtime, but for now it's recognised as just an object.
            // Error	CS0019	Operator '+' cannot be applied to operands of type 'T' and 'int'
            // var sum = unknown + known;
        }
        
    }

    internal class GenericAtMethod
    {
        // Generic-ness is not declared at class, but can be done in methods
        // Fields and properties cannot be set to that type though, not even at constructor
        // Lots of errors:
        // public GenericAtMethod<T>() {}
        public T SomeMethod<T> (T unknown, int known)
        {
            // Methods can also return that generic type.
            return unknown;
        }
    }

    // "T" is a good practice and is known as default name for generics. Stands for "Template" or "Type".
    // It can be named in any way, but starting it with "T" makes it recognizable as a generic type
    internal class GenericsManyTypes<TOneType, TAnotherType, TDifferentType>
    {
    }

    // Generics can be constrained in following ways (can have more than one constraint per type):
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
    // struct - must be a value type - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types
    // class - must be of reference type
    // new() - must have parameterless constructor (it doesn't come with parameterful option)
    // <className> - must be of <className> type or a derived class
    // <interface> - must be of interface kind
    // T : U - must be like another generic or it's derivative
    // and more in the link.
    internal class GenericsWithRestarints<TOneType, TAnotherType> 
        where TOneType : IComparable, new()  // multiple constraints on one type 
        where TAnotherType : IComparable
        // can be in one line, but this way is more readable
    {
        public int Compare(TOneType first, TAnotherType second)
        {
            // Even with struct this won't work, so stick to the methods
            // Error	CS0019	Operator '==' cannot be applied to operands of type 'TStruct' and 'TStruct'
            // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type
            // "The == and != operators can't operate on a struct unless the struct explicitly overloads them."
            // return first == second;
            // would work if these were constrained to "class" (they have "==" as "Equals")
            return first.CompareTo(second);
        }
    }
}
