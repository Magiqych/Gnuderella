using ScoreMakerMock.Project;
using ScoreMakerMock.Utilities;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Vortice.Direct3D12;
using Vortice.DXGI;
using Vortice.Mathematics;
using System;
using System.Windows.Forms;
using SharpGen.Runtime;
using Vortice.Direct3D;
using Vortice.Direct3D11;
using ScoreMakerMock.Renderers;
using Vortice.WinForms;

namespace ScoreMakerMock
{
    public partial class ScoreMaker : Form
    {
        /// <summary>
        /// ScoreMaker クラスの新しいインスタンスを初期化します。
        /// </summary>
        ScoreProject scoreProject;
        /// <summary>
        /// Score クラスの新しいインスタンスを初期化します。
        /// </summary>
        Score score;
        /// <summary>
        /// スコアディレクトリ
        /// </summary>
        string scoreDir;
        /// <summary>
        /// フォームアプリケーションタイトル
        /// </summary>
        string FormTitle
        {
            get { return _formTitle; }
            set
            {
                _formTitle = value;
                this.Text = _formTitle;
            }
        }
        string _formTitle;
        /// <summary>
        /// アプリケーション名
        /// </summary>
        string AppFullName;

        private Direct3D11Renderer renderer;
        private bool isClosing = false;

        /// <summary>
        /// ScoreMaker クラスの新しいインスタンスを初期化します。
        /// </summary>
        public ScoreMaker()
        {
            InitializeComponent();
            renderer = new Direct3D11Renderer(renderControl1);
            Application.Idle += RenderLoop;
        }
        private void RenderLoop(object sender, EventArgs e)
        {
            while (AppStillIdle)
            {
                renderer.Render();
            }
        }

        private bool AppStillIdle
        {
            get
            {
                NativeMethods.PeekMessage(out var msg, IntPtr.Zero, 0, 0, 0);
                return msg.message == 0;
            }
        }

        /// <summary>
        /// フォームがロードされたときに呼び出されます。
        /// </summary>
        /// <param name="sender">イベントの送信元</param>
        /// <param name="e">イベントデータ</param>
        private void ScoreMaker_Load(object sender, EventArgs e)
        {
            // バージョン情報を取得
            FormTitle = AppFullName = $"{Constants.AppName} v{Assembly.GetExecutingAssembly().GetName().Version}";
            // Scoresディレクトリが存在しない場合は作成
            DirectoryHelper.EnsureDirectoryExists("Scores");
        }

        /// <summary>
        /// フォームが閉じられるときに呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoreMaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosing) return;
            isClosing = true;
            renderer.Dispose();
            base.OnFormClosing(e);
        }

