using NAudio.Wave;
using NAudio.Lame;
using System.IO;
using System.Threading.Tasks;

namespace ScoreMakerMock.Utilities
{
    public static class AudioEncoder
    {
        public static async Task EncodeToMp3Async(string inputFilePath, string outputFilePath)
        {
            await Task.Run(() =>
            {
                using (var reader = new AudioFileReader(inputFilePath))
                using (var writer = new LameMP3FileWriter(outputFilePath, reader.WaveFormat, LAMEPreset.STANDARD))
                {
                    reader.CopyTo(writer);
                }
            });
        }
    }
}

