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
using static System.Net.Mime.MediaTypeNames;
using ComponentFactory.Krypton.Toolkit;


namespace Astronila
{
    public partial class FormSovz : KryptonForm
    {

        Query controller;
        int correctAnswerSozv;
        int questionNumberSozv = 0;
        int scorefSozv;
        int percentageSozv;
        int totalQuestionsSozv;

        Random rnd = new Random();

        List<int> lRnd = new List<int>();

        private List<Question> questions = new List<Question>();

        public FormSovz()
        {
            InitializeComponent();

            ResetButton();

            controller = new Query(ConnectionString.ConnStr);

            GetRandomNumbers();

            GetQustions();

            askQuestionSozv(questionNumberSozv);

            totalQuestionsSozv = 9;
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

        void GenQuest(List<int> lst)

        {
            for (int ctr = 1; ctr <= 55; ctr = ctr + 6)
            {
                int rn = rnd.Next(ctr, ctr + 6);
                lst.Add(rn);
            }
        }
        //метод для получения оценки
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

        //заполняем список 10 случайными числами по порядку
        public void GetRandomNumbers()
        {
            GenQuest(lRnd);
        }
        
        //заполняем список вопросов по радномным номерам из access
        public void GetQustions()
        {
            DataTable dv = controller.GetQuestion("QuestionsCozv");
            foreach (int id in lRnd)
            {
                Question qe = new Question(dv.Rows[id]["q"].ToString(), dv.Rows[id]["answ1"].ToString(), dv.Rows[id]["answ2"].ToString(), dv.Rows[id]["answ3"].ToString(), int.Parse(dv.Rows[id]["answTrueNum"].ToString()), dv.Rows[id]["pict"].ToString());
                questions.Add(qe);
            }
        }
        //выводим вопросы на форму
        private async Task askQuestionSozv(int qnum)
        {
            if (qnum >0)
            {
                await Task.Delay(700);
            }
            ResetButton();


            Question q = questions[qnum];
            System.Drawing.Image image = System.Drawing.Image.FromFile(@"..\..\Resources\" + q.Path);

            pictureBox1.Image = image;

            lblQuestionSozv.Text = q.Name.ToString();

            button1.Text = q.A1;
            button2.Text = q.A2;
            button3.Text = q.A3;

            correctAnswerSozv = q.CorrectAnsw;

        }
        //обратотчик для button1 button2 button3 - проверяется ответ, пишется в базу и переход на след вопрос
        private void ClickAnswerEventSozv(object sender, EventArgs e)
        {

            var senderObject = (Button)sender;
            int buttonTag = Convert.ToInt32(senderObject.Tag);

            string GrUser = "";

            if (buttonTag == correctAnswerSozv)
            {
                 scorefSozv++;
                 Check(buttonTag, Color.Green);
                 //MessageBox.Show("Green");
            }
            else
            {
                Check(buttonTag, Color.Red);
                Check(correctAnswerSozv, Color.Green);

                //MessageBox.Show("RED");
            }

            if (questionNumberSozv == totalQuestionsSozv)
            {
                percentageSozv = (int)Math.Round((double)(100 * scorefSozv) / (totalQuestionsSozv + 1));

                GrUser = GetGrade(percentageSozv);

                controller.AddAnswer(GameParametres.NameGamer, DateTime.Now.ToString(), scorefSozv, percentageSozv, GrUser, "Созвездия");

                MessageBox.Show("Игра окончена" + Environment.NewLine +
                            "Правильных ответов -" + scorefSozv + " " + Environment.NewLine +
                            "Всего % " + percentageSozv + " %" + " " + Environment.NewLine +
                            "Ваша оценка - " + GrUser
             );

                FormStarsDB.ActiveForm.Close();
                scorefSozv = 0;
                questionNumberSozv = 0;

                askQuestionSozv(questionNumberSozv);
            }

            questionNumberSozv++;

            askQuestionSozv(questionNumberSozv);
        }


        private void FormSovz_Load(object sender, EventArgs e)
        {

        }
    }
}
