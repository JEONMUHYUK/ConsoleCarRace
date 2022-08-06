using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptCarRace
{
    internal class DataManager
    {
        public void dataManager()
        {
            Console.SetWindowSize(71, 71);

            Random random = new Random();
            Board _board = new Board();
            Player _player = new Player();
            Obstacles _obstacles = new Obstacles();
            PointObj _pointObj = new PointObj();
            Score _score = new Score();
            GameOver gameOver = new GameOver();
            StartScene startScene = new StartScene();


            _score.Initialize(_pointObj, _player);
            _board.Initialize(40, 30, _player, _obstacles, _pointObj);
            _pointObj.Initialize(0, random.Next(0, 15), 0, random.Next(15, 30), _board._sizeY, _obstacles);
            _obstacles.Initialize(0, random.Next(0, 15), 0, random.Next(15, 30),
                0, random.Next(0, 15), 0, random.Next(15, 30), 0, random.Next(0, 15), 0, random.Next(15, 30),
                _board._sizeY);

            _player.Initialize(39, 15);

            //----------------start Scene------------------
            startScene.Start();
            Console.Clear();
            //---------------------------------------------

            Console.CursorVisible = false;


            const int WAIT_TICK = 1000 / 30;            // const로 프레임 값을 변경할 수 없게 선언한다.

            int lastTick = 0;

            while (true)
            {
                #region 프레임 관리
                int currentTick = System.Environment.TickCount;  // 밀리 세컨즈로 나타낸 현재시간.  1초 = 1000 밀리세컨즈
                if (currentTick - lastTick < WAIT_TICK) // 만약 경과한 시간이 1/30초보다 작다면 아래 모든 부분을 실행하지 않고 다시 위로
                    continue;

                int deltaTick = currentTick - lastTick;         // 1프레임 지날 때마다 업데이트
                lastTick = currentTick;  // 마지막 측정 시간 업뎃


                #endregion

                // 1프레임이 지날때마다 업데이트 되는 값을 전달
                _player.Update(deltaTick);              
                _obstacles.Update(deltaTick);
                _pointObj.Update(deltaTick);
                //---------------------------------------------


                #region GameOver 조건
                // 플레이어 위치값이 장애물 위치값과 같아지면 GameOver 함수 실행
                if ((_player._posY == _obstacles._pos0Y && _player._posX == _obstacles._pos0X) ||
                    (_player._posY == _obstacles._pos1Y && _player._posX == _obstacles._pos1X) ||
                    (_player._posY == _obstacles._pos2Y && _player._posX == _obstacles._pos2X) ||
                    (_player._posY == _obstacles._pos3Y && _player._posX == _obstacles._pos3X) ||
                    (_player._posY == _obstacles._pos4Y && _player._posX == _obstacles._pos4X) ||
                    (_player._posY == _obstacles._pos5Y && _player._posX == _obstacles._pos5X)
                    )
                {
                    Console.Clear();
                    gameOver.DrawGameOver();
                    break;
                }

                #endregion

                Console.SetCursorPosition(0, 0);
                _score.DrawScore();
                _board.Render();

            }



        }
    }
}
