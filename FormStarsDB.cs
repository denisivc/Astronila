using Astronila;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Astronila.Controller;
using ComponentFactory.Krypton.Toolkit;

namespace Astronila
{
        
     public partial class FormStarsDB : KryptonForm
    {
        Query controller;  
        int correctAnswerf4Db;
        int questionNumberf4Db = 0;
        int scoref4Db;
        int percentagef4Db;
        int totalQuestionsf4Db;

        Random rnd = new Random();

        List <int> lRnd = new List<int>();

        private List<Question> questions = new List<Question>();

       
        public FormStarsDB()
        {
            InitializeComponent();

            ResetButton();

            controller = new Query(ConnectionString.ConnStr);

            GetRandomNumbers();

            GetQustions();

            askQuestionf4Db(questionNumberf4Db);

            totalQuestionsf4Db = 9;

        }
        private void Check(int cor, Color clr)
        {
            if (cor == 1)
            {
                button1.BackColor = clr;
            }
            if (cor == 2)
            {
                button2.BackColor = clr;
            }
            if (cor == 3)
            {
                button3.BackColor = clr;
            }
        }

        private void ResetButton()
        {
            button1.BackColor = Color.FromArgb(6, 174, 244);
            button2.BackColor = Color.FromArgb(6, 174, 244);
            button3.BackColor = Color.FromArgb(6, 174, 244);
        }
        //обработчик для нажатия кнопки (1..3)
        private void ClickAnswerEventf4Db(object sender, EventArgs e)
        {

            var senderObject = (Button)sender;
            int buttonTag = Convert.ToInt32(senderObject.Tag);

            string GrUser = "";

            if (buttonTag == correctAnswerf4Db)
            {
                scoref4Db++;
                Check(buttonTag, Color.Green);
            }
            else
            {
                Check(buttonTag, Color.Red);
                Check(correctAnswerf4Db, Color.Green);
            }

            if (questionNumberf4Db == totalQuestionsf4Db)
            {
                percentagef4Db = (int)Math.Round((double)(100 * scoref4Db) / (totalQuestionsf4Db+1));
                
                GrUser = GetGrade(percentagef4Db);
               
                controller.AddAnswer(GameParametres.NameGamer, DateTime.Now.ToString(), scoref4Db, percentagef4Db, GrUser,"Звезды");
                
                    MessageBox.Show("Игра окончена" + Environment.NewLine +
                                "Правильных ответов -" + scoref4Db + " " + Environment.NewLine +
                                "Всего % " + percentagef4Db + " %" + " " + Environment.NewLine +
                                "Ваша оценка - " + GrUser
                 );

                FormStarsDB.ActiveForm.Close();
                scoref4Db = 0;
                questionNumberf4Db = 0;

                askQuestionf4Db(questionNumberf4Db);
            }

            questionNumberf4Db++;

            askQuestionf4Db(questionNumberf4Db);
        }

        //рандом для диапазонов с шагом
        void GenQuest(List<int> lst)
        

        {
            for (int ctr = 1; ctr <= 55; ctr = ctr + 6)
            {
                int rn = rnd.Next(ctr, ctr + 6);
                lst.Add(rn);
            }
        }

        //Заполняем список
        public void GetRandomNumbers()
        {
            GenQuest(lRnd);
        }

        public string GetGrade(int Percent)
        {
            string gr = "";

            if (Percent > 0)
            {
                if (Percent < 50)
                    gr = "Неудовлетворительно";
                if ((Percent < 65) && (Percent >= 50))
                    gr = "Удовлетворительно";
                if ((Percent < 80) && (Percent >= 65))
                    gr = "Хорошо";
                if (Percent >= 80)
                    gr = "Отлично";
            }
            else
            {
                gr = "Ужасно!";
            }
            return gr;
        }

        //получаем Список объектов вопросов с нужными ID
        public void GetQustions()
        {
            DataTable dv = controller.GetQuestion("QuestionsStars");
            foreach (int id in lRnd)
            {
                Question qe = new Question(dv.Rows[id]["q"].ToString(), dv.Rows[id]["answ1"].ToString(),dv.Rows[id]["answ2"].ToString(),dv.Rows[id]["answ3"].ToString(), int.Parse(dv.Rows[id]["answTrueNum"].ToString()));
                questions.Add(qe);
            }    
        }

        //выводим вопрос и ответы в форму
        private async Task askQuestionf4Db(int qnum)
        {
            if (qnum >0)
            {
                await Task.Delay(700);
            }
            
            ResetButton();

            Question q  = questions[qnum];
            label1f4Db.Text = q.Name.ToString();

            button1.Text = q.A1;
            button2.Text = q.A2;
            button3.Text = q.A3;

            correctAnswerf4Db = q.CorrectAnsw;
            
        }

    }
}
