﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Vocabulary.Core.Infrastructure;
using Vocabulary.Core.Annotations;

namespace Vocabulary.Core.Models
{
   public class EnglishWord: INotifyPropertyChanged
    {
        private string text;
        private Culture culture;
        private string transcription;
        private DateTime additionDate;
        private int englishWordId;

        public EnglishWord()
        {
            Translations = new ObservableCollection<WordTranslation>();
            Synonyms = new ObservableCollection<EnglishWord>();
        }

        public int EnglishWordId
        {
            get { return englishWordId; }
            set
            {
                englishWordId = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get  { return text; }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        public Culture Culture
        {
            get  { return culture; }
            set
            {
                culture = value;
                OnPropertyChanged();
            }
        }

        public string Transcription
        {
            get { return transcription; }
            set
            {
                transcription = value;
                OnPropertyChanged();
            }
        }

        public DateTime AdditionDate
        {
            get { return additionDate; }
            set
            {
                additionDate = value;
                OnPropertyChanged();
            }
        }

        public int? IdSpeechPart { get; set; }

        public virtual SpeechPart SpeechPart { get; set; }
        public virtual ObservableCollection<WordTranslation> Translations { get; set; }
        public virtual ObservableCollection<EnglishWord> Synonyms { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
