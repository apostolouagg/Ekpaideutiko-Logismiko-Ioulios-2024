using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EkpaideutikoLogismiko2024
{
    public partial class Quiz : Form
    {
        String username;
        int currentUnitID;
        int x = 5;

        public Quiz(string username, int currentUnitID)
        {
            InitializeComponent();
            this.username = username;
            this.currentUnitID = currentUnitID;
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            StartQuiz();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-9RR5NNA6\MSSQLSERVER01;Initial Catalog=Learn;Integrated Security=True;");

        private int currentQuestionId;
        public int questioncounter = 1;


        private void StartQuiz()
        {
            switch (currentUnitID)
            {
                case 1:
                    currentQuestionId = 1;
                    break;
                case 2:
                    currentQuestionId = 11;
                    break;
                case 3:
                    currentQuestionId = 21;
                    break;
                case 4:
                    currentQuestionId = 31;
                    break;
                case 10:
                    currentQuestionId = 41;
                    break;
            }

            LoadQuestion(currentQuestionId);
        }

        private void LoadQuestion(int questionId)
        {

            if (currentUnitID != 10)
            {
                string queryQuestions = "SELECT QuestionText,QuestionID,UnitID FROM Questions " +
                                        "WHERE QuestionID = @QuestionID AND UnitID='" + currentUnitID + "'";

                SqlCommand command = new SqlCommand(queryQuestions, conn);
                command.Parameters.AddWithValue("@QuestionID", questionId);
                command.Parameters.AddWithValue("@UnitId", quizUnit.Text);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Display the question
                        quizUnit.Text = "Unit " + reader["UnitId"];
                        questionLabel.Text = reader["QuestionText"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No more questions.");

                        conn.Close();

                        this.Hide();
                        var Menu = new Menu(username);
                        Menu.Closed += (s, args) => this.Close();
                        Menu.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving question: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            else if(currentUnitID == 10)
            {
                string q = "SELECT QuestionText, QuestionID, UnitID FROM Questions " +
                                        "WHERE QuestionID = @QuestionID AND UnitID IN (5, 6, 7)";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@QuestionID", questionId);

                try
                {
                    conn.Open();
                    SqlDataReader r = cmd.ExecuteReader();

                    if (r.Read())
                    {
                        quizUnit.Text = "Advanced Units (Unit " + r["UnitID"] + ")";
                        questionLabel.Text = r["QuestionText"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No more questions.");

                        conn.Close();

                        this.Hide();
                        var Menu = new Menu(username);
                        Menu.Closed += (s, args) => this.Close();
                        Menu.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving question: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }

            }

            


            string queryAnswers = "SELECT AnswerID,AnswerText FROM QuestionsAnswers WHERE QuestionID = @QuestionID";

            SqlCommand command2 = new SqlCommand(queryAnswers, conn);
            command2.Parameters.AddWithValue("@QuestionID", questionId);

            try
            {
                conn.Open();
                SqlDataReader reader2 = command2.ExecuteReader();

                while (reader2.Read())
                {
                    if (reader2["AnswerId"].ToString().Equals("1"))
                    {
                        command2.Parameters.AddWithValue("AnswerText", buttonAnswer1.Text);
                        buttonAnswer1.Text = reader2["AnswerText"].ToString();
                    }
                    if (reader2["AnswerId"].ToString().Equals("2"))
                    {
                        command2.Parameters.AddWithValue("AnswerText", buttonAnswer2.Text);
                        buttonAnswer2.Text = reader2["AnswerText"].ToString();
                    }
                    if (reader2["AnswerId"].ToString().Equals("3"))
                    {
                        command2.Parameters.AddWithValue("AnswerText", buttonAnswer3.Text);
                        buttonAnswer3.Text = reader2["AnswerText"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving question: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }

        }

        private void buttonAnswer1_Click(object sender, EventArgs e)
        {
            answer(1);
            ShowNextQuestion();
        }

        private void buttonAnswer2_Click(object sender, EventArgs e)
        {
            answer(2);
            ShowNextQuestion();
        }

        private void buttonAnswer3_Click(object sender, EventArgs e)
        {
            answer(3);
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            currentQuestionId++;
            LoadQuestion(currentQuestionId);
        }

        private void answer(int ans)
        {
            try
            {
                conn.Open();
                String insertQuery = "INSERT INTO UsersAnswers VALUES (@QuestionID, @QuizID, @Datetime, @Username, @AnswerID)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);

                cmd.Parameters.AddWithValue("@QuestionID", currentQuestionId);
                cmd.Parameters.AddWithValue("@QuizID", currentUnitID);
                cmd.Parameters.AddWithValue("@Datetime", DateTime.Now);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("AnswerID", ans);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}