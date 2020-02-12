using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TimeForChorein.Enums;
using TimeForChorein.Models.IModel;
using Xamarin.Forms;

namespace TimeForChorein.ViewModels
{
    public class ChoreProgressPageViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; } = "Time for Chorein'";
        public SessionStatus ChoreSessionStatus { get; set; } = SessionStatus.NewSession;
        public int NumberOfSessionMinutes { get; set; } = 60;
        public string NumberOfSessionMinutesText { get; set; } = "Minutes for Chores:";
        public string StartSessionText { get; set; } = "Start Chorin'";
        public string PauseSessionText { get; set; } = "Take a Breather";
        public string EndSessionText { get; set; } = "Finish Chorin'!";
        public string ContinueSessionText { get; set; } = "Back to Chorin'";
        private bool _startSessionVisible = true;
        public bool StartSessionVisible
        {
            get { return _startSessionVisible; }
            set { SetProperty(ref _startSessionVisible, value); }
        }
        private bool _continueSessionVisible = false;
        public bool ContinueSessionVisible
        {
            get { return _continueSessionVisible; }
            set { SetProperty(ref _continueSessionVisible, value); }
        }
        private bool _pauseSessionVisible = false;
        public bool PauseSessionVisible
        {
            get { return _pauseSessionVisible; }
            set { SetProperty(ref _pauseSessionVisible, value); }
        }
        private bool _endSessionVisible = false;
        public bool EndSessionVisible
        {
            get { return _endSessionVisible; }
            set { SetProperty(ref _endSessionVisible, value); }
        }

        public ObservableCollection<IChore> Chores { get; set; } = new ObservableCollection<IChore>();

        public ICommand StartSession_Clicked { private set; get; }
        public ICommand PauseSession_Clicked { private set; get; }
        public ICommand EndSession_Clicked { private set; get; }
        public ICommand ContinueSession_Clicked { private set; get; }

        private bool ButtonLock { get; set; } = false;
        public ChoreProgressPageViewModel()
        {
            StartSession_Clicked = new Command(
                execute: () =>
                {
                    StartSession();
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return !ButtonLock;
                });

            PauseSession_Clicked = new Command(
                execute: () =>
                {
                    PauseSession();
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return true;
                });

            ContinueSession_Clicked = new Command(
                execute: () =>
                {
                    ContinueSession();
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return true;
                });

            EndSession_Clicked = new Command(
                execute: () =>
                {
                    EndSession();
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return true;
                });
        }

        private void RefreshCanExecutes()
        {
            (StartSession_Clicked as Command).ChangeCanExecute();
            (PauseSession_Clicked as Command).ChangeCanExecute();
            (ContinueSession_Clicked as Command).ChangeCanExecute();
            (EndSession_Clicked as Command).ChangeCanExecute();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void StartSession()
        {
            ChoreSessionStatus = SessionStatus.InProgress;
            UpdateSessionButtons();
        }
        private void PauseSession()
        {
            ChoreSessionStatus = SessionStatus.Paused;
            UpdateSessionButtons();
        }

        private void EndSession()
        {
            ChoreSessionStatus = SessionStatus.Complete;
            UpdateSessionButtons();
        }

        private void ContinueSession()
        {
            ChoreSessionStatus = SessionStatus.InProgress;
            UpdateSessionButtons();
        }

        private void UpdateSessionButtons()
        {
            // easier to hide everything at first and then show what we want
            StartSessionVisible = false;
            PauseSessionVisible = false;
            ContinueSessionVisible = false;
            EndSessionVisible = false;

            switch (ChoreSessionStatus)
            {
                // same as default but this is more explicit about the logic
                case SessionStatus.NewSession:
                    StartSessionVisible = true;
                    break;
                case SessionStatus.InProgress:
                    PauseSessionVisible = true;
                    EndSessionVisible = true;
                    break;
                case SessionStatus.Paused:
                    ContinueSessionVisible = true;
                    EndSessionVisible = true;
                    break;
                default:
                    StartSessionVisible = true;
                    break;
            }
        }

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
