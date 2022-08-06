using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptCarRace
{
    internal class Player
    {

        // 플레이어 변수.
        public int _posY { get; private set; }                       //외부에서 위치값을 get으로 읽게만 하고 set을 private함으로 set을 방지한다.
        public int _posX { get; private set; }                       // 즉, 단순 읽기 속성



        ConsoleKeyInfo keys;                                 // 키 값을 입력 받을 수 있는 변수
        public void Initialize(int _posY, int _posX )
        {
            // 플레이어 초기값
            this._posY = _posY;
            this._posX = _posX;

        }

        #region Player_Render_&_Move

        private int MOVE_TICK = 10;         // 0.1 초 마다 움직이게
        private int _sumTick = 0;
        public void Update(int deltaTick)   // deltaTick은 메인 클래스에서 1프레임이 지날때마다 업데이트 되는 값을 받아온다
        {
            _sumTick += deltaTick;          // sumTick에 deltaTick을 더해준다.
            if (_sumTick >= MOVE_TICK)      //만약 sumTIck이 MOVE_TICK보다 커지거나 같아지면
            {
                _sumTick = 0;               //_sumTick을 초기화 시켜준다.


                // 여기에다가 0.1초마다 실행될 로직을 넣어 준다. ------------------------------------------------------

                if (Console.KeyAvailable == true)               // key.Available은 키 입력시 true, 입력받지 않을 시 false를 반환
                {
                    keys = Console.ReadKey();
                    if (keys.Key == ConsoleKey.RightArrow)
                    {
                        _posX ++;
                    }
                    if (keys.Key == ConsoleKey.LeftArrow)
                    {
                        _posX --;
                    }
                    if (keys.Key == ConsoleKey.UpArrow)
                    {
                        _posY --;
                    }
                    if (keys.Key == ConsoleKey.DownArrow)
                    {
                        _posY ++;
                    }
                }
            }
        }
        #endregion

    }
}
