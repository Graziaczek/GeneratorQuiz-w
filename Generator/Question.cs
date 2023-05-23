using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class Question : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        private int idQuiz;
        public int IdQuiz
        {
            get { return idQuiz; }
            set
            {
                if (idQuiz != value)
                {
                    idQuiz = value;
                    OnPropertyChanged(nameof(IdQuiz));
                }
            }
        }
        private string questionText;
        public string QuestionText
        {
            get { return questionText; }
            set
            {
                if (questionText != value)
                {
                    questionText = value;
                    OnPropertyChanged(nameof(QuestionText));
                }
            }
        }

        private string answer1;
        public string Answer1
        {
            get { return answer1; }
            set
            {
                if (answer1 != value)
                {
                    answer1 = value;
                    OnPropertyChanged(nameof(Answer1));
                }
            }
        }
        private string answer2;
        public string Answer2
        {
            get { return answer2; }
            set
            {
                if (answer2 != value)
                {
                    answer2 = value;
                    OnPropertyChanged(nameof(Answer2));
                }
            }
        }
        private string answer3;
        public string Answer3
        {
            get { return answer3; }
            set
            {
                if (answer3 != value)
                {
                    answer3 = value;
                    OnPropertyChanged(nameof(Answer3));
                }
            }
        }
        private string answer4;
        public string Answer4
        {
            get { return answer4; }
            set
            {
                if (answer4 != value)
                {
                    answer4 = value;
                    OnPropertyChanged(nameof(Answer4));
                }
            }
        }
        private bool false1;
        public bool False1
        {
            get { return false1; }
            set
            {
                if (false1 != value)
                {
                    false1 = value;
                    OnPropertyChanged(nameof(False1));
                }
            }
        }
        private bool false2;
        public bool False2
        {
            get { return false2; }
            set
            {
                if (false2 != value)
                {
                    false2 = value;
                    OnPropertyChanged(nameof(False2));
                }
            }
        }
        private bool false3;
        public bool False3
        {
            get { return false3; }
            set
            {
                if (false3 != value)
                {
                    false3 = value;
                    OnPropertyChanged(nameof(False3));
                }
            }
        }
        private bool false4;
        public bool False4
        {
            get { return false4; }
            set
            {
                if (false4 != value)
                {
                    false4 = value;
                    OnPropertyChanged(nameof(False4));
                }
            }
        }

        public Question()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
