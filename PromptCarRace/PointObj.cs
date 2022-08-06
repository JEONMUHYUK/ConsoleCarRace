using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptCarRace
{
    internal class PointObj
    {

        Obstacles _obstacles;
        Random random = new Random();

        // 위치값
        public int _pos0Y;
        public int _pos0X;
        public int _pos1Y;
        public int _pos1X;

        private int _mapSizeY;


        public void Initialize(int _pos0Y, int _pos0X, int _pos1Y, int _pos1X, int _mapSizeY, Obstacles obstacles)
        {
            // PointObject 초기값
            this._pos0Y = _pos0Y;
            this._pos0X = _pos0X;

            this._pos1Y = _pos1Y;
            this._pos1X = _pos1X;

            // 장애물 클래스 
            _obstacles = obstacles;

            // 맵 y축 크기
            this._mapSizeY = _mapSizeY;


        }

        #region PointObjects_Render_&_PosReset

        private int MOVE_TICK = 100;            //0.1초 마다 움직인다.
        private int _sumTick = 0;               // deltaTick을 담는 변수
        public void Update(int deltaTick)  
        {
            
            _sumTick += deltaTick;          
            if (_sumTick >= MOVE_TICK)      
            {
                _sumTick = 0;               

                //  PointObj 장애물 다음 위치 설정 
                if (_pos0Y == _mapSizeY - 1)
                {
                    _pos0Y = 0;
                    _pos0X = random.Next(0, 15);
                }
                else if (_pos1Y == _mapSizeY - 1)
                {
                    _pos1X = random.Next(15, 30);
                    _pos1Y = 0;
                }

                // ------------- PointObj 출발 시간 -------
                if (_obstacles.count > 0)
                {
                    _pos0Y++;
                }
                if (_obstacles.count > 5)
                {
                    _pos1Y++;
                }

                // ------------------------------------------
            }
        }
        #endregion
    }
}
