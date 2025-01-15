using NAudio.Wave;
using ScoreEditor.Models;
using ScoreEditor.Settings;
using ScoreEditor.Utilities;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreEditor
{
    public partial class Editor : Form
    {
        //devScoreProjectPath は開発用のパスです。適宜変更してください。
        string devScoreProjectPath = "E:\\10.Private\\Gnuderella\\mock\\ScoreEditor\\bin\\Debug\\net9.0-windows\\ScoreProjects\\ba74ab7e-1220-4599-b62e-bd928fbd8f51";

        #region Model読み込み
        private ScoreProject scoreProject;
        private Score score;
        #endregion
        #region Utility読み込み
        private AudioHelper audioHelper;
        private WaveOutEvent waveOutEvent;
        #endregion
        #region プライベート変数
        private double canvasWidth;
        private double canvasHeight;
        private double canvasZoom = 300.0;
        private System.Windows.Forms.Timer musicTimer;
        private Lane lane;
        private double musicPos;
        private const double notesSize = 0.7;
        #endregion

        /// <summary>
        /// Editor クラスの新しいインスタンスを初期化します。
        /// </summary>
        public Editor()
        {
            InitializeComponent();
            InitializeMusicTimer();
        }

        #region UIユーザ操作イベントハンドラ
        /// <summary>
        /// プロジェクトのロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string scoreProjectJsonFilePath = Path.Combine(devScoreProjectPath, Constants.ScoreProjectFileName);
            string scoreJsonFilePath = Path.Combine(devScoreProjectPath, Constants.ScoreFileName);
            try
            {
                if (!File.Exists(scoreProjectJsonFilePath))
                {
                    throw new FileNotFoundException(Constants.ScoreProjectFileName + "ファイルが見つかりません。", scoreProjectJsonFilePath);
                }
                if (!File.Exists(scoreJsonFilePath))
                {
                    throw new FileNotFoundException(Constants.ScoreFileName + "ファイルが見つかりません。", scoreJsonFilePath);
                }
                scoreProject = JsonHelper.LoadFromJsonFile<ScoreProject>(scoreProjectJsonFilePath);
                score = JsonHelper.LoadFromJsonFile<Score>(scoreJsonFilePath);
                LaneInit();
                (audioHelper, waveOutEvent) = await AudioHelper.CreateAsync(scoreProject.MusicFilePath);
                MusicTackbar.Maximum = (int)(score.Duration * 1000);
                waveOutEvent.Play();
                musicTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 一停止/再生ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseOrReplayButton_Click(object sender, EventArgs e)
        {
            if (waveOutEvent == null)
            {
                return;
            }
            if (waveOutEvent.PlaybackState == PlaybackState.Playing)
            {
                waveOutEvent.Pause();
                musicTimer.Stop();
            }
            else
            {
                waveOutEvent.Play();
                musicTimer.Start();
            }
        }
        #endregion


        #region イベントハンドラ
        /// <summary>
        private void InitializeMusicTimer()
        {
            musicTimer = new System.Windows.Forms.Timer();
            musicTimer.Interval = 300;
            musicTimer.Tick += MusicTimer_Tick;
        }

        private void MusicTimer_Tick(object? sender, EventArgs e)
        {
            if (MusicTackbar.Maximum < (int)audioHelper.GetCurrentPosition().TotalMilliseconds)
            {
                musicTimer.Stop();
                return;
            }
            ScoreSkControl.Invalidate();
            MusicTackbar.Value = (int)audioHelper.GetCurrentPosition().TotalMilliseconds;
        }
        #endregion

        private void MusicTackbar_Scroll(object sender, EventArgs e)
        {
            if (waveOutEvent == null)
            {
                return;
            }
            ScoreSkControl.Invalidate();
            if (waveOutEvent.PlaybackState == PlaybackState.Playing)
            {
                waveOutEvent.Stop();
                musicTimer.Stop();
                audioHelper.SetCurrentPosition(TimeSpan.FromMilliseconds(MusicTackbar.Value));
                waveOutEvent.Play();
                musicTimer.Start();
            }
            else
            {
                audioHelper.SetCurrentPosition(TimeSpan.FromMilliseconds(MusicTackbar.Value));
            }
        }

        private void ScoreSkControl_PaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            if (score == null)
            {
                return;
            }

            canvasHeight = ScoreSkControl.Height;
            canvasWidth = ScoreSkControl.Width;
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            // キャンバスクリア
            canvas.Clear(SKColors.Black);
            //レーン描写
            SKPaint LaneLine = new SKPaint
            {
                Style = SKPaintStyle.StrokeAndFill,
                Color = new SKColor(255, 255, 255),
                StrokeCap = (SKStrokeCap)3,
                IsAntialias = true,
                StrokeWidth = 3
            };
            foreach (var x in lane.LaneAxis)
            {
                canvas.DrawLine((float)x, 0, (float)x, (float)canvasHeight, LaneLine);
            }
            //ビート描写
            musicPos = audioHelper.GetCurrentPosition().TotalSeconds;
            double[] AreaOfRender = new double[] {musicPos,
                                                                        musicPos + canvasHeight/canvasZoom};
            SKPaint BeatsStaticLine = new SKPaint
            {
                Style = SKPaintStyle.StrokeAndFill,
                Color = new SKColor(125, 0, 0),
                StrokeCap = (SKStrokeCap)3,
                IsAntialias = true,
                StrokeWidth = 3
            };
            var beats_s = score.BeatsStatic.Where(beat => AreaOfRender[0] <= beat &&
                                                                    beat <= AreaOfRender[1]);
            foreach (var beat in beats_s)
            {
                var y = ConvertCanvasPos(beat, 0, canvasHeight)[0];
                if (y < 0)
                {
                    break;
                }
                canvas.DrawLine(0, (float)y, (float)canvasWidth, (float)y, BeatsStaticLine);
            }
            SKPaint BeatsDynamicLine = new SKPaint
            {
                Style = SKPaintStyle.StrokeAndFill,
                Color = new SKColor(0, 0, 125),
                StrokeCap = (SKStrokeCap)3,
                IsAntialias = true,
                StrokeWidth = 3
            };
            var beats_d = score.BeatsDynamic.Where(beat => AreaOfRender[0] <= beat &&
                                                                    beat <= AreaOfRender[1]);
            foreach (var beat in beats_d)
            {
                var y = ConvertCanvasPos(beat, 0, canvasHeight)[0];
                if (y < 0)
                {
                    break;
                }
                canvas.DrawLine(0, (float)y, (float)canvasWidth, (float)y, BeatsDynamicLine);
            }
            //拍数描写
            // AreaOfRender[0]とAreaOfRender[1]の間の整数を取得
            int start = (int)Math.Ceiling(AreaOfRender[0]);
            int end = (int)Math.Floor(AreaOfRender[1]);
            var integersInRange = Enumerable.Range(start, end - start + 1);
            foreach (var integer in integersInRange)
            {
                TimeSpan time = TimeSpan.FromSeconds(integer);
                string timeText = time.ToString(@"mm\:ss");
                var tx = ConvertCanvasPos(integer, 0, canvasHeight);
                if (tx[0] < 0)
                {
                    break;
                }
                var skFont = new SKFont
                {
                    Size = 20
                };
                var skPaint = new SKPaint
                {
                    Color = SKColors.White
                };
                canvas.DrawText(timeText, new SKPoint((float)0, (float)tx[0]), skFont, skPaint);
            }
            //ノーツ描写
            foreach (var notesGroup in score.NotesGroupList)
            {
                foreach (var notes in notesGroup.NotesList)
                {
                    var spawnLaneIndex = notes.SpawnLaneIndex;
                    var timing = notes.Timing;
                    if (AreaOfRender[0] <= timing && timing <= AreaOfRender[1])
                    {
                        var skPaint = new SKPaint
                        {
                            Color = SKColors.Red
                        };
                        var tx = ConvertCanvasPos(timing, spawnLaneIndex, canvasHeight);
                        canvas.DrawCircle((float)tx[1], (float)tx[0], (float)(lane.LaneWidth*notesSize/2), skPaint);
                    }
                }
            }

        }

        /// <summary>
        /// キャンバス座標を計算します。
        /// </summary>
        /// <param name="t">タイミング変数</param>
        /// <param name="x">x座標</param>
        /// <param name="CanvasHeight">キャンバスサイズ</param>
        /// <returns>timing,x</returns>
        private double[] ConvertCanvasPos(double t, int x, double CanvasHeight)
        {
            return [CanvasHeight - (t - musicPos) * canvasZoom, lane.LaneX[x]];
        }

        private void Editor_Load(object sender, EventArgs e)
        {
        }

        private void LaneInit()
        {
            if (score == null)
            {
                return;
            }
            canvasHeight = ScoreSkControl.Height;
            canvasWidth = ScoreSkControl.Width;
            List<double> laneaxis = new List<double>();
            List<double> LaneX = new List<double>();
            for (int i = 0; i < score.NumberOfLanes; i++)
            {
                laneaxis.Add(canvasWidth / score.NumberOfLanes * i);
                LaneX.Add((canvasWidth / score.NumberOfLanes / 2) * (i * 2 + 1));
            }
            lane = new Lane { LaneAxis = laneaxis, LaneX = LaneX ,LaneWidth = canvasWidth / score.NumberOfLanes };
        }

        private void ScoreSkControl_Click(object sender, EventArgs e)
        {

        }

        private void ScoreSkControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (score == null)
            {
                return;
            }
            if (waveOutEvent == null)
            {
                return;
            }
            //音声再生停止
            waveOutEvent.Stop();
            musicTimer.Stop();

            var clickedX = e.X;
            var clickedY = e.Y;
            // clickedXがどのレーンに属するかを判定
            int clickedLane = -1;
            for (int i = 0; i < lane.LaneAxis.Count - 1; i++)
            {
                if (clickedX >= lane.LaneAxis[i] && clickedX < lane.LaneAxis[i + 1])
                {
                    clickedLane = i;
                    break;
                }
            }
            // 最後のレーンの右端をクリックした場合
            if (clickedLane == -1 && clickedX >= lane.LaneAxis.Last())
            {
                clickedLane = lane.LaneAxis.Count - 1;
            }
            var clickedTime = musicPos + (canvasHeight - clickedY) / canvasZoom;

            //ノーツ編集か新規作成か
            bool IsEdit = false;
            //ノーツ編集
            //var tx = ConvertCanvasPos(clickedY, clickedLane, canvasHeight);
            //var tohu = lane.LaneWidth * notesSize / 2;
            //foreach (var notesGroup in score.NotesGroupList)
            //{
            //    foreach (var notes in notesGroup.NotesList)
            //    {
            //        var spawnLaneIndex = notes.SpawnLaneIndex;
            //        var timing = notes.Timing;
            //        if (spawnLaneIndex == clickedLane &&
            //            (tx[0]- tohu <= timing || timing <= tx[0] + tohu))
            //        {
                        
            //            IsEdit = true;
            //        }
            //    }
            //}
            //ノーツ追加
            if (!IsEdit)
            {
                NotesGroup notesGroup = new NotesGroup();
                Notes notes = new Notes
                {
                    SpawnLaneIndex = clickedLane,
                    DestLaneIndex = clickedLane,
                    Timing = clickedTime
                };
                notesGroup.NotesList.Add(notes);
                score.NotesGroupList.Add(notesGroup);
                var notesList = score.NotesGroupList.SelectMany(group => group.NotesList).ToList();
                dataGridView1.DataSource = notesList;
                ScoreSkControl.Invalidate();
            }
        }
    }
}
