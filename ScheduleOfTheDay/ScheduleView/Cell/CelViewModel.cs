using ScheduleOfTheDay.ViewModel;
using System;

namespace ScheduleOfTheDay.ScheduleView.Cell
{
    class CelViewModel: PropertyChange
    {
        public CelViewModel(int number, bool isSelect, DayOfWeek dayOfWeek)
        {
            SequenceNumber = number;
            IsSelect = isSelect;
            NameOfWeek = dayOfWeek;
        }

        private int _sequenceNumber;
        public int SequenceNumber
        {
            get { return _sequenceNumber; }
            set
            {
                _sequenceNumber = value;
                OnPropertyChanged();
            }
        }
        bool _isSelect;
        public bool IsSelect
        {
            get { return _isSelect; }
            set
            {
                _isSelect = value;
                OnPropertyChanged();
            }
        }
        DayOfWeek _nameOfWeek;
        public DayOfWeek NameOfWeek
        {
            get { return _nameOfWeek; }
            set
            {
                _nameOfWeek = value;
                OnPropertyChanged();
            }
        }
    }
}
