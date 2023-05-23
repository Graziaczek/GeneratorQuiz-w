using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections.ObjectModel;

namespace Generator
{

    public class DataBaseConnection
    {
        string connectionString = "DataSource=C:\\Users\\grazi\\source\\repos\\Generator\\Generator\\database.db";
        public ObservableCollection<Question> ReadQuestions()
        {
            ObservableCollection<Question> questions = new ObservableCollection<Question>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Pytanie";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Question question = new Question();
                            question.Id = reader.GetInt32(0);
                            question.QuestionText = reader.GetString(1);
                            question.Answer1 = reader.GetString(2);
                            question.False1 = reader.GetBoolean(3);
                            question.Answer2 = reader.GetString(4);
                            question.False2 = reader.GetBoolean(5);
                            question.Answer3 = reader.GetString(6);
                            question.False3 = reader.GetBoolean(7);
                            question.Answer4 = reader.GetString(8);
                            question.False4 = reader.GetBoolean(9);
                            questions.Add(question);
                        }
                    }
                }
                connection.Close();
            }
            return questions;
        }
        public ObservableCollection<Quiz> ReadQuizes()
        {
            ObservableCollection<Quiz> quizes = new ObservableCollection<Quiz>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Quiz";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Quiz quiz = new Quiz();
                            quiz.Id = reader.GetInt32(0);
                            quiz.Name = reader.GetString(1);
                            quiz.IdQuiz = reader.GetInt32(2);
                            quizes.Add(quiz);
                        }
                    }
                }
                connection.Close();
            }
            return quizes;
        }
        public void InsertQuestion(Question q)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Pytanie (Id,Question,Option1,Answer1,Option2,Answer2,Option3,Answer3,Option4,Answer4,IdQuiz) VALUES (@Id,@Question,@Option1,@Answer1,@Option2,@Answer2,@Option3,@Answer3,@Option4,@Answer4,@IdQuiz);";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", q.Id);
                    command.Parameters.AddWithValue("@Question", q.Id);
                    command.Parameters.AddWithValue("@Option1", q.Answer1);
                    command.Parameters.AddWithValue("@Answer1", q.False1);
                    command.Parameters.AddWithValue("@Option2", q.Answer2);
                    command.Parameters.AddWithValue("@Answer2", q.False2);
                    command.Parameters.AddWithValue("@Option3", q.Answer3);
                    command.Parameters.AddWithValue("@Answer3", q.False3);
                    command.Parameters.AddWithValue("@Option4", q.Answer4);
                    command.Parameters.AddWithValue("@Answer4", q.False4);
                    command.Parameters.AddWithValue("@IdQuiz", q.IdQuiz);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void InsertQuiz(Quiz q)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Quiz (Id_quiz,Nazwa) VALUES (@Id,@Nazwa);";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", q.Id);
                    command.Parameters.AddWithValue("@Nazwa", q.Name);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void DeleteDataBase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "Delete from Pytanie";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                sql = "Delete from Quiz";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
