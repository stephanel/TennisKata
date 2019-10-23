using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame
    {
        readonly Dictionary<int, string> _scoreMapping = new Dictionary<int, string>()
        {
            { 0, "love" },
            { 1, "fifteen" },
            { 2, "thirty" },
            { 3, "forty" },
        };

        private readonly int _player1Points;
        private readonly int _player2Points;

        public TennisGame(int player1Points, int player2Points)
        {
            this._player1Points = player1Points;
            this._player2Points = player2Points;
        }

        public string GetScore()
        {
            if (this.PlayerOneWins()) return "player one wins!";
            if (this.PlayerTwoWins()) return "player two wins!";
            if (this.IsAdvantage()) return "advantage";
            if (this.IsDeuce()) return "deuce";

            return $"{_scoreMapping[_player1Points]} {_scoreMapping[_player2Points]}";
        }

        public bool PlayerOneWins()
        {
            return _player1Points - _player2Points >= 2 && _player1Points >= 4;
        }

        public bool PlayerTwoWins()
        {
            return _player2Points - _player1Points >= 2 && _player2Points >= 4;
        }

        public bool IsAdvantage()
        {
            return Math.Abs(_player1Points - _player2Points) == 1 && Math.Max(_player1Points, _player2Points) >= 3;
        }

        public bool IsDeuce()
        {
            return _player2Points == _player1Points && _player2Points >= 3;
        }
    }
}
