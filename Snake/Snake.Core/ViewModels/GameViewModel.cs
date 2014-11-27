#region Using

using System;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Cirrious.CrossCore;
using System.Windows.Input;

#endregion

namespace Snake.Core
{
    public class GameViewModel : MvxViewModel
    {
        #region Fields

        private const int PointStep = 10;
        private Direction direction;

        private Snake Snake;
        private FoodShape Food;

        private List<RectangleF> shapes;
        private int points;
        private bool finishDialogHidden = true;

        private MvxCommand leftCommand;
        private MvxCommand rightCommand;
        private MvxCommand topCommand;
        private MvxCommand bottomCommand;
        private MvxCommand retryCommand;
        private MvxCommand pauseCommand;
        private MvxCommand closeCommand;
        private MvxCommand quitCommand;

        private bool isPause;

        private SizeF panelSize;
        private int pixelSize;
        private List<PointF> AvailablePoints;

        private IDataService service;
        private ITimer timer;

        #endregion

        #region Constructor

        public GameViewModel(IDataService service)
        {
            this.Shapes = new List<RectangleF>();
            this.service = service;
            this.timer = Mvx.Resolve<ITimer>();
        }

        #endregion

        #region Properties

        public List<RectangleF> Shapes 
        { 
            get
            {
                return shapes;
            }
            set
            {
                this.shapes = value;
                RaisePropertyChanged(() => Shapes);
            }
        }

        public string Level
        {
            get
            {
                return SnakeAppContext.Instance.LevelChoiced.ToString().ToUpper();
            }
        }

        public int Points 
        { 
            get
            {
                return points;
            }
            set
            {
                this.points = value;
                RaisePropertyChanged(() => Points);
            }
        }

        public bool FinishDialogHidden 
        { 
            get
            {
                return this.finishDialogHidden;
            }
            set
            {
                this.finishDialogHidden = value;
                RaisePropertyChanged(() => FinishDialogHidden);
            }
        }

        #region Commands

        public ICommand TopTouchCommand
        {
            get
            {
                if (this.topCommand == null)
                {
                    this.topCommand = new MvxCommand(()=> { this.OnDirectionChanged(Direction.Top); });
                }

                return this.topCommand;
            }
        }

        public ICommand PauseCommand
        {
            get
            {
                if (this.pauseCommand == null)
                {
                    this.pauseCommand = new MvxCommand(this.OnPause);
                }

                return this.pauseCommand;
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                if (this.closeCommand == null)
                {
                    this.closeCommand = new MvxCommand(this.OnClose);
                }

                return this.closeCommand;
            }
        }

        public ICommand BottomTouchCommand
        {
            get
            {
                if (this.bottomCommand == null)
                {
                    this.bottomCommand = new MvxCommand(()=> { this.OnDirectionChanged(Direction.Bottom); });
                }

                return this.bottomCommand;
            }
        }

        public ICommand RestartCommand
        {
            get
            {
                if (this.retryCommand == null)
                {
                    this.retryCommand = new MvxCommand(this.OnRetry);
                }

                return this.retryCommand;
            }
        }

        public ICommand QuitCommand
        {
            get
            {
                if (this.quitCommand == null)
                {
                    this.quitCommand = new MvxCommand(this.OnQuit);
                }

                return this.quitCommand;
            }
        }

        public ICommand RightTouchCommand
        {
            get
            {
                if (this.rightCommand == null)
                {
                    this.rightCommand = new MvxCommand(()=> { this.OnDirectionChanged(Direction.Right); });
                }

                return this.rightCommand;
            }
        }

        public ICommand LeftTouchCommand
        {
            get
            {
                if (this.leftCommand == null)
                {
                    this.leftCommand = new MvxCommand(()=> { this.OnDirectionChanged(Direction.Left); });
                }

                return this.leftCommand;
            }
        }

        #endregion

        #endregion

        #region Setup

