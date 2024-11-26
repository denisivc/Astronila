using Astronila.Controller;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astronila
{
    public partial class FormStarsTwo : Form
    {
        Query controller;
        int correctAnswer2;
        
        int scoreG1 = 0;
        int scoreG2 = 0;

        string CurentGamer = "";
        string WinGamer = "";

        int questionNumberfTwo = 0;
        
        int totalQuestionsfTwo;

        Random rnd2 = new Random();

        List<int> lRnd2 = new List<int>();

        private List<Question> questions2 = new List<Question>();

        public string CurName()
        {
            if (questionNumberfTwo > 4)
                CurentGamer = GameParametres.NameGamer2;
            else
                CurentGamer = GameParametres.NameGamer1;
            return CurentGamer;
        }

        public FormStarsTwo()
        {
            InitializeComponent();
            ResetButton();

            controller = new Query(ConnectionString.ConnStr);
            GetRandomNumbersTwo();
            GetQustionsTwo();
            askQuestionfTwo(questionNumberfTwo);
            totalQuestionsfTwo = 9;
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

        private void ClickAnswerEventfTwo(object sender, EventArgs e)
        {

            var senderObject = (Button)sender;
            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if (questionNumberfTwo >= 4)
            {
                label2.Text = "Играет игрок" + "- " + GameParametres.NameGamer2;
            }

            else
            {
                label2.Text = "Играет игрок" + "- " + GameParametres.NameGamer1;
            }

            if (buttonTag == correctAnswer2)
            {
                if (questionNumberfTwo > 4)
                {
                    scoreG1++;
                    Check(buttonTag, Color.Green);
                }
                else
                {
                    scoreG2++;
                    Check(buttonTag, Color.Green);
                }
            }
            else
            {
                Check(buttonTag, Color.Red);
                Check(correctAnswer2, Color.Green);
            }


            if (questionNumberfTwo == totalQuestionsfTwo)
            {
                
                if (scoreG1 > scoreG2)
                    WinGamer = GameParametres.NameGamer1;
                if (scoreG1 < scoreG2)
                    WinGamer = GameParametres.NameGamer2;
                if (scoreG1 == scoreG2)
                    WinGamer = "ничья";
                MessageBox.Show("Игра окончена" + Environment.NewLine +
                            "Правильных ответов - " + + scoreG1 + ", игрок - " + GameParametres.NameGamer1 + Environment.NewLine +
                            "Правильных ответов - " + +scoreG2 + ", игрок - " + GameParametres.NameGamer2 + Environment.NewLine +
                            "Победил игрок - " + WinGamer + Environment.NewLine
            );

                FormStarsTwo.ActiveForm.Close();
                scoreG1 = 0;
                scoreG2 = 0;
                questionNumberfTwo = 0;

                askQuestionfTwo(questionNumberfTwo);
            }

            questionNumberfTwo++;

            askQuestionfTwo(questionNumberfTwo);
        }//Click

        void GenQuest(List<int> lst2)
        
        {
            for (int ctr = 1; ctr <= 55; ctr = ctr + 6)
            {
                int rn = rnd2.Next(ctr, ctr + 6);
                lst2.Add(rn);
            }
        }//Gen
        public void GetRandomNumbersTwo()
        {
            GenQuest(lRnd2);
        }

        public void GetQustionsTwo()
        {
            DataTable dv = controller.GetQuestion("QuestionsStars");
            foreach (int id in lRnd2)
            {
                Question qe = new Question(dv.Rows[id]["q"].ToString(), dv.Rows[id]["answ1"].ToString(), dv.Rows[id]["answ2"].ToString(), dv.Rows[id]["answ3"].ToString(), int.Parse(dv.Rows[id]["answTrueNum"].ToString()));
                questions2.Add(qe);
            }
        }//Get Questions

        private async Task askQuestionfTwo(int qnum)
        {
            if (qnum >0)
            {
                await Task.Delay(700);
            }
            ResetButton();

            Question q2 = questions2[qnum];
            label1f4Db.Text = q2.Name.ToString();

            button1.Text = q2.A1;
            button2.Text = q2.A2;
            button3.Text = q2.A3;

            correctAnswer2 = q2.CorrectAnsw;

        }

        private void FormStarsTwo_Load(object sender, EventArgs e)
        {
            label2.Text = "Играет игрок- " + CurName(); 
        }
    }
}
