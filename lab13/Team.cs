using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lab13
{
    [Serializable] class Team
    {
        private static int maxId = 0;
        private string name;
        private int id;
        
        private List<Player> players;

        public int Id => id;
        public string Name
        {
            get { return name; }
        }
        public List<Player> Players
        {
            get { return players; }
        }
        public double Score
        {
            get { return teamScore; }
        }
        
        private int GetIndex()
        {
            return ++maxId;
        }

        public Team(int teamMembersCount)
        {
            id = GetIndex();
            name = "Team_" + id;
            players = new List<Player>(teamMembersCount);
            for (int i = 0; i < teamMembersCount; i++)
                AddPlayer(new Player());
        }

        public Team(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.players = new List<Player>();
            if (id > maxId)
                maxId = id;
        }

        private Team(string[] teamDetails)
        {
            id = int.Parse(teamDetails[0]);
            name = "Team_" + id;

            players = new List<Player>(teamDetails.Length - 1);
            for (int i = 1; i < teamDetails.Length; i++)
            {
                Player player = Player.FromText(teamDetails[i]);
                players.Add(player);
                teamScore += player.Score;
            }
                

            if (id > maxId)
                maxId = id;
        }

        public void AddPlayer(Player p)
        {
            players.Add(p);
            teamScore += p.Score;
        }

        public override string ToString()
        {
            string ret = String.Format("Team: {0} has {1} players" + Environment.NewLine, name, players.Count);
            players.ForEach(p => ret += p.ToString() + Environment.NewLine);
            ret += "Team Score is " + Score + Environment.NewLine + Environment.NewLine; 
            return ret;
        }
        private double teamScore = 0;

        // ETAP 4
        public string ToText()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id);
            foreach (var player in players)
                sb.AppendFormat(",{0}", player.ToText());
                
            return sb.ToString();
        }

        // ETAP 5
        static public Team FromText(string teamRecordData)
        {
            return new Team(teamRecordData.Split(','));
        }
}
}
