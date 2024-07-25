using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace EkpaideutikoLogismiko2024
{
    public partial class Menu : Form
    {
        String username;
        int questionNumber;

        public Menu(string username)
        {
            InitializeComponent();
            this.username = username;
        }


        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-9RR5NNA6\MSSQLSERVER01;Initial Catalog=Learn;Integrated Security=True;");


        private void Introduction_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Introduction = new Introduction(username);
            Introduction.Closed += (s, args) => this.Close();
            Introduction.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successful Log Out!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            var Login = new Login();
            Login.Closed += (s, args) => this.Close();
            Login.Show();
        }

        private void labelVarsAndDataTypes_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Vars = new Vars(username);
            Vars.Closed += (s, args) => this.Close();
            Vars.Show();
        }

        private void labelControlStructures_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ConStr = new ConStr(username);
            ConStr.Closed += (s, args) => this.Close();
            ConStr.Show();
        }

        private void labelFunctions_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Functions = new Functions(username);
            Functions.Closed += (s, args) => this.Close();
            Functions.Show();
        }

        private void labelDataStructures_Click(object sender, EventArgs e)
        {
            this.Hide();
            var DataStr = new DataStr(username);
            DataStr.Closed += (s, args) => this.Close();
            DataStr.Show();
        }

        private void labelFileHandling_Click(object sender, EventArgs e)
        {
            this.Hide();
            var File = new File(username);
            File.Closed += (s, args) => this.Close();
            File.Show();
        }

        private void labelOOP_Click(object sender, EventArgs e)
        {
            this.Hide();
            var OOP = new OOP(username);
            OOP.Closed += (s, args) => this.Close();
            OOP.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // clicks
            string query = "SELECT UnitID, SUM(Clicks) AS TotalClicks FROM Clicks WHERE Username = @username GROUP BY UnitID";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.Parameters.AddWithValue("@username", (object)username ?? DBNull.Value);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // Δημιουργούμε ένα StringBuilder για να συγκεντρώσουμε τα clicks ανά UnitID
                StringBuilder clicksInfo = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    int unitID = Convert.ToInt32(row["UnitID"]);
                    int totalClicks = Convert.ToInt32(row["TotalClicks"]);
                    clicksInfo.AppendLine($"Unit {unitID}: {totalClicks} clicks");
                }
                labelClicks.Text = clicksInfo.ToString();
            }
            else
            {
                labelClicks.Text = "No clicks found for the user.";
            }

            // stats
            string statsQuery = @"
            SELECT 
                UA.QuizID,
                UA.QuestionID, 
                UA.AnswerID, 
                Q.CorrectAnswerID, 
                UA.DateTime 
            FROM 
                UsersAnswers UA 
            JOIN 
                Questions Q ON UA.QuestionID = Q.QuestionID 
            WHERE 
                UA.Username = @username AND 
                UA.DateTime = (
                    SELECT MAX(DateTime) 
                    FROM UsersAnswers 
                    WHERE Username = UA.Username AND QuestionID = UA.QuestionID AND QuizID = UA.QuizID);";

            SqlDataAdapter statsAdapter = new SqlDataAdapter(statsQuery, conn);
            statsAdapter.SelectCommand.Parameters.AddWithValue("@username", (object)username ?? DBNull.Value);

            DataTable statsTable = new DataTable();
            statsAdapter.Fill(statsTable);

            // Dictionary to store correct answer counts and total questions for each quiz
            Dictionary<int, (int correctAnswers, int totalQuestions)> quizStats = new Dictionary<int, (int, int)>();

            foreach (DataRow row in statsTable.Rows)
            {
                int quizID = Convert.ToInt32(row["QuizID"]);
                int answerID = Convert.ToInt32(row["AnswerID"]);
                int correctAnswerID = Convert.ToInt32(row["CorrectAnswerID"]);

                if (!quizStats.ContainsKey(quizID))
                {
                    quizStats[quizID] = (0, 0);
                }

                var stats = quizStats[quizID];
                stats.totalQuestions++;

                if (answerID == correctAnswerID)
                {
                    stats.correctAnswers++;
                }

                quizStats[quizID] = stats;
            }

            // Update labels for each quiz
            if (quizStats.ContainsKey(1))
            {
                UpdateQuizLabel(labelStatsIntro, quizStats[1]);
            }
            if (quizStats.ContainsKey(2))
            {
                UpdateQuizLabel(labelStatsVar, quizStats[2]);
            }
            if (quizStats.ContainsKey(3))
            {
                UpdateQuizLabel(labelStatsConStr, quizStats[3]);
            }
            if (quizStats.ContainsKey(4))
            {
                UpdateQuizLabel(labelStatsFunc, quizStats[4]);
            }
            if (quizStats.ContainsKey(10))
            {
                UpdateQuizLabel(labelStatsAdv, quizStats[10]);
            }

            conn.Close();
            label7.Text = username;
        }

        private void UpdateQuizLabel(Label label, (int correctAnswers, int totalQuestions) stats)
        {
            if (stats.totalQuestions > 0)
            {
                double correctPercentage = (stats.correctAnswers / (double)stats.totalQuestions) * 100;
                label.Text = $"{correctPercentage:F2}%";
            }
        }

        private void buttonIntro_Click(object sender, EventArgs e)
        {
            ShowFeedback(1);
        }

        private void buttonVars_Click(object sender, EventArgs e)
        {
            ShowFeedback(2);
        }

        private void buttonConStr_Click(object sender, EventArgs e)
        {
            ShowFeedback(3);
        }

        private void buttonFunc_Click(object sender, EventArgs e)
        {
            ShowFeedback(4);
        }

        private void buttonAdv_Click(object sender, EventArgs e)
        {
            ShowFeedback(10);
        }

        private void ShowFeedback(int quizId)
        {
            string feedbackQuery = @"
            SELECT Q.QuestionText, Q.UnitID, Q.SubunitID
            FROM UsersAnswers UA
            JOIN Questions Q ON UA.QuestionID = Q.QuestionID
            WHERE 
                UA.Username = @username AND 
                UA.QuizID = @quizId AND 
                UA.AnswerID != Q.CorrectAnswerID AND
                UA.DateTime = (
                    SELECT MAX(DateTime) 
                    FROM UsersAnswers 
                    WHERE Username = UA.Username AND QuestionID = UA.QuestionID AND QuizID = UA.QuizID);";

            SqlCommand feedbackCommand = new SqlCommand(feedbackQuery, conn);
            feedbackCommand.Parameters.AddWithValue("@username", username);
            feedbackCommand.Parameters.AddWithValue("@quizId", quizId);

            try
            {
                conn.Open();
                SqlDataReader reader = feedbackCommand.ExecuteReader();

                StringBuilder feedbackMessage = new StringBuilder();
                while (reader.Read())
                {
                    string questionText = reader["QuestionText"].ToString();
                    string unitId = reader["UnitID"].ToString();
                    string subunitId = reader["SubunitID"].ToString();
                    feedbackMessage.AppendLine($"Question: {questionText}\nCheck Unit: {unitId}, Subunit: {subunitId}\n");
                }

                if (feedbackMessage.Length > 0)
                {
                    MessageBox.Show(feedbackMessage.ToString(), "Incorrect Answers", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No incorrect answers found for this quiz.", "Incorrect Answers", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving feedback: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        private void IntroQuiz_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Quiz = new Quiz(username, 1);
            Quiz.Closed += (s, args) => this.Close();
            Quiz.Show();

        }

        private void VarsAndDataTypesQuiz_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Quiz = new Quiz(username, 2);
            Quiz.Closed += (s, args) => this.Close();
            Quiz.Show();
        }

        private void ConStrQuiz_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Quiz = new Quiz(username, 3);
            Quiz.Closed += (s, args) => this.Close();
            Quiz.Show();
        }

        private void FuncQuiz_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Quiz = new Quiz(username, 4);
            Quiz.Closed += (s, args) => this.Close();
            Quiz.Show();
        }

        private void labelFinalBoss_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Quiz = new Quiz(username, 10);
            Quiz.Closed += (s, args) => this.Close();
            Quiz.Show();
        }
    }
}
