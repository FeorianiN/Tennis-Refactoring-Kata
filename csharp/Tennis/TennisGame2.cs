using System.Collections.Generic;
using System;

namespace Tennis
{
    public class TennisGame2 (string player1Nam, string player2Nam) : ITennisGame
    {
        private int p1point => 0;
        private int p2point => 0;
        private string p1res => "";
        private string p2res => "";
        private string player1Name => player1Nam;
        private string player2Name => player2Nam;

        public TennisGame2() : this (player1Name, player2Name) { }

        // determining the current score in a game
        public string GetScore()
        {
            var score = "";
            var pointNames = new Dictionary<int, string>
            {
                { 0, "Love" },
                { 1, "Fifteen" },
                { 2, "Thirty" },
                { 3, "Forty" }
            };

            // processing of tied results
            if (p1point == p2point)
            {
                if (p1point < 3)
                    score = pointNames[p1point] + "-All";
                else
                    score = "Deuce";
            }
            else if (p1point >= 4 || p2point >= 4)
            {
                var pointDiff = Math.Abs(p1point - p2point);

                // if the gap is big enough, the game ends
                if (pointDiff >= 2)
                    score = "Win for " + (p1point > p2point ? "player1" : "player2");

                // processing advantage game-stage
                else if (pointDiff == 1)
                    score = "Advantage " + (p1point > p2point ? "player1" : "player2");
            }
            else
                score = pointNames[p1point] + "-" + pointNames[p2point];

            return score;
        }

        // increasing the score of any player
        public void SetPlayerScore(int playerNumber, int number)
        {
            for (int i = 0; i < number; i++)
            {
                if (playerNumber == 1)
                    p1point++;
                else if (playerNumber == 2)
                    p2point++;
            }
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                SetPlayerScore(1, 1);
            else
                SetPlayerScore(2, 1);
        }

    }
}

