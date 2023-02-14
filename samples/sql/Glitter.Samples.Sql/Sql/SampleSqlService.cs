using System.Data.SqlClient;

using Glitter.Sql;

namespace Glitter.Samples.Sql.Sql;

/// <summary>
/// Represents a sample <see cref="SqlService"/>.
/// </summary>
internal sealed class SampleSqlService : SqlService
{
    private readonly string _connectionString;
    /// <summary>
    /// Creates a new <see cref="SqlService"/> instance.
    /// </summary>
    /// <param name="connectionInformation">The <see cref="ConnectionInformation"/> used by this service for interacting with SQL.</param>
    /// <exception cref="ArgumentNullException"><paramref name="connectionInformation"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><see cref="ConnectionInformation.Server"/> is <see langword="null"/> or whitespace.</exception>
    /// <exception cref="ArgumentException"><see cref="ConnectionInformation.Database"/> is <see langword="null"/> or whitespace.</exception>
    /// <exception cref="ArgumentException"><see cref="ConnectionInformation.IntegratedSecurity"/> is <see langword="false"/> and <see cref="ConnectionInformation.Username"/> is <see langword="null"/> or whitespace.</exception>
    /// <exception cref="ArgumentException"><see cref="ConnectionInformation.IntegratedSecurity"/> is <see langword="false"/> and <see cref="ConnectionInformation.Password"/> is <see langword="null"/> or whitespace.</exception>
    public SampleSqlService(ConnectionInformation connectionInformation) :
        base(connectionInformation)
    {
        if (connectionInformation is null)
            throw new ArgumentNullException(nameof(connectionInformation));

        if (string.IsNullOrWhiteSpace(connectionInformation.Server))
            throw new ArgumentException("The connection information's server cannot be `null` or whitespace.");

        if (string.IsNullOrWhiteSpace(connectionInformation.Database))
            throw new ArgumentException("The connection information's database cannot be `null` or whitespace.");

        if (!connectionInformation.IntegratedSecurity && string.IsNullOrWhiteSpace(connectionInformation.Username))
            throw new ArgumentException("A username must be specified when integrated security is not being utilized.");

        if (!connectionInformation.IntegratedSecurity && string.IsNullOrWhiteSpace(connectionInformation.Password))
            throw new ArgumentException("A password must be specified when integrated security is not being utilized.");

        var connectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = connectionInformation.Server,
            InitialCatalog = connectionInformation.Database,
            IntegratedSecurity = connectionInformation.IntegratedSecurity
        };

        if (connectionInformation.IntegratedSecurity)
        {
            connectionStringBuilder.UserID = connectionInformation.Username;
            connectionStringBuilder.Password = connectionInformation.Password;
            connectionStringBuilder.ConnectTimeout = (int)(connectionInformation.ConnectionTimeout?.TotalSeconds ?? 30);
        }

        _connectionString = connectionStringBuilder.ConnectionString;
    }
    public override Task Execute(SqlRequest request) => throw new NotImplementedException();
    public override Task<T> ExecuteScalar<T>(SqlRequest request) => throw new NotImplementedException();
    public override Task<IEnumerable<T>> Query<T>(SqlRequest request) => throw new NotImplementedException();

}
