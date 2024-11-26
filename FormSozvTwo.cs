using Astronila.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Astronila
{
    public partial class FormSozvTwo : KryptonForm
    {

        Query controller;
        int correctAnswer3;

        int scoreG11 = 0;
        int scoreG21 = 0;

        string CurentGamer2 = "";
        string WinGamer2 = "";

        int questionNumberSozvTwo = 0;

        int totalQuestionssozvTwo;

        Random rnd2sozv = new Random();

        List<int> lRnd2sozv = new List<int>();

        private List<Question> questions2sozv = new List<Question>();

        public FormSozvTwo()
        {
            InitializeComponent();

            ResetButton();

            controller = new Query(ConnectionString.ConnStr);

            GetRandomNumbersSozv();

            GetQustionsSozv();

            askQuestionSozvSozv(questionNumberSozvTwo);

            totalQuestionssozvTwo = 9;
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

        void GenQuestSozv(List<int> lst2sozv)

        {
            for (int ctr = 1; ctr <= 55; ctr = ctr + 6)
            {
                int rn = rnd2sozv.Next(ctr, ctr + 6);
                lst2sozv.Add(rn);
            }
        }

        public void GetRandomNumbersSozv()
        {
            GenQuestSozv(lRnd2sozv);
        }

        //заполняем список вопросов по радномным номерам из access
        public void GetQustionsSozv()
        {
            DataTable dv = controller.GetQuestion("QuestionsCozv");
            foreach (int id in lRnd2sozv)
            {
                Question qe2 = new Question(dv.Rows[id]["q"].ToString(), dv.Rows[id]["answ1"].ToString(), dv.Rows[id]["answ2"].ToString(), dv.Rows[id]["answ3"].ToString(), int.Parse(dv.Rows[id]["answTrueNum"].ToString()), dv.Rows[id]["pict"].ToString());
                questions2sozv.Add(qe2);
            }
        }

        private async Task askQuestionSozvSozv(int qnum)
        {
            if (qnum >0)
            {
                await Task.Delay(700);
            }
            ResetButton();

            Question q2S = questions2sozv[qnum];
            System.Drawing.Image image = System.Drawing.Image.FromFile(@"..\..\Resources\" + q2S.Path);

            pictureBox1.Image = image;

            lblQuestionSozv.Text = q2S.Name.ToString();

            button1.Text = q2S.A1;
            button2.Text = q2S.A2;
            button3.Text = q2S.A3;

            correctAnswer3 = q2S.CorrectAnsw;

        }


        private void ClickAnswerEventSozv2(object sender, EventArgs e)
        {

            var senderObject = (Button)sender;
            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if (questionNumberSozvTwo >= 4)
            {
                label1.Text = "Играет игрок" + "- " + GameParametres.NameGamer2;
                
            }

            else
            {
                label1.Text = "Играет игрок" + "- " + GameParametres.NameGamer1;
            }

            if (buttonTag == correctAnswer3)
            {
                if (questionNumberSozvTwo > 4)
                {
                    scoreG21++;
                    Check(buttonTag, Color.Green);
                }
                else
                {
                    scoreG11++;
                    Check(buttonTag, Color.Green);
                }
            }
            else
            {
                Check(buttonTag, Color.Red);
                Check(correctAnswer3, Color.Green);
            }

            if (questionNumberSozvTwo == totalQuestionssozvTwo)
            {
                if (scoreG11 > scoreG21)
                    WinGamer2 = GameParametres.NameGamer1;
                if (scoreG11 < scoreG21)
                    WinGamer2 = GameParametres.NameGamer2;
                if (scoreG11 == scoreG21)
                    WinGamer2 = "ничья";

                MessageBox.Show("Игра окончена" + Environment.NewLine +
                            "Правильных ответов - " + +scoreG11 + ", игрок - " + GameParametres.NameGamer1 + Environment.NewLine +
                            "Правильных ответов - " + +scoreG21 + ", игрок - " + GameParametres.NameGamer2 + Environment.NewLine +
                            "Победил игрок - " + WinGamer2 + Environment.NewLine
            );

                FormStarsTwo.ActiveForm.Close();
                scoreG11 = 0;
                scoreG21 = 0;
                questionNumberSozvTwo = 0;

                askQuestionSozvSozv(questionNumberSozvTwo);
            }

            questionNumberSozvTwo++;

            askQuestionSozvSozv(questionNumberSozvTwo);

        }//click

        private void FormSozvTwo_Load(object sender, EventArgs e)
        {
            label1.Text = "Играет игрок- " + CurName2();
        }

        public string CurName2()
        {
            if (questionNumberSozvTwo > 4)
                CurentGamer2 = GameParametres.NameGamer2;
            else
                CurentGamer2 = GameParametres.NameGamer1;
            return CurentGamer2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
