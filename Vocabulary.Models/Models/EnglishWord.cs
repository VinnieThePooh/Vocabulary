using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            get => englishWordId;
            set
            {
                englishWordId = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        public Culture Culture
        {
            get => culture;
            set
            {
                culture = value;
                OnPropertyChanged();
            }
        }

        public string Transcription
        {
            get => transcription;
            set
            {
                transcription = value;
                OnPropertyChanged();
            }
        }

        public DateTime AdditionDate
        {
            get => additionDate;
            set
            {
                additionDate = value;
                OnPropertyChanged();
            }
        }

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
