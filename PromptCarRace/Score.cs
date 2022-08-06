using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptCarRace
{
    internal class Score
    {
        PointObj _pointObj;
        Player _player;
        Random random = new Random();
        private int score;

        public void Initialize(PointObj _pointObj, Player _player)
        {

            this._pointObj = _pointObj;
            this._player = _player;
        }

        public void DrawScore()
        {
            // 스코어 값을 받아서 출력한다.
            ScoreCount();
            Console.WriteLine($@"
                            Score : {score}



");
        }

        #region Score_Count_&_PointObjects_Position_Reset
        private void ScoreCount()
        {
            // PointObjects 의 Pos값이 Player의 Pos 값이 같으면 점수를 올리고 PointObjects의 위치값 Reset
            if (_pointObj._pos0X == _player._posX && _pointObj._pos0Y == _player._posY)
            {
                score += 100;
                Console.Beep();
                _pointObj._pos0X = random.Next(0, 15);
                _pointObj._pos0Y = 0;

            }
            else if (_pointObj._pos1X == _player._posX && _pointObj._pos1Y == _player._posY)
            {
                score += 100;
                Console.Beep();
                _pointObj._pos1X = random.Next(15, 30);
                _pointObj._pos1Y = 0;
            }
        }
        #endregion





    }
}
