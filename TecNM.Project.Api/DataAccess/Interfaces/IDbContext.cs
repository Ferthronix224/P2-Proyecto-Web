using System.Data.Common;

namespace TecNM.Project.Api.DataAccess.Interfaces;

public interface IDbContext
{
    DbConnection Connection { get; }
}