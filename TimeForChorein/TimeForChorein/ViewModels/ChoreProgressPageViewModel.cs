using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using System.Windows.Input;
using TimeForChorein.Enums;
using TimeForChorein.Models.IModel;
using Xamarin.Forms;

namespace TimeForChorein.ViewModels
{
    public class ChoreProgressPageViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; } = "Time for Chorin'";
        public SessionStatus ChoreSessionStatus { get; set; } = SessionStatus.NewSession;
        public int NumberOfSessionMinutes { get; set; } = 60;
        public string NumberOfSessionMinutesText { get; set; } = "Minutes for Chores:";
        public string StartSessionText { get; set; } = "Start Chorin'";
        public string PauseSessionText { get; set; } = "Take a Breather";
        public string EndSessionText { get; set; } = "Finish Chorin'!";
        public string ContinueSessionText { get; set; } = "Back to Chorin'";
        public string FinishCurrentChoreText { get; set; } = "Finish Current Chore";

        private bool _numberOfSessionMinutesLabelVisible = true;
        public bool SessionMinutesLabelVisible
        {
            get { return _numberOfSessionMinutesLabelVisible; }
            set { SetProperty(ref _numberOfSessionMinutesLabelVisible, value); }
        }
        private bool _numberOfSessionMinutesVisible = true;
        public bool SessionMinutesVisible
        {
            get { return _numberOfSessionMinutesVisible; }
            set { SetProperty(ref _numberOfSessionMinutesVisible, value); }
        }
               
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

        private string _timerValue = "00:00";
        public string TimerValue
        {
            get { return _timerValue; }
            set { SetProperty(ref _timerValue, value); }
        }

        private bool _timerValueVisible = false;
        public bool TimerValueVisible
        {
            get { return _timerValueVisible; }
            set { SetProperty(ref _timerValueVisible, value); }
        }

        private string _currentChoreName = string.Empty;
        public string CurrentChoreName
        {
            get { return _currentChoreName; }
            set { SetProperty(ref _currentChoreName, value); }
        }

        private bool _currentChoreNameVisible = false;
        public bool CurrentChoreNameVisible
        {
            get { return _currentChoreNameVisible; }
            set { SetProperty(ref _currentChoreNameVisible, value); }
        }

        private bool _finishCurrentChoreButtonVisible = false;
        public bool FinishCurrentChoreButtonVisible
        {
            get { return _finishCurrentChoreButtonVisible; }
            set { SetProperty(ref _finishCurrentChoreButtonVisible, value); }
        }

        public ObservableCollection<IChore> Chores { get; set; } = new ObservableCollection<IChore>();

        private Timer _choretimer;
        public Timer ChoreTimer
        {
            get; set;
        }

        public ICommand StartSession_Clicked { private set; get; }
        public ICommand PauseSession_Clicked { private set; get; }
        public ICommand EndSession_Clicked { private set; get; }
        public ICommand ContinueSession_Clicked { private set; get; }

        private bool ButtonLock { get; set; } = false;

        private int TimeRemaining { get; set; }

        public ChoreProgressPageViewModel()
        {
            StartSession_Clicked = new Command(
                execute: () =>
                {
                    StartSession();
                    RefreshCanExecute();
                },
                canExecute: () =>
                {
                    return ChoreSessionStatus == SessionStatus.NewSession;
                });

            PauseSession_Clicked = new Command(
                execute: () =>
                {
                    PauseSession();
                    RefreshCanExecute();
                },
                canExecute: () =>
                {
                    return ChoreSessionStatus == SessionStatus.InProgress;
                });

            ContinueSession_Clicked = new Command(
                execute: () =>
                {
                    ContinueSession();
                    RefreshCanExecute();
                },
                canExecute: () =>
                {
                    return ChoreSessionStatus == SessionStatus.Paused;
                });

            EndSession_Clicked = new Command(
                execute: () =>
                {
                    EndSession();
                    RefreshCanExecute();
                },
                canExecute: () =>
                {
                    return ChoreSessionStatus == SessionStatus.Paused || ChoreSessionStatus == SessionStatus.InProgress;
                });
        }

        private void RefreshCanExecute()
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
            SessionMinutesLabelVisible = false;
            SessionMinutesVisible = false;
            
            TimeRemaining = NumberOfSessionMinutes * 60;
            ChoreTimer = new Timer(NumberOfSessionMinutes * 60 * 1000);
            ChoreTimer.Interval = 1000;
            ChoreTimer.Elapsed += ChoreTimer_Elapsed;
            ChoreTimer.Start();

            TimerValue = "Chorin' Time Left " + TimeSpan.FromSeconds(TimeRemaining).ToString("t");
            TimerValueVisible = true;
            FinishCurrentChoreButtonVisible = true;

            UpdateCurrentChore();
            UpdateSessionButtons();
        }

        private void ChoreTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimerValue = TimeSpan.FromSeconds(TimeRemaining).ToString("t");
            TimeRemaining -= 1;
        }

        private void UpdateCurrentChore()
        {

        }

        private void PauseSession()
        {
            ChoreSessionStatus = SessionStatus.Paused;
            ChoreTimer.Stop();
            UpdateSessionButtons();
        }

        private void ContinueSession()
        {
            ChoreSessionStatus = SessionStatus.InProgress;
            ChoreTimer.Start();
            UpdateSessionButtons();
        }

        private void EndSession()
        {
            ChoreSessionStatus = SessionStatus.Complete;
            ChoreTimer.Stop();
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
