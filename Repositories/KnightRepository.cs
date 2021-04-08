using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;

namespace Repositories
{
    public class KnightRepository
    {

        public readonly IDbConnection _db;

        public KnightRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Knight> Get()
        {
            string sql = "SELECT * FROM knights;";
            return (_db.Query<Knight>(sql));
        }

        internal Knight Get(int id)
        {
            string sql = "SELECT * FROM knights WHERE id = @id;";
            return (_db.QueryFirstOrDefault<Knight>(sql, new { id }));
        }

        internal Knight Create(Knight knight)
        {
            string sql = @"
            INSERT INTO knights
            (name, title, age, castleId)
            VALUES
            (@Name, @Title, @Age, @CastleId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, knight);
            knight.Id = id;
            return (knight);
        }

        internal Knight Edit(Knight original)
        {
            string sql = @"
            UPDATE knights
            SET
                name = @Name,
                title = @Title,
                age = @Age
            WHERE id = @Id;
            SELET * FROM knights WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Knight>(sql, original);
        }

        internal IEnumerable<CastleKnight> GetByCastle(int id)
        {
            string sql = @"
            SELECT
            k.*,
            c.*
            FROM knights k
            JOIN castles c ON k.castleId = c.id
            WHERE castleId = @id;";

            return _db.Query<CastleKnight, Castle, CastleKnight>(sql, (knight, castle) =>
            {
                knight.Castle = castle;
                return knight;
            }, new { id }, splitOn: "id");
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM knights WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}