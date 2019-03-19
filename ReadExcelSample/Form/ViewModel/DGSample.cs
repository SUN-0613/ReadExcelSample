using AYam.Common.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace ReadExcelSample.Form.ViewModel
{

    /// <summary>
    /// DGSample.ViewModel
    /// </summary>
    public class DGSample : VMBase, IDisposable
    {

        #region Property

        /// <summary>
        /// DataGrid.行情報
        /// </summary>
        public ObservableCollection<ItemSources.DataGridRows> DataGridItems { get; set; }

        /// <summary>
        /// Excelファイルパス
        /// </summary>
        private string _ExcelPath = "";

        /// <summary>
        /// CSVファイルパスプロパティ
        /// </summary>
        public string ExcelPath
        {
            get { return _ExcelPath; }
            set
            {

                // 値更新
                _ExcelPath = value;
                CallPropertyChanged();

                // DataGrid初期化
                for (int iLoop = 0; iLoop < DataGridItems.Count; iLoop++)
                {
                    DataGridItems[iLoop].Dispose();
                }
                DataGridItems.Clear();

                for (int iLoop = MyDataGrid.Columns.Count - 1; iLoop >= 0; iLoop--)
                {
                    MyDataGrid.Columns.RemoveAt(iLoop);
                }

                // xlsx読込、DataGridへ表示
                var values = _Model.ReadExcel(_ExcelPath);
                for (int iLoop = 0; iLoop < values.Count; iLoop++)
                {
                    
                    if (iLoop.Equals(0))
                    {

                        for (int jLoop = 0; jLoop < values[0].Count; jLoop++)
                        {
                            MyDataGrid.Columns.Add(new DataGridTextColumn { Header = (jLoop + 1).ToString(), Binding = new Binding(String.Format("Column[{0}]", jLoop)) });
                        }

                    }

                    DataGridItems.Add(new ItemSources.DataGridRows(iLoop + 1, values[iLoop]));
                }

                // メモリ解放
                values.ForEach(rows => 
                {
                    rows.Clear();
                    rows = null;
                });
                values.Clear();
                values = null;

            }
        }

        #endregion

        /// <summary>
        /// Viewが持つDataGrid
        /// </summary>
        public readonly DataGrid MyDataGrid;

        /// <summary>
        /// DGSample.Model
        /// </summary>
        private Model.DGSample _Model;

        /// <summary>
        /// DGSample.ViewModel
        /// </summary>
        public DGSample(DataGrid dataGrid)
        {

            MyDataGrid = dataGrid;
            _Model = new Model.DGSample();

            DataGridItems = new ObservableCollection<ItemSources.DataGridRows>();

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {
            _Model.Dispose();
            _Model = null;
        }


    }

}
