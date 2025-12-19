//AppTestStudio 
//Copyright(C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

// Portions of this file were generated with GitHub Copilot.
// Generated: 2025-12-18
// Tool: GitHub Copilot (https://github.com/features/copilot)
using Microsoft.Data.Sqlite;

namespace AppTestStudio.Data
{
    /// <summary>
    /// Simple SQLite-backed repository for <see cref="Counter"/> keyed by <c>CounterName</c>.
    /// Stores DB in the application folder (Utils.GetApplicationFolder()) by default.
    /// </summary>
    internal class CounterRepository : IDisposable
    {
        private readonly string _dbPath;
        private readonly string _connectionString;
        private bool _disposed;

        public CounterRepository(string? filePath = null)
        {
            _dbPath = filePath ?? Path.Combine(Utils.GetApplicationFolder(), "counter.db");
            _connectionString = $"Data Source={_dbPath}";
            EnsureDatabase();
        }

        private void EnsureDatabase()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_dbPath) ?? ".");
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            const string createSql = @"
CREATE TABLE IF NOT EXISTS Counter (
CounterName TEXT PRIMARY KEY,
ClickCount INTEGER,
WaitLength INTEGER,
ScreenShots INTEGER,
GoHome INTEGER,
GoContinue INTEGER,
GoChild INTEGER,
GoParent INTEGER,
ClickDragRelease INTEGER,
MouseMove INTEGER,
GoStop INTEGER,
RNG INTEGER,
RNGContainer INTEGER,
AppLaunches INTEGER,
TestLoaded INTEGER,
TestSaved INTEGER
);";
            using var cmd = conn.CreateCommand();
            cmd.CommandText = createSql;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Insert or update the provided counter row. Uses CounterName as the primary key.
        /// </summary>
        public void Upsert(Counter counter)
        {
            if (counter == null) throw new ArgumentNullException(nameof(counter));

            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            const string upsertSql = @"
INSERT INTO Counter (
CounterName, ClickCount, WaitLength, ScreenShots, GoHome, GoContinue, GoChild, GoParent,
ClickDragRelease, MouseMove, GoStop, RNG, RNGContainer, AppLaunches, TestLoaded, TestSaved
) VALUES (
@CounterName, @ClickCount, @WaitLength, @ScreenShots, @GoHome, @GoContinue, @GoChild, @GoParent,
@ClickDragRelease, @MouseMove, @GoStop, @RNG, @RNGContainer, @AppLaunches, @TestLoaded, @TestSaved
)
ON CONFLICT(CounterName) DO UPDATE SET
ClickCount = excluded.ClickCount,
WaitLength = excluded.WaitLength,
ScreenShots = excluded.ScreenShots,
GoHome = excluded.GoHome,
GoContinue = excluded.GoContinue,
GoChild = excluded.GoChild,
GoParent = excluded.GoParent,
ClickDragRelease = excluded.ClickDragRelease,
MouseMove = excluded.MouseMove,
GoStop = excluded.GoStop,
RNG = excluded.RNG,
RNGContainer = excluded.RNGContainer,
AppLaunches = excluded.AppLaunches,
TestLoaded = excluded.TestLoaded,
TestSaved = excluded.TestSaved;
";

            using var cmd = conn.CreateCommand();
            cmd.CommandText = upsertSql;
            cmd.Parameters.AddWithValue("@CounterName", counter.CounterName ?? string.Empty);
            cmd.Parameters.AddWithValue("@ClickCount", counter.ClickCount);
            cmd.Parameters.AddWithValue("@WaitLength", counter.WaitLength);
            cmd.Parameters.AddWithValue("@ScreenShots", counter.ScreenShots);
            cmd.Parameters.AddWithValue("@GoHome", counter.GoHome);
            cmd.Parameters.AddWithValue("@GoContinue", counter.GoContinue);
            cmd.Parameters.AddWithValue("@GoChild", counter.GoChild);
            cmd.Parameters.AddWithValue("@GoParent", counter.GoParent);
            cmd.Parameters.AddWithValue("@ClickDragRelease", counter.ClickDragRelease);
            cmd.Parameters.AddWithValue("@MouseMove", counter.MouseMove);
            cmd.Parameters.AddWithValue("@GoStop", counter.GoStop);
            cmd.Parameters.AddWithValue("@RNG", counter.RNG);
            cmd.Parameters.AddWithValue("@RNGContainer", counter.RNGContainer);
            cmd.Parameters.AddWithValue("@AppLaunches", counter.AppLaunches);
            cmd.Parameters.AddWithValue("@TestLoaded", counter.TestLoaded);
            cmd.Parameters.AddWithValue("@TestSaved", counter.TestSaved);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Returns the counter row for the specified key, or null if not found.
        /// </summary>
        public Counter? Get(string counterName)
        {
            if (string.IsNullOrWhiteSpace(counterName))
            {
                // make a new counter;
                Counter counter = new Counter();
                counter.CounterName = counterName;
                return counter;
            }

            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Counter WHERE CounterName = @CounterName LIMIT 1;";
            cmd.Parameters.AddWithValue("@CounterName", counterName);

            using var rdr = cmd.ExecuteReader();
            if (!rdr.Read())
            {
                // make a new counter;
                Counter counter = new Counter();
                counter.CounterName = counterName;
                return counter;
            }

            return MapReaderToCounter(rdr);
        }

        /// <summary>
        /// Returns all stored counter.
        /// </summary>
        public List<Counter> GetAll()
        {
            var list = new List<Counter>();
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Counter ORDER BY CounterName;";

            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(MapReaderToCounter(rdr));
            }
            return list;
        }

        /// <summary>
        /// Delete a counter row by key.
        /// </summary>
        public bool Delete(string counterName)
        {
            if (string.IsNullOrWhiteSpace(counterName)) return false;
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Counter WHERE CounterName = @CounterName;";
            cmd.Parameters.AddWithValue("@CounterName", counterName);
            var affected = cmd.ExecuteNonQuery();
            return affected > 0;
        }

        private static Counter MapReaderToCounter(SqliteDataReader rdr)
        {
            var c = new Counter
            {
                CounterName = rdr.GetStringOrDefault("CounterName"),
                ClickCount = rdr.GetInt64OrDefault("ClickCount"),
                WaitLength = rdr.GetInt64OrDefault("WaitLength"),
                ScreenShots = rdr.GetInt64OrDefault("ScreenShots"),
                GoHome = rdr.GetInt64OrDefault("GoHome"),
                GoContinue = rdr.GetInt64OrDefault("GoContinue"),
                GoChild = rdr.GetInt64OrDefault("GoChild"),
                GoParent = rdr.GetInt64OrDefault("GoParent"),
                ClickDragRelease = rdr.GetInt64OrDefault("ClickDragRelease"),
                MouseMove = rdr.GetInt64OrDefault("MouseMove"),
                GoStop = rdr.GetInt64OrDefault("GoStop"),
                RNG = rdr.GetInt64OrDefault("RNG"),
                RNGContainer = rdr.GetInt64OrDefault("RNGContainer"),
                AppLaunches = rdr.GetInt64OrDefault("AppLaunches"),
                TestLoaded = rdr.GetInt64OrDefault("TestLoaded"),
                TestSaved = rdr.GetInt64OrDefault("TestSaved")
            };
            return c;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
        }
    }

    internal static class SqliteDataReaderExtensions
    {
        public static long GetInt64OrDefault(this SqliteDataReader rdr, string columnName)
        {
            var ordinal = rdr.GetOrdinalSafe(columnName);
            if (ordinal < 0 || rdr.IsDBNull(ordinal)) return 0;
            return rdr.GetInt64(ordinal);
        }

        public static string GetStringOrDefault(this SqliteDataReader rdr, string columnName)
        {
            var ordinal = rdr.GetOrdinalSafe(columnName);
            if (ordinal < 0 || rdr.IsDBNull(ordinal)) return string.Empty;
            return rdr.GetString(ordinal);
        }

        private static int GetOrdinalSafe(this SqliteDataReader rdr, string columnName)
        {
            try
            {
                return rdr.GetOrdinal(columnName);
            }
            catch (IndexOutOfRangeException)
            {
                return -1;
            }
        }
    }
}
