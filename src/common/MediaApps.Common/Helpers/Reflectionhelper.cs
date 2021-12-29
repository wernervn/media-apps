using System.Reflection;

namespace MediaApps.Common.Helpers;

/// <summary>
/// Reflection helper classes
/// </summary>
public static class Reflectionhelper
{
    /// <summary>
    /// Get a list of types in an assembly
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    /// <param name="assembly">Assembly for inspection</param>
    /// <returns>List of types</returns>
    public static IEnumerable<Type> GetTypesInAssembly<T>(Assembly assembly)
        => GetTypesInAssembly(assembly, typeof(T));

    /// <summary>
    /// Get a list of types in an assembly
    /// </summary>
    /// <param name="assembly">Assembly for inspection</param>
    /// <param name="type">Type of object</param>
    /// <returns></returns>
    public static IEnumerable<Type> GetTypesInAssembly(Assembly assembly, Type type)
        => from t in assembly.GetTypes()
           where !t.IsInterface
           where !t.IsAbstract
           where type.IsAssignableFrom(t)
           select t;

    /// <summary>
    /// Gets a list of types that implement a given interface
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetInterfaceImplementationsInAssembly<TInterface>(this Assembly assembly)
        => assembly.GetTypes()
            .Where(type => typeof(TInterface).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            .ToList();

    /// <summary>
    /// Get first or default type in an assembly
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    /// <param name="assembly">Assembly for inspection</param>
    /// <returns>Returns the first type in the sequence, else return null</returns>
    public static Type? GetFirstOrDefaultTypeInAssembly<T>(Assembly assembly)
        => GetTypesInAssembly<T>(assembly).FirstOrDefault();

    /// <summary>
    /// Get first or default type in an assembly
    /// </summary>
    /// <param name="assembly">Assembly for inspection</param>
    /// <param name="type">Type of object</param>
    /// <returns></returns>
    public static Type? GetFirstOrDefaultTypeInAssembly(Assembly assembly, Type type)
        => GetTypesInAssembly(assembly, type).FirstOrDefault();

    /// <summary>
    /// Get first type in an assembly
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    /// <param name="assembly">Assembly for inspection</param>
    /// <returns>Returns the first type in the sequence.</returns>
    public static Type GetFirstTypeInAssembly<T>(Assembly assembly)
        => GetTypesInAssembly<T>(assembly).First();

    /// <summary>
    /// Get single type in assembly
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    /// <param name="assembly">Assembly for inspection</param>
    /// <returns>Single type, throws exception if more than one fount</returns>
    public static Type GetSingleTypeInAssembly<T>(Assembly assembly)
    {
        var types = GetTypesInAssembly<T>(assembly);
        var enumerable = types as Type[] ?? types.ToArray();
        if (enumerable.Length == 0)
        {
            throw new InvalidOperationException($"One {typeof(T).Name} implementation should be available in {assembly.FullName}");
        }
        if (enumerable.Length > 1)
        {
            throw new InvalidOperationException($"Only one implementation of {typeof(T).Name} should be available in {assembly.FullName}");
        }
        return enumerable.Single();
    }

    /// <summary>
    /// Get a list of types for a specific attribute
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    /// <param name="assembly">Assembly for inspection</param>
    /// <returns>Returns a list of types containing the specified attribute</returns>
    public static List<Type> GetTypeByAttribute<T>(Assembly assembly) where T : Attribute
        => assembly.GetTypes()
            .Where(type => Attribute.IsDefined(type, typeof(T)))
            .ToList();

    /// <summary>
    /// Get list of methods for a specific attribute
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="bindingFlags"></param>
    /// <returns>Returns a list of methods decorated by the specified attribute</returns>
    public static List<MethodInfo> GetMethodsWithAttribute<T>(Type type, BindingFlags bindingFlags) where T : Attribute
        => type.GetMethods(bindingFlags | BindingFlags.Public)
            .Where(c => c.GetCustomAttributes<T>().Any()).ToList();

    /// <summary>
    /// Find types deriving from a specific type
    /// </summary>
    /// <param name="assembly">Assembly for inspection</param>
    /// <param name="baseType">Base type the type must inherit from</param>
    /// <returns>Returns a list of methods inheriting from a specific base type</returns>
    public static List<Type> FindDerivedTypes(Assembly assembly, Type baseType)
        => assembly.GetTypes()
            .Where(t => t != baseType && baseType.IsAssignableFrom(t))
            .ToList();

    /// <summary>
    /// Find types deriving from a specific type
    /// </summary>
    /// <param name="assembly">Assembly for inspection</param>
    /// <param name="baseType">Base type the type must inherit from</param>
    /// <returns>Returns a list of methods inheriting from a specific base type</returns>
    public static List<Type> FindDerivedGenericTypes(this Assembly assembly, Type baseType)
        => assembly.GetTypes()
            .Where(t => t.IsDerivedFromGenericParent(baseType))
            .ToList();

    /// <summary>
    /// Convert object to type
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    /// <param name="input">Boxed value of type</param>
    /// <returns>Unboxed object</returns>
    public static T ConvertObject<T>(object input) => (T)Convert.ChangeType(input, typeof(T));

    /// <summary>
    /// Recursively checks if a type is derived from a generic base type
    /// </summary>
    /// <param name="type">The type to check</param>
    /// <param name="parentType">The generic parent type to check against</param>
    /// <returns>true is type is derived from parentType, else false</returns>
    public static bool IsDerivedFromGenericParent(this Type type, Type parentType)
    {
        if (!parentType.IsGenericType)
        {
            throw new ArgumentException($"{nameof(parentType)} must be generic", nameof(parentType));
        }

        if (type is null || type == typeof(object))
        {
            return false;
        }

        if (type.IsGenericType && type.GetGenericTypeDefinition() == parentType)
        {
            return true;
        }

        return type.BaseType.IsDerivedFromGenericParent(parentType)
            || type.GetInterfaces().Any(t => t.IsDerivedFromGenericParent(parentType));
    }

    /// <summary>
    /// Return all types decorated with a specific attribute contained in a given assembly
    /// </summary>
    /// <typeparam name="TAttribute">The attribute to search for</typeparam>
    /// <param name="assembly">The assembly to search</param>
    /// <returns>The types decorated with attribute T in the assembly</returns>
    public static Dictionary<Type, TAttribute> GetTypesWithAttribute<TAttribute>(this Assembly assembly) where TAttribute : Attribute
    {
        var result = (from type in assembly.GetTypes()
                      where type.GetCustomAttributes<TAttribute>().Any()
                      let attrib = type.GetCustomAttribute<TAttribute>()
                      select new { type, attrib }).ToDictionary(c => c.type, c => c.attrib);
        return result;
    }

    /// <summary>
    /// Checks if an assembly contains a specific type
    /// </summary>
    /// <typeparam name="T">Type being searched for</typeparam>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static bool Contains<T>(this Assembly assembly)
        => Contains(assembly, typeof(T));

    /// <summary>
    /// Checks if an assembly contains a specific type
    /// </summary>
    /// <param name="assembly"></param>
    /// <param name="needle">Type being searched for</param>
    /// <returns></returns>
    public static bool Contains(this Assembly assembly, Type needle)
    {
        var types = from type in assembly.GetTypes()
                    where !type.IsInterface
                    where !type.IsAbstract
                    where type.IsDerivedFromGenericParent(needle)
                    select type.Name;
        return types.Any();
    }

    public static bool IsAtomic(this object source)
        => source is null ||
               source is string ||
               source is Enum ||
               source is DateTime ||
               source is decimal ||
               source is double ||
               source is int ||
               source is long ||
               source.GetType().GetTypeInfo().IsPrimitive ||
               !source.GetType().GetRuntimeProperties().Any();
}
