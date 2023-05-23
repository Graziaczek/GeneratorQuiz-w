using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class Quiz : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        private int idQuiz;
        public int IdQuiz
        {
            get { return idQuiz; }
            set
            {
                idQuiz = value;
            }
        }
        private ObservableCollection<Question> questions;
        public ObservableCollection<Question> Questions
        {
            get { return questions; }
            set
            {
                if (questions != value)
                {
                    questions = value;
                    OnPropertyChanged(nameof(Questions));
                }
            }
        }

        public Quiz()
        {
            Questions = new ObservableCollection<Question>();
        }
        public void AddQuestion(Question q)
        {
            var question = new Question()
            {
                IdQuiz = q.IdQuiz,
                QuestionText = q.QuestionText,
                Answer1 = q.Answer1,
                Answer2 = q.Answer2,
                Answer3 = q.Answer3,
                Answer4 = q.Answer4,
                False1 = q.False1,
                False2 = q.False2,
                False3 = q.False3,
                False4 = q.False4
            };

            Questions.Add(question);
        }
        public void UpdateQuestion(Question q, Question s)
        {
            var question = new Question()
            {
                IdQuiz = s.IdQuiz,
                QuestionText = q.QuestionText,
                Answer1 = q.Answer1,
                Answer2 = q.Answer2,
                Answer3 = q.Answer3,
                Answer4 = q.Answer4,
                False1 = q.False1,
                False2 = q.False2,
                False3 = q.False3,
                False4 = q.False4
            };
            Questions.Remove(s);
            Questions.Add(question);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
