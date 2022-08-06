using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptCarRace
{
    internal class Board
    {
        private char BLOCK = '■';

        public TileType[,] Tile { get; private set; }
        public int _sizeY { get; private set; }
        public int _sizeX { get; private set; }

        Player _player;
        Obstacles _obstacles;
        PointObj _pointObj;

        public enum TileType // 타일 타입을 정의 
        {
            Empty,   
            Obstacles,
            PointObj,
        }


        public void Initialize(int _sizeY, int _sizeX, Player _player, Obstacles _obstacles, PointObj _pointObj)
        {
            // 맵 사이즈 설정
            this._sizeY = _sizeY;
            this._sizeX = _sizeX;

            // 타일 배열은 맵 사이즈로 결정된다.
            Tile = new TileType[_sizeY, _sizeX];

            // 클래스 객체를 파라미터로 넘겨 받는다.
            this._player = _player;
            this._obstacles = _obstacles;
            this._pointObj = _pointObj;

            // 타일 색깔 초기값.
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    Tile[y, x] = TileType.Empty;                                              
                }
            }

        }

        public void Render()
        {                                     
            ConsoleColor prevColor = Console.ForegroundColor;
            
            for (int y = 0; y < _sizeY; y++)
            {
                Console.Write("    ");                                              // 게임보드를 콘솔창 중간까지 밀어낸다.
                for (int x = 0; x < _sizeX; x++)
                {
                    // 플레이어 색 설정
                    if (y == _player._posY && x == _player._posX)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    // ------------------- 장애물 색 설정 --------------------
                    else if ((y == _obstacles._pos0Y && x == _obstacles._pos0X) ||
                            (y == _obstacles._pos1Y && x == _obstacles._pos1X) ||
                            (y == _obstacles._pos2Y && x == _obstacles._pos2X) ||
                            (y == _obstacles._pos3Y && x == _obstacles._pos3X) ||
                            (y == _obstacles._pos4Y && x == _obstacles._pos4X) ||
                            (y == _obstacles._pos5Y && x == _obstacles._pos5X))
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    // --------------------------------------------------------

                    // PointObjects 색을 그린다.
                    else if ((y == _pointObj._pos0Y && x == _pointObj._pos0X) ||
                            (y == _pointObj._pos1Y && x == _pointObj._pos1X))
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                    // 나머지
                    else
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);

                    Console.Write(BLOCK);  // 블럭 1개 그림
                }

                Console.WriteLine();  // 개행
            }

            Console.ForegroundColor = prevColor;
        }


        ConsoleColor GetTileColor(TileType type)
        {
            // 타일의 색을 지정하는 곳.
            switch (type)
            {
                case TileType.Empty:  
                    return ConsoleColor.DarkGray;
                default:  
                    return ConsoleColor.DarkGray;
            }
        }


    }
}
