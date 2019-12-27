using System;

namespace DH.Entities
{
    public class BaseEntity
    {
        public int CreUser { get; set; }
        public int ModUser { get; set; }
        public bool IsDeleted { get; set; }

        private DateTime _credate;
        public DateTime CreDate
        {
            get
            {
                if (_credate == null || _credate.Year < 1911)
                {
                    _credate = DateTime.Now;
                    return _credate;
                }
                else
                {
                    return _credate;
                }
            }
            set { _credate = value; }
        }

        private DateTime _modDate;
        public DateTime ModDate
        {
            get
            {
                if (_credate != null || _modDate.Year < 1911)
                {
                    _modDate = DateTime.Now;
                    return _modDate;
                }
                else
                {
                    return _modDate;
                }
            }
            set { _modDate = value; }
        }
    }
}
