// namespace Glitter.Persistence;
//
// /// <summary>
// /// Represents a bag of objects that are scoped to the current session.
// /// </summary>
// public class SessionBag
// {
//     private readonly IServiceProvider? _serviceProvider;
//     private readonly Dictionary<string, object?> _namedValues;
//     private readonly Dictionary<string, object?> _typedValues;
//
//     /// <summary>
//     /// Initializes a new instance of the <see cref="SessionBag"/> class.
//     /// </summary>
//     public SessionBag()
//     {
//         _namedValues = new Dictionary<string, object?>();
//         _typedValues = new Dictionary<string, object?>();
//     }
//
//     /// <summary>
//     /// Initializes a new instance of the <see cref="SessionBag"/> class.
//     /// </summary>
//     /// <param name="serviceProvider">The service provider to use when attempting to resolve requests.</param>
//     public SessionBag(IServiceProvider serviceProvider)
//     {
//         _serviceProvider = serviceProvider;
//         _namedValues = new Dictionary<string, object?>();
//         _typedValues = new Dictionary<string, object?>();
//     }
//
//     /// <summary>
//     /// Gets the value associated with the specified type.
//     /// </summary>
//     /// <typeparam name="T">The type of the value to get.</typeparam>
//     /// <returns>The value associated with the specified type.</returns>
//     public T? Get<T>()
//     {
//         if (_typedValues.TryGetValue(typeof(T).FullName!, out object? value))
//             return (T?)value;
//
//         if (_serviceProvider is not null)
//         {
//             object? service = _serviceProvider.GetService(typeof(T));
//             if (service != null)
//                 return (T?)service;
//         }
//
//         return default;
//     }
//
//     /// <summary>
//     /// Sets the value associated with the specified type.
//     /// </summary>
//     /// <typeparam name="T">The type of the value to set.</typeparam>
//     /// <param name="value">The value to set.</param>
//     public void Set<T>(T? value)
//     {
//         if (_typedValues.ContainsKey(typeof(T).FullName!))
//             _typedValues[typeof(T).FullName!] = value;
//         else
//             _typedValues.Add(typeof(T).FullName!, value);
//     }
//
//     /// <summary>
//     /// Gets or sets the value associated with the specified key.
//     /// </summary>
//     /// <param name="key">The key of the value to get or set.</param>
//     /// <returns>The value associated with the specified key.</returns>
//     public object? this[string key]
//     {
//         get => _namedValues.TryGetValue(key, out object? value)
//             ? value
//             : null;
//         set
//         {
//             if (_namedValues.ContainsKey(key))
//                 _namedValues[key] = value;
//             else
//                 _namedValues.Add(key, value);
//         }
//     }
// }
