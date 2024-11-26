using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astronila
{
    internal class Question
    {
        
            public string Name;

            public string A1;
            public string A2;
            public string A3;
            public string Path;
            public int CorrectAnsw;

            //конструктор для текстовых вопросов 
            public Question(string name, string a1, string a2, string a3, int coransw)
            {
                this.Name = name;

                this.A1 = a1;
                this.A2 = a2;
                this.A3 = a3;
                this.CorrectAnsw = coransw;

            }
        //конструктор для текстовых вопросов с картинкой
        public Question(string name, string a1, string a2, string a3, int coransw, string path)
        {
            this.Name = name;

            this.A1 = a1;
            this.A2 = a2;
            this.A3 = a3;
            this.CorrectAnsw = coransw;
            this.Path = path;

        }


    }
}
