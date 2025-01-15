using System;
using System.IO;
using System.Text.Json;

namespace ScoreMakerMock.Utilities
{
    public static class JsonHelper
    {
        /// <summary>
        /// オブジェクトをJSON形式でシリアライズしてファイルに保存します。
        /// </summary>
        /// <typeparam name="T">シリアライズするオブジェクトの型</typeparam>
        /// <param name="obj">シリアライズするオブジェクト</param>
        /// <param name="filePath">保存先のファイルパス</param>
        public static void SaveToJsonFile<T>(T obj, string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                // エラーハンドリング
                throw new InvalidOperationException("JSONファイルの保存に失敗しました。", ex);
            }
        }

        /// <summary>
        /// JSONファイルからオブジェクトをデシリアライズします。
        /// </summary>
        /// <typeparam name="T">デシリアライズするオブジェクトの型</typeparam>
        /// <param name="filePath">読み込むJSONファイルのパス</param>
        /// <returns>デシリアライズされたオブジェクト</returns>
        public static T LoadFromJsonFile<T>(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                // エラーハンドリング
                throw new InvalidOperationException("JSONファイルの読み込みに失敗しました。", ex);
            }
        }
    }
}

