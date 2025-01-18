using ScoreEditor.Settings;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreEditor.SkControlPaint
{
    internal partial class CanvasHelper
    {
        /// <summary>
        /// キャンバスをクリアします。
        /// </summary>
        /// <param name="canvas">クリアするキャンバス</param>
        /// <param name="color">クリアする色</param>
        public static void ClearCanvas(SKCanvas canvas, SKColor? color = null)
        {
            canvas.Clear(color ?? AppSettings.BackGroundColor);
        }
    }
}
