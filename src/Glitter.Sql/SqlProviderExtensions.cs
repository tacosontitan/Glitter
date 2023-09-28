using Glitter.Sql.Encapsulation;

namespace Glitter.Sql;

/// <summary>
/// Defines extension methods for <see cref="ISqlProvider"/>.
/// </summary>
public static class SqlProviderExtensions
{
    /// <summary>
    /// Executes a <see cref="SqlScalarFunction"/> and returns the first column of the first row in the result set returned.
    /// </summary>
    /// <param name="source">The <see cref="ISqlProvider"/> to execute the request with.</param>
    /// <param name="function">The <see cref="SqlScalarFunction"/> to execute.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <typeparam name="T">The type of the value to return.</typeparam>
    /// <returns>The results of the request.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source"/> -or-
    ///     <paramref name="function"/> is null.
    /// </exception>
    public static Task<T> Execute<T>(
        this ISqlProvider source,
        SqlScalarFunction function,
        CancellationToken cancellationToken = default)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (function is null)
            throw new ArgumentNullException(nameof(function));
        
        return source.ExecuteScalar<T>(function, cancellationToken);
    }
}