        public void Initialize(SizeF panelSize, int pixelSize)
        {
            this.panelSize = panelSize;
            this.pixelSize = pixelSize;

            this.GenerateAvailablePoints();
            this.Snake = new Snake(new PointF(panelSize.Width / 2, panelSize.Height / 2), pixelSize);

            this.Food = new FoodShape(pixelSize);
            this.RandomFoodPositions();

            List<RectangleF> shapes = this.Snake.SnakeParts.Select(x => x.Shape).ToList();
            shapes.AddRange(this.Food.Shapes);

            this.Shapes = shapes;

            this.InitializeTimer();
        }

        private void InitializeTimer()
        {
            this.timer.OnTick = this.OnTimerTick;

            timer.Interval = (int)SnakeAppContext.Instance.LevelChoiced;
            timer.Start();
        }

        #endregion

        #region Methods

        private void GenerateAvailablePoints()
        {
            this.AvailablePoints = new List<PointF>();

            for (int i = 0; i <= this.panelSize.Width - pixelSize; i += this.pixelSize)
            {
                for (int j = 0; j <= this.panelSize.Height - pixelSize; j += this.pixelSize)
                {
                    this.AvailablePoints.Add(new PointF(i, j));
                }
            }
        }

        private int Random(int max)
        {
            Random r = new System.Random();

            return r.Next() % max;
        }

        private void RandomFoodPositions()
        {
            List<PointF> snakePositions = this.Snake.SnakeParts.Select(x => x.Shape.Position).ToList();
            List<PointF> available = this.AvailablePoints.Where(x => !snakePositions.Contains(x)).ToList();

            if (available.Count > 0)
            {
                int index = this.Random(available.Count - 1);

                this.Food.GetShapeForPosition((int)available[index].X, (int)available[index].Y);
            }
            else
            {
                this.Food.GetShapeForPosition(-1, -1);
            }
        }

        private bool IsEating()
        {
            if (this.Snake.SnakeParts[0].Shape.X == this.Food.Position.X
                && this.Snake.SnakeParts[0].Shape.Y == this.Food.Position.Y)
            {
                return true;
            }

            return false;
        }

        public void SaveScore()
        {
            Scores score = new Scores()
            {
                Score = this.points,
                Level = (int) SnakeAppContext.Instance.LevelChoiced,
                Date = DateTime.Now,
            };

            this.service.Insert(score);
        }

        #endregion

        #region Actions

        private void OnPause()
        {
            this.timer.Stop();
            this.FinishDialogHidden = false;
        }

        private void OnClose()
        {
            this.timer.Start();
            this.FinishDialogHidden = true;
        }

        private void OnQuit()
        {
            this.SaveScore();
            this.ShowViewModel<StartViewModel>();
        }

        private void OnRetry()
        {
            this.SaveScore();
            this.FinishDialogHidden = true;
            this.Points = 0;
            this.Initialize(this.panelSize, this.pixelSize);
        }

        private void OnDirectionChanged(Direction direction)
        {
            if ((this.direction == Direction.Left || this.direction == Direction.Right)
                && (direction == Direction.Left || direction == Direction.Right))
            {
                return;
            }

            if ((this.direction == Direction.Top || this.direction == Direction.Bottom)
                && (direction == Direction.Top || direction == Direction.Bottom))
            {
                return;
            }

            this.direction = direction;
        }

        private void OnTimerTick()
        {
            if (this.Snake.IsInBound(this.panelSize))
            {
                if (this.IsEating())
                {
                    this.Points += PointStep;

                    this.Snake.MoveWithAdd(this.direction);
                    this.RandomFoodPositions();
                }
                else
                {
                    this.Snake.Move(direction);
                }

                List<RectangleF> shapes = this.Snake.SnakeParts.Select(x => x.Shape).ToList();
                shapes.AddRange(this.Food.Shapes);

                this.Shapes = shapes;
            }
            else
            {
                this.timer.Stop();
                this.FinishDialogHidden = false;
            }
        }

        #endregion
    }
}
