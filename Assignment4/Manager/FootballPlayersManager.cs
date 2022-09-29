using Assignment1;

namespace Assignment4.Manager
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;
        private static readonly List<FootballPlayer> Data = new List<FootballPlayer>
        {
            new FootballPlayer {Id = _nextId++, Name="John Johnson", Age=18,ShirtNumber=18},
            new FootballPlayer {Id = _nextId++, Name="Peter Peterson", Age=19,ShirtNumber=19},
            new FootballPlayer {Id = _nextId++, Name="Katy Katherin", Age=18,ShirtNumber=20},
            new FootballPlayer {Id = _nextId++, Name="Tom Thomason", Age=22,ShirtNumber=21}
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        };

        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(Data);
        }

        public FootballPlayer GetById(int id)
        {
            return Data.Find(player => player.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newPlayer)
        {
            newPlayer.Id = _nextId++;
            Data.Add(newPlayer);
            return newPlayer;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer player = Data.Find(player1 => player1.Id == id);
            if (player == null) return null;
            Data.Remove(player);
            return player;
        }

        public FootballPlayer Update(int id, FootballPlayer updates)
        {
            FootballPlayer player = Data.Find(player1 => player1.Id == id);
            if (player == null) return null;
            player.Name = updates.Name;
            player.Age = updates.Age;
            player.ShirtNumber = updates.ShirtNumber;
            return player;
        }
    }
}
