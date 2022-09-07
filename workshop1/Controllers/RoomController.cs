using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workshop1.ViewModels;

namespace workshop1.Controllers
{
    public class RoomController : Controller
    {
        static RoomViewModel _room = new RoomViewModel();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int width=1, int height=1)
        {
            var dto = new RoomViewModel() { Width = width, Height = height };
            _room.Matrix = new string[dto.Width,dto.Height];
            dto.Matrix = _room.Matrix;
            return View(dto);
        }
        [HttpPost]
        public IActionResult AddFurniture(string name, int width=2, int height=2)
        {
            bool gotSpace = false;
            int legutolsoJoX = 0;
            int legutolsoJoY = 0;

            #region try1
            //    for (int i = 0; i < _room.Matrix.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < _room.Matrix.GetLength(1); j++)
            //        {
            //            if (_room.Matrix[i,j] ==null)
            //            {
            //            if (width==1 && height==1)
            //            {

            //            }
            //                int johelyX = 0;
            //                int johelyY = 0;
            //                for (int fi = 0; fi < width; fi++)
            //                {
            //                if (i+fi >= _room.Matrix.GetLength(0) - 1) continue;

            //                for (int fj = 0; fj < height; fj++)
            //                    {
            //                    if (j+fj >= _room.Matrix.GetLength(1) - 1) continue;
            //                    if (_room.Matrix[i + fi, j + fj] == null) { 
            //                        johelyY++;
            //                        legutolsoJoX = i + fi;
            //                        legutolsoJoY = j + fj;
            //                    }
            //                    }
            //                    if (johelyY == height) johelyX++;
            //                    else johelyY = 0;
            //                }
            //                if(johelyX == width)
            //                {
            //                gotSpace = true;
            //                break;
            //                }
            //            }
            //        }
            //    if (gotSpace) break;
            //    }

            //for (int i = 0; i < height-1; i++)
            //{
            //    _room.Matrix[legutolsoJoX - i, legutolsoJoY] = name;
            //}
            //for (int i = 0; i < width; i++)
            //{
            //    _room.Matrix[legutolsoJoX, legutolsoJoY - 1] = name;
            //}
            #endregion
            bool flag = false;
            for (int i = 0; i < _room.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _room.Matrix.GetLength(1); j++)
                {
                    flag = false;
                    for (int k = 0; k < height; k++)
                    {
                        for (int l = 0; l < width; l++)
                        {

                            if (_room.Matrix[i, j] != null)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (!flag)
                    {
                        for (int k = 0; k < height; k++)
                        {
                            for (int l = 0; l < width; l++)
                            {
                                _room.Matrix[i + k, j + l] = name;
                            }
                        }
                        break;
                    }
                    if (!flag)
                    { break; }
                }
                if (!flag)
                { break; }
            }
            return View("./Create",_room);
        }
    }
}
