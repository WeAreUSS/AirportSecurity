using System;
using System.Collections.Generic;
using System.Text;

namespace AirportSecurity.Interfaces
{
    public interface IHelpers
    {
        string GetAbbreviatedName(int day, int month, int year);
        List<T> CreateList<T>(params T[] values);
    }
}
