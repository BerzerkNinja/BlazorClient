using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class TableSorter<TData>
    {
        private bool IsSortedAscending;
        private string CurrentSortColumn;
        private List<TData> _tableData;

        public TableSorter(List<TData> tableData)
        {
            _tableData = tableData;
        }

        public List<TData> Sort(string columnName)
        {
            if (columnName != CurrentSortColumn)
            {
                _tableData = _tableData.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                CurrentSortColumn = columnName;
                IsSortedAscending = true;
            }
            else
            {
                if (IsSortedAscending)
                {
                    _tableData = _tableData.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    _tableData = _tableData.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }

                IsSortedAscending = !IsSortedAscending;
            }

            return _tableData;
        }

        public string GetIcon(string columnName)
        {
            if (CurrentSortColumn != columnName)
                return string.Empty;

            if (IsSortedAscending)
                return "↑";

            return "↓";
        }
    }
}