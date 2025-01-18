import json
import os
import sys
import librosa
import librosa.display
import numpy as np
import matplotlib.pyplot as plt

def process_music(ScoreProjectPath, ScorePath):
    # ScoreProjectファイルを読み込む
    ScoreProject = None
    Score = None
    with open(ScoreProjectPath, 'r', encoding='utf-8') as file:
        ScoreProject = json.load(file)
    with open(ScorePath, 'r', encoding='utf-8') as file:
        Score = json.load(file)

    # Estimate a static tempo
    music_path =  ScoreProject.get('MusicFilePath')
    y, sr = librosa.load(music_path)
    duration = librosa.get_duration(y=y, sr=sr)
    tempo, beats_static = librosa.beat.beat_track(y=y, sr=sr, units='time', trim=False)
    tempo_dynamic = librosa.feature.tempo(y=y, sr=sr, aggregate=None, start_bpm=tempo[0])
    tempo, beats_dynamic = librosa.beat.beat_track(y=y, sr=sr, units='time',bpm=tempo_dynamic, trim=False)
    Score['StaticTempo'] = tempo[0]
    Score['BeatsDynamic'] = beats_dynamic.tolist()
    Score['BeatsStatic'] = beats_static.tolist()
    Score['Duration'] = duration
    # Save Score
    with open(ScorePath, 'w', encoding='utf-8') as file:
        json.dump(Score, file, ensure_ascii=False, indent=4)

def main():
    if len(sys.argv) != 2:
        print("Usage: python MusicPy.py <ScoreProjectRootPath>")
        sys.exit(1)
    ScoreProjectRootPath = sys.argv[1]
    ScoreProjectPath = os.path.join(ScoreProjectRootPath, 'ScoreProject.json')
    ScorePath = os.path.join(ScoreProjectRootPath, 'Score.json')
    process_music(ScoreProjectPath, ScorePath)

if __name__ == "__main__":
    main()