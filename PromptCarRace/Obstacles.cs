using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PromptCarRace
{
    internal class Obstacles
    {
        #region obstaclePos
        public int _pos0Y { get; private set; }                       
        public int _pos0X { get; private set; }                      
        public int _pos1Y { get; private set; }                       
        public int _pos1X { get; private set; }                      
        public int _pos2Y { get; private set; }                      
        public int _pos2X { get; private set; }                      
        public int _pos3Y { get; private set; }                       
        public int _pos3X { get; private set; }                       
        public int _pos4Y { get; private set; }                       
        public int _pos4X { get; private set; }                       
        public int _pos5Y { get; private set; }                       
        public int _pos5X { get; private set; }
        #endregion


        private int _sizeY;

        public int count = 0;

       Random random = new Random();

        public void Initialize(int _pos0Y, int _pos0X, int _pos1Y, int _pos1X,
            int _pos2Y, int _pos2X, int _pos3Y, int _pos3X, int _pos4Y, int _pos4X, int _pos5Y, int _pos5X,
             int _sizeY)
        {
            this._pos0Y = _pos0Y;
            this._pos0X = _pos0X;

            this._pos1Y = _pos1Y;
            this._pos1X = _pos1X;

            this._pos2Y = _pos2Y;
            this._pos2X = _pos2X;

            this._pos3Y = _pos3Y;
            this._pos3X = _pos3X;

            this._pos4Y = _pos4Y;
            this._pos4X = _pos4X;

            this._pos5Y = _pos5Y;
            this._pos5X = _pos5X;


            this._sizeY = _sizeY;

        }

        private int MOVE_TICK = 10;   // 0.01 초 마다 움직이게       // 속도 설정
        private int _sumTick = 0;
        public void Update(int deltaTick)  // deltaTick은 메인 클래스에서 1프레임이 지날때마다 업데이트 되는 값을 받아온다
        {
            //_sumTick을 초기화 시켜준다.
            // 여기에다가 0.1초마다 실행될 로직을 넣어 준다. 
            _sumTick += deltaTick;          // sumTick에 deltaTick을 더해준다.
            if (_sumTick >= MOVE_TICK)      //만약 sumTIck이 MOVE_TICK보다 커지거나 같아지면
            {
                _sumTick = 0;               //_sumTick을 초기화 시켜준다.

                //  Obstacles 장애물 다음 위치 설정 
                if (_pos0Y == _sizeY - 1)
                {
                    _pos0Y = 0;
                    _pos0X = random.Next(0, 15);
                }
                else if (_pos1Y == _sizeY - 1)
                {
                    _pos1X = random.Next(15, 30);
                    _pos1Y = 0;
                }
                else if (_pos2Y == _sizeY - 1)
                {
                    _pos2Y = 0;
                    _pos2X = random.Next(0, 15);
                }
                else if (_pos3Y == _sizeY - 1)
                {
                    _pos3X = random.Next(15, 30);
                    _pos3Y = 0;
                }
                else if (_pos4Y == _sizeY - 1)
                {
                    _pos4Y = 0;
                    _pos4X = random.Next(0, 15);
                }
                else if (_pos5Y == _sizeY - 1)
                {
                    _pos5X = random.Next(15, 30);
                    _pos5Y = 0;
                }

                // --------------------------------------
                #region startCount
                // ------------- Obstacles 출발 시간 -------
                count++;

                if (count > 0)
                {
                    _pos0Y++;
                }
                if (count > 5)
                {
                    _pos1Y++;
                }
                if (count > 10)
                {
                    _pos2Y++;
                }
                if (count > 15)
                {
                    _pos3Y++;
                }
                if (count > 20)
                {
                    _pos4Y++;
                }
                if (count > 25)
                {
                    _pos5Y++;

                    count = 26;
                }

                // ------------------------------------------
                #endregion
            }



        }

    }
}
