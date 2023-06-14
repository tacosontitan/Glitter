namespace Glitter.Sql;

public static class AddParameterIfNotNullExtensions
{
    /// <summary>
    /// Adds a parameter to the request if its value is not <see langword="null"/>.
    /// </summary>
    /// <param name="name">The name of the parameter.</param>
    /// <param name="value">The value of the parameter.</param>
    /// <param name="type">The <see cref="DbType"/> of the parameter.</param>
    /// <param name="direction">The direction of the parameter.</param>
    /// <param name="size">The size of the parameter.</param>
    /// <param name="precision">The precision of the parameter.</param>
    /// <param name="scale">The scale of the parameter.</param>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <returns>The <see cref="SqlRequest"/> instance.</returns>
    public static SqlRequest AddParameterIfNotNull<T>(
        this SqlRequest request,
        string name,
        T? value,
        DbType? type = null,
        ParameterDirection? direction = null,
        int? size = null,
        byte? precision = null,
        byte? scale = null)
    {
        if (value is not null)
            request.Parameters.Add(new SqlRequestParameter(name, value, type, direction, size, precision, scale));

        return request;
    }
}