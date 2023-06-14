namespace Glitter.Sql;

public static class AddParameterIfNotExtensions
{
    /// <summary>
    /// Adds a parameter to the request if its value does not meet the condition of a specified predicate.
    /// </summary>
    /// <param name="request">The <see cref="SqlRequest"/> instance.</param>
    /// <param name="predicate">The predicate that determines whether the parameter should be added.</param>
    /// <param name="name">The name of the parameter.</param>
    /// <param name="value">The value of the parameter.</param>
    /// <param name="type">The <see cref="DbType"/> of the parameter.</param>
    /// <param name="direction">The direction of the parameter.</param>
    /// <param name="size">The size of the parameter.</param>
    /// <param name="precision">The precision of the parameter.</param>
    /// <param name="scale">The scale of the parameter.</param>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <returns>The <see cref="SqlRequest"/> instance.</returns>
    public static SqlRequest AddParameterIfNot<T>(
        this SqlRequest request,
        Func<T?, bool> predicate,
        string name,
        T? value,
        DbType? type = null,
        ParameterDirection? direction = null,
        int? size = null,
        byte? precision = null,
        byte? scale = null)
    {
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));

        if (!predicate(value))
            request.Parameters.Add(new SqlRequestParameter(name, value, type, direction, size, precision, scale));

        return request;
    }
}