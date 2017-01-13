using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    class RankSerializers
    {
        // ETAP 2
        public static MemoryStream SerializeBinary(Ranking ranking)
        {
            // E2 - zaimplementowac
            MemoryStream ms = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(ms, ranking);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
        public static Ranking DeserializeBinary(MemoryStream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return (Ranking)binaryFormatter.Deserialize(stream);
        }

        // ETAP 3
        public static void SerializeSOAP(Ranking ranking, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            SoapFormatter soapFormatter = new SoapFormatter();
            soapFormatter.Serialize(fs, ranking.Teams.Count);
            foreach (var team in ranking.Teams)
            {
                soapFormatter.Serialize(fs, team.Id);
                soapFormatter.Serialize(fs, team.Name);
                soapFormatter.Serialize(fs, team.Players.Count);
                foreach (var player in team.Players)
                    soapFormatter.Serialize(fs, player);
            }
            fs.Close();
        }
        public static Ranking DeserializeSOAP(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            SoapFormatter soapFormatter = new SoapFormatter();
            int teamsAmount = (int)soapFormatter.Deserialize(fs);

            List<Team> teams = new List<Team>(teamsAmount);
            for (int i=0; i < teamsAmount; i++)
            {
                int teamId = (int)soapFormatter.Deserialize(fs);
                string teamName = (string)soapFormatter.Deserialize(fs);
                Team team = new Team(teamId, teamName);

                int playersCount = (int)soapFormatter.Deserialize(fs);
                for (int j=0; j < playersCount; j++)
                {
                    Player player = soapFormatter.Deserialize(fs) as Player;
                    team.AddPlayer(player);
                }
                
                teams.Add(team);
            }
            
            fs.Close();
            return new Ranking(teams);
        }

        // ETAP 5 - serializacja do pliku tekstowego w formacie podanym w treści zadania
        public static void SerializeOwn(Ranking ranking, Stream stream)
        {
            byte[] bytes = new UTF8Encoding().GetBytes(ranking.ToText());
            stream.Write(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
        }
        public static Ranking DeserializeOwn(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);

            return Ranking.FromText(Encoding.UTF8.GetString(bytes));
        }
    }
}
