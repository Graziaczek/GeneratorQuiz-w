using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Generator
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DataBaseConnection db;
        public MainWindowViewModel()
        {
            Quizzes = new ObservableCollection<Quiz>();
            Questions = new ObservableCollection<Question>();
            SelectedQuizQuestions = new ObservableCollection<Question>();
            db = new DataBaseConnection(); 
        }
        private ObservableCollection<Quiz> quizzes;
        public ObservableCollection<Quiz> Quizzes
        {
            get { return quizzes; }
            set
            {
                quizzes = value;
                OnPropertyChanged(nameof(Quizzes));
            }
        }
        private RelayCommand addQuizCommand;
        public RelayCommand AddQuizCommand
        {
            get
            {
                if (addQuizCommand == null)
                {
                    addQuizCommand = new RelayCommand(AddQuiz, CanAddQuiz);
                }
                return addQuizCommand;

            }
        }
        private RelayCommand removeQuizCommand;
        public RelayCommand RemoveQuizCommand
        {
            get
            {
                if (removeQuizCommand == null)
                {
                    removeQuizCommand = new RelayCommand(DeleteQuiz, CanDeleteQuiz);
                }
                return removeQuizCommand;

            }
        }
        private RelayCommand updateQuizCommand;
        public RelayCommand UpdateQuizCommand
        {
            get
            {
                if (updateQuizCommand == null)
                {
                    updateQuizCommand = new RelayCommand(UpdateQuiz, CanUpdateQuiz);
                }
                return updateQuizCommand;

            }
        }
        private void UpdateQuiz()
        {
            Quiz newQuiz = new Quiz { Name = newQuizName, Questions = SelectedQuiz.Questions }; ;
            Quizzes.Remove(SelectedQuiz);
            Quizzes.Add(newQuiz);
        }
        private string newQuizName;
        public string NewQuizName
        {
            get { return newQuizName; }
            set
            {
                newQuizName = value;
                OnPropertyChanged(nameof(NewQuizName));
                AddQuizCommand.RaiseCanExecuteChanged();
                UpdateQuizCommand.RaiseCanExecuteChanged();
            }
        }

        private void AddQuiz()
        {
            if (!string.IsNullOrEmpty(newQuizName))
            {
                Quiz newQuiz = new Quiz { Name = newQuizName };
                Quizzes.Add(newQuiz);
            }
        }
        private void DeleteQuiz()
        {
            if (SelectedQuiz != null)
            {
                foreach (Question question in SelectedQuiz.Questions)
                {
                    Questions.Remove(question);
                }
                Quizzes.Remove(SelectedQuiz);
            }
        }
        private bool CanAddQuiz()
        {
            return !string.IsNullOrEmpty(newQuizName);
        }
        private bool CanDeleteQuiz()
        {
            return SelectedQuiz!=null;
        }
        private bool CanUpdateQuiz()
        {
            return !string.IsNullOrEmpty(newQuizName)&&SelectedQuiz!=null;
        }
        private Quiz selectedQuiz;
        public Quiz SelectedQuiz
        {
            get { return selectedQuiz; }
            set
            {
                if (selectedQuiz != value)
                {
                    selectedQuiz = value;
                    OnPropertyChanged(nameof(SelectedQuiz));
                    OnPropertyChanged(nameof(SelectedQuizTitle));
                    UpdateSelectedQuizQuestions();
                    RemoveQuizCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string SelectedQuizTitle
        {
            get { return SelectedQuiz?.Name; }
        }

        private ObservableCollection<Question> selectedQuizQuestions;
        public ObservableCollection<Question> SelectedQuizQuestions
        {
            get { return selectedQuizQuestions; }
            set
            {
                if (selectedQuizQuestions != value)
                {
                    selectedQuizQuestions = value;
                    OnPropertyChanged(nameof(SelectedQuizQuestions));
                    AddQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private void UpdateSelectedQuizQuestions()
        {
            SelectedQuizQuestions.Clear();
            if (SelectedQuiz != null)
            {
                foreach (Question question in SelectedQuiz.Questions)
                {
                    SelectedQuizQuestions.Add(question);
                }
            }
        }
        private Question _selectedQuestion;

        public Question SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                if (_selectedQuestion != value)
                {
                    _selectedQuestion = value;
                    OnPropertyChanged(nameof(SelectedQuestion));
                    OnPropertyChanged(nameof(SelectedQuestion.QuestionText));
                    OnPropertyChanged(nameof(SelectedQuestion.Answer1));
                    OnPropertyChanged(nameof(SelectedQuestion.Answer2));
                    OnPropertyChanged(nameof(SelectedQuestion.Answer3));
                    OnPropertyChanged(nameof(SelectedQuestion.Answer4));
                    OnPropertyChanged(nameof(SelectedQuestion.False1));
                    OnPropertyChanged(nameof(SelectedQuestion.False2));
                    OnPropertyChanged(nameof(SelectedQuestion.False3));
                    OnPropertyChanged(nameof(SelectedQuestion.False4));
                    UpdateQuestionCommand.RaiseCanExecuteChanged();
                    RemoveQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string SelectedQuestionTitle
        {
            get { return SelectedQuestion?.QuestionText; }
        }
        public string SelectedQuestionAnswer1
        {
            get { return SelectedQuestion?.Answer1; }
        }
        public string SelectedQuestionAnswer2
        {
            get { return SelectedQuestion?.Answer2; }
        }
        public string SelectedQuestionAnswer3
        {
            get { return SelectedQuestion?.Answer3; }
        }
        public string SelectedQuestionAnswer4
        {
            get { return SelectedQuestion?.Answer4; }
        }
        public bool SelectedQuestionFalse1
        {
            get { return SelectedQuestion.False1; }
        }
        public bool SelectedQuestionFalse2
        {
            get { return SelectedQuestion.False2; }
        }
        public bool SelectedQuestionFalse3
        {
            get { return SelectedQuestion.False3; }
        }
        public bool SelectedQuestionFalse4
        {
            get { return SelectedQuestion.False4; }
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
                    AddQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string newQuestionText;
        public string NewQuestionText
        {
            get { return newQuestionText; }
            set
            {
                if (newQuestionText != value)
                {
                    newQuestionText = value;
                    OnPropertyChanged(nameof(NewQuestionText));
                    AddQuestionCommand.RaiseCanExecuteChanged();
                    UpdateQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private int newQuizId;
        public int NewQuizId
        {
            get { return newQuizId; }
            set
            {
                if (newQuizId != value)
                {
                    newQuizId = value;
                    OnPropertyChanged(nameof(NewQuizId));
                    AddQuestionCommand.RaiseCanExecuteChanged();
                    UpdateQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string newAnswer1;
        public string NewAnswer1
        {
            get { return newAnswer1; }
            set
            {
                if (newAnswer1 != value)
                {
                    newAnswer1 = value;
                    OnPropertyChanged(nameof(NewAnswer1));
                    AddQuestionCommand.RaiseCanExecuteChanged();
                    UpdateQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string newAnswer2;
        public string NewAnswer2
        {
            get { return newAnswer2; }
            set
            {
                if (newAnswer2 != value)
                {
                    newAnswer2 = value;
                    OnPropertyChanged(nameof(NewAnswer2));
                    AddQuestionCommand.RaiseCanExecuteChanged();
                    UpdateQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string newAnswer3;
        public string NewAnswer3
        {
            get { return newAnswer3; }
            set
            {
                if (newAnswer3 != value)
                {
                    newAnswer3 = value;
                    OnPropertyChanged(nameof(NewAnswer3));
                    AddQuestionCommand.RaiseCanExecuteChanged();
                    UpdateQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string newAnswer4;
        public string NewAnswer4
        {
            get { return newAnswer4; }
            set
            {
                if (newAnswer4 != value)
                {
                    newAnswer4 = value;
                    OnPropertyChanged(nameof(NewAnswer4));
                    AddQuestionCommand.RaiseCanExecuteChanged();
                    UpdateQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private bool newfalse1;
        public bool NewFalse1
        {
            get { return newfalse1; }
            set
            {
                if (newfalse1 != value)
                {
                    newfalse1 = value;
                    OnPropertyChanged(nameof(NewFalse1));
                    AddQuestionCommand.RaiseCanExecuteChanged();
                    UpdateQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private bool newfalse2;
        public bool NewFalse2
        {
            get { return newfalse2; }
            set
            {
                if (newfalse2 != value)
                {
                    newfalse2 = value;
                    OnPropertyChanged(nameof(NewFalse2));
                    AddQuestionCommand.RaiseCanExecuteChanged();
                    UpdateQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private bool newfalse3;
        public bool NewFalse3
        {
            get { return newfalse3; }
            set
            {
                if (newfalse3 != value)
                {
                    newfalse3 = value;
                    OnPropertyChanged(nameof(NewFalse3));
                    AddQuestionCommand.RaiseCanExecuteChanged();
                    UpdateQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private bool newfalse4;
        public bool NewFalse4
        {
            get { return newfalse4; }
            set
            {
                if (newfalse4 != value)
                {
                    newfalse4 = value;
                    OnPropertyChanged(nameof(NewFalse4));
                    AddQuestionCommand.RaiseCanExecuteChanged();
                    UpdateQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private RelayCommand addQuestionCommand;
        public RelayCommand AddQuestionCommand {
            get {
                if (addQuestionCommand == null)
                {
                    addQuestionCommand = new RelayCommand(AddQuestion, CanAddQuestion);
                }
                return addQuestionCommand;
            }
        }
        private RelayCommand updateQuestionCommand;
        public RelayCommand UpdateQuestionCommand
        {
            get
            {
                if (updateQuestionCommand == null)
                {
                    updateQuestionCommand = new RelayCommand(UpdateQuestion, CanUpdateQuestion);
                }
                return updateQuestionCommand;
            }
        }
        private RelayCommand removeQuestionCommand;
        public RelayCommand RemoveQuestionCommand
        {
            get
            {
                if (removeQuestionCommand == null)
                {
                    removeQuestionCommand = new RelayCommand(DeleteQuestion, CanDeleteQuestion);
                }
                return removeQuestionCommand;
            }
        }
        private RelayCommand readDataBaseCommand;
        public RelayCommand ReadDataBaseCommand
        {
            get
            {
                if (readDataBaseCommand == null)
                {
                    readDataBaseCommand = new RelayCommand(ReadDataBase, CanDataBase);
                }
                return readDataBaseCommand;
            }
        }
        private RelayCommand saveDataBaseCommand;
        public RelayCommand SaveDataBaseCommand
        {
            get
            {
                if (saveDataBaseCommand == null)
                {
                    saveDataBaseCommand = new RelayCommand(SaveDataBase, CanDataBase);
                }
                return saveDataBaseCommand;
            }
        }
        private void ReadDataBase()
        {
            Questions = db.ReadQuestions();
            Quizzes = db.ReadQuizes();
        }
        private void SaveDataBase()
        {
            db.DeleteDataBase();
            foreach(Question question in Questions)
            {
                db.InsertQuestion(question);
            }
            foreach(Quiz quiz in Quizzes)
            {
                db.InsertQuiz(quiz);
            }
        }
        private void AddQuestion()
        {
            var question = new Question()
            {
                IdQuiz = NewQuizId,
                QuestionText = NewQuestionText,
                Answer1 = NewAnswer1, 
                Answer2 = NewAnswer2,
                Answer3 = NewAnswer3, 
                Answer4 = NewAnswer4,
                False1 = NewFalse1,
                False2 = NewFalse2,
                False3 = NewFalse3,
                False4 = NewFalse4
            };

            SelectedQuiz.AddQuestion(question);
            NewQuizId = -1;
            NewQuestionText = string.Empty;
            NewAnswer1 = string.Empty;
            NewAnswer2 = string.Empty;
            NewAnswer3 = string.Empty;
            NewAnswer4 = string.Empty;
            NewFalse1 = false;
            NewFalse2 = false;
            NewFalse3 = false;
            NewFalse4 = false;
        }
        private void UpdateQuestion()
        {
            var question = new Question()
            {
                QuestionText = NewQuestionText,
                Answer1 = NewAnswer1,
                Answer2 = NewAnswer2,
                Answer3 = NewAnswer3,
                Answer4 = NewAnswer4,
                False1 = NewFalse1,
                False2 = NewFalse2,
                False3 = NewFalse3,
                False4 = NewFalse4
            };
            SelectedQuiz.UpdateQuestion(question,SelectedQuestion);
            NewQuizId = -1;
            NewQuestionText = string.Empty;
            NewAnswer1 = string.Empty;
            NewAnswer2 = string.Empty;
            NewAnswer3 = string.Empty;
            NewAnswer4 = string.Empty;
            NewFalse1 = false;
            NewFalse2 = false;
            NewFalse3 = false;
            NewFalse4 = false;
        }
        private void DeleteQuestion()
        {
            if (SelectedQuestion != null)
            {
                Questions.Remove(SelectedQuestion);
                NewQuizId = -1;
                NewQuestionText = string.Empty;
                NewAnswer1 = string.Empty;
                NewAnswer2 = string.Empty;
                NewAnswer3 = string.Empty;
                NewAnswer4 = string.Empty;
                NewFalse1 = false;
                NewFalse2 = false;
                NewFalse3 = false;
                NewFalse4 = false;
            }
        }
        private bool CanDataBase()
        {
            return db != null;
        }
        private bool CanDeleteQuestion()
        {
            return SelectedQuestion!=null;
        }
        private bool CanAddQuestion()
        {
            return !string.IsNullOrEmpty(NewQuestionText) && !string.IsNullOrEmpty(NewAnswer1) && !string.IsNullOrEmpty(NewAnswer2) && !string.IsNullOrEmpty(NewAnswer3) && !string.IsNullOrEmpty(NewAnswer4) &&(NewFalse1||NewFalse2||NewFalse3||NewFalse4)&&NewQuizId!=-1;
        }
        private bool CanUpdateQuestion()
        {
            return !string.IsNullOrEmpty(NewQuestionText) && !string.IsNullOrEmpty(NewAnswer1) && !string.IsNullOrEmpty(NewAnswer2) && !string.IsNullOrEmpty(NewAnswer3) && !string.IsNullOrEmpty(NewAnswer4) && (NewFalse1 || NewFalse2 || NewFalse3 || NewFalse4) && NewQuizId != -1 && SelectedQuestion!=null;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
