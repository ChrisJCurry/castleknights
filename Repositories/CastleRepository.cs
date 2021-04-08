using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;

namespace Repositories
{
    public class CastleRepository
    {
        public readonly IDbConnection _db;

        public CastleRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Castle> Get()
        {
            string sql = "SELECT * FROM castles;";
            return (_db.Query<Castle>(sql));
        }

        internal Castle Get(int id)
        {
            string sql = "SELECT * FROM castles WHERE id = @id;";
            return (_db.QueryFirstOrDefault<Castle>(sql, new { id }));
        }

        internal Castle Create(Castle castle)
        {
            string sql = @"
            INSERT INTO castles
            (name, year, kingName, size)
            VALUES
            (@Name, @Year, @KingName, @Size);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, castle);
            castle.Id = id;
            return (castle);
        }

        internal Castle Edit(Castle original)
        {
            string sql = @"
            UPDATE castles
            SET
                name=@Name,
                year=@Year,
                kingName=@Kingname,
                size=@Size
            WHERE id = @Id;
            SELECT * FROM castles WHERE id = @Id;";
            Castle updatedCastle = _db.QueryFirstOrDefault<Castle>(sql, original);
            return updatedCastle;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM castles WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}