using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workshop1.ViewModels
{
    public class RoomViewModel
    {
        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public string[,] Matrix { get => matrix; set => matrix = value; }

        private string[,] matrix;
    }
}