        #region Score Project Tab
        /// <summary>
        /// スコア生成ボタンがクリックされたときに呼び出されます。
        /// </summary>
        /// <param name="sender">イベントの送信元</param>
        /// <param name="e">イベントデータ</param>
        private async void GenerateScoreButton_Click(object sender, EventArgs e)
        {
            /*入力値のチェック*/
            if (!ValidateInputs(out string scoreName, out int numberOfLanes, out string musicFilePath, out string backGroundFilePath, out string author, out string creditMembers))
            {
                return;
            }

            /* プロジェクト生成 */
            // UUIDを生成
            string uuid = Guid.NewGuid().ToString();
            // ScoreProjectインスタンスを生成
            scoreProject = new ScoreProject();
            scoreProject.ProjectName = scoreName;
            scoreProject.LaneCount = numberOfLanes;
            scoreProject.Author = author;
            scoreProject.Credit = creditMembers;
            // Scoresディレクトリ以下にディレクトリを作成
            scoreProject.ProjectPath = scoreDir = DirectoryHelper.EnsureDirectoryExists($"Scores\\{uuid}");
            // 音楽ファイルをコピー
            string musicFileName = Constants.MusicFileName;
            string destinationMusicFilePath = Path.Combine(scoreDir, musicFileName);
            if (Path.GetExtension(musicFilePath).ToLower() == ".wav")
            {
                using (var progressDialog = new ProgressDialog())
                {
                    await progressDialog.ShowDialogAsync(async () =>
                    {
                        await AudioEncoder.EncodeToMp3Async(musicFilePath, destinationMusicFilePath);
                    });
                }
            }
            else
            {
                // WAV 以外のファイルはそのままコピー
                destinationMusicFilePath = Path.Combine(scoreDir, Path.GetFileName(musicFilePath));
                File.Copy(musicFilePath, destinationMusicFilePath, true);
            }
            scoreProject.MusicFilePath = destinationMusicFilePath;
            // 背景ファイルをコピー
            if (!string.IsNullOrEmpty(backGroundFilePath))
            {
                string backGroundFileName = Path.GetFileName(backGroundFilePath);
                string destinationBackGroundFilePath = Path.Combine(scoreDir, backGroundFileName);
                scoreProject.BackGroundFilePath = destinationBackGroundFilePath;
                File.Copy(backGroundFilePath, destinationBackGroundFilePath, true);
            }
            // ScoreProjectをJSONでシリアライズして保存
            string jsonFilePath = Path.Combine(scoreDir, Constants.ScoreProjectFileName);
            JsonHelper.SaveToJsonFile(scoreProject, jsonFilePath);
            // scoreをJSONでシリアライズして保存
            score = new Score(scoreProject.NormalizedNotesSpeed, scoreProject.NotesSpeed);
            score.LaneCount = scoreProject.LaneCount;
            jsonFilePath = Path.Combine(scoreDir, Constants.ScoreFileName);
            JsonHelper.SaveToJsonFile(score, jsonFilePath);
            // 表示内容更新
            UpdateTextBoxesFromScoreProject();
        }
        /// <summary>
        /// プロジェクトに音声ファイルを追加するボタンがクリックされたときに呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMusicFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "音声ファイル (*.mp3;*.wav;*.flac)|*.mp3;*.wav;*.flac";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    MusicFilePathTextbox.Text = selectedFilePath;
                }
            }
        }
        /// <summary>
        /// プロジェクトに背景ファイルを追加するボタンがクリックされたときに呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBackgroundFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "画像ファイル (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|動画ファイル (*.mp4;*.avi;*.mov)|*.mp4;*.avi;*.mov";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    BackGroundFilePathTextbox.Text = selectedFilePath;
                }
            }
        }
        /// <summary>
        /// プロジェクトディレクトリを開くボタンがクリックされたときに呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OpenProjectDirButton_Click(object sender, EventArgs e)
        {
            if (scoreProject == null || string.IsNullOrEmpty(scoreProject.ProjectPath))
            {
                MessageBox.Show("プロジェクトディレクトリが設定されていません。");
                return;
            }
            try
            {
                Process.Start("explorer.exe", scoreProject.ProjectPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"プロジェクトディレクトリを開くことができませんでした: {ex.Message}");
            }
        }

        /// <summary>
        /// スコアプロジェクトを開くボタンがクリックされたときに呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenScoreButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "スコアプロジェクトファイル (*.json)|*.json";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    try
                    {
                        // ScoreProject.json ファイルをデシリアライズ
                        string scoreProjectFilePath = Path.Combine(Path.GetDirectoryName(selectedFilePath), Constants.ScoreProjectFileName);
                        scoreProject = JsonHelper.LoadFromJsonFile<ScoreProject>(scoreProjectFilePath);
                        scoreDir = scoreProject.ProjectPath;
                        UpdateTextBoxesFromScoreProject();

                        // Score.json ファイルをデシリアライズ
                        string scoreFilePath = Path.Combine(Path.GetDirectoryName(selectedFilePath), Constants.ScoreFileName);
                        score = JsonHelper.LoadFromJsonFile<Score>(scoreFilePath);
                        score.NormalizedNotesSpeed = scoreProject.NormalizedNotesSpeed;
                        score.NotesSpeed = scoreProject.NotesSpeed;
                        score.NotesSpeedRatio = scoreProject.NotesSpeed / scoreProject.NormalizedNotesSpeed;
                        score.LaneCount = scoreProject.LaneCount;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"プロジェクトファイルのでシリアライズ中にエラーが発生しました。: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// スコアプロジェクトの更新を行うボタンがクリックされたときに呼び出されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateScoreProjectButton_Click(object sender, EventArgs e)
        {
            /*プロジェクトがロードチェック*/
            if (scoreProject == null)
            {
                MessageBox.Show("プロジェクトがロードされていません。");
                return;
            }
            else
            {
                /*上書き確認*/
                DialogResult result = MessageBox.Show("プロジェクトを上書きしますか？", "確認", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            /*入力値のチェック*/
            if (!ValidateInputs(out string scoreName, out int numberOfLanes, out string musicFilePath, out string backGroundFilePath, out string author, out string creditMembers))
            {
                return;
            }

            /* プロジェクト更新 */
            scoreProject.ProjectName = scoreName;
            scoreProject.LaneCount = numberOfLanes;
            scoreProject.Author = author;
            scoreProject.Credit = creditMembers;
            // 音楽ファイルをコピー
            string musicFileName = Constants.MusicFileName;
            string destinationMusicFilePath = Path.Combine(scoreDir, musicFileName);
            //ディレクトリに変更ある場合は音楽ファイルをコピー
            if (destinationMusicFilePath != musicFilePath)
            {
                if (Path.GetExtension(musicFilePath).ToLower() == ".wav")
                {
                    using (var progressDialog = new ProgressDialog())
                    {
                        await progressDialog.ShowDialogAsync(async () =>
                        {
                            await AudioEncoder.EncodeToMp3Async(musicFilePath, destinationMusicFilePath);
                        });
                    }
                }
                else
                {
                    // WAV 以外のファイルはそのままコピー
                    destinationMusicFilePath = Path.Combine(scoreDir, Path.GetFileName(musicFilePath));
                    File.Copy(musicFilePath, destinationMusicFilePath, true);
                }
                scoreProject.MusicFilePath = destinationMusicFilePath;
            }
            // 背景ファイルをコピー
            if (!string.IsNullOrEmpty(backGroundFilePath))
            {
                string backGroundFileName = Path.GetFileName(backGroundFilePath);
                string destinationBackGroundFilePath = Path.Combine(scoreDir, backGroundFileName);
                if (backGroundFilePath != destinationBackGroundFilePath)
                {
                    File.Copy(backGroundFilePath, destinationBackGroundFilePath, true);
                    scoreProject.BackGroundFilePath = destinationBackGroundFilePath;
                }
            }
            // ScoreProjectをJSONでシリアライズして保存
            string jsonFilePath = Path.Combine(scoreDir, Constants.ScoreProjectFileName);
            JsonHelper.SaveToJsonFile(scoreProject, jsonFilePath);
            // 表示内容更新
            UpdateTextBoxesFromScoreProject();
        }

        /// <summary>
        /// scoreProjectの内容でテキストボックスの内容を書き換えます。
        /// </summary>
        private void UpdateTextBoxesFromScoreProject()
        {
            if (scoreProject == null)
            {
                return;
            }
            ScoreDirTextbox.Text = scoreProject.ProjectPath;
            ScoreNameTextbox.Text = scoreProject.ProjectName;
            NumberOfLanesTextbox.Text = scoreProject.LaneCount.ToString();
            MusicFilePathTextbox.Text = scoreProject.MusicFilePath;
            BackGroundFilePathTextbox.Text = scoreProject.BackGroundFilePath;
            AuthorTextbox.Text = scoreProject.Author;
            CreditTextbox.Text = scoreProject.Credit;
            FormTitle = $"{AppFullName}\tScoreProject = {scoreProject.ProjectName}\tProjectID = {Path.GetFileName(scoreProject.ProjectPath)}";
        }

        /// <summary>
        /// 入力値のチェックを行います。
        /// </summary>
        /// <param name="scoreName">譜面名</param>
        /// <param name="numberOfLanes">レーン数</param>
        /// <param name="musicFilePath">音楽ファイルパス</param>
        /// <param name="backGroundFilePath">背景ファイルパス</param>
        /// <param name="author">作者</param>
        /// <param name="credit">クレジット</param>
        /// <returns></returns>
        private bool ValidateInputs(out string scoreName, out int numberOfLanes, out string musicFilePath, out string backGroundFilePath, out string author, out string credit)
        {
            scoreName = ScoreNameTextbox.Text;
            musicFilePath = MusicFilePathTextbox.Text;
            backGroundFilePath = BackGroundFilePathTextbox.Text;
            author = AuthorTextbox.Text;
            credit = CreditTextbox.Text;
            string numberOfLanesText = NumberOfLanesTextbox.Text;

            //レーン数
            if (!int.TryParse(numberOfLanesText, out numberOfLanes) || numberOfLanes < Constants.MinNumberOfLanes || numberOfLanes > Constants.MaxNumberOfLanes)
            {
                MessageBox.Show($"レーン数は{Constants.MinNumberOfLanes}から{Constants.MaxNumberOfLanes}の間の正の整数で入力してください。");
                return false;
            }
            //スコア名
            if (string.IsNullOrEmpty(scoreName))
            {
                MessageBox.Show("スコア名を入力してください。");
                return false;
            }
            //音楽ファイル
            if (string.IsNullOrEmpty(musicFilePath) || !File.Exists(musicFilePath))
            {
                MessageBox.Show("有効な音楽ファイルを選択してください。");
                return false;
            }
            //背景ファイル
            if (!string.IsNullOrEmpty(backGroundFilePath) && !File.Exists(backGroundFilePath))
            {
                MessageBox.Show("有効な背景ファイルを選択してください。");
                return false;
            }

            return true;
        }
        #endregion

        #region Score Editor Tab

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            score = new Score(5, 1.0, 1.0);
        }
    }
}
