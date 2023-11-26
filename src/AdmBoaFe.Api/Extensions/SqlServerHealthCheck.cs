using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdmBoaFe.Api.Extensions
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        private readonly string _connection;
        private readonly List<string> _tables;

        public SqlServerHealthCheck(string connection, List<string> tables)
        {
            _connection = connection;
            _tables = tables;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                using (var connection = new SqlConnection(_connection))
                {
                    await connection.OpenAsync(cancellationToken);

                    foreach (var table in _tables)
                    {
                        var command = connection.CreateCommand();
                        command.CommandText = $"select count(id) from {table}";

                        var result = Convert.ToInt32(await command.ExecuteScalarAsync(cancellationToken));

                        if (result <= 0)
                        {
                            return HealthCheckResult.Unhealthy($"Tabela '{table}' está vazia.");
                        }
                    }

                    return HealthCheckResult.Healthy();
                }
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy($"Erro ao verificar tabelas: {ex.Message}");
            }
        }
    }
}
