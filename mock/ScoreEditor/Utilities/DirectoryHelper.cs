using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ScoreEditor.Utilities
{
    public static class DirectoryHelper
    {
        /// <summary>
        /// 指定されたディレクトリが存在しない場合は作成します。
        /// </summary>
        /// <param name="relativePath">実行ファイルからの相対パス</param>
        /// <returns>作成された、または既に存在するディレクトリのパス</returns>
        /// <exception cref="ArgumentException">relativePath が null または空の場合にスローされます。</exception>
        /// <exception cref="InvalidOperationException">実行ファイルのディレクトリが取得できない場合にスローされます。</exception>
        public static string EnsureDirectoryExists(string relativePath)
        {
            if (relativePath == null || string.IsNullOrEmpty(relativePath))
            {
                throw new ArgumentException("relativePath が null または空です。");
            }

            // 実行中の自身のインスタンスのパスを取得
            string? executablePath = Assembly.GetExecutingAssembly().Location;
            string? executableDirectory = Path.GetDirectoryName(executablePath);
            if (executableDirectory == null)
            {
                throw new InvalidOperationException("実行ファイルのディレクトリが取得できませんでした。");
            }

            string directoryPath = Path.Combine(executableDirectory, relativePath);

            // ディレクトリが存在しない場合は作成
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }

        /// <summary>
        /// 禁則文字を削除または変換して有効なディレクトリ名を生成します。
        /// </summary>
        /// <param name="input">入力文字列</param>
        /// <returns>有効なディレクトリ名</returns>
        public static string MakeValidDirectoryName(string input)
        {
            // 禁則文字を削除または変換
            string invalidChars = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            string regexSearch = new string(invalidChars.Distinct().ToArray());
            string validName = Regex.Replace(input, $"[{Regex.Escape(regexSearch)}]", "_");
            return validName;
        }

        /// <summary>
        /// 指定されたディレクトリ内のファイルを別のディレクトリにコピーします。
        /// </summary>
        /// <param name="sourceDirectory">コピー元のディレクトリ</param>
        /// <param name="destinationDirectory">コピー先のディレクトリ</param>
        public static void CopyDirectory(string sourceDirectory, string destinationDirectory)
        {
            if (!Directory.Exists(sourceDirectory))
            {
                throw new DirectoryNotFoundException($"コピー元のディレクトリが見つかりません: {sourceDirectory}");
            }

            Directory.CreateDirectory(destinationDirectory);

            foreach (string filePath in Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories))
            {
                string relativePath = Path.GetRelativePath(sourceDirectory, filePath);
                string? destinationPath = Path.Combine(destinationDirectory, relativePath);
                string? destinationDir = Path.GetDirectoryName(destinationPath);
                if (destinationDir != null)
                {
                    Directory.CreateDirectory(destinationDir);
                }
                File.Copy(filePath, destinationPath, true);
            }
        }

        /// <summary>
        /// 指定されたディレクトリを再帰的に削除します。
        /// </summary>
        /// <param name="directoryPath">削除するディレクトリのパス</param>
        public static void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }

        /// <summary>
        /// 指定されたディレクトリ内のファイルリストを取得します。
        /// </summary>
        /// <param name="directoryPath">ディレクトリのパス</param>
        /// <returns>ファイルパスのリスト</returns>
        public static List<string> GetFiles(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"ディレクトリが見つかりません: {directoryPath}");
            }

            return new List<string>(Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories));
        }
    }
}


