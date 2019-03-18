using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReadExcelSample.ItemSources
{

    /// <summary>
    /// DataGrid.ItemsSource
    /// </summary>
    public class DataGridRows : IDisposable
    {

        #region Property

        /// <summary>
        /// 行Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 項目
        /// </summary>
        public ObservableCollection<string> Column { get; set; }

        #endregion

        /// <summary>
        /// DataGrid.ItemsSource
        /// </summary>
        /// <param name="rowCount">行数</param>
        /// <param name="columnCount">列数</param>
        public DataGridRows(int rowCount, int columnCount)
        {

            Index = rowCount;

            Column = new ObservableCollection<string>();
            for (int iLoop = 0; iLoop < columnCount; iLoop++)
            {
                Column.Add("");
            }

        }

        /// <summary>
        /// DataGrid.ItemsSource
        /// </summary>
        /// <param name="rowCount">行数</param>
        /// <param name="columnValues">列値</param>
        public DataGridRows(int rowCount, List<string> columnValues)
        {

            Index = rowCount;

            Column = new ObservableCollection<string>();
            for (int iLoop = 0; iLoop < columnValues.Count; iLoop++)
            {
                Column.Add(columnValues[iLoop]);
            }

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {
            Column.Clear();
        }

    }

}
