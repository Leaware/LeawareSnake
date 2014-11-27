#region Using

using System;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Plugins.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

#endregion

namespace Snake.Core
{
    public class StartViewModel : MvxViewModel
    {
        #region Fields

        private MvxCommand onEasyChoicedCommand;
        private MvxCommand onMediumChoicedCommand;
        private MvxCommand onHardChoicedCommand;
        private MvxCommand onStartCommand;
        private MvxCommand onCloseCommand;

        private bool selectLevelHidden = true;

        private string easyMaxScore = "-";
        private string mediumMaxScore = "-";
        private string hardMaxScore = "-";

        private IDataService service;

        #endregion

        #region Constructor

        public StartViewModel(IDataService serivce)
        {
            this.service = serivce;
        }

        #endregion

        #region Properties

        public bool SelectLevelHidden
        {
            get
            {
                return this.selectLevelHidden;
            }

            set
            {
                this.selectLevelHidden = value;
                this.RaisePropertyChanged(() => SelectLevelHidden);
            }
        }

        public ICommand EasyChoicedCommand
        {
            get
            {
                if (this.onEasyChoicedCommand == null)
                {
                    this.onEasyChoicedCommand = new MvxCommand(this.OnEasyChoiced);
                }

                return this.onEasyChoicedCommand;
            }
        }

        public ICommand MediumChoicedCommand
        {
            get
            {
                if (this.onMediumChoicedCommand == null)
                {
                    this.onMediumChoicedCommand = new MvxCommand(this.OnMediumChoiced);
                }

                return this.onMediumChoicedCommand;
            }
        }

        public ICommand HardChoicedCommand
        {
            get
            {
                if (this.onHardChoicedCommand == null)
                {
                    this.onHardChoicedCommand = new MvxCommand(this.OnHardChoiced);
                }

                return this.onHardChoicedCommand;
            }
        }

        public ICommand StartTouchCommand
        {
            get
            {
                if (this.onStartCommand == null)
                {
                    this.onStartCommand = new MvxCommand(this.OnStarTouched);
                }

                return this.onStartCommand;
            }
        }

        public string EasyMaxScore
        {
            get
            {
                return this.easyMaxScore;
            }

            set
            {
                this.easyMaxScore = value;
                this.RaisePropertyChanged(() => EasyMaxScore);
            }
        }

        public string MediumMaxScore
        {
            get
            {
                return this.mediumMaxScore;
            }

            set
            {
                this.mediumMaxScore = value;
                this.RaisePropertyChanged(() => MediumMaxScore);
            }
        }

        public string HardMaxScore
        {
            get
            {
                return this.hardMaxScore;
            }

            set
            {
                this.hardMaxScore = value;
                this.RaisePropertyChanged(() => HardMaxScore);
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                if (this.onCloseCommand == null)
                {
                    this.onCloseCommand = new MvxCommand(this.OnClose);
                }

                return this.onCloseCommand;
            }
        }

        #endregion

        #region Methods

        public override void Start()
        {
            base.Start();

            List<Scores> easy = this.service.GetAll(Levels.Easy);
            List<Scores> medium = this.service.GetAll(Levels.Medium);
            List<Scores> hard = this.service.GetAll(Levels.Hard);

            if (easy.Count > 0)
            {
                this.EasyMaxScore = easy.FirstOrDefault(x => x.Score == easy.Max(y => y.Score)).Score.ToString();
            }

            if (medium.Count > 0)
            {
                this.MediumMaxScore = medium.FirstOrDefault(x => x.Score == medium.Max(y => y.Score)).Score.ToString();
            }

            if (hard.Count > 0)
            {
                this.HardMaxScore = hard.FirstOrDefault(x => x.Score == hard.Max(y => y.Score)).Score.ToString();
            }

        }

        private void OnClose()
        {
            this.SelectLevelHidden = true;
        }

        private void OnStarTouched()
        {
            this.SelectLevelHidden = false;
        }

        private void OnEasyChoiced()
        {
            SnakeAppContext.Instance.LevelChoiced = Levels.Easy;
            this.ShowViewModel<GameViewModel>();
        }

        private void OnMediumChoiced()
        {
            SnakeAppContext.Instance.LevelChoiced = Levels.Medium;
            this.ShowViewModel<GameViewModel>();
        }

        private void OnHardChoiced()
        {
            SnakeAppContext.Instance.LevelChoiced = Levels.Hard;
            this.ShowViewModel<GameViewModel>();
        }

        #endregion
    }
}
