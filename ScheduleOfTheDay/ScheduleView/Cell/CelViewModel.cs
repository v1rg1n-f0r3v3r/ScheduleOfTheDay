using ScheduleOfTheDay.ViewModel;
using System;
using DayOfWeek = ScheduleOfTheDay.Model.DayOfWeek;

namespace ScheduleOfTheDay.ScheduleView.Cell
{
    public class CelViewModel: PropertyChange
    {
        public CelViewModel(int number, DayOfWeek dayOfWeek)
        {
            SequenceNumber = number;
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
        DateTime _time;
        public DateTime Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }
        public void ChangeCellStatus(bool property)
        {
            IsSelect = property;
        }
    }
}
