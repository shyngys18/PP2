using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
    class Wall : GameObject
    {
        public Wall(char sign) : base(sign)
        {
            LoadLevel(1);
        }

        void LoadLevel(int level)
        {
            string name = string.Format(@"C:\Users\Shyngys\Desktop\Week1/level1.txt", level);
            using (StreamReader streamReader = new StreamReader(name))
            {
                int r = 0;
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    for (int c = 0; c < line.Length; ++c)
                    {
                        if (line[c] == '#')
                        {
                            body.Add(new Point(c, r));
                        }
                    }
                    r++;
                }
            }
        }
    }
}
