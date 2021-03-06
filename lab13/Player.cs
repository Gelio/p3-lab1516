﻿using System;
using System.Runtime.Serialization;
using System.Text;

namespace Lab13
{
    [Serializable] class Player
    {
        private static int NAME_LENGTH = 3;
        private static Random rand = new Random(0);
        private static int maxId = -1;

        private int id;
        private string nickname;
        private int age;
        private double score;
        
        public int Id
        {
            get { return id; }
        }
        public string Name
        {
            get { return nickname; }
        }
        public int Age
        {
            get { return age; }
        }
        public double Score
        {
            get { return score; }
        }

        private static string GenerateName()
        {
            string name = "";
            for (int i = 0; i < NAME_LENGTH; ++i)
                name += Char.ConvertFromUtf32(rand.Next('z' - 'a') + 'a');
            return name;
        }

        private static int GenerateAge()
        {
            return rand.Next(20) + 16;
        }

        public Player()
        {
            id = ++maxId;
            this.nickname = GenerateName();
            this.age = GenerateAge();
            this.score = rand.Next() % 1000;
        }
        private Player(int id) {
            this.id = id;
        }
        public override string ToString()
        {
            return "player: " + id + " name: " + nickname + " age: " + age + " score: " + score;
        }

        // ETAP 4
        public string ToText()
        {
            return string.Format("{0}|{1}|{2}|{3}", id, nickname, age, score);
        }

        // ETAP 5
        static public Player FromText(string playerDetailsString)
        {
            string[] playerParts = playerDetailsString.Split('|');
            Player player = new Player(int.Parse(playerParts[0]));
            player.nickname = playerParts[1];
            player.age = int.Parse(playerParts[2]);
            player.score = int.Parse(playerParts[3]);
            return player;
        }
    }
}
