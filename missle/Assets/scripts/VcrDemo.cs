#if UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_5
#define UNITY_FEATURE_UGUI
#endif

using UnityEngine;
#if UNITY_FEATURE_UGUI
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;
using RenderHeads.Media.AVProVideo;

//-----------------------------------------------------------------------------
// Copyright 2015-2016 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

namespace RenderHeads.Media.AVProWindowsMedia.Demos
{
	public class VcrDemo : MonoBehaviour 
	{
        public AVProWindowsMediaMovie _movie;
        public AVProWindowsMediaMovie _movieB;
        public string _folder;
        public List<string> _filenames;

        public GameObject movie;
        public GameObject image;
        public Slider		_videoSeekSlider;
		private float		_setVideoSeekSliderValue;
		private bool		_wasPlayingOnScrub;


        private AVProWindowsMediaMovie[] _movies;
        private int _moviePlayIndex;
        private int _movieLoadIndex;
        public  int _index = -1;
        private bool _loadSuccess = true;
        private int _playItemIndex = -1;

        public AVProWindowsMediaMovie PlayingMovie { get { return _movies[_moviePlayIndex]; } }
        public AVProWindowsMediaMovie LoadingMovie { get { return _movies[_movieLoadIndex]; } }
        

        DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\chile109\Desktop\display");


        public void NextMovie()
        {            
            
            if (_filenames.Count > 0)
            {
                _index += 1;
                if(_index >= _filenames.Count)
                {
                    _index = _filenames.Count - 1;
                }
            }
            

            print(_index);
            LoadingMovie._folder = _folder;
            LoadingMovie._filename = _filenames[_index];
            LoadingMovie._useStreamingAssetsPath = true;
            LoadingMovie._playOnStart = true;
            _loadSuccess = LoadingMovie.LoadMovie(true);
            _playItemIndex = _index;

            _moviePlayIndex = (_moviePlayIndex + 1) % 2;
            _movieLoadIndex = (_movieLoadIndex + 1) % 2;
        }
        public void OnPlayButton()
        {
            if (_movie)
            {
                _movie.Play();
                
            }
        }
        
        public void Next()
        {
            timespanBar2.page_index += 1;
            playmovie5.kj = dirInfo.GetFiles("*.jpg").Length - 1;
            NextMovie();

                        
        }
        public void Previous()
        {
            
            if (_index > 0)
            {
                timespanBar2.page_index -= 1;
                _index -= 2;
                
                NextMovie();                
            }
            else
            {
                _movie.MovieInstance.Rewind();
                this.gameObject.SetActive(false);
                movie.SetActive(false);
                image.SetActive(true);
            }
            
        }
        public void OnPauseButton()
		{
			if( _movie )
			{
				_movie.Pause();
				
			}
		}

		public void OnVideoSeekSlider()
		{
            if (_movie && _videoSeekSlider && _videoSeekSlider.value != _setVideoSeekSliderValue)
            {
                _movie.MovieInstance.PositionSeconds = (_videoSeekSlider.value * _movie.MovieInstance.DurationSeconds);
            }
		
		}
		public void OnVideoSliderDown()
		{
			if( _movie )
			{
				_wasPlayingOnScrub = _movie.MovieInstance.IsPlaying;
				if( _wasPlayingOnScrub )
				{
					_movie.Pause();
					
				}
				OnVideoSeekSlider();
			}
		}
		public void OnVideoSliderUp()
		{
			if( _movie && _wasPlayingOnScrub )
			{
				_movie.Play();
				_wasPlayingOnScrub = false;

				
			}			
		}

		
        public void OnAudioVolumeMute()
        {
            
                _movie._volume = 0.0f;
            
        }
        public void OnAudioOn()
        {

            _movie._volume = 1.0f;

        }

        public void OnRewindButton()
		{
			if( _movie )
			{
				_movie.MovieInstance.Rewind();
			}
		}

		void Start()
		{
            _movie._loop = false;
            _movieB._loop = false;
            _movies = new AVProWindowsMediaMovie[2];
            _movies[0] = _movie;
            _movies[1] = _movieB;
            _moviePlayIndex = 0;
            _movieLoadIndex = 1;
            _movie._volume = 1.0f;
            for (int i = 0; i < dirInfo.GetFiles("*.ogv").Length; i++)
            {
                _filenames.Add("movies" + i + ".ogv");
            }
            NextMovie();
        }

		void Update()
		{

            if (_movie && _movie.MovieInstance != null)
            {
                float time = _movie.MovieInstance.PositionSeconds;
                float d = time / _movie.MovieInstance.DurationSeconds;
                _setVideoSeekSliderValue = d;
                _videoSeekSlider.value = d;
                
            }
            
            
		}

		
	}
}
#endif